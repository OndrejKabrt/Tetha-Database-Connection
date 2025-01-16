using Tetha_Row_Gataway;

namespace Tetha_Row_Gataway
{
    public class BankAccount : IBaseClass
    {
        private int id;
        private int account_number;
        private float currency;
        private bool active;
        private int client_id;
        private int type_id;
        private int bank_id;

        public int ID { get => id; set => id = value; }
        public int AccountNumber { get => account_number; set => account_number = value; }
        public float Currency { get => currency; set => currency = value; }
        public bool Active { get => active; set => active = value; }
        public int Client_id { get => client_id; set => client_id = value; }
        public int Type_id { get => type_id; set => type_id = value; }
        public int Bank_id { get => bank_id; set => bank_id = value; }

        public BankAccount(int id, int account_number, float currency, bool active, int client_id, int type_id, int bank_id)
        {
            this.id = id;
            this.account_number = account_number;
            this.currency = currency;
            this.active = active;
            this.client_id = client_id;
            this.type_id = type_id;
            this.bank_id = bank_id;
        }

        public BankAccount(int account_number, float currency, bool active, int client_id, int type_id, int bank_id)
        {
            this.account_number = account_number;
            this.currency = currency;
            this.active = active;
            this.client_id = client_id;
            this.type_id = type_id;
            this.bank_id = bank_id;
        }

        public BankAccount()
        {
        }

        public override string? ToString()
        {
            return account_number +" "+currency+ " "+active;
        }


    }
}
