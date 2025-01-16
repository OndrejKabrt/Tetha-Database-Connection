using MySql.Data.MySqlClient;

using Tetha_Row_Gataway;

namespace Tetha_Row_Gataway
{
    public class AccountTypeRowGateway : IRepozitoryRG<AccountType>
    {
        public void DeleteByID(int id)
        {
            MySqlConnection conn = DatabaseSingleton.GetInstance();
            using (MySqlCommand command = new MySqlCommand("DELETE FROM account_type WHERE id = ?", conn))
            {
                command.Parameters.AddWithValue("?", id);
                command.ExecuteNonQuery();
                id = 0;
            }
        }

        public AccountType GetByID(int id)
        {
            AccountType account_type = null;
            MySqlConnection conn = DatabaseSingleton.GetInstance();

            using (MySqlCommand command = new MySqlCommand("Select * from account_type WHERE id = @id", conn))
            {
                command.Parameters.Add(new MySqlParameter("@id", id));
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    account_type = new AccountType
                    {
                        ID = Convert.ToInt32(reader[0].ToString),
                        Type_name = (Type)Enum.Parse(typeof(Type), reader[1].ToString(), true),
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

            using (MySqlCommand command = new MySqlCommand("UPDATE bank Set interest = @interest Where id = @id, type_name = @type_name", conn))
            {
                command.Parameters.AddWithValue("@id", element.ID);
                command.Parameters.AddWithValue("@type_name", element.Type_name);
                command.Parameters.AddWithValue("@interest", element.Interest);

                command.ExecuteNonQuery();
            }
        }
    }
}
