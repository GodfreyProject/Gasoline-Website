using CartLibrary.persistence.ReposInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CartLibrary.business.ManagerClass
{
   public class CheckoutManager: ICheckoutRepository
    {
        private ICheckoutRepository checkRepository;

        public CheckoutManager(ICheckoutRepository repository)
        {

            this.checkRepository = repository;
        }

        public bool AddNewCheckout(Checkout checkout)
        {
            return this.checkRepository.AddNewCheckout(checkout);
        }

        public List<Checkout> GetAllCheckouts()
        {
            return this.checkRepository.GetAllCheckouts();
        }

        public Checkout GetCheckout(int ID)
        {
            return this.checkRepository.GetCheckout(ID);
        }

        public List<Checkout> GetCheckouts(int ID)
        {
            return this.checkRepository.GetCheckouts(ID);
        }
    }
}
