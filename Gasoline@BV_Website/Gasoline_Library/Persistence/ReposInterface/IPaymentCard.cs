using Stock_Inventory_Library.Business.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stock_Inventory_Library.Persistence.ReposInterface
{
   public interface IPaymentCard
    {

        // Get all Payment by Card

        public List<TransactionByCard> GetTransactionByCards();

        // Get All Payment by Card by customers ID
        public List<TransactionByCard> GetTransactionByCardsByID(int USERID);

        public TransactionByCard GetTransactionByCard(int CardId);


        // Add Payment

        public bool MakePayment(TransactionByCard transaction);

        
    }
}
