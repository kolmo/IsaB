using IsaB.Entities;
using Windows.UI.Xaml.Controls;
using System;
using IsaB.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace IsaB.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EstateDetailsPage : Page
    {
        public EstateDetailsPage()
        {
            this.InitializeComponent();
        }

        private void itemListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImmobilieBildEntity pic = e.ClickedItem as ImmobilieBildEntity;
            if (pic != null)
            {
                Template10.Common.BootStrapper.Current.NavigationService.Navigate(typeof(Views.PictureEditPage), pic.ID);
            }
        }

        private async void AppBarButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ContentDialog noWifiDialog = new ContentDialog()
            {
                Title = "Immobilie löschen",
                Content = "Diese Immobilie wirklich löschen?",
                PrimaryButtonText = "Ja",
                SecondaryButtonText = "Nein"
            };
            ContentDialogResult result = await noWifiDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                EstateDetailsPageViewModel viewModel = DataContext as EstateDetailsPageViewModel;
                if (viewModel != null && viewModel.DeleteEstateCommand.CanExecute())
                {
                    viewModel.DeleteEstateCommand.Execute();
                    App.Current.NavigationService.Navigate(typeof(EstateListPage));
                }
            }
        }
    }
}
