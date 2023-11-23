using System;
using System.Collections.Generic;
using System.Text;

namespace Stock_Inventory_Library.Business.Logic
{
   public class Admin:User
    {
        public Admin(int id, string full, string user, string email, string pass, string zip, byte[] img, string role):base(id, full, user, email, pass,zip, img, role)
        {
         
        }


        public Admin( string full, string user, string email, string pass, string zip,byte[] img, string role) : base( full, user, email, pass, zip, img, role)
        {

        }

        public Admin()
        {

        }
    }
}
