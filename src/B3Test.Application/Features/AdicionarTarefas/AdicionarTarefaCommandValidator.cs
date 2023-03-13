using FluentValidation;

namespace B3Test.Application.Features.AdicionarTarefas
{
    internal class AdicionarTarefaCommandValidator : AbstractValidator<AdicionarTarefaCommand>
    {
        public AdicionarTarefaCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull()
                .WithMessage("Campo 'data' obrigatório.");

            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("Campo 'descricao' obrigatório.");
        }
    }
}
