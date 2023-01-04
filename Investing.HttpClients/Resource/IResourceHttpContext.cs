using Investing.HttpClients.Resource.Bcs;
using Investing.HttpClients.Resource.Import;

namespace Investing.HttpClients.Resource
{
    public interface IResourceHttpContext
    {
        IBcsHttpContext Bcs => new BcsHttpContext();

        IImportHttpContext Import => new ImportHttpContext();
    }
}
