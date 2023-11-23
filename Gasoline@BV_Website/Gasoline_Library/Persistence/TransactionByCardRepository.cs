using MySql.Data.MySqlClient;
using Stock_Inventory_Library.Business.Logic;
using Stock_Inventory_Library.Persistence.ReposInterface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace Stock_Inventory_Library.Persistence
{
    public class TransactionByCardRepository : IPaymentCard
    {
        private String ADD_PAYMENT_TRANSACTION = "INSERT INTO bycard(UserId, FullName, Address, Zipcode, PaymentMethod, TotalAmount, Date, ImageCard, CardNo)VALUES(@userid, @full, @adres, @zip, @pay, @total, @date, @img, @card)";

        private String GET_ALL_PAYMENTS = "SELECT * FROM bycard";

        private String GET_CUSTOMER_PAYMENT_BYID = "SELECT * FROM bycard WHERE UserId=@userid";

        private String GET_TRANSACTION_BYID = "SELECT * FROM bycard WHERE CardID=@id";
        public TransactionByCard GetTransactionByCard(int CardId)
        {
            MySqlConnection conn = DBConnection.GetConnection();

            String SQl = GET_TRANSACTION_BYID;

           

            try
            {
                TransactionByCard byCard = new TransactionByCard();

                MySqlCommand cmd = new MySqlCommand(SQl, conn);
                cmd.Parameters.AddWithValue("@id", CardId);
                conn.Open();



                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int CardID = Convert.ToInt32(reader["CardID"]);

                   int USERID = Convert.ToInt32(reader["UserId"]);

                    String FullName = reader["FullName"].ToString();

                    String Address = reader["Address"].ToString();

                    String zipcode = reader["Zipcode"].ToString();

                    String Payment = reader["PaymentCard"].ToString();
                    Double TotalCost = Convert.ToDouble(reader["TotalAmount"].ToString());

                    String Date = reader["Date"].ToString();

                    Byte[] ImageProd = (Byte[])reader["ImageCard"];

                    String CardNumber = reader["CardNo"].ToString();

                   // int OrderID = Convert.ToInt32(reader["OrderID"]);



                    byCard =  new TransactionByCard(CardID, USERID, FullName, Address, zipcode, Payment, TotalCost, Date, ImageProd, CardNumber);

                    return byCard;
                }
            }
            catch (Exception exp)
            {

            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return null;
        }

        public List<TransactionByCard> GetTransactionByCards()
        {
            MySqlConnection conn = DBConnection.GetConnection();

            String SQl = GET_ALL_PAYMENTS;

            List<TransactionByCard> carts = new List<TransactionByCard>();

            try
            {
                TransactionByCard byCard = new TransactionByCard();

                MySqlCommand cmd = new MySqlCommand(SQl, conn);
               
                conn.Open();



                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int CardID = Convert.ToInt32(reader["CardID"]);

                   int USERID = Convert.ToInt32(reader["UserId"]);

                    String FullName = reader["FullName"].ToString();

                    String Address = reader["Address"].ToString();

                    String zipcode = reader["Zipcode"].ToString();

                    String Payment = reader["PaymentCard"].ToString();
                    Double TotalCost = Convert.ToDouble(reader["TotalAmount"].ToString());

                    String Date = reader["Date"].ToString();

                    Byte[] ImageProd = (Byte[])reader["ImageCard"];

                    String CardNumber = reader["CardNo"].ToString();

                    //int OrderID = Convert.ToInt32(reader["OrderID"]);



                    carts.Add(new TransactionByCard(CardID, USERID, FullName, Address, zipcode, Payment, TotalCost, Date, ImageProd, CardNumber));
                }
            }
            catch (Exception exp)
            {

            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return carts;
        }

        public List<TransactionByCard> GetTransactionByCardsByID(int USERID)
        {
            MySqlConnection conn = DBConnection.GetConnection();

            String SQl = "SELECT * FROM bycard WHERE UserId=@userid";

            List<TransactionByCard> carts = new List<TransactionByCard>();

            try
            {
                TransactionByCard byCard = new TransactionByCard();

                MySqlCommand cmd = new MySqlCommand(SQl, conn);
                cmd.Parameters.AddWithValue("@userid", USERID);
                conn.Open();



                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int CardID = Convert.ToInt32(reader["CardID"]);

                    USERID = Convert.ToInt32(reader["UserId"]);

                    String FullName = reader["FullName"].ToString();

                    String Address = reader["Address"].ToString();

                    String zipcode = reader["Zipcode"].ToString();

                    String Payment = reader["PaymentCard"].ToString();
                    Double TotalCost = Convert.ToDouble(reader["TotalAmount"].ToString());

                    String Date = reader["Date"].ToString();

                    Byte[] ImageProd = (Byte[])reader["ImageCard"];
                    String CardNumber = reader["CardNo"].ToString();
                    //int OrderID = Convert.ToInt32(reader["OrderID"]);





                    carts.Add(new TransactionByCard(CardID, USERID, FullName, Address, zipcode, Payment, TotalCost, Date, ImageProd, CardNumber));
                }
            }
            catch (Exception exp)
            {

            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return carts;
        }

        public bool MakePayment(TransactionByCard transaction)
        {
            MySqlConnection conn = DBConnection.GetConnection();


            try
            {
                String SQL = ADD_PAYMENT_TRANSACTION;

                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@userid", transaction.UserID);
                cmd.Parameters.AddWithValue("@full", transaction.FullName);
                cmd.Parameters.AddWithValue("@adres", transaction.Address);
                cmd.Parameters.AddWithValue("@zip", transaction.Zipcode);
                cmd.Parameters.AddWithValue("@pay", transaction.PaymentMethod);
                cmd.Parameters.AddWithValue("@total", transaction.TotalAmount);
                cmd.Parameters.AddWithValue("@date", transaction.Date);
                cmd.Parameters.AddWithValue("@img", transaction.ImageCard);
                cmd.Parameters.AddWithValue("@card", transaction.CardNumber);
                //cmd.Parameters.AddWithValue("@order", transaction.OrderID);

                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader is null)
                {
                    return false;
                }
                if (reader.RecordsAffected > 0)
                {
                    return true;
                }
            }
            catch (InvalidOperationException exp)
            {
                Debug.Write(exp.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Clone();
                }
            }
            return false;
        }
    }
}
