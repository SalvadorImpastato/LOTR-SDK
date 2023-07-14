using System.Net;

namespace LOTR_SDK
{
    internal class CallToLotrAPI
    {
        // The following method takes the completed request URL and makes the call to the LOTR API
        public async Task<string> CallLotrAPI(string requestUrl)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Authentication.APIKey}");

                HttpResponseMessage response = await httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    LogToLogFile(requestUrl, response.StatusCode, responseBody); // Save request URL, response status code, and response body to designated log file
                    return responseBody;
                }
                else
                {
                    LogToLogFile(requestUrl, response.StatusCode, $"Error: {response.StatusCode}"); // Save request URL, response status code, and error message to designated log file
                    return $"Error: {response.StatusCode}";
                }
            }
        }

        private void LogToLogFile(string requestUrl, HttpStatusCode statusCode, string message)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(Setup.logFilePath))
                {
                    writer.WriteLine($"{DateTime.Now} - Request URL: {requestUrl}");
                    writer.WriteLine($"{DateTime.Now} - Status Code: {statusCode} - {message}");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur while logging
                Console.WriteLine($"Error occurred while logging to file: {ex.Message}");
            }
        }
    }
}