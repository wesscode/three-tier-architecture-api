using ApiThreeTier.Business.Interfaces;
using ApiThreeTier.Business.Models;
using ApiThreeTier.Business.Models.Validations;
using System.Reflection.Metadata;

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
            if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento informado.");
                return;
            }

            await _fornecedorRepository.Adicionar(fornecedor);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;

            if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id).Result.Any())
            {
                Notificar("Já existe fornecedor com este documento informado.");
                return;
            }

            await _fornecedorRepository.Atualizar(fornecedor);
        }

        public async Task Remover(Guid id)
        {
            var fornecedor = await _fornecedorRepository.ObterFornecedorProdutosEndereco(id);

            if (fornecedor == null)
            {
                Notificar("Fornecedor não existe.");
                return;
            }

            if (fornecedor.Produtos.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados.");
                return;
            }

            var endereco = await _fornecedorRepository.ObterEnderecoPorFornecedor(id);
            if (endereco != null)
            {
                await _fornecedorRepository.RemoverEnderecoFornecedor(endereco);
            }

            await _fornecedorRepository.Remover(id);
        }
        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
        }
    }
}
