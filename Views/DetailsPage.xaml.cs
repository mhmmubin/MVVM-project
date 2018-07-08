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
    public sealed partial class DetailsPage : Page
    {
        DetailsViewModel viewModel;
      
        public DetailsPage()
        {
            this.InitializeComponent();
        }

        //navigated FROM display page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            int id = (int)e.Parameter;

            if (viewModel == null)
            {
                viewModel = new DetailsViewModel(id);
                DataContext = viewModel.product;
            }
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DisplayPage));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EditPage), viewModel.product.Id);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            viewModel.DelProduct(viewModel.product.Id);
            Frame.Navigate(typeof(DisplayPage));
        }
    }
}
