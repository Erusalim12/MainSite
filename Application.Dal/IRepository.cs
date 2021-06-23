using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Dal.Domain;

namespace Application.Dal
{
    public interface IRepository<T> where T : BaseEntity
    {
       abstract void Add(T entity);
       abstract void Add(IEnumerable<T> entities);
       abstract void Update(T entity);
       abstract void Update(IEnumerable<T> entities);
       abstract void Delete(string id);
       abstract void Delete(T entity);
       abstract void Delete(IEnumerable<T> entities);
       abstract T Get(string id);
       abstract T Get(Expression<Func<T, Boolean>> where);
       abstract IEnumerable<T> GetMany(Expression<Func<T, Boolean>> where);
       abstract IEnumerable<T> GetAll { get; }
    }
}