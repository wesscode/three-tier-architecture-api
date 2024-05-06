using DevIO.Business.Models.Validations.Documentos;
using FluentValidation;

namespace ApiThreeTier.Business.Models.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(x => x.Nome)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
               .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLenth} caracters");

            When(x => x.TipoFornecedor == TipoFornecedor.PessoaFisica, () =>
            {
                RuleFor(x => x.Documento.Length).Equal(CpfValidacao.TamanhoCpf).WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}");

                RuleFor(x => CpfValidacao.Validar(x.Documento)).Equal(true).WithMessage("O documento fornecido é inválido.");
            });

            When(x => x.TipoFornecedor == TipoFornecedor.PessoaJuridica, () =>
            {
                RuleFor(x => x.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj).WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}");

                RuleFor(x => CnpjValidacao.Validar(x.Documento)).Equal(true).WithMessage("O documento fornecido é inválido.");
            });
        }
    }
}
