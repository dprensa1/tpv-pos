using FluentValidation;
using TPV.Models;

namespace TPV.Infrastructure.Validation
{
    public class AccesoValidator : AbstractValidator<Acceso>
    {
        public AccesoValidator()
        {
            RuleFor(a => a.Nombre)
                .Matches(@"^[a-zA-Z ]+\w$").WithMessage("Solo letras.")
                .NotNull().WithMessage("Requerido.")
                .NotEmpty().WithMessage("Requerido.")
                .Length(4, 16).WithMessage("Debe tener entre 4 y 16 letras.");

            RuleFor(a => a.Descripcion)
                .Matches(@"^[a-zA-Z ]+\w$").WithMessage("Solo letras.")
                .NotNull().WithMessage("Requerida.")
                .NotEmpty().WithMessage("Requerida.")
                .Length(128).WithMessage("Maximo 128 carecteres.");

            RuleFor(a => a.Rutas)
                .NotNull().WithMessage("Requiere al menos un Acceso")
                .NotEmpty().WithMessage("Requere al menos un Acceso");
        }

    }
}