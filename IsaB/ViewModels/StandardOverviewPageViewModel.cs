using System.Collections.Generic;
using System.Threading.Tasks;
using IsaB.Infrastructure;
using System.Linq;
using IsaB.QueryStack;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;
using IsaB.Entities;
using System.Collections.ObjectModel;
using IsaB.Models;
using System.Runtime.CompilerServices;

namespace IsaB.ViewModels
{
    public class StandardOverviewPageViewModel : ViewModelBase
    {
        #region Private members
        private bool _isInitializing;
        private int _estateID;
        private readonly IStaticsService _staticsService;
        private readonly IEstateService _estateService;
        private readonly IBus _bus;
        #endregion

        #region Constructor
        public StandardOverviewPageViewModel(IEstateService estateService, IStaticsService staticsService, IBus bus)
        {
            _staticsService = staticsService;
            _estateService = estateService;
            _bus = bus;
        }
        #endregion

        #region Properties
        private ImmobilieEntity _estate;
        /// <summary>
        /// 
        /// </summary>
        public ImmobilieEntity Estate
        {
            get { return _estate; }
            set { Set(ref _estate, value); }
        }

        private ObservableCollection<BuildingPartModel> _buildingParts;
        /// <summary>
        /// Gebäudeteile
        /// </summary>
        public ObservableCollection<BuildingPartModel> BuildingParts
        {
            get { return _buildingParts; }
            set { Set(ref _buildingParts, value); }
        }
        private double _maximumLevelManually;
        /// <summary>
        /// 
        /// </summary>
        public double MaximumLevelManually
        {
            get { return _maximumLevelManually; }
            set { Set(ref _maximumLevelManually, value); }
        }
        private double _minimumLevelManually;
        /// <summary>
        /// 
        /// </summary>
        public double MinimumLevelManually
        {
            get { return _minimumLevelManually; }
            set { Set(ref _minimumLevelManually, value); }
        }
        private double? _standardManuallySet;
        /// <summary>
        /// 
        /// </summary>
        public double? StandardManuallySet
        {
            get { return _standardManuallySet; }
            set { Set(ref _standardManuallySet, value); }
        }

        #endregion

        #region Overrides
        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            _isInitializing = true;
            if (parameter != null && parameter is string)
            {
                int estateID;
                if (int.TryParse((string)parameter, out estateID))
                {
                    var buildingKinds = _staticsService.BuildingKinds;
                    _estateID = estateID;
                    Estate = _estateService.GetEstate(_estateID);
                    int stdTableId = buildingKinds.First(x => x.ID == Estate.GebaeudeartId).StandardTableId;
                    var stdQuery = from e in _estateService.PartStandards
                                   where e.ImmoId == _estateID
                                   select e;
                    var q = from part in _staticsService.BuildingParts
                            join entry in stdQuery
                            on part.ID equals entry.TeileId into partGroup
                            from item in partGroup.DefaultIfEmpty(new Entities.PartStandardEntity { ID = 0, TeileId = 0, ImmoId = 0, Wert = 0 })
                            select new { PartName = part.Bezeichnung, PartValue = item.Wert, PartId = part.ID };
                    BuildingParts = new ObservableCollection<BuildingPartModel>();
                    foreach (var grp in q)
                    {
                        BuildingParts.Add(new BuildingPartModel
                        {
                            Name = grp.PartName,
                            Value = grp.PartValue,
                            PartId = grp.PartId,
                            EstateId = _estateID,
                            StdTableId = stdTableId
                        });
                    }
                    var standardTable = _staticsService.StandardTables.Single(x => x.ID == stdTableId);
                    MaximumLevelManually = standardTable.MaximumLevel;
                    MinimumLevelManually = standardTable.MinimumLevel;
                    StandardManuallySet = _estate.StandardManuallySet;
                }
            }
            _isInitializing = false;
            return Task.CompletedTask;
        }
        public override void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!_isInitializing && propertyName == nameof(StandardManuallySet))
            {
                CommandStack.Commands.SaveStandardManuallySetCommand cmd = new CommandStack.Commands.SaveStandardManuallySetCommand();
                cmd.EstateId = _estateID;
                cmd.StandardManuallySet = StandardManuallySet;
                _bus.Send(cmd);
            }
            base.RaisePropertyChanged(propertyName);
        }
        #endregion
    }
}
