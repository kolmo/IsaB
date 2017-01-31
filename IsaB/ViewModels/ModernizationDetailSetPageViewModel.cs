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
using System.Runtime.CompilerServices;
using IsaB.CommandStack.Commands;

namespace IsaB.ViewModels
{
    public class ModernizationDetailSetPageViewModel : ViewModelBase
    {
        #region Private members
        private bool _isInitializing = false;
        private int _estateId;
        private int _modernElementId;
        private Entities.ImmobilieModernisierungEntity _estateModernization = null;
        private readonly IBus _bus;
        private readonly IStaticsService _staticsServcie;
        private readonly IEstateService _estateService;
        #endregion

        #region Constructor
        public ModernizationDetailSetPageViewModel(
            IBus bus,
            IStaticsService staticsService,
            IEstateService estateService)
        {
            _bus = bus;
            _staticsServcie = staticsService;
            _estateService = estateService;
            SaveCommand = new DelegateCommand(SaveAction);
        }
        #endregion

        #region Properties
        public DelegateCommand SaveCommand { get; }
        private string _comment;
        /// <summary>
        /// 
        /// </summary>
        public string Comment
        {
            get { return _comment; }
            set { Set(ref _comment, value); }
        }

        private double? _points;
        /// <summary>
        /// 
        /// </summary>
        public double? Points
        {
            get { return _points; }
            set { Set(ref _points, value); }
        }
        private double _maximumPoints;
        /// <summary>
        /// 
        /// </summary>
        public double MaximumPoints
        {
            get { return _maximumPoints; }
            set { Set(ref _maximumPoints, value); }
        }

        private Tuple<double,double?> _modernization;
        /// <summary>
        /// 
        /// </summary>
        public Tuple<double, double?> Modernization
        {
            get { return _modernization; }
            set { Set(ref _modernization, value); }
        }
        private string _modernElementTitle;
        /// <summary>
        /// 
        /// </summary>
        public string ModernElementTitle
        {
            get { return _modernElementTitle; }
            set { Set(ref _modernElementTitle, value); }
        }

        #endregion
        #region Overrides
        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            _isInitializing = true;
            ModernizationModel mmodel = parameter as ModernizationModel;
            if (mmodel!= null)
            {
                _modernElementId = mmodel.ModernElementId;
                _estateId = mmodel.EstateId;
                _estateModernization = _estateService.EstateModernizations.FirstOrDefault(x=>x.ImmoID==_estateId && x.ModernId == _modernElementId);
                if (_estateModernization==null)
                {
                    _estateModernization = new Entities.ImmobilieModernisierungEntity()
                    {
                        ImmoID = _estateId,
                        ModernId = _modernElementId
                    };
                }
                ModernElementTitle = mmodel.Description;
                MaximumPoints = mmodel.MaximumPoints;
                Points = mmodel.PointsSet;
                Comment = _estateModernization.Bemerkung;
                SetModernization();
            }
            _isInitializing = false;
            return Task.CompletedTask;
        }
        public override void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!_isInitializing && propertyName == nameof(Points))
            {
                SetModernization();
            }
            base.RaisePropertyChanged(propertyName);
        }
        #endregion

        #region Private helper methods
        private void SaveAction()
        {
            _estateModernization.Punkte = Points;
            _estateModernization.Bemerkung = Comment;
            SaveModernizationCommand cmd = new SaveModernizationCommand()
            {
               EstateModernization = _estateModernization
            };
            _bus.Send(cmd);
            NavigationService.GoBack();
        }
        private void SetModernization()
        {
            Modernization = new Tuple<double, double?>(MaximumPoints, Points);
        }
        #endregion
    }
}
