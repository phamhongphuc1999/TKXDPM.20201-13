namespace RentalBikeApp.Entities.APIEntities
{
    public class ProcessTransactionResponse
    {
        public string errorCode { get; set; }
        public TransactionInfo transaction { get; set; }
    }
}
