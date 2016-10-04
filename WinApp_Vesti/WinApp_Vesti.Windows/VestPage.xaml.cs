using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WinApp_Vesti
{
    
    public sealed partial class VestPage : Page
    {
        Vest vest = new Vest();
        List<Vest> sveVesti = new List<Vest>();
        //StackPanel myStackPanel;
        String[] sviK;
        //TextBlock txt1;
        //TextBlock txt2;
        //TextBlock txt3;
        //private string prvi;
        //private string drugi;
        //private string treci;
            

        public VestPage()
        {
            this.InitializeComponent();
            //myStackPanel = new StackPanel();
            //txt1 = new TextBlock();
            //txt2 = new TextBlock();
            //txt3 = new TextBlock();
            //txt1.Text = "";
            //txt2.Text = "";
            //txt3.Text = "";
            //myStackPanel.Children.Add(txt1);
            //myStackPanel.Children.Add(txt2);
            //myStackPanel.Children.Add(txt3);

            //TextboxText komen = new TextboxText(txt1.Text);
            
            //jedan.DataContext = komen.prvi;
            //dva.DataContext = komen.drugi;
            //tri.DataContext = komen.treci;
        }

        public class TextboxText : INotifyPropertyChanged
        {
            private string prvi;
            private string drugi;
            private string treci;

            public event PropertyChangedEventHandler PropertyChanged;

            public TextboxText(string a, string b, string c)
            {
                this.prvi = a;
                this.drugi = b;
                this.treci = c;
            }
            public string Prvi
            {
                get { return prvi; }
                set
                {
                    prvi = value;
                    OnPropertyChanged("Prvi");
                }
            }
            public string Drugi
            {
                get { return drugi; }
                set
                {
                    drugi = value;
                    OnPropertyChanged("Drugi");
                }
            }
            public string Treci
            {
                get { return treci; }
                set
                {
                    treci = value;
                    OnPropertyChanged("Treci");
                }
            }
            
            public void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler == null) return;
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.DataContext = e.Parameter;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.DataContext = e.Parameter;
            List<object> sve = (List<object>)e.Parameter;
            vest = (Vest)sve[1];
            sveVesti = (List<Vest>)sve[0];
            //vest = (Vest)e.Parameter;
            

            if (vest.komentari!=null && !vest.komentari.Equals(""))
            {
                //Skidamo krajnji '#' koji se unosi sa komentarom
                string temp = vest.komentari.Remove(vest.komentari.Length - 1);
                sviK = temp.Split('#');
                
                //txt1.Text = sviK[sviK.Length-1];
                //txt1.FontSize = 12;
                TextboxText komen = new TextboxText(sviK[sviK.Length - 1], null, null);
                jedan.DataContext = komen;
                if (sviK.Length > 1)
                {
                    //txt2.Text = sviK[sviK.Length - 2];
                    komen = new TextboxText(sviK[sviK.Length - 1], sviK[sviK.Length - 2], null);
                    dva.DataContext = komen;
                }
                if (sviK.Length > 2)
                {
                    //txt3.Text = sviK[sviK.Length - 3];
                    komen = new TextboxText(sviK[sviK.Length - 1], sviK[sviK.Length - 2], sviK[sviK.Length - 3]);
                    tri.DataContext = komen;
                }

            }
        }

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            var sb = Resources["FadeImageStoryboard"] as Storyboard;
            sb.Begin();
        }

        private void TextBlock_Loaded_1(object sender, RoutedEventArgs e)
        {
            var sb = Resources["FadeImageStoryboard1"] as Storyboard;
            sb.Begin();
        }

        private void Unesi_Click(object sender, RoutedEventArgs e)
        {
            TextboxText komen = new TextboxText(tbTekst.Text, jedan.Text, dva.Text);
            jedan.DataContext = komen;
            dva.DataContext = komen;
            tri.DataContext = komen;

            vest.dodajKomentar(tbTekst.Text);
        }
    }
}
