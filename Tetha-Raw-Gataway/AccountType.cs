using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TethaRawGataway;

namespace Tetha_Raw_Gataway
{
    public class AccountType : IBaseClass
    {
        private int id;
        private string type_name;
        private double interest;

        public int ID { get => id; set => id = value; }
        public string Type_name { get => type_name; set => type_name = value; }
        public double Interest { get => interest; set => interest = value; }

        public AccountType(int id, string type_name, double interest)
        {
            this.id = id;
            this.type_name = type_name;
            this.interest = interest;
        }

        public AccountType(string type_name, double interest)
        {
            this.type_name = type_name;
            this.interest = interest;
        }

        public AccountType()
        {
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
