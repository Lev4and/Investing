using Investing.HttpClients.Resource.Bcs;
using Investing.HttpClients.Resource.Import;

namespace Investing.HttpClients.Resource
{
    public class ResourceHttpContext : IResourceHttpContext
    {
        public IBcsHttpContext Bcs => new BcsHttpContext();

        public IImportHttpContext Import => new ImportHttpContext();
    }
}
