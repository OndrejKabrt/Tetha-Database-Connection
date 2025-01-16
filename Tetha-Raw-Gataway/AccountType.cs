
using Tetha_Row_Gataway;

namespace Tetha_Row_Gataway
{
    public class AccountType : IBaseClass
    {
        private int id;
        private Type type_name;
        private double interest;

        public int ID { get => id; set => id = value; }
        public Type Type_name { get => type_name; set => type_name = value; }
        public double Interest { get => interest; set => interest = value; }

        public AccountType(int id, Type type_name, double interest)
        {
            this.id = id;
            this.type_name = type_name;
            this.interest = interest;
        }

        public AccountType(Type type_name, double interest)
        {
            this.type_name = type_name;
            this.interest = interest;
        }

        public AccountType()
        {
        }

        public override string? ToString()
        {
            return type_name + " " + interest;
        }
    }
}
