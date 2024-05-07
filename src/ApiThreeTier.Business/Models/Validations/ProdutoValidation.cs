using FluentValidation;

namespace ApiThreeTier.Business.Models.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLenth} caracters"); 

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLenth} caracters");

            RuleFor(x => x.Valor)
                .GreaterThan(0).WithMessage("O compo {PropertyName} precisa ser maior {ComparisonValue}");
        }
    }
}
