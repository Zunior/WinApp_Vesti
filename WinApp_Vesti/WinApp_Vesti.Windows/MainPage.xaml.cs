using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WinApp_Vesti
{
    
    public sealed partial class MainPage : Page
    {
        List<Vest> vestiGl = new List<Vest>();
        List<Vest> vestiPriv = new List<Vest>();

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Task<List<Vest>> vestTask = LoadTextFromFile();
            vestiGl = await vestTask;

        }
        
        private async Task<List<Vest>> LoadTextFromFile()
        {
            List<Vest> vesti = new List<Vest>();
            Task<string> stringTask = FileManager.ReadTextFile("vesti.txt");
            string vestiText = await stringTask;
            String[] procitano = vestiText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            //skida poslednji prazan red
            for (int i = 0; i < procitano.Length - 1; i++)
            {
                String[] Podatak = procitano[i].Split('|');
                vesti.Add(new Vest(Podatak[0], Podatak[1], Podatak[2], Podatak[3], Podatak[4], bool.Parse(Podatak[5]), Podatak[6]));
            }
            return vesti;
        }

        
        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //frame.Navigate(typeof(ZabavaPage));
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

        private void tb5_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            var sb = Resources["AnimacijaTeksta5"] as Storyboard;
            sb.Begin();
        }

        private void tb5_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            var sb = Resources["AnimacijaTekstaNazad5"] as Storyboard;
            sb.Begin();
        }

        async private void tb1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Task<List<Vest>> vestTask = LoadTextFromFile();
            vestiGl = await vestTask;
            vestiPriv = new List<Vest>(vestiGl);

            for (int i = vestiPriv.Count - 1; i >= 0; i--)
            {
                if (vestiPriv[i].aktuelno != true)
                    vestiPriv.Remove(vestiPriv[i]);
            }
            pBar.Visibility = Visibility.Visible;
            await Task.Delay(TimeSpan.FromSeconds(2));
            pBar.Visibility = Visibility.Collapsed;
            frame.Navigate(typeof(ZabavaPage), vestiPriv);
        }

        async private void tb2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Task<List<Vest>> vestTask = LoadTextFromFile();
            vestiGl = await vestTask;
            vestiPriv = new List<Vest>(vestiGl);

            for (int i = vestiPriv.Count - 1; i >= 0; i--)
            {
                if (vestiPriv[i].tip != "Svet")
                    vestiPriv.Remove(vestiPriv[i]);
            }
            pBar.Visibility = Visibility.Visible;
            await Task.Delay(TimeSpan.FromSeconds(2));
            pBar.Visibility = Visibility.Collapsed;
            frame.Navigate(typeof(ZabavaPage), vestiPriv);
        }

        async private void tb3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Task<List<Vest>> vestTask = LoadTextFromFile();
            vestiGl = await vestTask;
            vestiPriv = new List<Vest>(vestiGl);

            for (int i = vestiPriv.Count - 1; i >= 0; i--)
            {
                if (vestiPriv[i].tip != "Zabava")
                    vestiPriv.Remove(vestiPriv[i]);
            }
            pBar.Visibility = Visibility.Visible;
            await Task.Delay(TimeSpan.FromSeconds(2));
            pBar.Visibility = Visibility.Collapsed;
            frame.Navigate(typeof(ZabavaPage), vestiPriv);
        }

        async private void tb5_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Task<List<Vest>> vestTask = LoadTextFromFile();
            vestiGl = await vestTask;
            frame.Navigate(typeof(UnosPage), vestiGl);
        }
    }
}
