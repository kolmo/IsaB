using IsaB.Helper;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Template10.Common;
using Template10.Controls;
using Template10.Services.NavigationService;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace IsaB.Views
{
    public sealed partial class Shell : Page
    {
        public static Shell Instance { get; set; }
        public static HamburgerMenu HamburgerMenu => Instance.MyHamburgerMenu;

        public Shell()
        {
            Instance = this;
            InitializeComponent();
            DynamicButtons = new ObservableCollection<HamburgerButtonInfo>();
            App.EventAggregator.GetEvent<IsaB.Helper.CommandsToAddEvent>().Subscribe(AddCommandsToMenu);
        }

        public Shell(INavigationService navigationService) : this()
        {
            SetNavigationService(navigationService);
        }
        public ObservableCollection<HamburgerButtonInfo> DynamicButtons { get; private set; }
        public void SetNavigationService(INavigationService navigationService)
        {
            MyHamburgerMenu.NavigationService = navigationService;
        }

        private void AddCommandsToMenu(List<CommandWrapper> wrappers)
        {
            DynamicButtons.Clear();
            if (wrappers?.Any() == true)
            {
                foreach (CommandWrapper wrapper in wrappers)
                {
                    HamburgerButtonInfo info = new HamburgerButtonInfo();
                    info.PageType = wrapper.PageType;
                    info.Command = wrapper.Command;
                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Orientation = Orientation.Horizontal;
                    SymbolIcon icon = new SymbolIcon(wrapper.CommandSymbol);
                    icon.Width = 48;
                    icon.Height = 48;
                    TextBlock text = new TextBlock { Text = wrapper.CommandText };
                    text.VerticalAlignment = VerticalAlignment.Center;
                    text.Margin = new Thickness(12, 0, 0, 0);
                    stackPanel.Children.Add(icon);
                    stackPanel.Children.Add(text);
                    info.Content = stackPanel;
                    DynamicButtons.Add(info);
                }
            }
        }
    }
}

