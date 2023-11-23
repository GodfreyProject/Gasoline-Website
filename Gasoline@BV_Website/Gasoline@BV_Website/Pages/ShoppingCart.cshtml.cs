using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stock_Inventory_Library;
using Stock_Inventory_Library.Business.ManagerClass;
using Stock_Inventory_Library.Persistence;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace Gasoline_BV_Website.Pages
{
    [Authorize]
    public class ShoppingCartModel : PageModel
    {
        ProductManager productManager = new ProductManager(new ProductRepository());

        public List<Product> products = new List<Product>();


        //[HttpGet]
        //public IHttpActionResult GetAllProducts()
        //{
        //     products = productManager.GetAllProducts();
        //    return ((IHttpActionResult)products);
        //}
        public void OnGet()
        {
            products = productManager.GetAllProducts();
        }

        [Route("api/GetProducts")]
        [HttpGet]
        public List<Product> GetProducts()
        {
            return productManager.GetAllProducts();
        }
    }
}
