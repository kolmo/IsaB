using IsaB.Entities;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace IsaB.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EstateListPage : Page
    {
        public EstateListPage()
        {
            this.InitializeComponent();
        }
      

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog noWifiDialog = new ContentDialog()
            {
                Title = "Neue Immobilie",
                Content = "Eine neue Immobilie anlegen?",
                PrimaryButtonText = "Ja",
                SecondaryButtonText = "Nein"
            };
            ContentDialogResult result = await noWifiDialog.ShowAsync();
            if (result== ContentDialogResult.Primary )
            {
                App.Current.NavigationService.Navigate(typeof(Views.NewEstatePage));
            }
        }
        private void itemGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImmobilieEntity immo = e.ClickedItem as ImmobilieEntity;
            if (immo != null)
            {
                App.Current.NavigationService.Navigate(typeof(Views.EstateDetailsPage), immo.ID);
            }
        }
    }
}
