using IsaB.Infrastructure;
using IsaB.QueryStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;
using System.Runtime.CompilerServices;
using IsaB.Models;
using System.Collections.ObjectModel;

namespace IsaB.ViewModels
{
    public class ConstructionYearModernizationPageViewModel : ViewModelBase
    {
        #region Private members
        private bool _isInitializing = false;
        IBus _bus;
        private int _estateID;
        private readonly IEstateService _estateService;
        private readonly IStaticsService _staticsService;
        #endregion
        #region Construction
        public ConstructionYearModernizationPageViewModel(
            IBus bus,
            IStaticsService staticsService,
            IEstateService estateService)
        {
            _bus = bus;
            _estateService = estateService;
            _staticsService = staticsService;
        }
        #endregion

        #region Properties
        private int? _constructionYear;
        /// <summary>
        /// 
        /// </summary>
        public int? ConstructionYear
        {
            get { return _constructionYear; }
            set { Set(ref _constructionYear, value); }
        }
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<ModernizationModel> Modernizations { get; } = new ObservableCollection<ModernizationModel>();


        #endregion
        #region overrides
        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            _isInitializing = true;
            if (parameter != null && parameter is string)
            {
                int estateID;
                if (int.TryParse((string)parameter, out estateID))
                {
                    _estateID = estateID;
                    var estate = _estateService.GetEstate(_estateID);
                    ConstructionYear = estate.Baujahr;
                    var modernizations = _estateService.EstateModernizations.Where(x => x.ImmoID == _estateID).ToList();
                    foreach (var item in _staticsService.Modernizations)
                    {
                        var estateModernization = modernizations.FirstOrDefault(x => x.ModernId == item.ID);
                        if (estateModernization == null)
                        {

                        }
                        ModernizationModel model = new ModernizationModel()
                        {
                            EstateId = _estateID,
                            ModernElementId = item.ID,
                            PointsSet = modernizations.FirstOrDefault(x => x.ModernId == item.ID)?.Punkte,
                            Description=item.ModernElement,
                            MaximumPoints=item.MaxPunkte
                        };
                        Modernizations.Add(model);
                    }
                }
            }
            _isInitializing = false;
            return Task.CompletedTask;
        }
        public override void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!_isInitializing)
            {
                CommandStack.Commands.SaveEstateConstructionYearCommand cmd = new CommandStack.Commands.SaveEstateConstructionYearCommand();
                cmd.EstateId = _estateID;
                cmd.ConstructionYear = ConstructionYear;
                _bus.Send(cmd);
            }
            base.RaisePropertyChanged(propertyName);
        }
        #endregion
    }
}
