using MySql.Data.MySqlClient;
using Tetha_Row_Gataway;

namespace Tetha_Row_Gataway
{
    public class TransactionDAO : IRepozitoryDAO<Transaction>
    {
        public void Delete(Transaction element)
        {
            MySqlConnection conn = DatabaseSingleton.GetInstance();
            using (MySqlCommand command = new MySqlCommand("DELETE FROM transaction WHERE id = ?", conn))
            {
                command.Parameters.AddWithValue("?", element.ID);
                command.ExecuteNonQuery();
                element.ID = 0;
            }
        }

        public IEnumerable<Transaction> GetAll()
        {
            MySqlConnection conn = DatabaseSingleton.GetInstance();

            using (MySqlCommand command = new MySqlCommand("Select * from transaction", conn))
            {
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Transaction transaction = new Transaction
                    {
                        ID = Convert.ToInt32(reader[0].ToString),
                        Cash_amount = Convert.ToSingle(reader[1].ToString),
                        Sender_account_id = Convert.ToInt32(reader[2].ToString),
                        Reciever_account_id = Convert.ToInt32(reader[3].ToString)
                    };
                    yield return transaction;
                }
                reader.Close();
            }
        }

        public Transaction GetByID(int id)
        {
            Transaction transaction = null;
            MySqlConnection conn = DatabaseSingleton.GetInstance();

            using (MySqlCommand command = new MySqlCommand("Select * from transaction WHERE id = @id", conn))
            {
                command.Parameters.Add(new MySqlParameter("id", id));
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    transaction = new Transaction
                    {
                        ID = Convert.ToInt32(reader[0].ToString),
                        Cash_amount = Convert.ToSingle(reader[1].ToString),
                        Sender_account_id = Convert.ToInt32(reader[2].ToString),
                        Reciever_account_id = Convert.ToInt32(reader[3].ToString)
                    };
                }
                reader.Close();
                return transaction;
            }
        }

        public void Save(Transaction element)
        {
            MySqlConnection conn = DatabaseSingleton.GetInstance();
            MySqlCommand command = null;

            if (element.ID < 1)
            {
                using (command = new MySqlCommand("Insert INTO transaction Values (@id, @cash_amount, @sender_account_id, @reciever_account_id)", conn))
                {
                    command.Parameters.AddWithValue("@id", element.ID);
                    command.Parameters.AddWithValue("@cash_amount", element.Cash_amount);
                    command.Parameters.AddWithValue("@sender_account_id", element.Sender_account_id);
                    command.Parameters.AddWithValue("@reciever_account_id", element.Reciever_account_id);
                    command.ExecuteNonQuery();
                    command.CommandText = "Select @@Identity";
                    element.ID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            else
            {
                using (command = new MySqlCommand("UPDATE transaction Set cash_amount = @cash_amount, sender_account_id = @sender_account_id, reciever_account_id = @reciever_account_id, Where id = @id", conn))
                {
                    command.Parameters.AddWithValue("@id", element.ID);
                    command.Parameters.AddWithValue("@name", element.Cash_amount);
                    command.Parameters.AddWithValue("@surname", element.Sender_account_id);
                    command.Parameters.AddWithValue("@email", element.Reciever_account_id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
