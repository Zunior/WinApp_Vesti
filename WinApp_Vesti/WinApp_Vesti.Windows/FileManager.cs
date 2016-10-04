using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace WinApp_Vesti
{
    class FileManager
    {
        static List<Vest> vestiGL = new List<Vest>();
                
        public static async Task<FileManager> Create()
        {
            var fileManager = new FileManager();
            await fileManager.Initialize();
            return fileManager;
        }

        private FileManager()
        {

        }

        private async Task Initialize()
        {
            Task<List<Vest>> vestTask = ReadTextFile();
            vestiGL = await vestTask;
        }

        public List<Vest> vratiVesti()
        {
            return vestiGL;
        }
        
        public static async Task<List<Vest>> ReadTextFile()
        {
            string contents;
            List<Vest> vesti = new List<Vest>();

            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile textFile = await localFolder.GetFileAsync("vesti.txt");
            // Pravi folder C:\Users\Sasa.Popovic\AppData\Local\Packages\799b77d2-6b3c-4e93-a40c-eb6ca27db8b3_gzz65b1z4sg4w\LocalState

            using (IRandomAccessStream textStream = await textFile.OpenReadAsync())
            {
                using (DataReader textReader = new DataReader(textStream))
                {
                    uint textLength = (uint)textStream.Size;
                    await textReader.LoadAsync(textLength);
                    contents = textReader.ReadString(textLength);
                }
            }
            //Obrada pročitanog teksta
            String[] procitano = contents.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            //skida poslednji prazan red
            for (int i = 0; i < procitano.Length - 1; i++)
            {
                String[] Podatak = procitano[i].Split('|');
                vesti.Add(new Vest(Podatak[0], Podatak[1], Podatak[2], Podatak[3], Podatak[4], bool.Parse(Podatak[5]), Podatak[6]));
            }
            return vesti;
        }
    }
}
