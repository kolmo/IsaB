using IsaB.Models;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace IsaB.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StandardOverviewPage : Page
    {

        public StandardOverviewPage()
        {
            this.InitializeComponent();
        }

        private void lvPartLevels_ItemClick(object sender, ItemClickEventArgs e)
        {
            BuildingPartModel part = e.ClickedItem as BuildingPartModel;
            if (part != null)
            {
                Template10.Common.BootStrapper.Current.NavigationService.Navigate(typeof(Views.StandardLevelPropSelectionPage), part);
            }
        }
    }
}
