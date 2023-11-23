using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stock_Inventory_Library.Business.Logic;
using Stock_Inventory_Library.Business.ManagerClass;
using Stock_Inventory_Library.Persistence;

namespace Gasoline_BV_Website.Pages
{
    public class CreateAccountModel : PageModel
    {

        public UserManager manager = new UserManager(new UserRepository());
        [BindProperty]
        public User customer { get; set; }

        [BindProperty]

        public IFormFile UploadImage { get; set; }

        public String Msg;
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            UserManager personManager = new UserManager(new UserRepository());

            int ID = customer.UserID;
            if (personManager.GetUserByUserName(customer.UserName) == null)
            {
                if (UploadImage != null && UploadImage.Length > 0)
                {
                    byte[] imageData;

                    using (var memoryStream = new MemoryStream())
                    {
                        UploadImage.CopyTo(memoryStream);
                        customer.Photo = memoryStream.ToArray();
                    }
                    string message = NewAcountInfoCheck(customer.FullName, customer.UserName, customer.Email, customer.Password, customer.Zipcode);
                    if (message == "")
                    {
                        personManager.AddNewUser(new User(customer.FullName, customer.UserName, customer.Email, customer.Password, customer.Zipcode, customer.Photo, "WareHouse-Manager"));
                        if (ID != 0)
                        {
                            HttpContext.Session.SetInt32("UserID", ID);
                            HttpContext.Session.SetString("UserPosition", "Player");
                            ViewData["Message"] = "New Player Info has been Created.";
                            return new RedirectToPageResult("/Login");
                        }
                        ViewData["Message"] = "New Player Info has been Created."; //"Something went wrong please try again later.";

                        return new RedirectToPageResult("/Login");
                    }
                    else
                    {
                        ViewData["Message"] = message;
                    }
                }
                else
                {
                    ViewData["Message"] = "Username already exists.";
                }
                return Page();
            }
            return Page();
        }

        public string NewAcountInfoCheck(string FullName, string UserName, string Email, string Password, string Zipcode)
        {
            if (string.IsNullOrEmpty(FullName))
            {
                return "Full name is required.";
            }
            else if (!Regex.IsMatch(FullName, @"^[a-zA-Z]+\s[a-zA-Z]+$"))
            {
                return "Full name should be in the format 'First Name' followed by 'Last Name'.";
            }
            ////else if (!Regex.IsMatch(FullName, @"/^[a-zA-Z]+(?: [a-zA-Z]+){1,2}$/"))///*^[a-zA-Z]{8,12}$" */))
            ////{
            ////    return "Full name should be 8 or 12 characters long and can contain only alphabets.";
            ////}
            else if (string.IsNullOrEmpty(Email))
            {
                return "Email is required.";
            }
            else if (!Regex.IsMatch(Email, @"[a-z]+@gmail.com$"))
            {
                return "Email is not in a valid format.";
            }
            else if (string.IsNullOrEmpty(UserName))
            {
                return "Username is required.";
            }
            else if (!Regex.IsMatch(UserName, @"^[a-zA-Z0-9]{4,12}$"))
            {
                return "Username should be at least 4 characters long and can contain only alphabets and numbers.";
            }
            else if (string.IsNullOrEmpty(Password))
            {
                return "Password is required.";
            }
            else if (!Regex.IsMatch(Password, @"^(?=.*\d)(?=.*[a-zA-Z]).{6,40}$"))
            {
                return "Password should be at least 6 characters long and contain at least 1 letter and 1 number.";
            }
            else if (String.IsNullOrEmpty(Zipcode))
            {
                return "Zipcode is required.";
            }
            else if (!Regex.IsMatch(Zipcode, @"^[0-9]{4}[A-Z]{2}$"))
            {
                return "Zipcode should be in the format: 1234AB.";
            }
            return "";
        }

    }
}

