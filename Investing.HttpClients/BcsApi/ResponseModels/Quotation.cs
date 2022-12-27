namespace Investing.HttpClients.BcsApi.ResponseModels
{
    public class Quotation
    {
        public decimal Low { get; }

        public decimal High { get; }

        public decimal Open { get; }

        public decimal Close { get; }

        public decimal Volume { get; }

        public DateTime Time { get; }

        public Quotation(decimal low, decimal high, decimal open, decimal close, decimal volume, long timeUnix)
        {
            Low = low; 
            High = high; 
            Open = open;
            Close = close;
            Volume = volume;
            Time = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timeUnix);
        }
    }
}
