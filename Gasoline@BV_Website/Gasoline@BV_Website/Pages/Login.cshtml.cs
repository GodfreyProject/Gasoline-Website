using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Gasoline_Library.Business.Logic;
using GasolineBV_Library.Business.Logic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stock_Inventory_Library;
using Stock_Inventory_Library.Business.Logic;
using Stock_Inventory_Library.Business.ManagerClass;
using Stock_Inventory_Library.Persistence;

namespace Gasoline_BV_Website.Pages
{
    public class LoginModel : PageModel
    {
        public string PageTitle { get; set; }

        UserManager registerManager = new UserManager(new UserRepository());

        ProductManager productManager = new ProductManager(new ProductRepository());




        // public RegisterTournament R { get; set; }

        [BindProperty]

        public ShoppingCart cart { get; set; }

        [BindProperty]
        public Customer customer { get; set; }

        [BindProperty]
        public Product product { get; set; }
        public void OnGet(int ID)
        {


            // tournament = tournamentManager.GetNewTournament(ID);
            //if (HttpContext.Session.GetString("UserPosition") == "Employee")
            //{
            //    return new RedirectToPageResult("EmployeeHome");
            //}
            //else if (HttpContext.Session.GetString("UserPosition") == "PLayer")
            //{
            //    return new RedirectToPageResult("PlayerHome");
            //}
            //return Page();
        }

        public IActionResult OnPostContent()
        {
            //this.ds = new DatabaseSelector(DatabaseType.Cloud);

            return RedirectToPage();
        }


        //public IActionResult OnPost()
        // WHERE STAFF OR EMPLOYEE AND PLAYER LOGIN, REDIRECT TO THRIR OWN PAGE
        public async Task<IActionResult> OnPostAsync()
        {
            //Review review = new Review();
            cart = new ShoppingCart();
            product = new Product();
            string Username = customer.UserName;
            string Password = customer.Password;
            //if (!ModelState.IsValid) return Page();

            if (string.IsNullOrEmpty(Username))
            {
                return null;
            }
            if (string.IsNullOrEmpty(Password))
            {
                return null;
            }

            if (checkLogin(customer.UserName.ToString(), customer.Password.ToString()) != null)
            {

                User a = checkLogin(customer.UserName.ToString(), customer.Password.ToString());

                if (a is Admin)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, a.Role),

                    new Claim(ClaimTypes.Name, "UserID"),
                    // new Claim(ClaimTypes.Name, "OrderID"),//"admin@gmail.com"),
                    //new Claim("Department", "HR"),
                    new Claim("Admin", "true"),
                    //new Claim("Manager", "true"),
                    //new Claim("EmployeeDate", "23-05-2022"),

                };
                    var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    //var authproperties = new AuthenticationProperties
                    //{
                    //    IsPersistent = credential.RememberMe
                    //};
                    HttpContext.Session.SetInt32("UserID", a.UserID);
                    // HttpContext.Session.SetInt32("UserID", cart.OrderId);
                    // HttpContext.Session.SetInt32("SchID", tournament.TournammentID);
                    HttpContext.Session.SetString("UserPosition", "Admin");

                    await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);//, authproperties);
                                                                                   // return RedirectToPage("/Index");


                    return new RedirectToPageResult("/AdminHome");
                }
                else if (a is Customer )
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, a.Role),//"PLayer"),

                    new Claim(ClaimTypes.Name, "UserID"),
                     new Claim(ClaimTypes.Name, "OrderId"),

                    new Claim("Consumer", "true"),


                };
                    var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    //var authproperties = new AuthenticationProperties
                    //{
                    //    IsPersistent = credential.RememberMe
                    //};
                    HttpContext.Session.SetInt32("UserID", a.UserID);
                    HttpContext.Session.SetInt32("OrderId", cart.CartId);
                    //HttpContext.Session.SetInt32("ProductID", product.ID);
                    HttpContext.Session.SetString("UserPosition", "Consumer");

                    await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);//, authproperties);
                                                                                   // return RedirectToPage("/Index");


                    //HttpContext.Session.SetInt32("UserID", a.PersonID);
                    ////HttpContext.Session.SetInt32("ID", news.NewsID);

                    //HttpContext.Session.SetString("UserPosition", "PLayer");

                    return new RedirectToPageResult("/ConsumerProfile");
                }
                else if (a is Retailer)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, a.Role),//"PLayer"),

                    new Claim(ClaimTypes.Name, "UserID"),
                     new Claim(ClaimTypes.Name, "OrderId"),

                    new Claim("Retailer", "true"),


                };
                    var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    //var authproperties = new AuthenticationProperties
                    //{
                    //    IsPersistent = credential.RememberMe
                    //};
                    HttpContext.Session.SetInt32("UserID", a.UserID);
                    HttpContext.Session.SetInt32("OrderId", cart.CartId);
                    HttpContext.Session.SetInt32("ProductID", product.ID);
                    HttpContext.Session.SetString("UserPosition", "Retailer");

                    await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);//, authproperties);
                                                                                   // return RedirectToPage("/Index");


                    //HttpContext.Session.SetInt32("UserID", a.PersonID);
                    ////HttpContext.Session.SetInt32("ID", news.NewsID);

                    //HttpContext.Session.SetString("UserPosition", "PLayer");

                    return new RedirectToPageResult("/RetailerProfile");
                }
                else if (a is WareHouse_Manager)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, a.Role),//"PLayer"),

                    new Claim(ClaimTypes.Name, "UserID"),
                     new Claim(ClaimTypes.Name, "OrderId"),

                    new Claim("WareHouse-Manager", "true"),


                };
                    var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    //var authproperties = new AuthenticationProperties
                    //{
                    //    IsPersistent = credential.RememberMe
                    //};
                    HttpContext.Session.SetInt32("UserID", a.UserID);
                    HttpContext.Session.SetInt32("OrderId", cart.CartId);
                    HttpContext.Session.SetInt32("ProductID", product.ID);
                    HttpContext.Session.SetString("UserPosition", "Retailer");

                    await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);//, authproperties);
                                                                                   // return RedirectToPage("/Index");


                    //HttpContext.Session.SetInt32("UserID", a.PersonID);
                    ////HttpContext.Session.SetInt32("ID", news.NewsID);

                    //HttpContext.Session.SetString("UserPosition", "PLayer");

                    return new RedirectToPageResult("/WareHouse_Section");
                }
                else if (a is Production_Manager)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, a.Role),//"PLayer"),

                    new Claim(ClaimTypes.Name, "UserID"),
                     new Claim(ClaimTypes.Name, "OrderId"),

                    new Claim("Production-Manager", "true"),


                };
                    var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    //var authproperties = new AuthenticationProperties
                    //{
                    //    IsPersistent = credential.RememberMe
                    //};
                    HttpContext.Session.SetInt32("UserID", a.UserID);
                    HttpContext.Session.SetInt32("OrderId", cart.CartId);
                    HttpContext.Session.SetInt32("ProductID", product.ID);
                    HttpContext.Session.SetString("UserPosition", "Production-Manager");

                    await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);//, authproperties);
                                                                                   // return RedirectToPage("/Index");


                    //HttpContext.Session.SetInt32("UserID", a.PersonID);
                    ////HttpContext.Session.SetInt32("ID", news.NewsID);

                    //HttpContext.Session.SetString("UserPosition", "PLayer");

                    return new RedirectToPageResult("/ProductionHome");
                }

                else if (a is Financial_Manager)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, a.Role),//"PLayer"),

                    new Claim(ClaimTypes.Name, "UserID"),
                     new Claim(ClaimTypes.Name, "OrderId"),

                    new Claim("Retailer", "true"),


                };
                    var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    //var authproperties = new AuthenticationProperties
                    //{
                    //    IsPersistent = credential.RememberMe
                    //};
                    HttpContext.Session.SetInt32("UserID", a.UserID);
                    HttpContext.Session.SetInt32("OrderId", cart.CartId);
                    HttpContext.Session.SetInt32("ProductID", product.ID);
                    HttpContext.Session.SetString("UserPosition", "Retailer");

                    await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);//, authproperties);
                                                                                   // return RedirectToPage("/Index");


                    //HttpContext.Session.SetInt32("UserID", a.PersonID);
                    ////HttpContext.Session.SetInt32("ID", news.NewsID);

                    //HttpContext.Session.SetString("UserPosition", "PLayer");

                    return new RedirectToPageResult("/RetailerProfile");
                }
                else if (a is Sales_Manager)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, a.Role),//"PLayer"),

                    new Claim(ClaimTypes.Name, "UserID"),
                     new Claim(ClaimTypes.Name, "OrderId"),

                    new Claim("Retailer", "true"),


                };
                    var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    //var authproperties = new AuthenticationProperties
                    //{
                    //    IsPersistent = credential.RememberMe
                    //};
                    HttpContext.Session.SetInt32("UserID", a.UserID);
                    HttpContext.Session.SetInt32("OrderId", cart.CartId);
                    HttpContext.Session.SetInt32("ProductID", product.ID);
                    HttpContext.Session.SetString("UserPosition", "Retailer");

                    await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);//, authproperties);
                                                                                   // return RedirectToPage("/Index");


                    //HttpContext.Session.SetInt32("UserID", a.PersonID);
                    ////HttpContext.Session.SetInt32("ID", news.NewsID);

                    //HttpContext.Session.SetString("UserPosition", "PLayer");

                    return new RedirectToPageResult("/RetailerProfile");
                }

                else if (a is Supplier)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, a.Role),//"PLayer"),

                    new Claim(ClaimTypes.Name, "UserID"),
                     new Claim(ClaimTypes.Name, "OrderId"),

                    new Claim("Supplier", "true"),


                };
                    var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    //var authproperties = new AuthenticationProperties
                    //{
                    //    IsPersistent = credential.RememberMe
                    //};
                    HttpContext.Session.SetInt32("UserID", a.UserID);
                    HttpContext.Session.SetInt32("OrderId", cart.CartId);
                    HttpContext.Session.SetInt32("ProductID", product.ID);
                    HttpContext.Session.SetString("UserPosition", "Supplier");

                    await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);//, authproperties);
                                                                                   // return RedirectToPage("/Index");


                    //HttpContext.Session.SetInt32("UserID", a.PersonID);
                    ////HttpContext.Session.SetInt32("ID", news.NewsID);

                    //HttpContext.Session.SetString("UserPosition", "PLayer");

                    return new RedirectToPageResult("/Supplier_Section");
                }

                else
                {
                    return Page();
                }
            }
            string message = "Invalid credentials, try again";
            ViewData["LoginMessage"] = message;
            return Page();
        }



        //public void OnPostForgotPassword()
        //{
        //    Login Login = new Login(new PersonManager(new dbPersonManager()), new EmailManager());

        //    Person person = Login.personManager.GetPerson(customer.Username);

        //    if (person != null)
        //    {
        //        Login.emailManager.ForgotPassword(person);
        //        ViewData["LoginMessage"] = "A email has been send to your email address with the inforamtion you'll need to reset you password.";
        //    }
        //}

        public User checkLogin(String Username, String Password)
        {
            UserManager personManager = new UserManager(new UserRepository());


            return personManager.GetUserInfo(Username, Password);
        }
        //public void OnGet()
        //{
        //}

      
    }
}
