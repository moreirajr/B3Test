using B3Test.Shared.Enums;
using MediatR;

namespace B3Test.Application.Features.AdicionarTarefas
{
    public class AdicionarTarefaCommand : IRequest<AdicionarTarefaResponse>
    {
        public string? Descricao { get; set; }
        public DateTime Data { get; set; }
        public EStatusTarefa Status { get; set; }

        public AdicionarTarefaCommand() { }

        public AdicionarTarefaCommand(AdicionarTarefaRequest request)
        {
            Descricao = request.Descricao;
            Status = request.Status;
        }
    }
}
