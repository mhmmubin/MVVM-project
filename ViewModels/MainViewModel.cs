using MyWork.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace MyWork.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private IProductRepository Db { get; }
        private ObservableCollection<Products> PRODUCT;

        public ObservableCollection<Products> products
        {
            get { return PRODUCT; }

            set
            {
                if (value != PRODUCT)
                {
                    PRODUCT = value;
                    NotifyPropertyChanged("Products");
                }
            }
        }

        public MainViewModel()
        {
            Db = App.Data;

        }


        public bool IsDataLoaded
        {
            get;
            private set;
        }


        public void LoadData()
        {
            products = new ObservableCollection<Products>(Db.GetProducts().ToList());
            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        internal async void AddNewProduct(Products newProduct)
        {

            if (Db.InsertProduct(newProduct))
            {

                MessageDialog md = new MessageDialog("Product added to databse", "INSERT UPDATE");
                await md.ShowAsync();

            }
            else
            {
                MessageDialog md = new MessageDialog("Product NOT added to databse", "INSERT UPDATE");
                await md.ShowAsync();
            }

        }


        internal Products FindProduct(int pID)
        {

            return Db.searchProduct(pID);
        }






    }
}
