using Gasoline_Library.Business.Logic;
using Stock_Inventory_Library.Persistence.ReposInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stock_Inventory_Library.Business.ManagerClass
{
    public class ProductManager : IProductRepository
    {
        private IProductRepository productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public bool AddNewProduct(Product newProduct)
        {
            if (this.productRepository.AddNewProduct(newProduct))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteProduct(int ID)
        {
            if (this.productRepository.DeleteProduct(ID))
            {
                return true;
            }
            return false;
        }

        public List<Product> GetAllProducts()
        {
            return this.productRepository.GetAllProducts();
        }

        public Product GetProduct(int ID)
        {
            return this.productRepository.GetProduct(ID);
        }

        public Product GetProductByName(string ProductName)
        {
            return this.productRepository.GetProductByName(ProductName);
        }

        public List<Product> SearchProducts(string Search)
        {
            return this.productRepository.SearchProducts(Search);
        }

        public List<Product> GetProductsBYID(string Search)
        {
            return this.productRepository.GetProductsBYID(Search);
        }

        public bool IncreaseProduct(int ID, int IncreaseQty)
        {
            if(this.productRepository.IncreaseProduct(ID, IncreaseQty))
            {
                return true;
            }

            return false;
        }

        public Product SearchProduct(string Search)
        {
            return this.productRepository.SearchProduct(Search);
        }

        public bool UpdateProuct(Product product)
        {
            if (this.productRepository.UpdateProuct(product))
            {
                return true;
            }
            return false;
        }

        public List<Stock> GetListAllProducts()
        {
            return this.productRepository.GetListAllProducts();
        }
    }
}
