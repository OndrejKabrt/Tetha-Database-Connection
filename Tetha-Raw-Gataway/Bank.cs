using Tetha_Row_Gataway;

namespace Tetha_Row_Gataway
{
    public class Bank : IBaseClass
    {
        private int id;
        private string bank_name;
        private string bank_code;
        private string ICO;

        public int ID { get => id; set => id = value; }
        public string Bank_name { get => bank_name; set => bank_name = value; }
        public string Bank_code { get => bank_code; set => bank_code = value; }
        public string Ico { get => ICO; set => ICO = value; }

        public Bank(int id, string bank_name, string bank_code, string iCO)
        {
            this.id = id;
            this.bank_name = bank_name;
            this.bank_code = bank_code;
            ICO = iCO;
        }

        public Bank(string bank_name, string bank_code, string iCO)
        {
            this.bank_name = bank_name;
            this.bank_code = bank_code;
            ICO = iCO;
        }

        public Bank()
        {
        }

        public override string? ToString()
        {
            return id +" "+ bank_name+" "+bank_code+" "+ICO;
        }
    }
}
