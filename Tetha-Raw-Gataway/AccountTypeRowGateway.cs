using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TethaRawGataway;

namespace Tetha_Raw_Gataway
{
    public class AccountTypeRowGateway : IRepozitoryRG<AccountType>
    {
        public void DeleteByID(AccountType element)
        {
            MySqlConnection conn = DatabaseSingleton.GetInstance();
            using (MySqlCommand command = new MySqlCommand("DELETE FROM account_type WHERE id = ?", conn))
            {
                command.Parameters.AddWithValue("?", element.ID);
                command.ExecuteNonQuery();
                element.ID = 0;
            }
        }

        public AccountType GetByID(int id)
        {
            AccountType account_type = null;
            MySqlConnection conn = DatabaseSingleton.GetInstance();

            using (MySqlCommand command = new MySqlCommand("Select * from account_type WHERE id = @id", conn))
            {
                command.Parameters.Add(new MySqlParameter("id", id));
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    account_type = new AccountType
                    {
                        ID = Convert.ToInt32(reader[0].ToString),
                        Type_name = reader[1].ToString(),
                        Interest = Convert.ToDouble(reader[2].ToString())
                    };
                }
                reader.Close();
                return account_type;
            }
        }

        public void InsertInto(AccountType element)
        {
            MySqlConnection conn = DatabaseSingleton.GetInstance();

            using (MySqlCommand command = new MySqlCommand("Insert INTO account_type Values (@type_name, @interest)", conn))
            {
                command.Parameters.AddWithValue("@bank_name", element.Type_name);
                command.Parameters.AddWithValue("@bank_code", element.Interest);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateByID(AccountType element)
        {
            MySqlConnection conn = DatabaseSingleton.GetInstance();

            using (MySqlCommand command = new MySqlCommand("UPDATE bank Set type_name = @type_name, interest = @interest Where id = @id", conn))
            {
                command.Parameters.AddWithValue("@id", element.ID);
                command.Parameters.AddWithValue("@type_name", element.Type_name);
                command.Parameters.AddWithValue("@interest", element.Interest);

                command.ExecuteNonQuery();
            }
        }
    }
}
