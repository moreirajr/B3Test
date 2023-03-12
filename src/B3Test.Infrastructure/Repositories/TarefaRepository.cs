using B3Test.Domain.Entities;
using B3Test.Domain.Events;
using B3Test.Domain.Repositories;
using B3Test.Domain.SeedWork;
using B3Test.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace B3Test.Infrastructure.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly B3TestContext _context;

        public TarefaRepository(B3TestContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task Adicionar(Tarefa tarefa, CancellationToken cancellationToken = default)
        {
            tarefa.AddDomainEvent(new TarefaAdicionadaEvent(tarefa));
            await _context.AddAsync(tarefa);
        }

        public void Atualizar(Tarefa tarefa)
        {
            _context.Update(tarefa);
        }

        public async Task<IEnumerable<Tarefa>> Listar(Expression<Func<Tarefa, bool>>? predicate = null,
            CancellationToken cancellationToken = default)
        {
            if (predicate == null)
                return await _context.Tarefas.ToListAsync();

            return await _context.Tarefas.Where(predicate).ToListAsync();
        }
    }
}
