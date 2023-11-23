using System;
using System.Collections.Generic;
using System.Text;

namespace Stock_Inventory_Library.Business.Logic
{
   public class ShoppingCart
    {
        public int CartId { get; set; }

        public int UserID { get; set; }
        public int  ProductID { get; set; }


        public String FullName { get; set; }
        public String Name { get; set; }

        public int OrderQuantity { get; set; }

        public Decimal OrderPrice { get; set; }
        public Byte[] ImageProd { get; set; }

        public Decimal TotalCost { get; set; }


        public String Date { get; set; }

        public Double TotalAmount { get; set; }
      


        public ShoppingCart()
        {

        }

       public ShoppingCart( int ProductID, int UserId,  string Name, int OrderQuantity, byte[]ImageProd, decimal OrderPrice, decimal TotalCost)
        {
            
            this.ProductID = ProductID;
            this.UserID = UserId;
            this.Name = Name;
            this.OrderQuantity = OrderQuantity;
            this.ImageProd = ImageProd;
            this.OrderPrice = OrderPrice;
            this.TotalCost = TotalCost;
        }

        public ShoppingCart(int id, int ProductID, int UserId, string Name, int OrderQuantity, byte[] ImageProd, decimal OrderPrice, decimal TotalCost)
        {
            this.CartId = id;
            this.ProductID = ProductID;
            this.UserID = UserId;
            this.Name = Name;
            this.OrderQuantity = OrderQuantity;
            this.ImageProd = ImageProd;
            this.OrderPrice = OrderPrice;
            this.TotalCost = TotalCost;
        }

        public ShoppingCart(int id ,  int qty, decimal price)
        {
            this.CartId = id;
            //this.ProductID = prod;
            this.OrderQuantity = qty;
            this.OrderPrice = price;
        }

        public ShoppingCart(int id, int userid, int prodid, string username, string name, int qty, decimal price,byte[]img , decimal total, string date, double amount)
        {
            this.CartId = id;
            this.UserID = userid;
            this.ProductID = prodid;
          
            this.FullName = username;
            this.Name = name;
            this.OrderQuantity = qty;
            this.OrderPrice = price;
            this.ImageProd = img;
            this.TotalCost = total;
            this.Date = date;
            this.TotalAmount = amount;
        }

        public ShoppingCart(int prodid, int userid, string username, string name, int qty, decimal price, byte[] img, decimal total, string date, double amount)
        {

            this.UserID = userid;
            this.ProductID = prodid;
            
            this.FullName = username;
            this.Name = name;
            this.OrderQuantity = qty;
            this.OrderPrice = price;
            this.ImageProd = img;
            this.TotalCost = total;
            this.Date = date;
            this.TotalAmount = amount;
        }

      
    }
}
