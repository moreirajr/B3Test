using B3Test.Domain.Entities;
using B3Test.Domain.Filters;
using B3Test.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace B3Test.Application.Features.ListarTarefas
{
    public class ListarTarefaQueryHandler : IRequestHandler<ListarTarefaQuery, IEnumerable<ListarTarefaResponse>>
    {
        private readonly ILogger<ListarTarefaQueryHandler> _logger;
        private readonly ITarefaRepository _tarefaRepository;

        public ListarTarefaQueryHandler(ILogger<ListarTarefaQueryHandler> logger, ITarefaRepository tarefaRepository)
        {
            _logger = logger;
            _tarefaRepository = tarefaRepository;
        }

        private Expression<Func<Tarefa, bool>>? CreateFilter(ListarTarefaQuery request)
            => request == null ? null : TarefasFilter.CreateFilter(request.Id,
                request.Descricao,
                request.Status ?? Shared.Enums.EStatusTarefa.Indefinido);

        public async Task<IEnumerable<ListarTarefaResponse>> Handle(ListarTarefaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var filter = CreateFilter(request);
                var tarefas = await _tarefaRepository.Listar(filter);
                if (tarefas == null) return Enumerable.Empty<ListarTarefaResponse>();

                return tarefas.Select(x => new ListarTarefaResponse
                {
                    Id = x.Id,
                    Data = x.Data,
                    Descricao = x.Descricao,
                    Status = x.Status,
                    DescricaoStatus = x.Status.ToString()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Falha ao listar tarefas");
            }

            return Enumerable.Empty<ListarTarefaResponse>();
        }
    }
}
