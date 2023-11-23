using Stock_Inventory_Library.Business.Logic;
using Stock_Inventory_Library.Persistence.ReposInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stock_Inventory_Library.Business.ManagerClass
{
    public class CardManager : IPaymentCard
    {
        private IPaymentCard paymentCard;

        public CardManager(IPaymentCard payment)
        {
            this.paymentCard = payment;
        }
        public TransactionByCard GetTransactionByCard(int CardId)
        {
            TransactionByCard byCard = new TransactionByCard();

            byCard = paymentCard.GetTransactionByCard(CardId);

            if(byCard != null)
            {
                return byCard;
            }
            else
            {
                return null;
            }
        }

        public List<TransactionByCard> GetTransactionByCards()
        {
            return this.paymentCard.GetTransactionByCards();
        }

        public List<TransactionByCard> GetTransactionByCardsByID(int USERID)
        {
            List<TransactionByCard> byCards = new List<TransactionByCard>();

            byCards = paymentCard.GetTransactionByCardsByID(USERID);

            if(byCards != null)
            {
                return byCards;
            }
            else
            {
                return null;
            }
        }

        public bool MakePayment(TransactionByCard transaction)
        {
            if (this.paymentCard.MakePayment(transaction))
            {
                return true;
            }

            return false;
        }
    }
}
