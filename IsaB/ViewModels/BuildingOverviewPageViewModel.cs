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
        /// <summary>
        /// Gebaeudeart
        /// </summary>
        public string BuildingKind
        {
            get { return _buildingKind; }
            set { Set(ref _buildingKind, value); }
        }
        private string _construction;
        /// <summary>
        /// Bauweise
        /// </summary>
        public string Construction
        {
            get { return _construction; }
            set { Set(ref _construction, value); }
        }
        private string _fittingOut;
        /// <summary>
        /// Ausbauzustand
        /// </summary>
        public string FittingOut
        {
            get { return _fittingOut; }
            set { Set(ref _fittingOut, value); }
        }
        /// <summary>
        /// 
        /// </summary>
        public ImmobilieEntity Estate
        {
            get { return _estate; }
            set { Set(ref _estate, value); }
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
                    Estate = _estateService.GetEstate(_estateID);
                    if (Estate != null)
                    {
                        BuildingKind = _staticsService.BuildingKinds.FirstOrDefault(x => x.ID == Estate.GebaeudeartId)?.Bezeichnung;
                        Construction = _staticsService.Constructions.FirstOrDefault(x => x.ID == Estate.BauweiseId)?.Bezeichnung;
                        FittingOut = _staticsService.FittingOuts.FirstOrDefault(x => x.ID == Estate.AusbauzustandId)?.Bezeichnung;
                    }
                }
            }
            return Task.CompletedTask;
        }
        #endregion
    }
}
