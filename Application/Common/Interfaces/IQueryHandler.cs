using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IQueryHandler<in T, TResult>
    {
        ValueTask<TResult> Handle(T query);
    }
}
