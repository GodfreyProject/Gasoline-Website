using Stock_Inventory_Library.Business.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stock_Inventory_Library.Persistence.ReposInterface
{
   public interface IOrderRepository
    {

        // Get Users Orders

        public List<ShoppingCart> GetshoppingCarts();

        public List<ShoppingCart> GetCustomerShoppingCart(int UserID);

        // Place Order

        // Get Shopping Cart with ProductID
        public ShoppingCart ShoppingCart(int ProductID);
        // Get Customer Personsonal Data By UserId

        public ShoppingCart GETCustomerOrderByID(int ORDERID);
        public bool PlaceOrder(ShoppingCart shoppingCart);


        public int GetProductQuantity(int ProductID);


        public bool UpdateProductQuantity(int ProductID, int NewQty);


        public bool DecreaseProduct(int ID, int DecreaseQty);


        public User SearchCustomer(String SearchUserInfo);

        public Product SearchForProduct(String Search);

        /// Update Customer Order
        /// 

        public bool UpdateCustomersOrder(ShoppingCart shoppingCart);

        public bool IncreaseProduct(int ID, int IncreaseQty);


        public int GetProductRowCount();

        public ShoppingCart GetCartByName(String Name);


        public bool PurchaseCartItem(ShoppingCart cart);

        public bool RemoveOrderCartItem(int ID);
    }
}
