using LibDDD.Application.Interface;
using LibDDD.Domain.Entities;
using LibDDD.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDDD.Application
{
    public class LivroAppService : AppServiceBase<Livro>, ILivroAppService
    {
        private readonly ILivroService _livroService;
        public LivroAppService(ILivroService livroService)
            :base(livroService)
        {
            _livroService = livroService;
        }
    }
}
