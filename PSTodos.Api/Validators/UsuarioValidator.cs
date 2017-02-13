using FluentValidation;
using PSTodos.Application.ViewModels;

namespace PSTodos.Api.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioViewModel>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Login).NotNull().WithMessage("O campo Login é obrigatório.");
            RuleFor(x => x.Email).NotNull().WithMessage("O campo Email é obrigatório.");
            RuleFor(x => x.Senha).NotNull().WithMessage("O campo Senha é obrigatório.");
        }
    }
}