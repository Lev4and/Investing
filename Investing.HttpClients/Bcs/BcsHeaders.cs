namespace Investing.HttpClients.Bcs
{
    public class BcsHeaders
    {
        public static Dictionary<string, string> DefaultHeaders => new Dictionary<string, string>()
        {
            { "sec-ch-ua", "\"Chromium\";v=\"106\", \"Yandex\";v=\"22\", \"Not;A=Brand\";v=\"99\"" },
            { "sec-ch-ua-mobile", "?0" },
            { "sec-ch-ua-platform", "\"Windows\"" },
            { "user-agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/106.0.0.0 YaBrowser/22.11.0.2423 Yowser/2.5 Safari/537.36" }
        };
    }
}
