using FluentValidation;
using TPV.Models;

namespace TPV.Infrastructure.Validation
{
    public class PuestoValidator : AbstractValidator<Puesto>
    {
        public PuestoValidator()
        {
            RuleFor(p => p.Nombre)
                .Matches(@"/[a-zA-Z ]+\w/g").WithMessage("Solo letras.")
                .NotNull().WithMessage("Requerido.")
                .NotEmpty().WithMessage("Requerido.")
                .Length(4, 32).WithMessage("Debe tener entre 4 y 32 letras.");

            RuleFor(p => p.Descripcion)
                .Matches(@"/[a-zA-Z ]+\w/g").WithMessage("Solo letras.")
                .NotNull().WithMessage("Requerido.")
                .NotEmpty().WithMessage("Requerido.")
                .Length(8, 128).WithMessage("Debe tener entre 8 y 128 letras.");

            RuleFor(p => p.Funciones)
                .NotNull().WithMessage("Requerido.")
                .NotEmpty().WithMessage("Requerido.")
                .Length(8, 254).WithMessage("Debe tener entre 8 y 254 letras.");
        }
    }
}