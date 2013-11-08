using MyRehersalMetronom.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyRehersalMetronom.Behavior;

namespace MyRehersalMetronom.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        private ObservableCollection<RehersalViewModel> rehersals;
        private ICommand addRehersalCommand;
        private RehersalViewModel basicRehersal;
        private ICommand renameRehersal;
        private ICommand deleteRehersalCommand;

        public AppViewModel()
        {
            this.HandleGetDataAsync();
        }

        public IEnumerable<RehersalViewModel> Rehersals
        {
            get
            {
                if (this.rehersals == null)
                {
                    this.rehersals = new ObservableCollection<RehersalViewModel>();
                }
                return this.rehersals;
            }
            set
            {
                if (this.rehersals == null)
                {
                    this.rehersals = new ObservableCollection<RehersalViewModel>();
                }
                this.SetObservableValues(this.rehersals, value);
            }
        }

        public ICommand AddRehersal
        {
            get
            {
                if (this.addRehersalCommand == null)
                {
                    this.addRehersalCommand = new DelegateCommand<RehersalViewModel>(this.HandleAddRehersalCommand);
                }
                return this.addRehersalCommand;
            }
        }

        public ICommand DeleteRehersal
        {
            get
            {
                if (this.deleteRehersalCommand == null)
                {
                    this.deleteRehersalCommand = new DelegateCommand<int>(this.HandleDeleteRehersalCommand);
                }
                return this.deleteRehersalCommand;
            }
        }

        private void SetObservableValues<T>(ObservableCollection<T> observableCollection, IEnumerable<T> values)
        {
            if (observableCollection != values)
            {
                observableCollection.Clear();
                foreach (var item in values)
                {
                    observableCollection.Add(item);
                }
            }
        }

        private async void HandleGetDataAsync()
        {
            this.Rehersals = await DataPersister.GetRehersalsDataAsync();
        }

        private void HandleAddRehersalCommand(RehersalViewModel parameter)
        {
            parameter = DataPersister.GetBasicRehersal();
            int nameCounter = 1;
            parameter.Name = this.GetUniqueName(parameter.Name, nameCounter);
            this.rehersals.Insert(0, parameter);
        }

        private string GetUniqueName(string paramName, int nameCounter)
        {
            foreach (var item in rehersals)
            {
                if (paramName == item.Name)
                {
                    paramName = paramName.Substring(0, 5) + " " + nameCounter;
                    nameCounter++;
                    paramName = this.GetUniqueName(paramName, nameCounter);
                }
            }

            return paramName;
        }

        private void HandleDeleteRehersalCommand(int parameter)
        {
            this.rehersals.RemoveAt(parameter);
        }
    }
}
