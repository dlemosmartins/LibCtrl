

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LibDDD.Domain.Interface.Services
{
    public interface IServiceBase<T> where T: class 
    {
        void Add(T obj);

        T GetById(int id);

        List<T> GetAll();

        List<T> GetAllWithWhere(Expression<Func<T, bool>> _exp);
        void Update(T obj);

        void Remove(T obj);

        void Dispose();
    }
}
