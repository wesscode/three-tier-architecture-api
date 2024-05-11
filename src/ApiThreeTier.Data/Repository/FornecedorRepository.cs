using ApiThreeTier.Business.Interfaces;
using ApiThreeTier.Business.Models;
using ApiThreeTier.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiThreeTier.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDbContext context) : base(context) { }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
          return await Db.Fornecedores.AsNoTracking()
                .Include(f => f.Produtos)
                .Include(e => e.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()
                 .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }

        public async Task RemoverEnderecoFornecedor(Endereco endereco)
        {
             Db.Remove(endereco);
            await SaveChanges();
        }
    }
}
