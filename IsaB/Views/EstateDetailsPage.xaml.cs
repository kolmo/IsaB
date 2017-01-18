using IsaB.Entities;
using Windows.UI.Xaml.Controls;

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
    }
}
