using LibDDD.Domain.Interfaces;
using LibDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibDDD.Domain.Interfaces.Repositories;

namespace LibDDD.Infra.Data.Repository
{
    public class AutorRepository : RepositoryBase<Autor>, IAutorRepository
    {
    }
}
