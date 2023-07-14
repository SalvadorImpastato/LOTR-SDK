namespace LOTR_SDK
{
    public class Quote
    {
        public static async Task<string> Call(string quoteId = null, int pageSelection = 1, int limitAmount = 50, int offSet = 0, string sortBy = null, string sortOrder = null, string match = null, string include = null, string exists = null, string regex = null, string greaterLessThanEqual = null)
        {
            string requestUrl = endpoints.baseUrl + endpoints.quote;
            if (quoteId != null)
            {
                requestUrl += "/" + quoteId;
            }

            string query = Utilities.BuildQuery(pageSelection, limitAmount, offSet, sortBy, sortOrder, match, include, exists, regex, greaterLessThanEqual);
            requestUrl += query;

            CallToLotrAPI lotr = new CallToLotrAPI();
            return await lotr.CallLotrAPI(requestUrl);
        }
    }
}