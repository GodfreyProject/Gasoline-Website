using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stock_Inventory_Library.Business.Logic;
using Stock_Inventory_Library.Business.ManagerClass;
using Stock_Inventory_Library.Persistence;

namespace Test_ShoppingCart.Pages
{
    [Authorize]
    public class OnDeleteCartItemModel : PageModel
    {

        [BindProperty]

        public String ProductName { get; set; }

        [BindProperty]

        public int Quantity { get; set; }


        [BindProperty]

        public Decimal Price { get; set; }


        [BindProperty]

        public String Name { get; set; }

        [BindProperty]

        public Byte[] ImagePath { get; set; }


        [BindProperty]

        public IFormFile UploadImage { get; set; }

        public int ProductID { get; set; }


        [BindProperty]

        public String Date { get; set; }


        [BindProperty]

        public int OrderQuantity { get; set; }

        [BindProperty]
        public ShoppingCart GetCart { get; set; }

        [BindProperty]


        public byte[] OrderImage { get; set; }

        [BindProperty]

        public int OrderId { get; set; }
        [BindProperty]
        public Double TotalCost { get; set; }

        public ProductManager productManager = new ProductManager(new ProductRepository());

        public OrderManager orderManager = new OrderManager(new OrderRepository());
        public void OnGet(int ID)
        {
            GetCart = new ShoppingCart();
            GetCart = orderManager.GETCustomerOrderByID(ID);

            if (GetCart != null)
            {
                OrderId = GetCart.CartId;
                Name = GetCart.Name;
                OrderQuantity = GetCart.OrderQuantity;
            }



        }


        public void InCreaseOrderQty(int ProductID, int DecreaseQty)
        {
            if (DecreaseQty > 0)
            {
                orderManager.IncreaseProduct(ProductID, DecreaseQty);
            }
            else
            {
                String Message = "Product Quantity can not be decrease";
                ViewData["OrderMessage"] = Message;


            }
        }


        public IActionResult OnPost(int ID)
        {
            if (String.IsNullOrEmpty(ID.ToString()))
            {
                String Message = "The Specified to Delete that CartItem does not Exist";
                ViewData["Message"] = Message;

                return Page();
            }
            else
            {
                  orderManager.RemoveOrderCartItem(ID);
                String Message = "CartItem has been Deleted Successfully";

              

                ViewData["Message"] = Message;

                return RedirectToAction("CartItem");
            }

        }


    }
}

