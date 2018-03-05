using LibDDD.Application.Interface;
using LibDDD.Domain.Entities;
using LibDDD.Domain.Interface.Services;

namespace LibDDD.Application
{
    public class AutorAppService : AppServiceBase<Autor>, IAutorAppService
    {
        private readonly IAutorService _autorService;

        public AutorAppService(IAutorService autorService)
            : base(autorService)
        {
            _autorService = autorService;
        }
    }
}

