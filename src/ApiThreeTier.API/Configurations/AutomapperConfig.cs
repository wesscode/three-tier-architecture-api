using ApiThreeTier.API.ViewModels;
using ApiThreeTier.Business.Models;
using AutoMapper;

namespace ApiThreeTier.API.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<ProdutoViewModel, Produto>();

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome)); //ReverseMap nn funciona, pq existe uma propriedade especiazada que preciso explicar como fazer o binding
        }
    }
}
