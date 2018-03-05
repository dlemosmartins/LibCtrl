using LibDDD.Domain.Interfaces.Repositories;
using LibDDD.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace LibDDD.Infra.Data.Repository
{
    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {
        protected LibContext db = new LibContext();

        public void Add(T obj)
        {
            db.Set<T>().Add(obj);
            db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public List<T> GetAllWithWhere(Expression<Func<T, bool>> _exp)
        {
            return db.Set<T>().Where(_exp.Compile()).ToList();
        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);

        }

        public void Remove(T obj)
        {
            db.Set<T>().Remove(obj);
            db.SaveChanges();
        }

        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
