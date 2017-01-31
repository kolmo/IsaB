using IsaB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class ConstructionYearModernizationPage : Page
    {
        public ConstructionYearModernizationPage()
        {
            this.InitializeComponent();
        }

        private void modernizationsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ModernizationModel model = e.ClickedItem as ModernizationModel;
            if (model!= null)
            {
                App.Current.NavigationService.Navigate(typeof(ModernizationDetailSetPage), model);
            }
        }
    }
}
