using System;
using System.Collections.Generic;
using System.Text;

namespace Stock_Inventory_Library.Business.Logic
{
   public class TransactionByCard
    {
        public int CardID { get; set; }
        
        public int UserID { get; set; }

        public String FullName { get; set; }

        public String Address { get; set; }

        public String Zipcode { get; set; }

        public String PaymentMethod { get; set; }

        public Double TotalAmount { get; set; }

        public String Date { get; set; }

        public Byte[] ImageCard { get; set; }

        public String CardNumber { get; set; }

        public int OrderID { get; set; }
        public TransactionByCard(int id, int userid, string full, string addres, string zip, string pay, double total, string date, byte[] image, string card)
        {
            this.CardID = id;
            this.UserID = userid;
            this.FullName = full;
            this.Address = addres;
            this.Zipcode = zip;
            this.PaymentMethod = pay;
            this.TotalAmount = total;
            this.Date = date;
            this.ImageCard = image;
            this.CardNumber = card;
            //this.OrderID = order;
        }

        public TransactionByCard()
        {

        }
        public TransactionByCard( int userid, string full, string addres, string zip, string pay, double total, string date, byte[] image, string card)
        {
          
            this.UserID = userid;
            this.FullName = full;
            this.Address = addres;
            this.Zipcode = zip;
            this.PaymentMethod = pay;
            this.TotalAmount = total;
            this.Date = date;
            this.ImageCard = image;
            this.CardNumber = card;
           // this.OrderID = order;
        }
    }
}
