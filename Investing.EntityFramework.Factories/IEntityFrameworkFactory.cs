using Investing.Core.Abstracts;
using Investing.Core.Domain;

namespace Investing.EntityFramework.Factories
{
    public interface IEntityFrameworkFactory<TInput, TOutput> : IFactory<TInput, TOutput> where TOutput : EntityBase
    {

    }
}
