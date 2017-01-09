using IsaB.BusinessObjects;
using IsaB.Entities;
using IsaB.Interfaces;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace IsaB.ViewModels
{
    public class EstateListPageViewModel : ViewModelBase
    {
        private readonly IEstateService _immobilienService;
        public EstateListPageViewModel(IEstateService immoService )
        {
            _immobilienService = immoService;
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
            Immobilie immo =  new Immobilie
            {
                GebaeudeartId = 1,
                BauweiseId = 1,
                AusbauzustandId = 1,
                ErzeugtAm = DateTime.Now
            };
            //_immobilienService.AddNewImmobilie(immo);
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