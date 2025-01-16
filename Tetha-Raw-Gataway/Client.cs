using Tetha_Row_Gataway;

namespace Tetha_Row_Gataway
{
    public class Client :IBaseClass
    {
        private int id;
        private string name;
        private string surname;
        private string phone_number;
        private string email;
        private string birth_number;
        private string birth_date;

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Phone_number { get => phone_number; set => phone_number = value; }
        public string Email { get => email; set => email = value; }
        public string Birth_number { get => birth_number; set => birth_number = value; }
        public string Birth_date { get => birth_date; set => birth_date = value; }

        public Client(int id, string name, string surname, string phone_number, string email, string birth_number, string birth_date)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.phone_number = phone_number;
            this.email = email;
            this.birth_number = birth_number;
            this.birth_date = birth_date;
        }

        public Client(string name, string surname, string phone_number, string email, string birth_number, string birth_date, int iD)
        {
            this.name = name;
            this.surname = surname;
            this.phone_number = phone_number;
            this.email = email;
            this.birth_number = birth_number;
            this.birth_date = birth_date;
            ID = iD;
        }

        public Client()
        {
        }

        public override string? ToString()
        {
            return id +" "+name + " "+ surname + " "+ phone_number +" "+email +" "+ birth_number+" "+birth_date;
        }
    }
}
