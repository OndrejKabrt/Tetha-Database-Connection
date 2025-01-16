
using Tetha_Row_Gataway;

namespace Tetha_Row_Gataway
{
    public class Transaction : IBaseClass
    {

        private int id;
        private float cash_amount;
        private int sender_account_id;
        private int reciever_account_id;

        public int ID { get => id; set => id = value; }
        public float Cash_amount { get => cash_amount; set => cash_amount = value; }
        public int Sender_account_id { get => sender_account_id; set => sender_account_id = value; }

        public int Reciever_account_id { get => reciever_account_id; set => reciever_account_id = value; }

        public Transaction(float cash_amount, int sender_account_id, int reciever_account_id)
        {
            this.cash_amount = cash_amount;
            this.sender_account_id = sender_account_id;
            this.reciever_account_id = reciever_account_id;
        }

        public Transaction(int iD, float cash_amount, int sender_account_id, int reciever_account_id)
        {
            this.ID = iD;
            this.cash_amount = cash_amount;
            this.sender_account_id = sender_account_id;
            this.reciever_account_id = reciever_account_id;
        }

        public Transaction()
        {
        }

        public override string? ToString()
        {
            return cash_amount+" "+ sender_account_id+" "+ reciever_account_id;
        }
    }
}
