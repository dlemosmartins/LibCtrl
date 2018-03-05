using LibDDD.Domain.Entities;
using LibDDD.Domain.Interface.Services;
using LibDDD.Domain.Interfaces.Repositories;

namespace LibDDD.Domain.Services
{
    public class LivroService : ServiceBase<Livro>, ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
            :base(livroRepository)
        {
            _livroRepository = livroRepository;
        }
    }
}
