using IsaB.CommandStack.Commands;
using IsaB.Entities;
using IsaB.Infrastructure;
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
    public class EstateLandsizeEditPageViewModel : ViewModelBase
    {
        private ImmobilieEntity _estate;
        private int _estateID;
        private readonly IEstateService _estateService;
        private readonly IBus _bus;
        public EstateLandsizeEditPageViewModel(IEstateService estateService, IBus bus)
        {
            _estateService = estateService;
            _bus = bus;
            SaveLandsize = new DelegateCommand(SaveLandsizeAction);
        }

        public DelegateCommand SaveLandsize { get; }
        private float? _landisze;
        public float? Landsize
        {
            get { return _landisze; }
            set { Set(ref _landisze, value); }
        }
        private float? _standardGroundValue;
        public float? StandardGroundValue
        {
            get { return _standardGroundValue; }
            set { Set(ref _standardGroundValue, value); }
        }
        private float? _livingSpace;

        public float? LivingSpace
        {
            get { return _livingSpace; }
            set { Set(ref _livingSpace, value); }
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
                        Landsize = _estate.Grundstuecksflaeche;
                        StandardGroundValue = _estate.Bodenrichtwert;
                        LivingSpace = _estate.Bruttogrundflaeche;
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
        }
        #endregion
    }
}
