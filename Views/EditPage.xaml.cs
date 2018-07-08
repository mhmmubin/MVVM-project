using MyWork.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class EditPage : Page
    {
        DetailsViewModel viewModel;

        public EditPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            int id = (int)e.Parameter;

            if (viewModel == null)
            {
                viewModel = new DetailsViewModel(id);
                DataContext = viewModel.product;
            }
            
        }

        //Save button click; navigate TO Details Page
        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            viewModel.product.Name = nameTextBox.Text;
            viewModel.product.Price = double.Parse(priceTextBox.Text);
            viewModel.product.Quantity = int.Parse(qtyTextBox.Text);
            viewModel.product.Description = desTextBox.Text;
            if (viewModel.SaveEditedProduct(viewModel.product))
            {
                MessageDialog md = new MessageDialog("Prdouct changes updated", "UPDATE OUTCOME");
                await md.ShowAsync();
            }
            else
            {
                MessageDialog md = new MessageDialog("Product changes NOT updated", "UPDATE OUTCOME");
                await md.ShowAsync();
            }

            Frame.Navigate(typeof(DetailsPage), viewModel.product.Id);
        }

        //Cancel click; navigate TO Details Page
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DetailsPage), viewModel.product.Id);
        }
    }
}
