using FluentValidation;
using TPV.Models;

namespace TPV.Infrastructure.Validation
{
    public class RolValidator : AbstractValidator<Rol>
    {
        public RolValidator()
        {
            RuleFor(a => a.Nombre)
                .Matches(@"/[a-zA-Z ]+\w/g").WithMessage("Solo letras.")
                .NotNull().WithMessage("Requerido.")
                .NotEmpty().WithMessage("Requerido.")
                .Length(4, 16).WithMessage("Debe tener entre 4 y 16 letras.");

            RuleFor(r => r.Descripcion)
                .Matches(@"/[a-zA-Z ]+\w/g").WithMessage("Solo letras.")
                .NotNull().WithMessage("Requerida.")
                .NotEmpty().WithMessage("Requerida.")
                .Length(4, 128).WithMessage("Debe tener entre 4 y 127 letras.");
        }
    }
}