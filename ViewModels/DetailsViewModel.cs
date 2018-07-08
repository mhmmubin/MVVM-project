using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWork.models;
using System.ComponentModel;
using Windows.UI.Popups;

namespace MyWork.ViewModels
{
    class DetailsViewModel : INotifyPropertyChanged
    {
        private IProductRepository Db { get; }
        private Products PRODUCT;

        public Products product
        {
            get { return PRODUCT; }

            set
            {
                if (PRODUCT != value)
                {
                    PRODUCT = value;
                    RaisePropertyChanged("Product");

                }
            }

        }

        public DetailsViewModel(int ProductId)
        {
            Db = App.Data;
            this.product = Db.GetProductByID(ProductId);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string propname)
        {
            var eh = PropertyChanged;
            if (eh != null)
                eh(this, new PropertyChangedEventArgs(propname));
        }

        public bool SaveEditedProduct(Products p)
        {
            return Db.UpdateProduct(p);
        }

      

        internal async void DelProduct(int pID)
        {

            if (Db.DeleteProduct(pID))
            {

                MessageDialog md = new MessageDialog("Product deleted from database", "DELETE OUTCOME");
                await md.ShowAsync();

            }
            else
            {
                MessageDialog md = new MessageDialog("Product NOT deleted from database", "DELETE OUTCOME");
                await md.ShowAsync();
            }

        }
    }
}
