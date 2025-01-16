using MySql.Data.MySqlClient;
using Tetha_Row_Gataway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Tetha_Row_Gataway
{
    public class ClientDAO : IRepozitoryDAO<Client>

    {
        public void Delete(Client element)
        {
            MySqlConnection conn = DatabaseSingleton.GetInstance();
            using (MySqlCommand command = new MySqlCommand("DELETE FROM client WHERE id = @id and birth_number = @Birth_number", conn))
            {
                command.Parameters.AddWithValue("@id", element.ID);
                command.Parameters.AddWithValue("@Birth_number", element.Birth_number);
                command.ExecuteNonQuery();
                element.ID = 0;
            }
        }

        public IEnumerable<Client> GetAll()
        {
            MySqlConnection conn = DatabaseSingleton.GetInstance();

            using (MySqlCommand command = new MySqlCommand("Select * from client", conn))
            {
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Client client = new Client
                    {
                        ID = Convert.ToInt32(reader[0].ToString()), // Corrected usage of ToString()
                        Name = reader[1].ToString(),
                        Surname = reader[2].ToString(),
                        Phone_number = reader[3].ToString(),
                        Email = reader[4].ToString(),
                        Birth_number = reader[5].ToString(),
                        Birth_date = reader[6].ToString()
                    };
                    yield return client;
                }
                reader.Close();
            }
        }

        public Client GetByID(int id)
        {
            Client client = null;
            MySqlConnection conn = DatabaseSingleton.GetInstance();

            using (MySqlCommand command = new MySqlCommand("Select * from client WHERE id = @id", conn))
            {
                command.Parameters.Add(new MySqlParameter("id", id));
                MySqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    client = new Client
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        Name = reader[1].ToString(),
                        Surname = reader[2].ToString(),
                        Phone_number = reader[3].ToString(),
                        Email = reader[4].ToString(),
                        Birth_number = reader[5].ToString(),
                        Birth_date = reader[6].ToString()
                    };
                }
                reader.Close();
                return client;
            }
        }

        public void Save(Client element)
        {
            MySqlConnection conn = DatabaseSingleton.GetInstance();
            MySqlCommand command = null;

            if(element.ID < 1)
            {
                using (command = new MySqlCommand("Insert INTO client Values (@id, @name, @surname, @phone_number, @email, @birth_number, @birth_date)", conn))
                {
                    command.Parameters.AddWithValue("@id", element.ID);
                    command.Parameters.AddWithValue("@name", element.Name);
                    command.Parameters.AddWithValue("@surname", element.Surname);
                    command.Parameters.AddWithValue("@email", element.Email);
                    command.Parameters.AddWithValue("@birth_number", element.Birth_number);
                    command.Parameters.AddWithValue("@birth_date", element.Birth_date);
                    command.ExecuteNonQuery();
                    command.CommandText = "Select @@Identity";
                    element.ID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            else
            {
                using (command = new MySqlCommand("UPDATE client Set name = @name, surname = @surname, phone_number = @phone_number, email = @email," +
                    " birth_number = @birthnumber, birth_date = @birth_date Where id = @id", conn))
                {
                    command.Parameters.AddWithValue("@id", element.ID);
                    command.Parameters.AddWithValue("@name", element.Name);
                    command.Parameters.AddWithValue("@surname", element.Surname);
                    command.Parameters.AddWithValue("@email", element.Email);
                    command.Parameters.AddWithValue("@birth_number", element.Birth_number);
                    command.Parameters.AddWithValue("@birth_date", element.Birth_date);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
