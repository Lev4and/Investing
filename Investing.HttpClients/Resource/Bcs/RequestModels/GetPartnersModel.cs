namespace Investing.HttpClients.Resource.Bcs.RequestModels
{
    public class GetPartnersModel
    {
        public int Offset { get; }

        public GetPartnersModel(int offset = 0)
        {
            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

            Offset = offset;
        }
    }
}
