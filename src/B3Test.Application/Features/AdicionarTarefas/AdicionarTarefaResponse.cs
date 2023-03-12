using B3Test.Shared.Enums;

namespace B3Test.Application.Features.AdicionarTarefas
{
    public class AdicionarTarefaResponse
    {
        public Guid Id { get; set; }
        public string? Descricao { get; set; }
        public EStatusTarefa Status { get; set; }
    }
}
