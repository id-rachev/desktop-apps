using MyRehersalMetronom.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.Storage;

namespace MyRehersalMetronom.Data
{
    internal class XmlParser
    {
        private const string RootNodeName = "rehersal";
        private const string RehersalNameNodeName = "name";
        private const string TBarsNodeName = "time-bars";
        private const string TBarNodeName = "time-bar";
        private const string TBNameNodeName = "bar-name";
        private const string TBTempoNodeName = "tempo";
        private const string TBTicksCountNodeName = "ticks-count";
        private const string TBTickTimeValueNodeName = "tick-time-value";
        private const string TBRepeatsNodeName = "repeats";

        internal static XmlDocument CreateXmlDocByData(RehersalViewModel rehersalData)
        {
            XmlDocument rehersalDoc = new XmlDocument();
            XmlElement rootNode = rehersalDoc.CreateElement(RootNodeName);
            rehersalDoc.AppendChild(rootNode);

            XmlElement rehersalNameNode = rehersalDoc.CreateElement(RehersalNameNodeName);
            rehersalNameNode.InnerText = rehersalData.Name;
            rootNode.AppendChild(rehersalNameNode);

            XmlElement timeBarsNode = rehersalDoc.CreateElement(TBarsNodeName);
            rootNode.AppendChild(timeBarsNode);

            foreach (var timeBarData in rehersalData.TimeBars)
            {
                XmlElement timeBarNode = rehersalDoc.CreateElement(TBarNodeName);
                timeBarsNode.AppendChild(timeBarNode);

                XmlElement tbNameNode = rehersalDoc.CreateElement(TBNameNodeName);
                tbNameNode.InnerText = timeBarData.Name;
                timeBarNode.AppendChild(tbNameNode);

                XmlElement tbTempoNode = rehersalDoc.CreateElement(TBTempoNodeName);
                tbTempoNode.InnerText = timeBarData.Tempo.ToString();
                timeBarNode.AppendChild(tbTempoNode);

                XmlElement tbTicksCountNode = rehersalDoc.CreateElement(TBTicksCountNodeName);
                tbTicksCountNode.InnerText = timeBarData.TicksCount.ToString();
                timeBarNode.AppendChild(tbTicksCountNode);

                XmlElement tbTickTimeValueNode = rehersalDoc.CreateElement(TBTickTimeValueNodeName);
                tbTickTimeValueNode.InnerText = timeBarData.TickTimeValue.ToString();
                timeBarNode.AppendChild(tbTickTimeValueNode);

                XmlElement tbRepeatsNode = rehersalDoc.CreateElement(TBRepeatsNodeName);
                tbRepeatsNode.InnerText = timeBarData.Repeats.ToString();
                timeBarNode.AppendChild(tbRepeatsNode);
            }

            return rehersalDoc;
        }

        internal static async Task<RehersalViewModel> GetDataByXmlDocAsync(StorageFile xmlFile)
        {
            XmlDocument rehersalDoc = await XmlDocument.LoadFromFileAsync(xmlFile);
            XmlElement rootNode = rehersalDoc.DocumentElement;

            var timeBarsData = new ObservableCollection<TimeBarViewModel>();

            var timeBarNodes = rootNode.ChildNodes.FirstOrDefault(x => x.NodeName == TBarsNodeName).ChildNodes;
            foreach (var tbNode in timeBarNodes)
            {
                var timeBar = new TimeBarViewModel()
                    {
                        Name = tbNode.ChildNodes.FirstOrDefault(x => x.NodeName == TBNameNodeName).InnerText,
                        Tempo = int.Parse(tbNode.ChildNodes.FirstOrDefault(x => x.NodeName == TBTempoNodeName).InnerText),
                        TicksCount = int.Parse(tbNode.ChildNodes.FirstOrDefault(x => x.NodeName == TBTicksCountNodeName).InnerText),
                        TickTimeValue = int.Parse(tbNode.ChildNodes.FirstOrDefault(x => x.NodeName == TBTickTimeValueNodeName).InnerText),
                        Repeats = int.Parse(tbNode.ChildNodes.FirstOrDefault(x => x.NodeName == TBRepeatsNodeName).InnerText)
                    };

                timeBarsData.Add(timeBar);
            }

            return new RehersalViewModel()
                {
                    Name = rootNode.ChildNodes.FirstOrDefault(x => x.NodeName == RehersalNameNodeName).InnerText,
                    TimeBars = timeBarsData
                };
        }
    }
}