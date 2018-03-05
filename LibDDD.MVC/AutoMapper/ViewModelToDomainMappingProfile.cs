using AutoMapper;
using LibDDD.Domain.Entities;
using LibDDD.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibDDD.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {

        public ViewModelToDomainMappingProfile()
        {
            ConfigureMappings();
        }

        protected  void ConfigureMappings()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AutorViewModel,Autor >();
                cfg.CreateMap<LivroViewModel, Livro>();
                cfg.CreateMap<EditoraViewModel, Editora>();
            });

            IMapper mapper = config.CreateMapper();

            mapper.Map<AutorViewModel, Autor>(new AutorViewModel());
            mapper.Map<EditoraViewModel, Editora>(new EditoraViewModel());
            mapper.Map<LivroViewModel, Livro>(new LivroViewModel());
        }
    }
}