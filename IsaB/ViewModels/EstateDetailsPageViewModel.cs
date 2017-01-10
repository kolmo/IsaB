using IsaB.Entities;
using IsaB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace IsaB.ViewModels
{
    public class EstateDetailsPageViewModel : ViewModelBase
    {
        private readonly IEstateService _estateService;
        public EstateDetailsPageViewModel(IEstateService estateService)
        {
            _estateService = estateService;
        }
        private ImmobilieEntity _estate;
        public ImmobilieEntity Estate
        {
            get { return _estate; }
            set { Set(ref _estate, value); }
        }
        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (parameter!=null && parameter is int)
            {
                int estateId = (int)parameter;
                Estate = _estateService.AllEStates.Where(x => x.ID == estateId).FirstOrDefault();
            }
            return Task.CompletedTask;
        }
    }
}
