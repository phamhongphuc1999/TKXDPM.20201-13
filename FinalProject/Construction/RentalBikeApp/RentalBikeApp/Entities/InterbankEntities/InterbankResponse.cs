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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorCode"></param>
        public InterbankResponse(string errorCode)
        {
            this.errorCode = errorCode;
        }
    }
}
