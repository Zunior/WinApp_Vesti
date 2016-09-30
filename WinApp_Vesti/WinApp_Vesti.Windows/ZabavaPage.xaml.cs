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

namespace WinApp_Vesti
{
    
    public sealed partial class ZabavaPage : Page
    {
        List<Vest> prikazVesti = new List<Vest>();
                
        public ZabavaPage()
        {
            this.InitializeComponent();
        }
        
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.DataContext = e.Parameter;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.DataContext = e.Parameter;
            prikazVesti = (List<Vest>)e.Parameter;
            galerija.ItemsSource = prikazVesti;
        }

        private void Item_click(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem;
            this.Frame.Navigate(typeof(VestPage), item);
        }


    }
}
