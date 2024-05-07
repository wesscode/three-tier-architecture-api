
using ApiThreeTier.Business.Models;

namespace ApiThreeTier.Business.Interfaces
{
    public interface IProdutoService
    {
        Task Adicionar(Fornecedor fornecedor);
        Task Atualizar(Fornecedor fornecedor);
        Task Remover(Guid id);
    }
}
