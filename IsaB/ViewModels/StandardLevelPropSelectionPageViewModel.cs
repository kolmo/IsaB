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
    public class StandardLevelPropSelectionPageViewModel : EditViewModelBase
    {
        #region Private members
        private readonly IStaticsService _staticsService;
        private readonly IEstateService _estateService;
        private readonly IBus _bus;
        private List<StandardLevelPropertyModel> _standardProperties;
        #endregion

        #region Constructor
        public StandardLevelPropSelectionPageViewModel(IEstateService estateService, IStaticsService staticsService, IBus bus)
        {
            _staticsService = staticsService;
            _estateService = estateService;
            _bus = bus;
            CommandBag.Add(SaveCommand = new DelegateCommand(SaveAction, () => HasChanges));
        }
        #endregion

        #region Properties
        public DelegateCommand SaveCommand { get; }
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

        #endregion

        #region Overrides
        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            BuildingPartModel part = parameter as BuildingPartModel;
            if (part != null)
            {
                _title = part.Name;
                var query = from s in _staticsService.StandardLevelProperties
                            orderby s.Stufe descending
                            where s.GebTeilId == part.PartId && s.StdTabellenId == part.StdTableId
                            select s;
                var selectedProps = _estateService.EstateStandardLevelPropertyEntities.Where(x => x.EstateId == part.EstateId).ToList();
                _standardProperties = new List<StandardLevelPropertyModel>();
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
                    _standardProperties.Add(pi);
                }
                var grpQuery = from s in _standardProperties
                               group s by s.Level into grp
                               orderby grp.Key descending
                               select grp;
                _stdLevelProperties = grpQuery;
                RaisePropertyChanged(nameof(Title));
                RaisePropertyChanged(nameof(StdLevelProperties));
            }
            return Task.CompletedTask;
        }

        #endregion
        #region Event Handler
        private void Pi_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (_standardProperties != null)
            {
                HasChanges = _standardProperties.Any(x => x.HasChanges);
            }
        }

        #endregion

        #region Private Methods
        private void SaveAction()
        {
            if (_standardProperties?.Any(x => x.HasChanges) == true)
            {
                CommandStack.Commands.SavePartPropSettingCommand cmd = new CommandStack.Commands.SavePartPropSettingCommand();
                cmd.EstateStdLevelProp = _standardProperties.Where(x => x.HasChanges).Select(x => x.EstateStandardLevelProp).ToList();
                _bus.Send(cmd);
            }
            NavigationService.GoBack();
        }
        #endregion

    }
}
