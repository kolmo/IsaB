using IsaB.Entities;
using IsaB.Infrastructure;
using IsaB.Models;
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
    public class ConstructionFittingOutSelectionPageViewModel : ViewModelBase
    {
        #region Private members
        IBus _bus;
        private int _estateID;
        private readonly IEstateService _estateService;
        private readonly IStaticsService _staticsService;
        #endregion
        #region Construction
        public ConstructionFittingOutSelectionPageViewModel(
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
        private IList<ConstructionSelectionModel> _constructions;
        /// <summary>
        /// 
        /// </summary>
        public IList<ConstructionSelectionModel> Constructions
        {
            get { return _constructions; }
            set { Set(ref _constructions, value); }
        }
        private IList<FittingOutSelectionModel> _fittingOuts;
        /// <summary>
        /// 
        /// </summary>
        public IList<FittingOutSelectionModel> FittingOuts
        {
            get { return _fittingOuts; }
            set { Set(ref _fittingOuts, value); }
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
                    var estate = _estateService.AllEStates.Single(x => x.ID == _estateID);
                    // Construction-Setup
                    var constructions = _staticsService.ConstructionsByBuildingKind(estate.GebaeudeartId);
                    var constructionList = new List<ConstructionSelectionModel>();
                    foreach (var item in constructions)
                    {
                        ConstructionSelectionModel model = new ConstructionSelectionModel(item);
                        model.IsSelected = item.ID == estate.BauweiseId;
                        model.PropertyChanged += ConstructionModel_PropertyChanged;
                        constructionList.Add(model);
                    }
                    Constructions = constructionList;
                    // FittingOut-Setup
                    var fittingOuts = _staticsService.FittingOutsByBuildingKind(estate.GebaeudeartId);
                    var fittingOutList = new List<FittingOutSelectionModel>();
                    foreach (var item in fittingOuts)
                    {
                        FittingOutSelectionModel model = new FittingOutSelectionModel(item);
                        model.IsSelected = item.ID == estate.AusbauzustandId;
                        model.PropertyChanged += FittingOutModel_PropertyChanged;
                        fittingOutList.Add(model);
                    }
                    FittingOuts = fittingOutList;
                }
            }
            return Task.CompletedTask;
        }

        private void FittingOutModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            FittingOutSelectionModel model = sender as FittingOutSelectionModel;
            if (model?.IsSelected == true)
            {
                _bus.Send(new CommandStack.Commands.SaveEstateFittingOutCommand
                {
                    EstateId = _estateID,
                    FittingOutId = model.Entity.ID
                });
            }
        }

        private void ConstructionModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ConstructionSelectionModel model = sender as ConstructionSelectionModel;
            if (model?.IsSelected == true)
            {
                _bus.Send(new CommandStack.Commands.SaveEstateConstructionCommand
                {
                    EstateId = _estateID,
                    ConstructionId = model.Entity.ID
                });
            }
        }
        #endregion

    }
}
