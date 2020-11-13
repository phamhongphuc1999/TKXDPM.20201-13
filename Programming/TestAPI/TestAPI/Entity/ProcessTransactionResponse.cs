namespace TestAPI.Entity
{
    public class TransactionResponse
    {
        public string command { get; set; }
        public string cardCode { get; set; }
        public string owner { get; set; }
        public string cvvCode { get; set; }
        public string dateExpired { get; set; }
        public string transactionContent { get; set; }
        public int amount { get; set; }
        public string createdAt { get; set; }
        //public string transactionId { get; set; }
    }

    public class ProcessTransactionResponse
    {
        public string errorCode { get; set; }
        public Transaction transaction { get; set; }
    }
}
