using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stock_Inventory_Library;
using Stock_Inventory_Library.Business.ManagerClass;
using Stock_Inventory_Library.Persistence;

namespace Gasoline_BV_Website.Pages
{
    [Authorize]
    public class ProductModel : PageModel
    {
        [BindProperty]
        public Product FoundProduct { get; set; }

        private readonly IWebHostEnvironment _environment;

        public ProductModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public ProductManager productManager = new ProductManager(new ProductRepository());
        public UserManager personManager = new UserManager(new UserRepository());
        public OrderManager orderManager = new OrderManager(new OrderRepository());

        [BindProperty]

        public IFormFile UploadImage { get; set; }


        // Other BindProperty properties

        public List<Product> GetProducts { get; set; }

        // Other properties and methods


        private double _costPrice;
        private double _price;

        [BindProperty]
        public double CostPrice
        {
            get { return _costPrice; }
            set { _costPrice = Math.Round(value, 2); }
        }

        [BindProperty]
        public double Price
        {
            get { return _price; }
            set { _price = Math.Round(value, 2); }
        }

        public IActionResult OnGet(int ID)
        {
            // Logic for OnGet method

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (UploadImage != null && UploadImage.Length > 0)
                {
                    byte[] imageData;

                    using (var memoryStream = new MemoryStream())
                    {
                        UploadImage.CopyTo(memoryStream);
                        FoundProduct.ImagePath = memoryStream.ToArray();
                    }

                   

                    // Create a new order and pass the image data
                    productManager.AddNewProduct(FoundProduct);

                    // Update the view with a success message
                    ViewData["OrderMessage"] = " New Product  has been Created Successfully";

                    return new RedirectToPageResult("/ProductList");

                    // Decrease the order quantity
                    // InCreaseOrderQty(FoundProduct.ID, cart.OrderQuantity);

                    // Redirect to the appropriate page
                    // return RedirectToPage("GetCustomerPersonalOrders");
                }
                else
                {
                    ModelState.AddModelError("UploadImage", "Please select an image file.");
                }
            }

            // If ModelState is not valid or the image upload fails, return to the page
            return Page();
        }
        //public void OnGet()
        //{
        //}
    }
}
