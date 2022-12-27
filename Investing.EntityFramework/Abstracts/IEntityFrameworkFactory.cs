using Investing.Core.Abstracts;
using Investing.EntityFramework.Domain;

namespace Investing.EntityFramework.Abstracts
{
    public interface IEntityFrameworkFactory<TInput, TOutput> : IFactory<TInput, TOutput> where TOutput : EntityFrameworkEntityBase
    {

    }
}
