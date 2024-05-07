using FluentValidation;

namespace ApiThreeTier.Business.Models.Validations
{
    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        public EnderecoValidation() {
            RuleFor(x => x.Logradouro)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLenth} caracters");

            RuleFor(x => x.Bairro)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLenth} caracters");

            RuleFor(x => x.Cep)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(8).WithMessage("O campo {PropertyName} precisa ter {MaxLenth} caracters");

            RuleFor(x => x.Cidade)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLenth} caracters");

            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLenth} caracters");

            RuleFor(x => x.Numero)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLenth} caracters");
        }
    }
}
