namespace Investing.Core.Domain.Entities
{
    public class Ohlc
    {
        public decimal Low { get; }

        public decimal Open { get; }

        public decimal High { get; }

        public decimal Close { get; }

        public decimal Volume { get; }

        public DateTime ClosedAt { get; }

        public Ohlc(decimal low, decimal open, decimal high, decimal close, decimal volume, DateTime closedAt) 
        {
            if (low > high) throw new ArgumentOutOfRangeException(nameof(low));
            if (open < low || open > high) throw new ArgumentOutOfRangeException(nameof(open));
            if (high < low) throw new ArgumentOutOfRangeException(nameof(high));
            if (close < low || close > high) throw new ArgumentOutOfRangeException(nameof(close));
            if (volume < 0) throw new ArgumentOutOfRangeException(nameof(volume));

            Low = low;
            Open = open; 
            High = high;
            Close = close;
            Volume = volume;
            ClosedAt = closedAt;
        }
    }
}
