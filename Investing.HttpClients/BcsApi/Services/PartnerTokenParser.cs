using System.Text.RegularExpressions;

namespace Investing.HttpClients.BcsApi.Services
{
    public class PartnerTokenParser
    {
        public static string? Parse(string content)
        {
            if (string.IsNullOrEmpty(content)) throw new ArgumentNullException(nameof(content));

            var pattern = @"token:""((\\""|[^""])*)""";
            var matches = Regex.Match(content, pattern);

            return matches.Groups.Values.ElementAtOrDefault(1)?.Value ?? null;
        }
    }
}
