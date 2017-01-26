using IsaB.Entities;
using IsaB.Infrastructure;
using IsaB.QueryStack;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;
using System.Linq;

namespace IsaB.ViewModels
{
    public class BuildingOverviewPageViewModel : ViewModelBase
    {
        #region Private members
        private ImmobilieEntity _estate;
        private int _estateID;
        private readonly IEstateService _estateService;
        private readonly IStaticsService _staticsService;
        private readonly IBus _bus;
        #endregion

        #region Constructor
        public BuildingOverviewPageViewModel(
            IEstateService estateService,
            IStaticsService staticsService,
            IBus bus)
        {
            _estateService = estateService;
            _staticsService = staticsService;
            _bus = bus;
        }
        #endregion

        #region Properties
        private string _buildingKind;

        public string BuildingKind
        {
            get { return _buildingKind; }
            set { Set(ref _buildingKind, value); }
        }
        private string _construction;

        public string Construction
        {
            get { return _construction; }
            set { Set(ref _construction, value); }
        }
        private string _fittingOut;

        public string FittingOut
        {
            get { return _fittingOut; }
            set { Set(ref _fittingOut, value); }
        }

        #endregion
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
                        BuildingKind = _staticsService.BuildingKinds.FirstOrDefault(x => x.ID == _estate.GebaeudeartId)?.Bezeichnung;
                        Construction = _staticsService.Constructions.FirstOrDefault(x => x.ID == _estate.BauweiseId)?.Bezeichnung;
                        FittingOut = _staticsService.FittingOuts.FirstOrDefault(x => x.ID == _estate.AusbauzustandId)?.Bezeichnung;
                    }
                }
            }
            return Task.CompletedTask;
        }
        #endregion
    }
}
