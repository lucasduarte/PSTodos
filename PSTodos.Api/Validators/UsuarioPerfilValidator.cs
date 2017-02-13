using FluentValidation;
using PSTodos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSTodos.Api.Validators
{
    public class UsuarioPerfilValidator : AbstractValidator<UsuarioPerfilViewModel>
    {
        public UsuarioPerfilValidator()
        {
            RuleFor(x => x.PerfilId).NotNull().WithMessage("O campo PerfilId é obrigatório.");
            RuleFor(x => x.UsuarioId).NotNull().WithMessage("O campo UsuarioId é obrigatório.");
        }
    }
}