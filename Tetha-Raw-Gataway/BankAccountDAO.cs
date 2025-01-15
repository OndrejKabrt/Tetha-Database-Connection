using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TethaRawGataway;

namespace Tetha_Raw_Gataway
{
    public class BankAccountDAO : IRepozitoryDAO<BankAccount>
    {
        public void Delete(BankAccount element)
        {
            MySqlConnection conn = DatabaseSingleton.GetInstance();
            using (MySqlCommand command = new MySqlCommand("DELETE FROM bank_account WHERE id = ?", conn))
            {
                command.Parameters.AddWithValue("?", element.ID);
                command.ExecuteNonQuery();
                element.ID = 0;
            }
        }

        public IEnumerable<BankAccount> GetAll()
        {
            MySqlConnection conn = DatabaseSingleton.GetInstance();

            using (MySqlCommand command = new MySqlCommand("Select * from bank_account", conn))
            {
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BankAccount bank_account = new BankAccount
                    {
                        ID = Convert.ToInt32(reader[0].ToString),
                        AccountNumber = Convert.ToInt32(reader[1].ToString),
                        Currency = Convert.ToSingle(reader[2].ToString),
                        Active = Convert.ToBoolean(reader[3].ToString),
                        Client_id = Convert.ToInt32(reader[4].ToString),
                        Type_id = Convert.ToInt32(reader[5].ToString),
                        Bank_id = Convert.ToInt32(reader[6].ToString)
                    };
                    yield return bank_account;
                }
                reader.Close();
            }
        }

        public BankAccount GetByID(int id)
        {
            BankAccount bank_account = null;
            MySqlConnection conn = DatabaseSingleton.GetInstance();

            using (MySqlCommand command = new MySqlCommand("Select * from bank_account WHERE id = @id", conn))
            {
                command.Parameters.Add(new MySqlParameter("id", id));
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    bank_account = new BankAccount
                    {
                        ID = Convert.ToInt32(reader[0].ToString),
                        AccountNumber = Convert.ToInt32(reader[1].ToString),
                        Currency = Convert.ToSingle(reader[2].ToString),
                        Active = Convert.ToBoolean(reader[3].ToString),
                        Client_id = Convert.ToInt32(reader[4].ToString),
                        Type_id = Convert.ToInt32(reader[5].ToString),
                        Bank_id = Convert.ToInt32(reader[6].ToString)
                    };
                }
                reader.Close();
                return bank_account;
            }
        }

        public void Save(BankAccount element)
        {
            MySqlConnection conn = DatabaseSingleton.GetInstance();
            MySqlCommand command = null;

            if (element.ID < 1)
            {
                using (command = new MySqlCommand("Insert INTO bank_account Values (@id, @account_number, @currency, @active, @client_id, @type_id, @bank_id)", conn))
                {
                    command.Parameters.AddWithValue("@id", element.ID);
                    command.Parameters.AddWithValue("@account_number", element.AccountNumber);
                    command.Parameters.AddWithValue("@currency", element.Currency);
                    command.Parameters.AddWithValue("@active", element.Active);
                    command.Parameters.AddWithValue("@client_id", element.Client_id);
                    command.Parameters.AddWithValue("@type_id", element.Type_id);
                    command.Parameters.AddWithValue("@bank_id", element.Bank_id);
                    command.ExecuteNonQuery();
                    command.CommandText = "Select @@Identity";
                    element.ID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            else
            {
                using (command = new MySqlCommand("UPDATE bank_account Set account_number = @account_number, currency = @currency, active = @active, client_id = @client_id," +
                    " type_id = @type_id, bank_id = @bank_id Where id = @id", conn))
                {
                    command.Parameters.AddWithValue("@id", element.ID);
                    command.Parameters.AddWithValue("@account_number", element.AccountNumber);
                    command.Parameters.AddWithValue("@currency", element.Currency);
                    command.Parameters.AddWithValue("@active", element.Active);
                    command.Parameters.AddWithValue("@client_id", element.Client_id);
                    command.Parameters.AddWithValue("@type_id", element.Type_id);
                    command.Parameters.AddWithValue("@bank_id", element.Bank_id);
                    command.ExecuteNonQuery();
                }
            }
        }








    }
}
