using IsaB.Entities;
using IsaB.Infrastructure;
using IsaB.Interfaces;
using IsaB.QueryStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace IsaB.ViewModels
{
    public class EstateDetailsPageViewModel : ViewModelBase
    {
        private int _estateID;
        private readonly IBus _bus;
        private readonly IEstateService _estateService;
        private readonly IStaticsService _staticsService;
        public EstateDetailsPageViewModel(IEstateService estateService,
            IStaticsService staticsService,
            IBus bus)
        {
            _estateService = estateService;
            _staticsService = staticsService;
            _bus = bus;
            TakePictureCommand = new DelegateCommand(TakePictureAction);
        }

        private ImmobilieEntity _estate;
        public ImmobilieEntity Estate
        {
            get { return _estate; }
            set { Set(ref _estate, value); }
        }
        private string _buildingKind;

        public string BuildingKind
        {
            get { return _buildingKind; }
            set { Set(ref _buildingKind, value); }
        }
        private string _hasModernizations;

        public string HasModernizations
        {
            get { return _hasModernizations; }
            set { Set(ref _hasModernizations, value); }
        }
        private IEnumerable<ImmobilieBildEntity> _pictures;

        public IEnumerable<ImmobilieBildEntity> Pictures
        {
            get { return _pictures; }
            set { Set(ref _pictures, value); }
        }
        private object _titlePicture;

        public object TitlePicture
        {
            get { return _titlePicture; }
            set { Set(ref _titlePicture, value); }
        }
        public DelegateCommand TakePictureCommand { get; private set; }

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (parameter!=null && parameter is int)
            {
                _estateID = (int)parameter;
                Estate = _estateService.GetEstate( _estateID);
                var buildingKinds = _staticsService.BuildingKinds;
                BuildingKind = buildingKinds?.FirstOrDefault(x => x.ID == Estate.GebaeudeartId)?.Bezeichnung;
                HasModernizations = _estateService.AllModernizations.Any(x => x.ImmoID == _estateID).ToString();
                LoadPictures();
            }
            return Task.CompletedTask;
        }
        private void LoadPictures()
        {
            Pictures = _estateService.GetEstatePics(_estateID);
            var titlePic = Pictures?.FirstOrDefault(x => x.ID == Estate.TitlePictureId)?.Bilddaten;
            if (titlePic == null)
            {
                if (Helper.Constants.DefaultImageSources.ContainsKey(Estate.GebaeudeartId))
                {
                    TitlePicture = Helper.Constants.DefaultImageSources[Estate.GebaeudeartId];
                }
            }
            else
            {
                TitlePicture = titlePic;
            }
        }
        private async void TakePictureAction()
        {
            var camera = new CameraCaptureUI();
            StorageFile storageFile = await camera.CaptureFileAsync(CameraCaptureUIMode.Photo);
            SaveNewImageData(storageFile);

        }
        private async void SaveNewImageData(StorageFile storageFile)
        {
            if (storageFile != null)
            {
                using (var stream = await storageFile.OpenAsync(FileAccessMode.Read))
                {
                    var s = stream.CloneStream();
                    var bitmap = new BitmapImage();
                    bitmap.SetSource(stream);
                    byte[] bilddaten = new byte[stream.Size];
                    using (DataReader reader = new DataReader(s))
                    {
                        await reader.LoadAsync((uint)s.Size);
                        reader.ReadBytes(bilddaten);
                    }
                    CommandStack.Commands.SavePictureCommand command = new CommandStack.Commands.SavePictureCommand()
                    {
                        EstateId = _estateID,
                        PictureData = bilddaten
                    };
                    _bus.Send(command);
                    LoadPictures();                
                }
            }
        }

    }
}
