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
        EstateListPageViewModel _viewModel;
        public EstateListPage()
        {
            this.InitializeComponent();
            Loaded += (s, a) => { _viewModel = DataContext as EstateListPageViewModel; };
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog noWifiDialog = new ContentDialog()
            {
                Title = "No wifi connection",
                Content = "Check connection and try again",
                PrimaryButtonText = "Ok",
                SecondaryButtonText = "Cancel"
            };
            ContentDialogResult result = await noWifiDialog.ShowAsync();
            if (result== ContentDialogResult.Primary)
            {
                _viewModel.AddNewEstate();
                await _viewModel.ReloadEstates();
            }
        }
        private void itemGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImmobilieEntity immo = e.ClickedItem as ImmobilieEntity;
            if (immo != null)
            {
                //this.Frame.Navigate(typeof(ImmobilieEditPage), immo.ID);
            }
        }
    }
}
