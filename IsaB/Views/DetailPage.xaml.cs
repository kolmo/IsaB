using IsaB.ViewModels;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;
using IsaB.Helper;
using System.Collections.Generic;

namespace IsaB.Views
{
    public sealed partial class DetailPage : Page
    {
        public DetailPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
            this.Loaded += DetailPage_Loaded;
        }

        private void DetailPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            List<CommandWrapper> wrappers = new List<CommandWrapper>();
            wrappers.Add(new CommandWrapper { CommandSymbol = Symbol.Camera, CommandText="Bild aufnehmen" });
            wrappers.Add(new CommandWrapper { CommandSymbol = Symbol.Delete, CommandText = "Löschen" });
            App.EventAggregator.GetEvent<CommandsToAddEvent>().Publish(wrappers);
        }
    }
}

