using MySql.Data.MySqlClient;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker
{
    internal class DataLayer
    {
        private MySqlConnection connection;
        public DataLayer() { 
            connection = new MySqlConnection($"server=localhost;port=3306;uid=root;pwd=;database=budget_tracker;");
        }

        public List<LineItem> GetLineItems()
        {
            List<LineItem> results =  new List<LineItem>();
            try
            {
                connection.Open();

                string query = "select * from line_items;";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(new LineItem(
                        reader.GetUInt32("id"),
                        reader.GetString("name"),
                        reader.GetUInt32("credit"),
                        reader.GetUInt32("debit")
                    ));
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }          

            return results;
        }
    
        public bool SaveLineItem(LineItem lineItem) {
            if (lineItem.Id != null) { return false; }
            bool result = false;

            try
            {
                connection.Open();
                // AUGH!
                string query = $"insert into line_items (`name`, credit, debit) " +
                    $"values (\"{lineItem.Name}\", {lineItem.Credit}, {lineItem.Debit})";
                MySqlCommand command = new MySqlCommand(query, connection);
                
                int returnValue = command.ExecuteNonQuery(); // -1 is a fail!

                if (returnValue != -1) { result = true;}
            } catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            } finally
            {
                connection.Close(); 
            }

            return result;
        }
    }
}
