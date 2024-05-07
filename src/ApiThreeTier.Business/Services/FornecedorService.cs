using ApiThreeTier.Business.Interfaces;
using ApiThreeTier.Business.Models;
using ApiThreeTier.Business.Models.Validations;

namespace ApiThreeTier.Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;    
        }

        public async Task Adicionar(Fornecedor fornecedor)
        {
            // Validar se a entidade é consistente.
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor) ||
                !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco)) return;

            // Validar se já não existe outro fornecedor com o mesmo documento.

            await _fornecedorRepository.Adicionar(fornecedor);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;

            await _fornecedorRepository.Atualizar(fornecedor);
        }

        public async Task Remover(Guid id)
        {
            await _fornecedorRepository.Remover(id);
        }
        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
        }
    }
}
