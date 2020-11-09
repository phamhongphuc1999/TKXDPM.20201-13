using System;
using TestAPI.Entity;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestAPI
{
    [Serializable]
    public class ABC
    {
        public string secretKey { get; set; }
        public Transaction transaction { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var abc = new ABC
            {
                secretKey = Config.KEY.SECRET_KEY,
                transaction = new Transaction
                {
                    command = Config.COMMAND.PAY,
                    cardCode = Config.CARD_INFO.CARD_CODE,
                    owner = Config.CARD_INFO.OWER,
                    cvvCode = Config.CARD_INFO.CVV,
                    dateExpired = Config.CARD_INFO.DATE_EXPIRED,
                    transactionContent = "Thanh toan",
                    amount = 100
                }
            };
            string hash = Utility.GenerateKey(abc);

            var body = new
            {
                version = "1.0.1",
                transaction = new
                {
                    cardCode = Config.CARD_INFO.CARD_CODE,
                    owner = Config.CARD_INFO.OWER,
                    cvvCode = Config.CARD_INFO.OWER,
                    dateExpired = Config.CARD_INFO.DATE_EXPIRED,
                    command = Config.COMMAND.PAY,
                    transactionContent = "Thanh toan",
                    amount = 100,
                    createdAt = Utility.ConvertDateToString(DateTime.Now)
                },
                appCode = Config.KEY.APP_CODE,
                hashCode = hash
            };
            Task<string> result = Utility.GetWebContent(Config.BASE_URL + "/api/card/processTransaction", HttpMethod.Patch, JsonConvert.SerializeObject(body));
            result.Wait();
            Console.WriteLine(result.Result);
            Console.WriteLine("==================");
        }
    }
}
