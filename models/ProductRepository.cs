using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWork.models
{
    class ProductRepository : IProductRepository
    {
        string path;
        SQLite.Net.SQLiteConnection conn;

        public ProductRepository(string dbName)
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            conn.CreateTable<Products>();
        }

        public IEnumerable<Products> GetProducts()
        {
            return conn.Table<Products>().ToList();
        }

        public Products GetProductByID(int productId)
        {
            var products = conn.Table<Products>().ToList();
            return products.First(c => c.Id == productId);

        }

        public bool DeleteProduct(int productID)
        {
            Products p = this.GetProductByID(productID);

            if (conn.Delete(p) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool InsertProduct(Products product)
        {
            if (conn.Insert(product) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool UpdateProduct(Products product)
        {
            if (conn.Update(product) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Products searchProduct(int productId)
        {
            var products = conn.Table<Products>().ToList();
            return products.Find(item => item.Id == productId);
        }


    }
}
