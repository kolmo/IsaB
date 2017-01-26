using System.Collections.Generic;
using System.Threading.Tasks;
using IsaB.Infrastructure;
using System.Linq;
using IsaB.QueryStack;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;
using IsaB.Entities;
using System.Collections.ObjectModel;

namespace IsaB.ViewModels
{
    public class StandardOverviewPageViewModel : ViewModelBase
    {
        private int _estateID;
        private readonly IStaticsService _staticsService;
        private readonly IEstateService _estateService;
        private readonly IBus _bus;
        public StandardOverviewPageViewModel(IEstateService estateService, IStaticsService staticsService, IBus bus)
        {
            _staticsService = staticsService;
            _estateService = estateService;
            _bus = bus;
        }
        private ImmobilieEntity _estate;
        /// <summary>
        /// 
        /// </summary>
        public ImmobilieEntity Estate
        {
            get { return _estate; }
            set { Set(ref _estate, value); }
        }
        private ObservableCollection<ListEntry> _buildingParts;

        public ObservableCollection<ListEntry> BuildingParts
        {
            get { return _buildingParts; }
            set { Set(ref _buildingParts, value); }
        }

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
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
                    BuildingParts = new ObservableCollection<ListEntry>();
                    foreach (var grp in q)
                    {
                        BuildingParts.Add(new ListEntry
                        {
                            Name = grp.PartName,
                            Value = grp.PartValue,
                            PartId = grp.PartId,
                            EstateId = _estateID,
                            StdTableId = stdTableId
                        });
                    }
                }
            }
            return Task.CompletedTask;
        }
        public class ListEntry
        {
            public int EstateId { get; set; }
            public int StdTableId { get; set; }
            public int PartId { get; set; }
            public double Value { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }
    }
}
