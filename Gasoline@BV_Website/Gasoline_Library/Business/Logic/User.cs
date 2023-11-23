using System;
using System.Collections.Generic;
using System.Text;

namespace Stock_Inventory_Library.Business.Logic
{
    public class User
    {
        public int UserID { get; set; }


        public String FullName { get; set; }


        public String UserName { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

        public String Zipcode { get; set; }
        public Byte[] Photo { get; set; }

        public String Role { get; set; }



        public User()
        {

        }

        public User(int id, string full, string user, string email, string pass, string zip,byte[] img, string role)
        {
            this.UserID = id;
            this.FullName = full;
            this.UserName = user;
            this.Email = email;
            this.Password = pass;
            this.Zipcode = zip;
            this.Photo = img;
            this.Role = role;
        }

        public User(string full, string user, string email, string pass, string zip, byte[] img, string role)
        {
           
            this.FullName = full;
            this.UserName = user;
            this.Email = email;
            this.Password = pass;
            this.Zipcode = zip;
            this.Photo = img;
            this.Role = role;
        }
    }
}
