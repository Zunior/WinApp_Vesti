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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Proj_2_XAML_proba
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Vest> vesti = new List<Vest>();
        String[] podaci;

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //LoadTextFromFile();
        }

        private async void LoadTextFromFile()
        {
            try
            {
                var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                folder = await folder.GetFolderAsync("Text");
                string putanja = "vesti.txt";
                var fajl = await folder.OpenStreamForReadAsync(putanja);
                string tekst = "";
                using (StreamReader streamReader = new StreamReader(fajl))
                {
                    while ((tekst = streamReader.ReadLine()) != null)
                    {
                        podaci = tekst.Split('|');
                        vesti.Add(new Vest(podaci[0], podaci[1], podaci[2], podaci[3], podaci[4], bool.Parse(podaci[5])));
                    }
                }
            }
            catch (Exception e)
            {
            }
        }

        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frame.Navigate(typeof(ZabavaPage));
        }

        private void tb1_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            var sb = Resources["AnimacijaTeksta1"] as Storyboard;
            sb.Begin();
        }

        private void tb1_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            var sb = Resources["AnimacijaTekstaNazad1"] as Storyboard;
            sb.Begin();
        }

        private void tb2_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            var sb = Resources["AnimacijaTeksta2"] as Storyboard;
            sb.Begin();
        }

        private void tb2_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            var sb = Resources["AnimacijaTekstaNazad2"] as Storyboard;
            sb.Begin();
        }

        private void tb3_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            var sb = Resources["AnimacijaTeksta3"] as Storyboard;
            sb.Begin();
        }

        private void tb3_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            var sb = Resources["AnimacijaTekstaNazad3"] as Storyboard;
            sb.Begin();
        }
    }
}
