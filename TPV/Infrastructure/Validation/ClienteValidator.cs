using FluentValidation;
using TPV.Models;

namespace TPV.Infrastructure.Validation
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(a => a.Nombre)
                .Matches(@"/[a-zA-Z ]+\w/g").WithMessage("Solo letras.")
                .NotNull().WithMessage("Requerido.")
                .NotEmpty().WithMessage("Requerido.")
                .Length(4, 64).WithMessage("Debe tener entre 4 y 64 letras.");

            RuleFor(a => a.Apellido)
                .Matches(@"/[a-zA-Z ]+\w/g").WithMessage("Solo letras.")
                .Length(4, 32).WithMessage("Debe tener entre 4 y 32 letras.");

            RuleFor(a => a.Identificacion)
                .NotNull().WithMessage("Requerida.")
                .NotEmpty().WithMessage("Requerida.")
                .Length(10, 16).WithMessage("Debe tener entre 10 y 16 caracteres.");

            RuleFor(a => a.Telefono)
                .Matches(@"^([0-9])+\w$").WithMessage("Solo numeros.")
                .NotNull().WithMessage("Requerido.")
                .NotEmpty().WithMessage("Requerido.")
                .Length(10, 10).WithMessage("Debe tener entre 10 numeros.");

            RuleFor(a => a.Direccion)
                .NotNull().WithMessage("Requerida.")
                .NotEmpty().WithMessage("Requerida.")
                .Length(16, 16).WithMessage("Debe tener entre 16 y 64 caracteres.");

            RuleFor(a => a.Contacto)
                .Matches(@"/[a-zA-Z ]+\w/g").WithMessage("Solo letras.")
                .Length(32).WithMessage("Maximo 32 caracteres.");

            RuleFor(a => a.Telefono_Contacto)
                .Matches(@"^([0-9])+\w$").WithMessage("Solo numeros.")
                .NotNull().WithMessage("Requerido.")
                .NotEmpty().WithMessage("Requerido.")
                .Length(10, 10).WithMessage("Debe tener entre 10 numeros.");

            RuleFor(a => a.Estado)
                .NotNull().WithMessage("Requerida.")
                .NotEmpty().WithMessage("Requerida.");
        }
    }
}