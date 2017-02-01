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
    public class ConstructionFittingOutSelectionPageViewModel : EditViewModelBase
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
            CommandBag.Add(SaveCommand = new DelegateCommand(SaveAction, () => HasChanges));
        }
        #endregion

        #region Properties
        public DelegateCommand SaveCommand { get; }
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
                    _constructions = new List<ConstructionSelectionModel>();
                    foreach (var item in constructions)
                    {
                        ConstructionSelectionModel model = new ConstructionSelectionModel(item, item.ID == estate.BauweiseId);
                        model.PropertyChanged += ConstructionModel_PropertyChanged;
                        _constructions.Add(model);
                    }
                    RaisePropertyChanged(nameof(Constructions));
                    // FittingOut-Setup
                    var fittingOuts = _staticsService.FittingOutsByBuildingKind(estate.GebaeudeartId);
                    _fittingOuts = new List<FittingOutSelectionModel>();
                    foreach (var item in fittingOuts)
                    {
                        FittingOutSelectionModel model = new FittingOutSelectionModel(item, item.ID == estate.AusbauzustandId);
                        model.PropertyChanged += FittingOutModel_PropertyChanged;
                        _fittingOuts.Add(model);
                    }
                    RaisePropertyChanged(nameof(FittingOuts));
                    this.HasChanges = false;
                }
            }
            return Task.CompletedTask;
        }

        private void FittingOutModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (!HasChanges)
                HasChanges = FittingOuts.Any(x => x.HasChanges);
        }

        private void ConstructionModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (!HasChanges)
                HasChanges = Constructions.Any(x => x.HasChanges);
        }
        #endregion

        #region Private Methods
        private void SaveAction()
        {
            ConstructionSelectionModel model = Constructions.FirstOrDefault(x => x.IsSelected && x.HasChanges);
            if (model != null)
            {
                _bus.Send(new CommandStack.Commands.SaveEstateConstructionCommand
                {
                    EstateId = _estateID,
                    ConstructionId = model.Entity.ID
                });
            }
            FittingOutSelectionModel fittingOutModel = FittingOuts.FirstOrDefault(x => x.IsSelected && x.HasChanges);
            if (fittingOutModel != null)
            {
                _bus.Send(new CommandStack.Commands.SaveEstateFittingOutCommand
                {
                    EstateId = _estateID,
                    FittingOutId = fittingOutModel.Entity.ID
                });
            }
            NavigationService.GoBack();
        }
        #endregion

    }
}
