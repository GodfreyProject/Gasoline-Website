using Gasoline_Library.Business.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stock_Inventory_Library.Persistence.ReposInterface
{
   public interface IProductRepository
    {

        // Get All Products

        public List<Product> GetAllProducts();

        public List<Product> GetProductsBYID(String Search);

        public Product GetProduct(int ID);


        public Product GetProductByName(String ProductName);


        // Add Product

        public bool AddNewProduct(Product newProduct);


        // Update

        public bool UpdateProuct(Product product);


        public bool IncreaseProduct(int ID, int IncreaseQty);
        // Delete

        public bool DeleteProduct(int ID);


        public Product SearchProduct(String Search);

        public List<Product> SearchProducts(String Search);


        public List<Stock> GetListAllProducts();
    }
}
