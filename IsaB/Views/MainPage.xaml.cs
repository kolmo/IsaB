using System;
using IsaB.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

namespace IsaB.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }
        MainPageViewModel _viewModel;

        public MainPageViewModel ViewModel
        {
            get { return _viewModel ?? (_viewModel = (MainPageViewModel)this.DataContext); }
        }

    }
}
