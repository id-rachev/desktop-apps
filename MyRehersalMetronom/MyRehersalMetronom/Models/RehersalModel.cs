using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRehersalMetronom.Models
{
    public class RehersalModel
    {
        public string Name { get; set; }

        public IList<TimeBarModel> TimeBars { get; set; }
    }
}
