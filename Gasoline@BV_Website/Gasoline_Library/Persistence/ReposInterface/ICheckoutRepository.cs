using CartLibrary.business;
using System;
using System.Collections.Generic;
using System.Text;

namespace CartLibrary.persistence.ReposInterface
{
 public interface ICheckoutRepository
    {

  


            // Get Users Orders

            public List<Checkout> GetAllCheckouts();

            public List<Checkout> GetCheckouts(int ID);

                 public Checkout GetCheckout(int ID);

            // Place Order

            // Get Customer Personsonal Data By UserId

         
            public bool AddNewCheckout(Checkout checkout);


          
        
    }

}

