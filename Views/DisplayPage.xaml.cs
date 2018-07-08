using MyWork.models;
using MyWork.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyWork.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DisplayPage : Page
    {
        MainViewModel viewModel;

        public DisplayPage()
        {
            this.InitializeComponent();
            viewModel = new MainViewModel();
            if (!viewModel.IsDataLoaded) { viewModel.LoadData(); }

            DataContext = viewModel;
            this.Loaded += new RoutedEventHandler(DisplayPage_Loaded);
        }

        //back button
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        //add button
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MainListBox.SelectedItem = null;
        }

        private void DisplayPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!viewModel.IsDataLoaded)
            {
                viewModel.LoadData();
            }
        }

        //list box selection
        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var product = MainListBox.SelectedItem as Products;

            if (product != null)
            {
                Frame.Navigate(typeof(Views.DetailsPage), product.Id);
            }
            // Reset selected index to -1 (no selection)
            MainListBox.SelectedIndex = -1;
        }
    }
}
