namespace RentalBikeApp.Entities.InterbankEntities
{
    /// <summary>
    /// representing response from interbank
    /// </summary>
    public class InterbankResponse
    {
        /// <summary>
        /// error code of response
        /// </summary>
        public string errorCode { get; protected set; }
    }
}
