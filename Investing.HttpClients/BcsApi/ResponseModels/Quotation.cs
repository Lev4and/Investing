namespace Investing.HttpClients.BcsApi.ResponseModels
{
    public class Quotation
    {
        public double Low { get; }

        public double High { get; }

        public double Open { get; }

        public double Close { get; }

        public double Volume { get; }

        public DateTime Time { get; }

        public Quotation(double low, double high, double open, double close, double volume, long timeUnix)
        {
            Low = low; 
            High = high; 
            Open = open;
            Close = close;
            Volume = volume;
            Time = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(timeUnix);
        }
    }
}
