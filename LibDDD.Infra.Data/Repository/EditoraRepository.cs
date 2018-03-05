using LibDDD.Domain.Entities;
using LibDDD.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDDD.Infra.Data.Repository
{
    public class EditoraRepository :RepositoryBase<Editora>, IEditoraRepository
    {
    }
}
