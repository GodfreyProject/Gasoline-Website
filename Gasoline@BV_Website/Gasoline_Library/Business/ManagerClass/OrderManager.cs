using Stock_Inventory_Library.Business.Logic;
using Stock_Inventory_Library.Persistence.ReposInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stock_Inventory_Library.Business.ManagerClass
{
    public class OrderManager : IOrderRepository
    {

        private IOrderRepository orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public bool DecreaseProduct(int ID, int DecreaseQty)
        {
            if(this.orderRepository.DecreaseProduct(ID, DecreaseQty))
            {
                return true;
            }

            return false;
        }

        public List<ShoppingCart> GetCustomerShoppingCart(int OrderID)
        {
            return this.orderRepository.GetCustomerShoppingCart(OrderID);
        }

        public int GetProductQuantity(int ProductID)
        {
            return this.GetProductQuantity(ProductID);
        }

        public List<ShoppingCart> GetshoppingCarts()
        {
            return this.orderRepository.GetshoppingCarts();
        }

        public bool PlaceOrder(ShoppingCart shoppingCart)
        {
            if (this.orderRepository.PlaceOrder(shoppingCart))
            {
                return true;
            }

            return false;
        }

        public User SearchCustomer(string SearchUserInfo)
        {
            return this.orderRepository.SearchCustomer(SearchUserInfo);
        }

        public Product SearchForProduct(string Search)
        {
            return this.orderRepository.SearchForProduct(Search);
        }

        public bool UpdateCustomersOrder(ShoppingCart shoppingCart)
        {
            if (this.orderRepository.UpdateCustomersOrder(shoppingCart))
            {
                return true;
            }

            return false;
        }

        public bool UpdateProductQuantity(int ProductID, int NewQty)
        {
            if(this.orderRepository.UpdateProductQuantity(ProductID, NewQty))
            {
                return true;
            }

            return false;
        }

        public bool IncreaseProduct(int ID, int IncreaseQty)
        {
            return this.orderRepository.IncreaseProduct(ID, IncreaseQty);
        }

        public ShoppingCart GETCustomerOrderByID(int ORDERID)
        {
            ShoppingCart cart = new ShoppingCart();

            if(cart != null)
            {
                return this.orderRepository.GETCustomerOrderByID(ORDERID);
            }
            else
            {
                return null;
            }
        }

        public int GetProductRowCount()
        {
            return orderRepository.GetProductRowCount();
        }

        public ShoppingCart GetCartByName(string Name)
        {
            return this.orderRepository.GetCartByName(Name);
        }

        public bool PurchaseCartItem(ShoppingCart cart)
        {
            return this.orderRepository.PurchaseCartItem(cart);
        }

        public bool RemoveOrderCartItem(int ID)
        {
            if (this.orderRepository.RemoveOrderCartItem(ID))
            {
                return true;
            }
            return false;
        }

        public ShoppingCart ShoppingCart(int ProductID)
        {
            return this.orderRepository.ShoppingCart(ProductID);
        }
    }
}
