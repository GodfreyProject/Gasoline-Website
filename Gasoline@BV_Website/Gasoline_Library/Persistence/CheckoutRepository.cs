using CartLibrary.business;
using CartLibrary.persistence.ReposInterface;
using MySql.Data.MySqlClient;
using Stock_Inventory_Library.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CartLibrary.persistence
{
    public class CheckoutRepository : ICheckoutRepository
    {
       /// private String AddCHECKOUT = "INSERT INTO orders (ProductName, OrderQuantity, Price, TotalAmount, CartID, FullName, UserID, AccountNr, BankNames, Address ) VALUES (@name, @qty, @price, @total, @cat, @full, @user, @acc, @bank, @adres)";

        private String GETALLCHECKOUTS = "SELECT * FROM orders";

        private String GETALLCHECKOUTS_BYID = "SELECT * FROM orders WHERE Id=@id";
        public bool AddNewCheckout(Checkout checkout)
        {
            if (checkout == null)
            {
                throw new ArgumentNullException("checkout", "Checkout object is null");
            }

            MySqlConnection conn = DBConnection.GetConnection();

            try
            {
                string SQL = "INSERT INTO orders(TotalAmount, FullName, UserID, AccountNr, BankNames, Address, Zipcode, OrderDate) VALUES(@total, @full, @user, @acc, @bank, @adres, @zip, @date)";

                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                // Adjust the data type based on the 'TotalAmount' column in the 'orders' table
                cmd.Parameters.AddWithValue("@total", checkout.GrandTotal); // Assuming GrandTotal is the correct property for TotalAmount
                cmd.Parameters.AddWithValue("@full", checkout.FullName);
                cmd.Parameters.AddWithValue("@user", checkout.UserId);
                cmd.Parameters.AddWithValue("@acc", checkout.AccountNr);
                cmd.Parameters.AddWithValue("@bank", checkout.BankNames);
                cmd.Parameters.AddWithValue("@adres", checkout.Address);
                cmd.Parameters.AddWithValue("@zip", checkout.Zipcode);
                cmd.Parameters.AddWithValue("@date", checkout.OrderDate);

                conn.Open();

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySqlException Error: {0}", ex.ToString());
                // Handle or log the exception accordingly
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
                // Handle or log the exception accordingly
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return false;
        }



        public List<Checkout> GetAllCheckouts()
        {
            MySqlConnection conn = DBConnection.GetConnection();

            String SQl = GETALLCHECKOUTS;

            List<Checkout> carts = new List<Checkout>();

            try
            {
                Checkout cart = new Checkout();

                MySqlCommand cmd = new MySqlCommand(SQl, conn);

                conn.Open();



                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int CheckID = Convert.ToInt32(reader["Id"]);

                   
                    Decimal GrandTotal = (Decimal)Convert.ToDecimal(reader["TotalAmount"].ToString());
                    //int CartId = Convert.ToInt32(reader["CartID"].ToString());
                    String FullName = reader["FullName"].ToString();
                    int UserID = Convert.ToInt32(reader["UserID"].ToString());
                    String AccountNr = reader["AccountNr"].ToString();
                    String Bank = reader["BankNames"].ToString();
                    String Address = reader["Address"].ToString();

                    String Zip = reader["Zipcode"].ToString();

                    DateTime GetDate = Convert.ToDateTime(reader["OrderDate"].ToString());

                    //  int CartID = Convert.ToInt32(reader["CartID"]);

                    carts.Add(new Checkout(CheckID, GrandTotal, FullName, UserID, AccountNr, Bank, Address, Zip, GetDate));

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

        public Checkout GetCheckout(int ID)
        {
            MySqlConnection conn = DBConnection.GetConnection();

            String SQl = GETALLCHECKOUTS_BYID;

           // List<Checkout> cart = new List<Checkout>();
            try
            {
                Checkout cart = new Checkout(); 

                MySqlCommand cmd = new MySqlCommand(SQl, conn);
                cmd.Parameters.AddWithValue("@id", ID);

                conn.Open();



                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int CheckID = Convert.ToInt32(reader["Id"]);

                  
                    Decimal GrandTotal = (Decimal)Convert.ToDecimal(reader["TotalAmount"].ToString());
                  
                    String FullName = reader["FullName"].ToString();
                    int UserID = Convert.ToInt32(reader["UserID"].ToString());
                    String AccountNr = reader["AccountNr"].ToString();
                    String Bank = reader["BankName"].ToString();
                    String Address = reader["Address"].ToString();

                    String Zip = reader["Zipcode"].ToString();

                    DateTime GetDate = Convert.ToDateTime(reader["OrderDate"].ToString());

                    //  int CartID = Convert.ToInt32(reader["CartID"]);


                    cart = new Checkout(CheckID, GrandTotal, FullName, UserID, AccountNr, Bank, Address, Zip, GetDate);


                    return cart;
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

        public List<Checkout> GetCheckouts(int CheckID)
        {
            MySqlConnection conn = DBConnection.GetConnection();

            String SQl = GETALLCHECKOUTS_BYID;

            List<Checkout> cart = new List<Checkout>();
            try
            {
              // List<Checkout> cart = new List<Checkout>();

                MySqlCommand cmd = new MySqlCommand(SQl, conn);
                cmd.Parameters.AddWithValue("@id", CheckID);

                conn.Open();



                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                     CheckID = Convert.ToInt32(reader["Id"]);

                 
                    Decimal GrandTotal = (Decimal)Convert.ToDecimal(reader["TotalAmount"].ToString());
                   // int CartId = Convert.ToInt32(reader["CartID"].ToString());
                    String FullName = reader["FullName"].ToString();
                    int UserID = Convert.ToInt32(reader["UserID"].ToString());
                    String AccountNr = reader["AccountNr"].ToString();
                    String Bank = reader["BankName"].ToString();
                    String Address = reader["Address"].ToString();

                    String Zip = reader["Zipcode"].ToString();

                    DateTime GetDate = Convert.ToDateTime(reader["OrderDate"].ToString());



                    //  int CartID = Convert.ToInt32(reader["CartID"]);

                    cart.Add(new Checkout(CheckID, GrandTotal,  FullName, UserID, AccountNr, Bank, Address, Zip, GetDate));
                  
                    return cart;
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

            return cart;
        }
    }
}
