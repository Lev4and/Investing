using Investing.Core.Abstracts;
using System.Text.RegularExpressions;

namespace Investing.HttpClients.BcsApi.Services
{
    public class PartnerTokenParser
    {
        public static string? Parse(string input)
        {
            if (string.IsNullOrEmpty(input)) throw new ArgumentNullException(nameof(input));

            var pattern = @"token:""((\\""|[^""])*)""";
            var matches = Regex.Match(input, pattern);

            return matches.Groups.Values.ElementAtOrDefault(1)?.Value ?? null;
        }
    }
}
