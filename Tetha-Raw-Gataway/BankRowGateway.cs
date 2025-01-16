using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetha_Row_Gataway;

namespace Tetha_Row_Gataway
{
    public class BankRowGateway : IRepozitoryRG<Bank>
    {
        public void DeleteByID(int id)
        {
            MySqlConnection conn = DatabaseSingleton.GetInstance();
            using (MySqlCommand command = new MySqlCommand("DELETE FROM bank WHERE id = ? and ", conn))
            {
                command.Parameters.AddWithValue("?", id);
                command.ExecuteNonQuery();
                id = 0;
            }
        }

        public Bank GetByID(int id)
        {
            Bank bank = null;
            MySqlConnection conn = DatabaseSingleton.GetInstance();

            using (MySqlCommand command = new MySqlCommand("Select * from bank WHERE id = @id", conn))
            {
                command.Parameters.Add(new MySqlParameter("@id", id));
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    bank = new Bank
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        Bank_name = reader[1].ToString(),
                        Bank_code = reader[2].ToString(),
                        Ico = reader[3].ToString()
                    };
                }
                reader.Close();
                return bank;
            }
        }

        public void InsertInto(Bank element)
        {
            MySqlConnection conn = DatabaseSingleton.GetInstance();
     
            using (MySqlCommand command = new MySqlCommand("Insert INTO bank Values (@bank_name, @bank_code, @ICO)", conn))
            {
                command.Parameters.AddWithValue("@bank_name", element.Bank_name);
                command.Parameters.AddWithValue("@bank_code", element.Bank_code);
                command.Parameters.AddWithValue("@ICO", element.Ico);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateByID(Bank element)
        {
            MySqlConnection conn = DatabaseSingleton.GetInstance();

            using (MySqlCommand command = new MySqlCommand("UPDATE bank Set bank_name = @bank_name, bank_code = @bank_code, ICO = @ICO Where id = @id", conn))
            {
                command.Parameters.AddWithValue("@id", element.ID);
                command.Parameters.AddWithValue("@bank_name", element.Bank_name);
                command.Parameters.AddWithValue("@bank_code", element.Bank_code);
                command.Parameters.AddWithValue("@ICO", element.Ico);
                
                command.ExecuteNonQuery();
            }
        }
    }
}
