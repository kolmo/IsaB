using Windows.UI.Xaml;
using System.Threading.Tasks;
using IsaB.Services.SettingsServices;
using Windows.ApplicationModel.Activation;
using Template10.Controls;
using System;
using Windows.UI.Xaml.Data;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Controls;
using IsaB.Views;
using IsaB.ViewModels;
using LightInject;
using System.IO;
using Windows.Storage;
using IsaB.Interfaces;
using IsaB.QueryStack;
using IsaB.CommandStack.Sagas;
using IsaB.CommandStack.Commands;
using IsaB.QueryStack.Services;
using IsaB.Infrastructure;
using IsaB.Infrastructure.Impl;
using IsaB.Infrastructure.SQLite;

namespace IsaB
{
    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    [Bindable]
    sealed partial class App : Template10.Common.BootStrapper
    {
        string _dbName = null;
        public static Prism.Events.EventAggregator EventAggregator;
        internal static ServiceContainer Container;
        public App()
        {
            InitializeComponent();
            SplashFactory = (e) => new Views.Splash(e);
            EventAggregator = new Prism.Events.EventAggregator();

            #region App settings

            var _settings = SettingsService.Instance;
            RequestedTheme = _settings.AppTheme;
            CacheMaxDuration = _settings.CacheMaxDuration;
            ShowShellBackButton = _settings.UseShellBackButton;

            #endregion
          
        }

        public override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            if (Container == null)
                Container = new ServiceContainer();
            _dbName = Path.Combine(ApplicationData.Current.LocalFolder.Path, "ISaB.sqlite");
            Container.RegisterInstance<IBus>(new InMemoryBus(Container));
            IBus bus = Container.GetInstance<IBus>();
            ConfigureRegistryBoundedContext(bus);
            Container.RegisterInstance<IDatabaseService>(new DatabaseService(_dbName));
            IDatabaseService dataBaseService = Container.GetInstance<IDatabaseService>();
            dataBaseService.InitializeDataSource();
            Container.RegisterInstance<IRepository>(new SQLiteRepository(_dbName));
            Container.Register<INavigable, MainPageViewModel>(typeof(MainPage).FullName);
            Container.Register<INavigable, EstateListPageViewModel>(typeof(EstateListPage).FullName);
            Container.Register<INavigable, EstateDetailsPageViewModel>(typeof(EstateDetailsPage).FullName);
            Container.Register<INavigable, EstateAddressEditPageViewModel>(typeof(EstateAddressEditPage).FullName);
            Container.Register<INavigable, EstateLandsizeEditPageViewModel>(typeof(EstateLandsizeEditPage).FullName);
            Container.Register<INavigable, PictureEditPageViewModel>(typeof(PictureEditPage).FullName);
            Container.Register<INavigable, PictureGalleryPageViewModel>(typeof(PictureGalleryPage).FullName);
            Container.Register<INavigable, StandardOverviewPageViewModel>(typeof(StandardOverviewPage).FullName);
            Container.Register<INavigable, StandardLevelPropSelectionPageViewModel>(typeof(StandardLevelPropSelectionPage).FullName);
            Container.Register<IQueryModelDatabase, QueryStack.QueryModelDatabase>(new PerContainerLifetime());
            Container.Register<IEstateService, EstateService>();
            Container.Register<IStaticsService, StaticsService>(new PerContainerLifetime());

            if (Window.Current.Content as ModalDialog == null)
            {
                // create a new frame 
                var nav = NavigationServiceFactory(BackButton.Attach, ExistingContent.Include);

                // create modal root
                Window.Current.Content = new ModalDialog
                {
                    DisableBackButtonWhenModal = true,
                    Content = new Views.Shell(nav),
                    ModalContent = new Views.Busy(),
                };
            }
            await Task.CompletedTask;
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            // long-running startup tasks go here

            NavigationService.Navigate(typeof(Views.EstateListPage));
            await Task.CompletedTask;
        }
        public override INavigable ResolveForPage(Page page, NavigationService navigationService)
        {
            INavigable viewModel = Container.GetInstance<INavigable>(page.GetType().FullName);
            return viewModel;
        }
        private void ConfigureRegistryBoundedContext(IBus bus)
        {
            //Sagas
            bus.RegisterSaga< CreateNewEstateCommand, CreateNewEstateSaga>();
            bus.RegisterSaga<SaveEstateAddressCommand, SaveEstateAddressSaga>();
            bus.RegisterSaga<SaveEstateLandsizeCommand, SaveEstateLandsizeSaga>();
            bus.RegisterSaga<SavePictureCommand, SavePictureSaga>();
            bus.RegisterSaga<DeletePictureCommand, DeletePictureSaga>();
            bus.RegisterSaga<SavePartPropSettingCommand, SavePartPropSettingSaga>();
            Container.Register(typeof(SavePartPropSettingSaga));
            Container.Register(typeof(CreateNewEstateSaga));
            Container.Register(typeof(SaveEstateAddressSaga));
            Container.Register(typeof(SaveEstateLandsizeSaga));
            Container.Register(typeof(SavePictureSaga));
            Container.Register(typeof(DeletePictureSaga));
        }
    }
}

