

using LibDDD.Application.Interface;
using LibDDD.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LibDDD.Application
{
    public class AppServiceBase<T> : IDisposable, IAppServiceBase<T> where T : class
    {
        private readonly IServiceBase<T> _serviceBase;

        public AppServiceBase(IServiceBase<T> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(T obj)
        {
            _serviceBase.Add(obj);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }

        public List<T> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public List<T> GetAllWithWhere(Expression<Func<T, bool>> _exp)
        {
            return _serviceBase.GetAllWithWhere(_exp);
        }

        public T GetById(int id)
        {
            return _serviceBase.GetById(id);
        }

        public void Remove(T obj)
        {
            _serviceBase.Remove(obj);
        }

        public void Update(T obj)
        {
            _serviceBase.Update(obj);
        }
    }
}
