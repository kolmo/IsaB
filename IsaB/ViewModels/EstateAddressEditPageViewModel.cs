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
    public class EstateAddressEditPageViewModel : ViewModelBase
    {
        private ImmobilieEntity _estate;
        private int _estateID;
        private readonly IEstateService _estateService;
        private readonly IBus _bus;
        public EstateAddressEditPageViewModel(IEstateService estateService, IBus bus)
        {
            _estateService = estateService;
            _bus = bus;
            SaveAddress = new DelegateCommand(SaveAddressAction);
        }

        public DelegateCommand SaveAddress { get; }
        private string _street;
        public string Street
        {
            get { return _street; }
            set { Set(ref _street, value); }
        }
        private string _city;

        public string City
        {
            get { return _city; }
            set { Set(ref _city, value); }
        }
        private string _postcode;

        public string Postcode
        {
            get { return _postcode; }
            set { Set(ref _postcode, value); }
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
                        Street = _estate.Strasse;
                        City = _estate.Ort;
                        Postcode = _estate.PLZ;
                    }
                }
            }
            return Task.CompletedTask;
        }

        #endregion
        #region Private Methods
        private void SaveAddressAction()
        {
            SaveEstateAddressCommand cmd = new SaveEstateAddressCommand()
            {
                EstateID = _estateID,
                Street = this.Street,
                Postcode = this.Postcode,
                City = this.City
            };
            _bus.Send(cmd);
        }
        #endregion
    }
}
