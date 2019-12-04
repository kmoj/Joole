using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JooleRepo
{
    public interface IRepo<T> where T: class
    {

        IEnumerable<T> find(T v);
        void remove(T entity);

        IQueryable<T> Entities { get; }
        T Find(int v);
        string Search(string s);
        IQueryable<T> DataSet(string s);

        void add(T entity);
       
    }
}