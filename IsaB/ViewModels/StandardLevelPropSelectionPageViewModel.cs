using IsaB.Entities;
using IsaB.Infrastructure;
using IsaB.Models;
using IsaB.QueryStack;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace IsaB.ViewModels
{
    public class StandardLevelPropSelectionPageViewModel : ViewModelBase
    {
        private readonly IStaticsService _staticsService;
        private readonly IEstateService _estateService;
        private readonly IBus _bus;
        public StandardLevelPropSelectionPageViewModel(IEstateService estateService, IStaticsService staticsService, IBus bus)
        {
            _staticsService = staticsService;
            _estateService = estateService;
            _bus = bus;
        }
        private object _stdLevelProperties;

        public object StdLevelProperties
        {
            get { return _stdLevelProperties; }
            set { Set(ref _stdLevelProperties, value); }
        }


        private string _title;
        public string Title
        {
            get { return _title; }
            set { Set(ref _title, value); }
        }

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            BuildingPartModel part = parameter as BuildingPartModel;
            if (part != null)
            {
                Title = part.Name;
                var query = from s in _staticsService.StandardLevelProperties
                            orderby s.Stufe descending
                            where s.GebTeilId == part.PartId && s.StdTabellenId == part.StdTableId
                            select s;
                var selectedProps = _estateService.EstateStandardLevelPropertyEntities.Where(x => x.EstateId == part.EstateId).ToList();
                List<StandardLevelPropertyModel> standardProperties = new List<StandardLevelPropertyModel>();
                foreach (var item in query)
                {
                    var exp = selectedProps.FirstOrDefault(x => x.StandardLevelPropertyId == item.ID);
                    if (exp == null)
                    {
                        exp = new EstateStandardLevelPropertyEntity
                        {
                            EstateId = part.EstateId,
                            StandardLevelPropertyId = item.ID
                        };
                    }
                    var pi = new StandardLevelPropertyModel(item, exp);
                    pi.PropertyChanged += Pi_PropertyChanged;
                    standardProperties.Add(pi);
                }
                var grpQuery = from s in standardProperties
                               group s by s.Level into grp
                               orderby grp.Key descending
                               select grp;
                StdLevelProperties = grpQuery;
            }
            return Task.CompletedTask;
        }

        private void Pi_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            StandardLevelPropertyModel pi = sender as StandardLevelPropertyModel;
            if (pi != null)
            {
                CommandStack.Commands.SavePartPropSettingCommand cmd = new CommandStack.Commands.SavePartPropSettingCommand();
                cmd.EstateStdLevelProp = pi.EstateStandardLevelProp;
                _bus.Send(cmd);
            }
        }
    }
}
