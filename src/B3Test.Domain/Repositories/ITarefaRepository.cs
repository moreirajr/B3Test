using B3Test.Domain.Entities;
using B3Test.Domain.SeedWork;
using System.Linq.Expressions;

namespace B3Test.Domain.Repositories
{
    public interface ITarefaRepository
    {
        IUnitOfWork UnitOfWork { get; }
        Task Adicionar(Tarefa tarefa, CancellationToken cancellationToken = default);
        void Atualizar(Tarefa tarefa);
        Task<IEnumerable<Tarefa>> Listar(Expression<Func<Tarefa, bool>>? predicate = null, CancellationToken cancellationToken = default);
    }
}
