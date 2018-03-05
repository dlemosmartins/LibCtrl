
using LibDDD.Domain.Interface.Services;
using LibDDD.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LibDDD.Domain.Services
{
    public class ServiceBase<T> : IDisposable, IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public void Add(T obj)
        {
            _repository.Add(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public List<T> GetAll()
        {
            return _repository.GetAll();
        }

        public List<T> GetAllWithWhere(Expression<Func<T, bool>> _exp)
        {
            return _repository.GetAllWithWhere(_exp);
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(T obj)
        {
            _repository.Remove(obj);
        }

        public void Update(T obj)
        {
            _repository.Update(obj);
        }
    }
}
