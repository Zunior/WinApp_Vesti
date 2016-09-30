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
        public static async Task<string> ReadTextFile(string filename)
        {
            string contents;

            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile textFile = await localFolder.GetFileAsync(filename);
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
            return contents;
        }
    }
}
