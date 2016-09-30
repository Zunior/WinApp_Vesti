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

namespace Proj_2_XAML_proba
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ZabavaPage : Page
    {
        public ZabavaPage()
        {
            this.InitializeComponent();
            //List<Vest> vesti = new List<Vest>();
            //vesti = Vest.IzlistajVesti();

            //for (int i = 0; i < vesti.Count; i++)
            //    listView.Items.Add(vesti[i]);

            galerija.ItemsSource = vesti;
        }
    }
}
