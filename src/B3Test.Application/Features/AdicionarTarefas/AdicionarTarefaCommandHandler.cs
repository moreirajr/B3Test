using B3Test.Domain.Entities;
using B3Test.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace B3Test.Application.Features.AdicionarTarefas
{
    public class AdicionarTarefaCommandHandler : IRequestHandler<AdicionarTarefaCommand, AdicionarTarefaResponse>
    {
        private readonly ILogger<AdicionarTarefaCommandHandler> _logger;
        private readonly ITarefaRepository _tarefaRepository;

        public AdicionarTarefaCommandHandler(ILogger<AdicionarTarefaCommandHandler> logger, ITarefaRepository tarefaRepository)
        {
            _logger = logger;
            _tarefaRepository = tarefaRepository;
        }

        private AdicionarTarefaResponse ErrorResult(IEnumerable<string> errors)
        {
            var errorResult = new AdicionarTarefaResponse();
            errorResult.Errors = errors;
            return errorResult;
        }

        public async Task<AdicionarTarefaResponse> Handle(AdicionarTarefaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new AdicionarTarefaCommandValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                    return ErrorResult(errors);
                }

                var tarefa = Tarefa.Create(request.Descricao!, request.Data, request.Status);

                await _tarefaRepository.Adicionar(tarefa);
                await _tarefaRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

                return new AdicionarTarefaResponse
                {
                    Id = tarefa.Id,
                    Descricao = tarefa.Descricao,
                    Status = tarefa.Status
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Falha ao salvar tarefa");
            }

            return null!;
        }
    }
}
