using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gasoline_Library.Business.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stock_Inventory_Library;
using Stock_Inventory_Library.Business.Logic;
using Stock_Inventory_Library.Business.ManagerClass;
using Stock_Inventory_Library.Persistence;

namespace Gasoline_BV_Website.Pages
{
    public class SearchAllStocksModel : PageModel
    {
        public ProductManager productManager = new ProductManager(new ProductRepository());

        public UserManager userManager = new UserManager(new UserRepository());


        [BindProperty]

        public String searchInput { get; set; }


        public List<Product> SearchResults { get; set; }


        public List<Stock> GetStocks { get; set; }

       

        [BindProperty]

        public User warehouse { get; set; }
        public void OnGet()
        {

            //if (SearchResults != null)
            //{
            //    SearchResults = productManager.SearchProducts(searchInput);
            //}
            //if (GetStocks != null)
            //{

                GetStocks = productManager.GetListAllProducts();
              
            //}
            //else
            //{
            //    ViewData["message"] = "ERROR";
            //}

            //SearchResults = SearchProducts(searchTerm);

            //warehouse = userManager.GetUser(Convert.ToInt32(HttpContext.Session.GetInt32("UserID")));
        }
    }
}
