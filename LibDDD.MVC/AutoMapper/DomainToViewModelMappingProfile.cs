using AutoMapper;
using LibDDD.Domain.Entities;
using LibDDD.MVC.Models;

namespace LibDDD.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            ConfigureMappings();
        }

        protected void ConfigureMappings()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Autor,AutorViewModel>();
                cfg.CreateMap<Livro, LivroViewModel>();
                cfg.CreateMap<Editora, EditoraViewModel>();
            });

            IMapper mapper = config.CreateMapper();

            mapper.Map<Autor, AutorViewModel>(new Autor());
            mapper.Map<Editora, EditoraViewModel>(new Editora());
            mapper.Map<Livro, LivroViewModel>(new Livro());
        }
    }
}