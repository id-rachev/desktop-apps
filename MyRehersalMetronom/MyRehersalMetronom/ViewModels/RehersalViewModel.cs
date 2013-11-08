using MyRehersalMetronom.Behavior;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyRehersalMetronom.ViewModels
{
    public class RehersalViewModel : BaseViewModel
    {
        private string name;
        private ObservableCollection<TimeBarViewModel> timeBars;
        private TimeSpan overallTime;
        private ICommand renameRehersal;

        public RehersalViewModel()
        {
            this.OverallTime = this.CalculateOverallTime();
        }

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

        public IEnumerable<TimeBarViewModel> TimeBars
        {
            get
            {
                if (this.timeBars == null)
                {
                    this.timeBars = new ObservableCollection<TimeBarViewModel>();
                }
                return this.timeBars;
            }
            set
            {
                if (this.timeBars == null)
                {
                    this.timeBars = new ObservableCollection<TimeBarViewModel>();
                }
                this.SetObservableValues(this.timeBars, value);
            }
        }

        public TimeSpan OverallTime
        {
            get { return this.overallTime; }
            set
            {
                if (this.overallTime != value)
                {
                    this.overallTime = value;
                    this.OnPropertyChanged("OverallTime");
                }
            }
        }

        public ICommand RenameRehersal
        {
            get
            {
                if (this.renameRehersal == null)
                {
                    this.renameRehersal = new DelegateCommand<string>(this.HandleRenameRehersalCommand);
                }
                return this.renameRehersal;
            }
        }

        private void SetObservableValues<T>(
            ObservableCollection<T> observableCollection, IEnumerable<T> values)
        {
            if (observableCollection != values)
            {
                observableCollection.Clear();
                foreach (var item in values)
                {
                    observableCollection.Add(item);
                }
                this.OverallTimeChanged();
            }
        }

        private void OverallTimeChanged()
        {
            this.OverallTime = this.CalculateOverallTime();
        }

        private TimeSpan CalculateOverallTime()
        {
            TimeSpan overallMinutes = TimeSpan.Zero;
            foreach (var timeBar in TimeBars)
            {
                overallMinutes += timeBar.OverallSeconds;
            }
            return overallMinutes;
        }
        
        private void HandleRenameRehersalCommand(string parameter)
        {
            string newName = parameter.Trim();
            if (newName.Length > 0 && newName.Length <= 30 &&
                this.Name != newName)
            {
                this.Name = newName;
            }
        }
    }
}
