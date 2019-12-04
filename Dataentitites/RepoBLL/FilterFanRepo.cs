using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Dataentitites;
using JooleRepo;

namespace RepoBLL
{
    public interface IFilterFanRepo : IRepo<tblProduct>
    {
        
    }

    public class FilterFanRepo : IFilterFanRepo
    {
       
        private DbContext context;

        public FilterFanRepo(DbContext context)
        {
            this.context = context;
        }

        public IQueryable<tblProduct> Entities => throw new NotImplementedException();

        public void add(tblProduct entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<tblProduct> DataSet(string s)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tblProduct> find(tblProduct v)
        {
            throw new NotImplementedException();
        }

        public tblProduct Find(int v)
        {
            throw new NotImplementedException();
        }

        public void remove(tblProduct entity)
        {
            throw new NotImplementedException();
        }

        public string Search(string s)
        {
            throw new NotImplementedException();
        }
    }
       
}
