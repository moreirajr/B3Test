using B3Test.Domain.Entities;
using B3Test.Domain.Extensions;
using B3Test.Shared.Enums;
using System.Linq.Expressions;

namespace B3Test.Domain.Filters
{
    public class TarefasFilter
    {
        public static Expression<Func<Tarefa, bool>> CreateFilter(Guid? id, string? descricao, EStatusTarefa status)
        {
            var predicate = PredicateExtensions.True<Tarefa>();

            if (id != null && id != Guid.Empty)
                predicate = predicate.And(x => x.Id == id);
            if (!string.IsNullOrEmpty(descricao))
                predicate = predicate.And(x => x.Descricao == descricao);
            if (status != EStatusTarefa.Indefinido)
                predicate = predicate.And(x => x.Status == status);

            return predicate;
        }
    }
}
