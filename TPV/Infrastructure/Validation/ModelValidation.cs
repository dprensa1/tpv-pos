using FluentValidation;
using FluentValidation.Results;

namespace TPV.Infrastructure.Validation
{
    public class ModelValidation<T>
    {
        public ValidationResult Validate { get; private set; }

        public ModelValidation(T modelo, AbstractValidator<T> validator)
        {
            Validate = validator.Validate(modelo);
        }
    }
}

/*
public class ModelValidation<T>
{
    T Modelo;
    AbstractValidator<T> Validator;

    public ValidationResult Validate { get; private set; }

    public ModelValidation(T modelo, AbstractValidator<T> validator)
    {
        Modelo = modelo;
        Validator = validator;
    }

    public ValidationResult Validate()
    {
        return Validator.Validate(Modelo);
    }
}
*/