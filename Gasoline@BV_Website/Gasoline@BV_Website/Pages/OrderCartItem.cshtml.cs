
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stock_Inventory_Library;
using Stock_Inventory_Library.Business.Logic;
using Stock_Inventory_Library.Business.ManagerClass;
using Stock_Inventory_Library.Persistence;
using System;
using System.Collections.Generic;

namespace Test_ShoppingCart.Pages
{
    [Authorize]
    public class OrderCartItemModel : PageModel
    {
        public List<Product> products = new List<Product>();

        public ProductManager manager = new ProductManager(new ProductRepository());
        public OrderManager orderManager = new OrderManager(new OrderRepository());
        public UserManager personManager = new UserManager(new UserRepository());

        [BindProperty]

        public String ProductName { get; set; }

        [BindProperty]
        public User customer { get; set; }

        [BindProperty]

        public int Quantity { get; set; }





        [BindProperty]

        public String ProductType { get; set; }

        [BindProperty]

        public Byte[] ImagePath { get; set; }


        [BindProperty]

        public IFormFile UploadImage { get; set; }

        [BindProperty]
        public int ProductID { get; set; }

       [BindProperty]
       public int UserId { get; set; }
        public void OnGet()
        {
            GetCart = new ShoppingCart(); // Initialize GetCart
            ///FoundProduct = manager.GetProduct(Convert.ToInt32(HttpContext.Session.GetInt32("ID")));
           // Product FoundProduct = new Product();
            FoundProduct = new Product();

            products = manager.GetAllProducts();

            customer = new User();

            if (UserId == customer.UserID)
            {
                rowCount = orderManager.GetProductRowCount();




            }
            else
            {
                ViewData["message"] = "User has not Order from the CartItem";
            }
            rowCount = orderManager.GetProductRowCount();

            // FoundProduct = manager.GetProduct(ID);

            // ProductID = FoundProduct.ProductId.ToString(); ;
            // ProductName = FoundProduct.Name;
            // Quantity = foundProduct.Quantity;
            // Price = FoundProduct.Price;

            //ImagePath = FoundProduct.ImageUrl;

            customer = personManager.GetUser(Convert.ToInt32(HttpContext.Session.GetInt32("UserID")));
        }

        [BindProperty]
        public ShoppingCart GetCart { get; set; }

        [BindProperty]
        public int rowCount { get; set; }

        [BindProperty]

        public Product FoundProduct { get; set; }
        // Other BindProperty properties

        public List<Product> GetProducts { get; set; }

        public List<ShoppingCart> cartItems = new List<ShoppingCart>();

        // Other properties and methods



        private double _costPrice;
        private double _price;

        [BindProperty]
        public double CostPrice
        {
            get { return _costPrice; }
            set { _costPrice = Math.Round(value, 4); }
        }

        [BindProperty]
        public decimal Price
        {
            get { return (decimal)_price; }
            set { _price = (double)Math.Round(value, 4); }
        }
        public void DeCreaseOrderQty(int ProductID, int DecreaseQty)
        {
            if (DecreaseQty > 0)
            {
                orderManager.DecreaseProduct(ProductID, DecreaseQty);
            }
            else
            {
                String Message = "Product Quantity can not be decrease";
                ViewData["OrderMessage"] = Message;


            }
        }

        public IActionResult YourActionName()
        {
            // Your logic to fetch CartItems count
            var cartItemCount = orderManager.GetshoppingCarts(); // Replace this with your actual logic

            // Call the function to get the row count from the database.

            // Assuming you have a shopping cart icon with an ID of "cartIcon" in your HTML markup.
            rowCount.ToString(); // 
            // Pass the cartItemCount to the view
            ViewData["CartItemCount"] = cartItemCount;

            return Page();
        }



        public IActionResult OnPost()
        {
            if (GetCart == null)
            {
                GetCart = new ShoppingCart(); // Initialize GetCart if it's null
            }

            if (string.IsNullOrEmpty(GetCart.Name))
            {
                ViewData["OrderMessage"] = "Product name cannot be empty.";
                return RedirectToPage("OrderCartItem");
            }

            var cartByName = orderManager.GetCartByName(GetCart.Name);

            if (cartByName != null)
            {
                ViewData["OrderMessage"] = $"CartItem with the product name: {cartByName.Name} already exists.";
                return RedirectToPage("OrderCartItem");
            }
            else
            {
                // Assuming the form data has been properly bound to GetCart properties
                // orderManager.PlaceOrder(GetCart);
                //Decrease Qty Product

                // Calculate the total amount before assigning it to GetCart
                CalculateTotalAmount();
                // Save GetCart to the database

                DeCreaseOrderQty(GetCart.ProductID, GetCart.OrderQuantity);


                orderManager.PurchaseCartItem(new ShoppingCart( GetCart.ProductID, GetCart.UserID, GetCart.Name, GetCart.OrderQuantity, GetCart.ImageProd, GetCart.OrderPrice, GetCart.TotalCost));

                // CalculateTotalAmount();
                GetCart.TotalCost = GetCart.TotalCost;
                //GetCart = GetCart.TotalAmount();
                ViewData["OrderMessage"] = "CartItem Created Successfully";

                return RedirectToPage("OrderCartItem");
            }
        }


        public void CalculateTotalAmount()
        {
            if (GetCart != null)
            {
                GetCart.TotalCost = (decimal)(GetCart.OrderPrice * GetCart.OrderQuantity);
            }
        }

    }


}