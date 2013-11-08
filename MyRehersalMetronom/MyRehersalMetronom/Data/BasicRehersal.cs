using MyRehersalMetronom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRehersalMetronom.Data
{
    public class BasicRehersal : RehersalModel
    {
        public string Name { get; set; }

        public IList<TimeBarModel> TimeBars { get; set; }

        public BasicRehersal()
        {
            this.Name = "Basic";
            this.TimeBars = new List<TimeBarModel>();
            TimeBars.Add(new TimeBarModel("1", 120, 4, (int)TickTimeValues.WholeNote, 8));
        }
    }
}
