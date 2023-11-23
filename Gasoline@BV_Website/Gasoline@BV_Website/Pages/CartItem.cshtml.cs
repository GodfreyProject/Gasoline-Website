using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stock_Inventory_Library;
using Stock_Inventory_Library.Business.Logic;
using Stock_Inventory_Library.Business.ManagerClass;
using Stock_Inventory_Library.Persistence;

namespace Test_ShoppingCart.Pages
{
    [Authorize]

    public class CartItemModel : PageModel
    {
        public ProductManager manager = new ProductManager(new ProductRepository());
        public OrderManager orderManager = new OrderManager(new OrderRepository());

        public UserManager personManager = new UserManager(new UserRepository());


        [BindProperty]

        public String ProductName { get; set; }

        [BindProperty]

        public int Quantity { get; set; }

        [BindProperty]

        public Decimal Price { get; set; }


        [BindProperty]

        public User customer { get; set; }


        [BindProperty]

        public String ProductType { get; set; }

        [BindProperty]

        public Byte[] ImagePath { get; set; }


        [BindProperty]

        public IFormFile UploadImage { get; set; }

        [BindProperty]
        public int ProductID { get; set; }

        [BindProperty]

        public Product FoundProduct { get; set; }

        [BindProperty]
        public ShoppingCart GetCart { get; set; }

        [BindProperty]
        public int rowCount { get; set; }


        public List<Product> products = new List<Product>();

        public List<ShoppingCart> CartItems = new List<ShoppingCart>();

        [BindProperty]
        public int UserId { get; set; }

        [BindProperty]

        public string message { get; set; }

        [BindProperty(SupportsGet =true)]

        public int ProdID { get; set; }

        [BindProperty]
        public String SearchItems { get; set; }

        public void OnGet()
        {
            GetCart = new ShoppingCart(); // Initialize GetCart

            customer = new Customer();

            FoundProduct = new Product();
          

            //}
            Product product = new Product();
            customer = personManager.GetUser(Convert.ToInt32(HttpContext.Session.GetInt32("UserID")));
            

            UserId = customer.UserID;
           
            products = manager.GetAllProducts();

            ShoppingCart cart = new ShoppingCart();
            //GetCart = orderManager.ShoppingCart(ID);
            ProductID = cart.ProductID;

            products = manager.GetProductsBYID(SearchItems);

            if(FoundProduct != null)
            {
                ProductID = FoundProduct.ID;
                ProductName = FoundProduct.ProductName;
                Quantity = FoundProduct.Quantity;
                Price = (decimal)FoundProduct.Price;
            }
            //{
                  
                    //if (rowCount == 0)
                    //{
                    //    //message = "Your Cart Item is Empty, please Order From the Cart";
                    //    //ViewData["LoginMessage"] = message;
                    //}
                   
                
            //    else
            //    {
            //        //rowCount = orderManager.GetProductRowCount();
            //        //message = "No orders placed from the Cart";
            //        //ViewData["LoginMessage"] = message;
            //    }
            //}
            //else
            //{
            //    message = "Invalid User ID";
            //    ViewData["LoginMessage"] = message;
            //}


             rowCount = orderManager.GetProductRowCount();
            GetCart = orderManager.GETCustomerOrderByID(ProdID);
            CartItems = orderManager.GetshoppingCarts();


        }





        public IActionResult OnPost()
        {
            if (GetCart != null )
            {
               
                CalculateTotalAmount();
                DeCreaseOrderQty(GetCart.ProductID, GetCart.OrderQuantity);
                orderManager.UpdateCustomersOrder(new ShoppingCart( GetCart.CartId,  GetCart.OrderQuantity, GetCart.OrderPrice));
               
            }
            else
            {
                ViewData["OrderMessage"] = "Product Quantity cannot be decreased.";
            }

            // Redirect to the same page
            return RedirectToPage();

        }


        // ...

        public void DeCreaseOrderQty(int productID, int decreaseQty)
        {
            FoundProduct = manager.GetProduct(productID);
            if (FoundProduct != null)
            {
                orderManager.DecreaseProduct(productID, decreaseQty);
            }
            else
            {
                ViewData["OrderMessage"] = "Product not found for ID: " + productID;
                // Add logging here to track the issue
                Console.WriteLine("Product not found for ID: " + productID);
            }
        }


        //public IActionResult OnPost()
        //{
        //    DeCreaseOrderQty(GetCart.ProductID, GetCart.OrderQuantity);
        //    CalculateTotalAmount();


        //    orderManager.UpdateCustomersOrder(new Cart(GetCart.CartId, GetCart.ProductID, GetCart.OrderQuantity, GetCart.Price));



        //    return new RedirectToPageResult("/CartItem");
        //}

        public void CalculateTotalAmount()
        {
            if (GetCart != null)
            {
                GetCart.TotalAmount = (double)(GetCart.OrderPrice * GetCart.OrderQuantity);
            }
        }

    }

}