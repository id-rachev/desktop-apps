using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRehersalMetronom.ViewModels
{
    public class TimeBarViewModel : BaseViewModel
    {
        private string name;
        private int tempo;
        private int tickTimeValue;
        private int ticksCount;
        private int repeats;
        private TimeSpan overallSeconds;

        public int RepeatsCounter { get; set; }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }

        public int Tempo
        {
            get { return this.tempo; }
            set
            {
                if (this.tempo != value)
                {
                    this.tempo = value;
                    this.OnPropertyChanged("Tempo");
                    this.OverallSecondsChanged();
                }
            }
        }

        public int TickTimeValue
        {
            get { return this.tickTimeValue; }
            set
            {
                if (this.tickTimeValue != value)
                {
                    this.tickTimeValue = value;
                    this.OnPropertyChanged("TickTimeValue");
                    this.OverallSecondsChanged();
                }
            }
        }

        public int TicksCount
        {
            get { return this.ticksCount; }
            set
            {
                if (this.ticksCount != value)
                {
                    this.ticksCount = value;
                    this.OnPropertyChanged("TicksCount");
                    this.OverallSecondsChanged();
                }
            }
        }

        public int Repeats
        {
            get { return this.repeats; }
            set
            {
                if (this.repeats != value)
                {
                    this.repeats = value;
                    this.OnPropertyChanged("Repeats");
                    this.OverallSecondsChanged();
                }
            }
        }

        public TimeSpan OverallSeconds
        {
            get
            {
                if (this.overallSeconds == null)
                {
                    this.overallSeconds = this.CalculateOverallSeconds();
                }
                return this.overallSeconds;
            }
            set
            {
                if (this.overallSeconds != value)
                {
                    this.overallSeconds = value;
                    this.OnPropertyChanged("OverallSeconds");
                }
            }
        }

        private void OverallSecondsChanged()
        {
            this.OverallSeconds = this.CalculateOverallSeconds();
        }

        private TimeSpan CalculateOverallSeconds()
        {
            if (this.tempo != 0 && this.ticksCount != 0 &&
                this.tickTimeValue != 0 && this.repeats != 0)
            {
                double millisecondsPerTick = (240000 / this.TickTimeValue) / this.Tempo;
                double overallMilliseconds = millisecondsPerTick * this.TicksCount * this.Repeats;
                TimeSpan overallTime = new TimeSpan(0, 0, 0, 0, (int)overallMilliseconds);

                return overallTime;
            }
            else
            {
                return TimeSpan.Zero;
            }
        }
    }
}
