using IsaB.CommandStack.Commands;
using IsaB.Entities;
using IsaB.Infrastructure;
using IsaB.QueryStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace IsaB.ViewModels
{
    public class NewEstatePageViewModel : ViewModelBase
    {
        #region Private members
        IBus _bus;
        IStaticsService _staticsService;
        #endregion
        #region Construction
        public NewEstatePageViewModel(IBus bus, IStaticsService staticsService)
        {
            _bus = bus;
            _staticsService = staticsService;
            SaveNewEstateCommand = new DelegateCommand(SaveNewEstateAction);
            CancelCommand = new DelegateCommand(()=> { NavigationService.GoBack(); });
        }
        #endregion

        #region Properties
        public DelegateCommand SaveNewEstateCommand { get; }
        public DelegateCommand CancelCommand { get; }
        private GebaeudeartEntity _selectedBuildingKind;
        /// <summary>
        /// Die ausgewählte Gebäudeart
        /// </summary>
        public GebaeudeartEntity SelectedBuildingKind
        {
            get { return _selectedBuildingKind; }
            set { Set(ref _selectedBuildingKind, value); }
        }
        private IList<GebaeudeartEntity> _allBuildingKinds;
        /// <summary>
        /// Auswahl aller Gebäudearten
        /// </summary>
        public IList<GebaeudeartEntity> AllBuildingKinds
        {
            get { return _allBuildingKinds; }
            set { Set(ref _allBuildingKinds, value); }
        }
        #endregion

        #region Overrides
        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            AllBuildingKinds = _staticsService.BuildingKinds;
            return Task.CompletedTask;
        }
        #endregion

        #region Private helper methods
        private void SaveNewEstateAction()
        {
            if (SelectedBuildingKind != null)
            {
                CreateNewEstateCommand cmd = new CreateNewEstateCommand()
                {
                    BuildingKind = SelectedBuildingKind.ID,
                    Construction = 1,
                    FittingOut = 1,
                    NewCity = "Schönaich",
                    NewStreet = "In den Bergen 3"
                };
                _bus.Send(cmd);
                NavigationService.GoBack();
            }
        }
        #endregion
    }
}
