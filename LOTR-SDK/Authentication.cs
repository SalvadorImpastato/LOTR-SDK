namespace LOTR_SDK
{
    public static class Authentication
    {
        private static string _apiKey = string.Empty;

        public static string APIKey { get => _apiKey; set => _apiKey = value; }
    }
}