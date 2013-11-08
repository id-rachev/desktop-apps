using MyRehersalMetronom.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.Storage;

namespace MyRehersalMetronom.Data
{
    internal class LocalAppDataManager
    {
        private const string LocalDataFolderName = "rehersals data";

        internal static async Task<ObservableCollection<RehersalViewModel>> GetLocalDataAsync()
        {
            try
            {
                StorageFolder localDataFolder = await ApplicationData.Current.LocalFolder.GetFolderAsync(LocalDataFolderName);
                var rehersalsDataCollection = new ObservableCollection<RehersalViewModel>();

                var rehersalFiles = await localDataFolder.GetFilesAsync().AsTask().ConfigureAwait(false);
                foreach (var xmlFile in rehersalFiles)
                {
                    RehersalViewModel rehersalData = await XmlParser.GetDataByXmlDocAsync(xmlFile);
                    rehersalsDataCollection.Add(rehersalData);
                }
                return rehersalsDataCollection;
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("Local data folder is empty.", LocalDataFolderName);
            }
        }

        internal static async void SaveLocalDataAsync(IEnumerable<RehersalViewModel> rehersalsData)
        {
            StorageFolder localDataFolder = await ApplicationData.Current.LocalFolder
                .CreateFolderAsync(LocalDataFolderName, CreationCollisionOption.OpenIfExists);

            foreach (var rehersal in rehersalsData)
            {
                StorageFile rehersalFile = await localDataFolder.CreateFileAsync(
                    rehersal.Name + ".mrm", CreationCollisionOption.ReplaceExisting);

                XmlDocument rehersalDoc = XmlParser.CreateXmlDocByData(rehersal);

                await rehersalDoc.SaveToFileAsync(rehersalFile);
            }
        }
    }
}
