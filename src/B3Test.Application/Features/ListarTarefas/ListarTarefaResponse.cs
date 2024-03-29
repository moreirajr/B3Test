﻿using B3Test.Shared.Enums;

namespace B3Test.Application.Features.ListarTarefas
{
    public class ListarTarefaResponse
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public string? Descricao { get; set; }
        public EStatusTarefa Status { get; set; }
        public string? DescricaoStatus { get; set; }
    }
}
