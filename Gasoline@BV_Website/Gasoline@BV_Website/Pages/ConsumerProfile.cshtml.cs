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

namespace Gasoline_BV_Website.Pages
{
    [Authorize]
    public class ConsumerProfileModel : PageModel
    {
        [BindProperty]
        public User customer { get; set; }

        public UserManager personManager;
        public ConsumerProfileModel()
        {
            this.personManager = new UserManager(new UserRepository());
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("UserPosition") == "Admin")
            {
                // return new RedirectToPageResult("/AccessDenied");
            }
            else if (HttpContext.Session.GetString("UserPosition") == "Consumer")
            {
                //Login Login = new Login(new EmailManager());

                customer = new Customer();

                customer = personManager.GetUser(Convert.ToInt32(HttpContext.Session.GetInt32("UserID")));

                return Page();
            }
            //else
            //{
            return new RedirectToPageResult("AccessDenied");
            //}

        }

    }
}
