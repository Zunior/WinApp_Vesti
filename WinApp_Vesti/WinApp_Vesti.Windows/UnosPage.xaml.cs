using System;
using System.Windows;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Storage.Pickers;
using Windows.Storage;
using System.Text;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WinApp_Vesti
{
    
    public sealed partial class UnosPage : Page
    {
        List<Vest> vesti = new List<Vest>();
        Vest uneta;

        public UnosPage()
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
            vesti = (List<Vest>)e.Parameter;
        }

        async private void button_Click(object sender, RoutedEventArgs e)
        {
            uneta = new Vest(tbNaslov.Text, tbPodnaslov.Text, tbTekst.Text, putanjaSlike.Text, tbTip.Text, (bool)rb1.IsChecked, "");
            vesti.Add(uneta);

            String[] zaUnos = new String[vesti.Count];
            StorageFolder folder = ApplicationData.Current.LocalFolder;

            if (folder != null)
            {

                StorageFile file = await folder.CreateFileAsync("vesti.txt", CreationCollisionOption.ReplaceExisting);
                Stream fileStream = await file.OpenStreamForWriteAsync();

                for (int i = 0; i < vesti.Count; i++)
                {
                    zaUnos[i] = vesti[i].naslov + "|" + vesti[i].podnaslov + "|" + vesti[i].tekst + "|" + vesti[i].putanja + "|" + vesti[i].tip + "|" + vesti[i].aktuelno.ToString() + System.Environment.NewLine;
                    byte[] fileContent = Encoding.UTF8.GetBytes(zaUnos[i].ToCharArray());
                    fileStream.Write(fileContent, 0, fileContent.Length);     
                }
                fileStream.Flush();
            }
        }

        async private void OdabirS_Click(object sender, RoutedEventArgs e)
        {
            var filepicker = new FileOpenPicker();
            filepicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            filepicker.ViewMode = PickerViewMode.Thumbnail;
            filepicker.FileTypeFilter.Add(".jpg");
            filepicker.FileTypeFilter.Add(".png");
            filepicker.FileTypeFilter.Add(".bmp");

            IAsyncOperation<StorageFile> asyncOp = filepicker.PickSingleFileAsync();
            StorageFile file = await asyncOp;

            if(file != null)
            {
                var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                var image = new BitmapImage();
                await image.SetSourceAsync(stream);
                var decoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(stream);
                imgPhoto.Source = image;
                putanjaSlike.Text = file.Path;
            }
        }
    }
}
