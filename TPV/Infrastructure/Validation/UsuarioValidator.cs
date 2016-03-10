using FluentValidation;
using TPV.Models;

namespace TPV.Infrastructure.Validation
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(a => a.User)
                .Matches(@"/[a-zA-Z]+\w/g").WithMessage("Solo letras. Sin espacios en blanco")
                .NotNull().WithMessage("Requerido.")
                .NotEmpty().WithMessage("Requerido.")
                .Length(4, 16).WithMessage("Debe tener entre 4 y 16 letras.");
            //    
            RuleFor(a => a.Clave)
                .Matches(@"/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{6,}$/gm").WithMessage("Minimos 6 Caracteres, Minuscula, Mayuscula y Numeros")
                .NotNull().WithMessage("Requerido.")
                .NotEmpty().WithMessage("Requerido.")
                .Length(6, 16).WithMessage("Debe tener entre 6 y 16 letras.");
        }
    }
}