namespace LOTR_SDK
{
    public class Setup
    {
        private static string _logFilePath = string.Empty;

        public static string logFilePath { get => _logFilePath; set => _logFilePath = value; }

        public static void SetLogFilePath(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                logFilePath = filePath + "/log.txt";

                // Check if log.txt file exists, create it if not
                if (!File.Exists(logFilePath))
                {
                    using (StreamWriter writer = File.CreateText(logFilePath))
                    {
                        writer.WriteLine($"Log file created on {DateTime.Now}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid log file path.");
            }
        }

        public static void SetAPIKey(string apiKey)
        {
            Authentication.APIKey = apiKey;
        }
    }
}