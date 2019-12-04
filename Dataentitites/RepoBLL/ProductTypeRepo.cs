using System;
using System.Linq;
using JooleRepo;
using Dataentitites;
using System.Data.Entity;
using System.Collections.Generic;

namespace RepoBLL
{
    public interface IProductType : IRepo<tblType>
    {
    }

    public class ProductTypeRepo : IProductType
    {

        private DbContext context;

        public ProductTypeRepo(DbContext context)
        {
            this.context = context;
        }

        private DbSet<tblType> dbset => context.Set<tblType>();

        public IQueryable<tblType> entities => throw new NotImplementedException();

        public IQueryable<tblType> Entities => throw new NotImplementedException();

        public tblType Find(int v)
        {
            var a = dbset.Find(v);
            return a;
        }

        public void remove(tblType entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tblType> find(tblType v)
        {
            throw new NotImplementedException();
        }

        public string Search(string s)
        {
            throw new NotImplementedException();
        }

        public IQueryable<tblType> DataSet(string s)
        {
            throw new NotImplementedException();
        }

        public void add(tblType entity)
        {
            throw new NotImplementedException();
        }
    }
}