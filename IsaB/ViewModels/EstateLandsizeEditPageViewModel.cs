using IsaB.CommandStack.Commands;
using IsaB.Entities;
using IsaB.Infrastructure;
using IsaB.QueryStack;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace IsaB.ViewModels
{
    public class EstateLandsizeEditPageViewModel : EditViewModelBase
    {
        #region Private members
        private ImmobilieEntity _estate;
        private int _estateID;
        private readonly IEstateService _estateService;
        private readonly IBus _bus;

        #endregion

        #region Constructor
        public EstateLandsizeEditPageViewModel(IEstateService estateService, IBus bus)
        {
            _estateService = estateService;
            _bus = bus;
            CommandBag.Add(SaveLandsize = new DelegateCommand(SaveLandsizeAction, () => HasChanges));
        }
        #endregion

        public DelegateCommand SaveLandsize { get; }
        private float? _landsize;
        public float? Landsize
        {
            get { return _landsize; }
            set
            {
                Set(ref _landsize, value);
            }
        }
        private float? _standardGroundValue;
        public float? StandardGroundValue
        {
            get { return _standardGroundValue; }
            set
            {
                Set(ref _standardGroundValue, value);
            }
        }
        private float? _livingSpace;

        public float? LivingSpace
        {
            get { return _livingSpace; }
            set
            {
                Set(ref _livingSpace, value);
            }
        }

        #region Overrides
        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (parameter != null && parameter is string)
            {
                int estateID;
                if (int.TryParse((string)parameter, out estateID))
                {
                    _estateID = estateID;
                    _estate = _estateService.GetEstate(_estateID);
                    if (_estate != null)
                    {
                        _landsize = _estate.Grundstuecksflaeche;
                        _standardGroundValue = _estate.Bodenrichtwert;
                        _livingSpace = _estate.Bruttogrundflaeche;
                        RaisePropertyChanged(nameof(Landsize));
                        RaisePropertyChanged(nameof(StandardGroundValue));
                        RaisePropertyChanged(nameof(LivingSpace));
                    }
                }
            }
            return Task.CompletedTask;
        }

        #endregion
        #region Private Methods
        private void SaveLandsizeAction()
        {
            SaveEstateLandsizeCommand cmd = new SaveEstateLandsizeCommand()
            {
                EstateID = _estateID,
                Landsize = Landsize,
                StandardGroundValue = StandardGroundValue,
                LivingSpace = LivingSpace
            };
            _bus.Send(cmd);
            HasChanges = false;
            NavigationService.GoBack();
        }
        #endregion
    }
}
