using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EHut.DataAccess.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //all of common function
        T Get(int id);

        IEnumerable<T> GetAll( //generic function
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            string includeProperties = null
            );

        T GetFirstOrDefault(  //generic function
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );

        void Add(T entity);

        void Remove(int id);

        void Remove(T entity);

        //thos function when i just need just retirve
    }
}