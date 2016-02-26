using FluentValidation;
using System;
using TPV.Models;

namespace TPV.Infrastructure.Validation
{
    public class EmpleadoValidator : AbstractValidator<Empleado>
    {
        public EmpleadoValidator()
        {
            RuleFor(a => a.Nombre)
                .Matches(@"^[a-zA-Z ]+\w$").WithMessage("Solo letras.")
                .NotNull().WithMessage("Requerido.")
                .NotEmpty().WithMessage("Requerido.")
                .Length(4, 64).WithMessage("Debe tener entre 4 y 32 letras.");

            RuleFor(a => a.Apellido)
                .Matches(@"^[a-zA-Z ]+\w$").WithMessage("Solo letras.")
                .Length(4, 32).WithMessage("Debe tener entre 4 y 32 letras.");

            RuleFor(a => a.Sexo)
                .Matches(@"/(f|m)/gmi").WithMessage("Solo Femenino o Femenino.")
                .Length(1).WithMessage("Solo letras.")
                .NotNull().WithMessage("Requerida.")
                .NotEmpty().WithMessage("Requerida.");

            RuleFor(a => a.FechaNacimiento)
                .NotNull().WithMessage("Requerida.")
                .NotEmpty().WithMessage("Requerida.")
                .GreaterThanOrEqualTo(DateTime.Now);

            RuleFor(a => a.Cedula)
                .Matches(@"^([0-9])+\w$").WithMessage("Solo numeros.")
                .Length(1).WithMessage("Solo letras.")
                .NotNull().WithMessage("Requerida.")
                .NotEmpty().WithMessage("Requerida.");

            RuleFor(a => a.Telefono)
                .Matches(@"^([0-9])+\w$").WithMessage("Solo numeros.")
                .NotNull().WithMessage("Requerido.")
                .NotEmpty().WithMessage("Requerido.")
                .Length(10, 10).WithMessage("Debe tener entre 10 numeros.");

            RuleFor(a => a.Salario)
                .NotNull().WithMessage("Requerido.")
                .NotEmpty().WithMessage("Requerido.");

            RuleFor(a => a.PuestoId)
                .NotNull().WithMessage("Requerido.")
                .NotEmpty().WithMessage("Requerido.")
                .GreaterThan(0);

            RuleFor(a => a.FechaEntrada)
                .NotNull().WithMessage("Requerida.")
                .NotEmpty().WithMessage("Requerida.")
                .GreaterThanOrEqualTo(DateTime.Now);

            RuleFor(a => a.Estado)
                .NotNull().WithMessage("Requerida.")
                .NotEmpty().WithMessage("Requerida.");
        }
    }
}