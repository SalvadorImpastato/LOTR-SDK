using System.Text;

namespace LOTR_SDK
{
    internal class Utilities
    {
        public static string BuildQuery(int pageSelection, int limitAmount, int offSet, string sortBy, string sortOrder, string match, string include, string exists, string regex, string greaterLessThanEqual)
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append("?" + endpoints.page + pageSelection);
            queryBuilder.Append("&" + endpoints.limit + limitAmount);

            if (sortBy != null)
            {
                queryBuilder.Append("&" + endpoints.offSet + limitAmount);
            }

            if (sortBy != null)
            {
                queryBuilder.Append("&" + "sort=" + sortBy);
            }

            if (sortOrder != null)
            {
                queryBuilder.Append(":" + sortOrder);
            }

            if (match != null)
            {
                queryBuilder.Append("&" + match);
            }

            if (include != null)
            {
                queryBuilder.Append("&" + include);
            }

            if (exists != null)
            {
                queryBuilder.Append("&" + exists);
            }

            if (regex != null)
            {
                string regexQuery = ConvertRegex(regex);
                queryBuilder.Append($"&{regexQuery}");
            }

            if (greaterLessThanEqual != null)
            {
                queryBuilder.Append("&" + greaterLessThanEqual);
            }

            return queryBuilder.ToString();
        }

        public static string ConvertRegex(string regexInput)
        {
            string[] parts = regexInput.Split(',');
            StringBuilder queryBuilder = new StringBuilder();

            if (parts.Length > 0)
            {
                queryBuilder.Append($"{parts[0]}=/{parts[1]}/i");

                for (int i = 2; i < parts.Length; i++)
                {
                    queryBuilder.Append($",{parts[i]}");
                }
            }

            return queryBuilder.ToString();
        }
    }
}