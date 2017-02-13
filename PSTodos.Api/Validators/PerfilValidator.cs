using FluentValidation;
using PSTodos.Application.ViewModels;

namespace PSTodos.Api.Validators
{
    public class PerfilValidator : AbstractValidator<PerfilViewModel>
    {
        public PerfilValidator()
        {
            RuleFor(x => x.Nome).NotNull().WithMessage("O campo Nome é obrigatório.");
        }
    }
}