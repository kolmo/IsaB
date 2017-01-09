using Windows.UI.Xaml;
using System.Threading.Tasks;
using IsaB.Services.SettingsServices;
using Windows.ApplicationModel.Activation;
using Template10.Controls;
using Template10.Common;
using System;
using System.Linq;
using Windows.UI.Xaml.Data;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Controls;
using IsaB.Views;
using IsaB.ViewModels;
using LightInject;
using System.IO;
using Windows.Storage;
using IsaB.Interfaces.Services;
using IsaB.Services;
using IsaB.Interfaces;

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
            Container.RegisterInstance<ISeedLoaderService>(new SeedLoaderService(_dbName));
            Container.Register<INavigable, MainPageViewModel>(typeof(MainPage).FullName);
            Container.Register<INavigable, EstateListPageViewModel>(typeof(EstateListPage).FullName);
            Container.Register<IDatabaseService, DatabaseService>();
            Container.Register<IQueryModelDatabase, QueryModelDatabase>();
            Container.Register<IEstateService, EstateService>();
            Container.Register<IBilderService, BilderService>();
            Container.Register<IImmobilienService, ImmobilienService>();
            Container.Register<IGebaeudeartService, GebaeudeartService>();
            Container.Register<IKorrfaktorService, KorrfaktorService>();
            Container.Register<IModernisierungService, ModernisierungService>();
            IDatabaseService dataBaseService = Container.GetInstance<IDatabaseService>();
            dataBaseService.InitializeDataSource();

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
            return Container.GetInstance<INavigable>(page.GetType().FullName);
        }
    }
}

