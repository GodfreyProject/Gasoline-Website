﻿using Stock_Inventory_Library.Business.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gasoline_Library.Business.Logic
{
   public class WareHouse_Manager:User
    {
        public WareHouse_Manager(int id, string full, string user, string email, string pass, string zip, byte[] img, string role) : base(id, full, user, email, pass, zip, img, role)
        {

        }


        public WareHouse_Manager(string full, string user, string email, string pass, string zip, byte[] img, string role) : base(full, user, email, pass, zip, img, role)
        {

        }

        public WareHouse_Manager()
        {

        }
    }
}
