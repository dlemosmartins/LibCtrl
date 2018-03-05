using LibDDD.Domain.Entities;
using LibDDD.Domain.Interface.Services;
using LibDDD.Domain.Interfaces.Repositories;

namespace LibDDD.Domain.Services
{
    public class AutorService : ServiceBase<Autor>, IAutorService
    {
        private readonly IAutorRepository _autorRepository;

        public AutorService(IAutorRepository autorRepository)
            : base(autorRepository)
        {
            _autorRepository = autorRepository;
        }
    }
}
