using System;
using System.Collections.Generic;
using System.Text;

namespace CartLibrary.business
{
   public class Checkout
    {
        public int ID { get; set; }

       

      
        public String FullName { get; set; }

        public String Address { get; set; }

        public String Zipcode { get; set; }

        public String AccountNr { get; set; }


        public  String BankNames { get; set; }

        public Decimal GrandTotal { get; set; }

        

        public int UserId { get; set; }

        public DateTime OrderDate { get; set; }

        public Checkout()
        {

        }

       

        public Checkout(int id, decimal grand, string fulll, int userid, string acnr, string bank, string addrs, string zip, DateTime order)
        {
            this.ID = id;
            this.GrandTotal = grand;
            this.FullName = fulll;
            this.UserId = userid;
            this.Address = addrs;
           
            this.AccountNr = acnr;
            this.BankNames = bank;
            this.Zipcode = zip;
            this.OrderDate = order;

            ///this.CartID = cart;
        }

        public Checkout( decimal grand, string fulll, int userid, string acnr, string bank, string addrs, string zip, DateTime order)
        {
            
            this.GrandTotal = grand;
            this.FullName = fulll;
            this.UserId = userid;
            this.Address = addrs;
            
            this.AccountNr = acnr;
            this.BankNames = bank;
            this.Zipcode = zip;
            this.OrderDate = order;
            ///this.CartID = cart;
        }
    }
}
