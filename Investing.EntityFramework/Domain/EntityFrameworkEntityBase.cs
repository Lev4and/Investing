using Investing.Core.Domain;
using Investing.EntityFramework.Abstracts;

namespace Investing.EntityFramework.Domain
{
    public abstract class EntityFrameworkEntityBase : EntityBase
    {
        public abstract Task ImportAsync(IImporterVisitor visitor);
    }
}
