using Gasoline_Library.Business.Logic;
using Gasoline_Library.Persistence.ReposInterface;
using MySql.Data.MySqlClient;
using Stock_Inventory_Library.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Gasoline_Library.Persistence
{
    public class ProductionRepository : IProductionRepos
    {

        private String GETALL_PRODUCTIONS = "SELECT * FROM gasoline_activity";

       // private String GETALL_PRODUCTIONS_BYID = "SELECT * FROM gasoline_activity WHERE Nr=@nr";
        public List<ManuFacturer> GetManuFacturers()
        {
            MySqlConnection conn = DBConnection.GetConnection();

            String SQl = GETALL_PRODUCTIONS;

            List<ManuFacturer> carts = new List<ManuFacturer>();

            try
            {
               ManuFacturer cart = new ManuFacturer();

                MySqlCommand cmd = new MySqlCommand(SQl, conn);

                conn.Open();



                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                   cart.Nr = Convert.ToInt32(reader["Nr"]);

                    cart.Productionpart = reader["Production part"].ToString();

                    cart.ProductionUnit = reader["Production Unit"].ToString();

                    cart.Batchnr = Convert.ToInt32(reader["Batchnr"].ToString());

                   cart.Stepnr = Convert.ToInt32(reader["Stepnr"].ToString());
                    cart.Productionsteps = reader["Production steps"].ToString();
                    cart.start = reader["start"].ToString();
                    cart.finish = reader["finish"].ToString();
                    cart.material = reader["material"].ToString();
                    cart.quantity = reader["qty"].ToString();
                    cart.scrap = reader["scrap"].ToString();

                    carts.Add(cart);
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

        public ManuFacturer ManuFacturer(int ID)
        {
            MySqlConnection conn = DBConnection.GetConnection();

            String SQl = GETALL_PRODUCTIONS;

            List<ManuFacturer> carts = new List<ManuFacturer>();

            try
            {
                ManuFacturer cart = new ManuFacturer();

                MySqlCommand cmd = new MySqlCommand(SQl, conn);
                cmd.Parameters.AddWithValue("@nr", ID);

                conn.Open();



                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cart.Nr = Convert.ToInt32(reader["Nr"]);

                    cart.Productionpart = reader["Production part"].ToString();

                    cart.ProductionUnit = reader["Production Unit"].ToString();

                    cart.Batchnr = Convert.ToInt32(reader["Batchnr"].ToString());

                    cart.Stepnr = Convert.ToInt32(reader["Stepnr"].ToString());
                    cart.Productionsteps = reader["Production steps"].ToString();
                    cart.start = reader["start"].ToString();
                    cart.finish = reader["finish"].ToString();
                    cart.material = reader["material"].ToString();
                    cart.quantity = reader["qty"].ToString();
                    cart.scrap = reader["scrap"].ToString();

                    cart = new ManuFacturer();
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
    }
}
