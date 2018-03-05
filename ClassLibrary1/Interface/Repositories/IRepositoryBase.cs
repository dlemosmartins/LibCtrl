using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibDDD.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T obj);

        T GetById(int id);

        List<T> GetAll();

        List<T> GetAllWithWhere(Expression<Func<T,bool>> _exp);
        void Update(T obj);

        void Remove(T obj);

        void Dispose();
    }
}
