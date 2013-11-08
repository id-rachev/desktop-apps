using MyRehersalMetronom.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace MyRehersalMetronom.Pages
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class HomePage : MyRehersalMetronom.Common.LayoutAwarePage
    {
        public HomePage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            this.DefaultViewModel["AppViewModel"] = new AppViewModel();
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void pageRoot_LoadedUiAccess(object sender, RoutedEventArgs e)
        {

        }

        private void GridView_ItemClickToRehersalPage(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(RehersalPage), e.ClickedItem);
        }

        private void GridView_RehersalSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (rehersalsGridView.SelectedItem != null)
            {
                bottomAppBar.IsOpen = true;
            }
            else
            {
                bottomAppBar.IsOpen = false;
            }
        }

        private void bottomAppBar_Opened(object sender, object e)
        {
            if (rehersalsGridView.SelectedItem == null)
            {
                rehersalsGridView.SelectedIndex = 0;
            }
        }

        private void bottomAppBar_Closed(object sender, object e)
        {
            rehersalsGridView.SelectedItem = null;
        }

        private void openRenameBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!renamePopup.IsOpen)
            {
                openRenameBtn.Visibility = Visibility.Collapsed;
                renamePopup.DataContext = rehersalsGridView.SelectedItem as RehersalViewModel;
                renamePopup.IsOpen = true;
                renameText.Text = (rehersalsGridView.SelectedItem as RehersalViewModel).Name;
            }
        }

        private void renamePopup_Closed(object sender, object e)
        {
            openRenameBtn.Visibility = Visibility.Visible;
            renameErrorMsg.Text = "";
        }

        private void saveRenameBtn_Click_ErrorHandling(object sender, RoutedEventArgs e)
        {
            renameErrorMsg.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            renameErrorMsg.Text = String.Empty;
            string renameInput = renameText.Text.Trim();

            if (renameInput.Length == 0)
            {
                renameErrorMsg.Text = "Rehersal Name is required!";
            }
            else if (renameInput.Length >= 30)
            {
                renameErrorMsg.Text = "Rehersal Name reached max length of 30 characters!";
            }

            foreach (var item in rehersalsGridView.Items)
            {
                var rehersal = item as RehersalViewModel;
                if (renameInput == rehersal.Name &&
                    renameInput != (rehersalsGridView.SelectedItem as RehersalViewModel).Name)
                {
                    renameText.Text = renameInput + "-copy";
                    renameErrorMsg.Text = "Unique Name is required!";
                    break;
                }
            }

            if (renameErrorMsg.Text == String.Empty &&
                renameInput != (rehersalsGridView.SelectedItem as RehersalViewModel).Name)
            {
                renameErrorMsg.Foreground = new SolidColorBrush(Windows.UI.Colors.GreenYellow);
                renameErrorMsg.Text = "Rename Successful!";
            }
        }

        private async void confirmDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            invokeDeleteBtn.CommandParameter = rehersalsGridView.SelectedIndex;
            MessageDialog dialog = new MessageDialog("Do you really want to delete rehersal \"" +
                (rehersalsGridView.SelectedItem as RehersalViewModel).Name + "\"?", "Delete confirmation");
            dialog.Commands.Add(new UICommand("Delete", new UICommandInvokedHandler(DeleteCommandHandler)));
            dialog.Commands.Add(new UICommand("Cancel", new UICommandInvokedHandler(DeleteCommandHandler)));

            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 1;
            await dialog.ShowAsync();
        }

        private void DeleteCommandHandler(IUICommand command)
        {
            switch (command.Label)
            {
                case "Delete":
                    ButtonAutomationPeer peer = new ButtonAutomationPeer(invokeDeleteBtn as Button);
                    var provider = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
                    provider.Invoke();
                    break;
                case "Cancel":
                    break;
            }
        }
    }
}
