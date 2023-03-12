using B3Test.Shared.Enums;
using MediatR;

namespace B3Test.Application.Features.ListarTarefas
{
    public class ListarTarefaQuery : IRequest<IEnumerable<ListarTarefaResponse>>
    {
        public Guid? Id { get; set; }
        public string? Descricao { get; set; }
        public EStatusTarefa? Status { get; set; }

        public ListarTarefaQuery() { }

        public ListarTarefaQuery(ListarTarefaRequest request)
        {
            Id = request.Id;
            Descricao = request.Descricao;
            Status = request.Status;
        }
    }
}
