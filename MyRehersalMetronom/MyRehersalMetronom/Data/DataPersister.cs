using MyRehersalMetronom.Models;
using MyRehersalMetronom.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MyRehersalMetronom.Data
{
    public class DataPersister
    {
        internal static async void UpdateRehersalsDataAsync()
        {
        }

        internal static async Task<IEnumerable<RehersalViewModel>> GetRehersalsDataAsync()
        {
            try
            {
                var rehersalsList = await LocalAppDataManager.GetLocalDataAsync();
                return rehersalsList;
            }
            catch (Exception e)
            {
                var basicRehersalInstance = GetBasicRehersal();
                var basicRehersalList = new ObservableCollection<RehersalViewModel>();
                basicRehersalList.Add(basicRehersalInstance);

                LocalAppDataManager.SaveLocalDataAsync(basicRehersalList);

                return basicRehersalList;
            }
        }

        internal static RehersalViewModel GetBasicRehersal()
        {
            BasicRehersal basicRehersalData = new BasicRehersal();
            var basicTimeBarData = basicRehersalData.TimeBars.FirstOrDefault();
            
            var basicRehersalInstance = new RehersalViewModel()
                {
                    Name = basicRehersalData.Name,
                    TimeBars = new ObservableCollection<TimeBarViewModel>()
                    {
                        GetBasicTimeBar("1")
                    }
                };

            return basicRehersalInstance;
        }

        private static TimeBarViewModel GetBasicTimeBar(string name)
        {
            BasicRehersal basicRehersalData = new BasicRehersal();
            TimeBarModel basicTimeBarData = basicRehersalData.TimeBars.FirstOrDefault();

            if (name == null)
            {
                name = basicTimeBarData.Name;
            }

            return new TimeBarViewModel()
            {
                Name = name,
                Tempo = basicTimeBarData.Tempo,
                TicksCount = basicTimeBarData.TicksCount,
                TickTimeValue = basicTimeBarData.TickTimeValue,
                Repeats = basicTimeBarData.Repeats
            };
        }
    }
}
