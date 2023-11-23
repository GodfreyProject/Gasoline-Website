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
    public class Supplier_SectionModel : PageModel
    {
        public UserManager userManager = new UserManager(new UserRepository());

        [BindProperty]

        public User supplier { get; set; }
        public void OnGet()
        {
            supplier = new User();

            supplier = userManager.GetUser(Convert.ToInt32(HttpContext.Session.GetInt32("UserID")));
        }
    }
}
