using IsaB.Entities;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;
using IsaB.Infrastructure;
using IsaB.CommandStack.Commands;
using IsaB.QueryStack;

namespace IsaB.ViewModels
{
    public class EstateListPageViewModel : ViewModelBase
    {
        private readonly IEstateService _immobilienService;
        private readonly IBus _bus;
        public EstateListPageViewModel(IEstateService immoService , IBus bus)
        {
            _immobilienService = immoService;
            _bus = bus;
        }
        private ObservableCollection<ImmobilieEntity> _alleImmobilien;

        public ObservableCollection<ImmobilieEntity> AlleImmobilien
        {
            get { return _alleImmobilien; }
            set
            {
                Set(ref _alleImmobilien, value);
            }
        }
        public void AddNewEstate()
        {
            CreateNewEstateCommand cmd = new CreateNewEstateCommand()
            {
                BuildingKind = 1,
                Construction=1,
                FittingOut=1,
                NewCity = "Schönaich",
                NewStreet = "In den Bergen 3"
            };
            _bus.Send(cmd);
        }
        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            return ReloadEstates();
        }
        public Task ReloadEstates()
        {
            AlleImmobilien = new ObservableCollection<ImmobilieEntity>(_immobilienService.AllEStates.ToList());        
            return Task.CompletedTask;
        }
    }
}