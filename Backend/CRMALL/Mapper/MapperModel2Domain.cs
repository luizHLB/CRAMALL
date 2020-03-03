using AutoMapper;
using CRMALL.Teste.Domain.Models.Endereco;
using CRMALL.Teste.Domain.Models.Pessoa;
using CRMALL.Teste.Domain.ViewModels.Pessoa;

namespace CRMALL.Api.Mapper
{
    public class MapperModel2Domain : Profile
    {
        public MapperModel2Domain()
        {
            CreateMap<PessoaInsertViewModel, EnderecoModel>()
                .ForMember(to => to.Cep, map => map.MapFrom(src => src.Cep))
                .ForMember(to => to.Cidade, map => map.MapFrom(src => src.Cidade))
                .ForMember(to => to.Complemento, map => map.MapFrom(src => src.Complemento))
                .ForMember(to => to.Estado, map => map.MapFrom(src => src.Estado))
                .ForMember(to => to.Numero, map => map.MapFrom(src => src.Numero))
                .ForMember(to => to.Rua, map => map.MapFrom(src => src.Rua));

            CreateMap<PessoaInsertViewModel, PessoaModel>()
                .ForMember(to => to.Nome, map => map.MapFrom(src => src.Nome))
                .ForMember(to => to.DataNascimento, map => map.MapFrom(src => src.DataNascimento))
                .ForMember(to => to.Sexo, map => map.MapFrom(src => src.Sexo))
                .ForMember(to => to.Endereco, map => map.MapFrom(src => src));

            CreateMap<PessoaUpdateViewModel, EnderecoModel>()
                .ForMember(to => to.Cep, map => map.MapFrom(src => src.Cep))
                .ForMember(to => to.Cidade, map => map.MapFrom(src => src.Cidade))
                .ForMember(to => to.Complemento, map => map.MapFrom(src => src.Complemento))
                .ForMember(to => to.Estado, map => map.MapFrom(src => src.Estado))
                .ForMember(to => to.Numero, map => map.MapFrom(src => src.Numero))
                .ForMember(to => to.Rua, map => map.MapFrom(src => src.Rua));

            CreateMap<PessoaUpdateViewModel, PessoaModel>()
                .ForMember(to => to.Id, map => map.MapFrom(src => src.Id))
                .ForMember(to => to.Nome, map => map.MapFrom(src => src.Nome))
                .ForMember(to => to.DataNascimento, map => map.MapFrom(src => src.DataNascimento))
                .ForMember(to => to.Sexo, map => map.MapFrom(src => src.Sexo))
                .ForMember(to => to.Endereco, map => map.MapFrom(src => src));
        }
    }
}
