using IsaB.Entities;
using IsaB.Helper;
using IsaB.Model;
using IsaB.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Template10.Controls;
using Template10.Services.NavigationService;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
            EstateListPageViewModel viewModel = DataContext as EstateListPageViewModel;
            if (result== ContentDialogResult.Primary && viewModel!= null)
            {
                viewModel.AddNewEstate();
                await viewModel.ReloadEstates();
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
