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
using System.Reflection;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Proj_2_XAML_proba
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UnosPage : Page
    {
        StorageFile file;
        BitmapImage image = new BitmapImage();
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
            uneta = new Vest(tbNaslov.Text, tbPodnaslov.Text, tbTekst.Text, file.Path.ToString(), tbTip.Text, (bool)rb1.IsChecked, "");
            vesti.Add(uneta);
            String[] zaUnos = new String[vesti.Count];
            //StreamWriter fajl = new StreamWriter(@"Text\vesti.txt");
            //StringWriter fajl = new StringWriter(new StringBuilder(@"Text\vesti.txt"));
            //StringWriter fajl = new StringWriter();

            //for (int i = 0; i < vesti.Count; i++)
            //{
            //    zaUnos[i] = vesti[i].naslov + "|" + vesti[i].podnaslov + "|" + vesti[i].tekst + "|" + vesti[i].putanja + "|" + vesti[i].tip + "|" + vesti[i].aktuelno.ToString();
            //    fajl.WriteLine(@"Text\vesti.txt", zaUnos[i]);
            //}
            //fajl.Flush();

            var folder = ApplicationData.Current.LocalFolder;
            var fajl = await folder.CreateFileAsync("vesti.txt", CreationCollisionOption.ReplaceExisting);
            for (int i = 0; i < vesti.Count; i++)
            {
                zaUnos[i] = vesti[i].naslov + "|" + vesti[i].podnaslov + "|" + vesti[i].tekst + "|" + vesti[i].putanja + "|" + vesti[i].tip + "|" + vesti[i].aktuelno.ToString() + "" + Environment.NewLine;
                byte[] data = Encoding.Unicode.GetBytes(zaUnos[i]);
 
                using (var s = await fajl.OpenStreamForWriteAsync())
                {
                    await s.WriteAsync(data, 0, data.Length);
                }

            }

            
            // Set a variable to the My Documents path.

            //var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            //folder = await folder.GetFolderAsync("Text");
            //string putanja = "vesti.txt";
            //var fajl = await folder.OpenStreamForWriteAsync(putanja, CreationCollisionOption );


            //string mydocpath =
            //    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //// Write the string array to a new file named "WriteLines.txt".
            //using (StreamWriter outputFile = new StreamWriter( mydocpath + @"\WriteLines.txt"))
            //{
            //    foreach (string line in lines)
            //        outputFile.WriteLine(line);


            //StorageFolder folder = ApplicationData.Current.LocalFolder;

            //if (folder != null)
            //{

            //    StorageFile file = await folder.CreateFileAsync("vesti.txt", CreationCollisionOption.ReplaceExisting);

            //    byte[] fileContent = Encoding.UTF8.GetBytes(txtFileContent.Text.ToCharArray());

            //    Stream fileStream = await file.OpenStreamForWriteAsync();
            //    fileStream.Write(fileContent, 0, fileContent.Length);
            //    fileStream.Flush();
            //    fileStream.Close();

            //    MessageBox.Show("File Has Been Created");
            //    txtFileContent.Text = "";
            //    txtFileName.Text = "";
            //}
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
            file = await asyncOp;

            if(file != null)
            {
                var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                //var image = new BitmapImage();
                await image.SetSourceAsync(stream);
                var decoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(stream);
                imgPhoto.Source = image;
            }
        }
    }
}
