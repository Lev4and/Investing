namespace Investing.Core.Abstracts
{
    public interface IBuilder<TOutput>
    {
        TOutput Build();
    }
}
