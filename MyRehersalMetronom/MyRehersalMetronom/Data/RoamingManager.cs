using MyRehersalMetronom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MyRehersalMetronom.Data
{
    internal class RoamingManager
    {
        internal static void SaveRehersalDataToRoamingIfNotExists(RehersalModel rehersalData)
        {
            var roamingSettings = ApplicationData.Current.RoamingSettings;

            string containerName = rehersalData.Name.ToLower() + "-rehersal";
            if (!roamingSettings.Containers.ContainsKey(containerName))
            {
                roamingSettings.CreateContainer(containerName, Windows.Storage.ApplicationDataCreateDisposition.Always);

                var rehersalContainer = roamingSettings.Containers[containerName];
                rehersalContainer.Values["name"] = rehersalData.Name;

                rehersalContainer.CreateContainer("timeBars", Windows.Storage.ApplicationDataCreateDisposition.Always);
                var timeBarsContainer = rehersalContainer.Containers["timeBars"];

                int sameNameBarsCounter = 1;
                ApplicationDataContainer currentBarContainer;
                foreach (var timeBarData in rehersalData.TimeBars)
                {
                    containerName = timeBarData.Name.ToLower() + "-timeBar";
                    if (timeBarsContainer.Containers.ContainsKey(containerName))
                    {
                        sameNameBarsCounter += 1;
                        containerName += "-" + sameNameBarsCounter;
                    }

                    timeBarsContainer.CreateContainer(containerName, ApplicationDataCreateDisposition.Always);
                    currentBarContainer = timeBarsContainer.Containers[containerName];

                    currentBarContainer.Values["name"] = timeBarData.Name;
                    currentBarContainer.Values["tempo"] = timeBarData.Tempo;
                    currentBarContainer.Values["ticksCount"] = timeBarData.TicksCount;
                    currentBarContainer.Values["tickTimeValue"] = timeBarData.TickTimeValue;
                    currentBarContainer.Values["repeats"] = timeBarData.Repeats;
                }
            }
        }
    }
}
