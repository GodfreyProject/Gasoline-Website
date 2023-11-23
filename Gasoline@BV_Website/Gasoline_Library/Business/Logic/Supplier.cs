using Stock_Inventory_Library.Business.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gasoline_Library.Business.Logic
{
   public class Supplier:User
    {
        public Supplier(int id, string full, string user, string email, string pass, string zip, byte[] img, string role) : base(id, full, user, email, pass, zip, img, role)
        {

        }


        public Supplier(string full, string user, string email, string pass, string zip, byte[] img, string role) : base(full, user, email, pass, zip, img, role)
        {

        }

        public Supplier()
        {

        }
    }
}
