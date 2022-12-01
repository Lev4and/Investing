namespace Investing.HttpClients.BcsApi
{

    public class BcsApiHeaders
    {
        public static Dictionary<string, string> DefaultHeaders => new Dictionary<string, string>()
        {
            { "accept", "application/json, text/plain, */*" },
            { "accept-encoding", "gzip, deflate, br" },
            { "accept-language", "ru,en;q=0.9" },
            { "sec-ch-ua", "\"Chromium\";v=\"106\", \"Yandex\";v=\"22\", \"Not;A=Brand\";v=\"99\"" },
            { "sec-ch-ua-mobile", "?0" },
            { "sec-ch-ua-platform", "\"Windows\"" },
            { "sec-fetch-dest", "empty" },
            { "sec-fetch-mode", "cors" },
            { "sec-fetch-site", "same-site" },
            { "user-agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) " +
                "Chrome/106.0.0.0 YaBrowser/22.11.0.2423 Yowser/2.5 Safari/537.36" }
        };
    }
}
