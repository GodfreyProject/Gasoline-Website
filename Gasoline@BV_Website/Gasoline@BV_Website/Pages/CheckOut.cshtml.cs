using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartLibrary.business;
using CartLibrary.business.ManagerClass;
using CartLibrary.persistence;
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
    public class CheckOutModel : PageModel
    {
        public OrderManager orderManager = new OrderManager(new OrderRepository());

        public CheckoutManager Manager = new CheckoutManager(new CheckoutRepository());

        public List<ShoppingCart> CartItems = new List<ShoppingCart>();
        UserManager userManager = new UserManager(new UserRepository());

        [BindProperty]
        public int CartID { get; set; }

        [BindProperty]
        public ShoppingCart GetCart { get; set; }

        [BindProperty]

        public User customer { get; set; }

        [BindProperty]
        public Checkout checkout { get; set; }
        public void OnGet(int ID)
        {
            CartItems = orderManager.GetshoppingCarts();

            GetCart = orderManager.GETCustomerOrderByID(ID);

            if (GetCart != null)
            {
                CartID = GetCart.CartId;
            }
            else
            {
                ViewData["message"] = "Something went Wrong";
                // Handle the situation when GetCart is null
                // For example, you might redirect to an error page or return an error message
            }

            customer = new User();

            customer = userManager.GetUser(Convert.ToInt32(HttpContext.Session.GetInt32("UserID")));
        }


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Manager.AddNewCheckout(new Checkout(checkout.GrandTotal, customer.FullName, customer.UserID, checkout.AccountNr, checkout.BankNames, checkout.Address, customer.Zipcode, checkout.OrderDate));

                ViewData["Message"] = "Successfully Created";

                return RedirectToPage("CheckOut");
            }
            else
            {
                ViewData["Message"] = "Something went Wrong";
            }

            return Page();
        }
    }
}
