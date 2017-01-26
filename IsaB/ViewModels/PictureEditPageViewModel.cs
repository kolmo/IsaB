using IsaB.Entities;
using IsaB.Infrastructure;
using IsaB.QueryStack;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace IsaB.ViewModels
{
    public class PictureEditPageViewModel : ViewModelBase
    {
        private readonly IEstateService _immobilienService;
        private readonly IBus _bus;
        private ImmobilieBildEntity _picture;
        public PictureEditPageViewModel(IEstateService immoService, IBus bus)
        {
            _immobilienService = immoService;
            _bus = bus;
            DeletePictureCommand = new DelegateCommand(DeletePictureAction, ()=> { return Picture != null; });
        }
        #region Properties

        public ImmobilieBildEntity Picture
        {
            get { return _picture; }
            set { Set(ref _picture, value); }
        }
        public DelegateCommand DeletePictureCommand { get; private set; }
        #endregion
        #region Overrides
        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (parameter != null && parameter is int)
            {
                int picID = (int)parameter;
                Picture = _immobilienService.GetEstatePic(picID);
                DeletePictureCommand.RaiseCanExecuteChanged();
            }
            return Task.CompletedTask;
        }
        #endregion

        #region Private methods
        private void DeletePictureAction()
        {
            CommandStack.Commands.DeletePictureCommand cmd = new CommandStack.Commands.DeletePictureCommand() { PictureID = Picture.ID };
            _bus.Send(cmd);
            NavigationService.GoBack();
        }
        #endregion
    }
}
