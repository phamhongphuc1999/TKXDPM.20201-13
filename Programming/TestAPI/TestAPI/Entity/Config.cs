namespace TestAPI.Entity
{
    public static class Config
    {
        public const string BASE_URL = " https://ecopark-system-api.herokuapp.com";

        public static class COMMAND
        {
            public const string PAY = "pay";
            public const string REFUND = "refund";
        }

        public static class CARD_INFO
        {
            public const string CARD_CODE = "118609_group13_2020";
            public const string OWER = "Group 13";
            public const string CVV = "474";
            public const string DATE_EXPIRED = "1125";
        }

        public static class KEY
        {
            public const string APP_CODE = "Bi3TiyT5q00=";
            public const string SECRET_KEY = "B92s318KCwI=";
        }
    }
}
