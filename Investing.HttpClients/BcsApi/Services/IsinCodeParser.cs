using System.Text.RegularExpressions;

namespace Investing.HttpClients.BcsApi.Services
{
    public class IsinCodeParser
    {
        public static string? Parse(string content)
        {
            if (string.IsNullOrEmpty(content)) throw new ArgumentNullException(nameof(content));

            var pattern = @"\""isinCode\"":\""((\\""|[^""])*)\""";
            var matches = Regex.Match(content, pattern);

            return matches.Groups.Values.ElementAtOrDefault(1)?.Value ?? null;
        }
    }
}
