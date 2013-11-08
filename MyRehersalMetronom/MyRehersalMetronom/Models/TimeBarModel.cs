using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRehersalMetronom.Models
{
    public class TimeBarModel
    {
        private string name;
        private int tempo;
        private int ticksCount;
        private int tickTimeValue;
        private int repeats;

        public TimeBarModel(string name, int tempo,
            int ticksCount, int tickTimeValue, int repeats)
        {
            this.Name = name;
            this.Tempo = tempo;
            this.TicksCount = ticksCount;
            this.TickTimeValue = tickTimeValue;
            this.Repeats = repeats;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length > 0 && value.Length <= 20)
                {
                    this.name = value;
                }
            }
        }

        public int Tempo
        {
            get { return this.tempo; }
            set
            {
                if (value >= 20 && value <= 240)
                {
                    this.tempo = value;
                }
            }
        }

        public int TicksCount
        {
            get { return this.ticksCount; }
            set
            {
                if (value >= 1 && value <= 16)
                {
                    this.ticksCount = value;
                }
            }
        }

        public int TickTimeValue
        {
            get { return this.tickTimeValue; }
            set
            {
                if (value >= 1 && value <= 16)
                {
                    this.tickTimeValue = value;
                }
            }
        }

        public int Repeats
        {
            get { return this.repeats; }
            set
            {
                if (value >= 1 && value <= 999)
                {
                    this.repeats = value;
                }
            }
        }
    }
}
