using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JooleRepo;
using Dataentitites;
using System.Data.Entity;

namespace RepoBLL
{
    public interface IManufacturer : IRepo<tblManufacturer>
    {

    }

    public class ManufacturerRepo:IManufacturer
    {

        private DbContext context;

        public ManufacturerRepo(DbContext context)
        {
            this.context = context;
        }

        public IQueryable<tblManufacturer> entities => throw new NotImplementedException();

        public IQueryable<tblManufacturer> Entities => throw new NotImplementedException();

        private DbSet<tblManufacturer> dbset => context.Set<tblManufacturer>();

        public void add(tblManufacturer entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<tblManufacturer> DataSet(string s)
        {
            throw new NotImplementedException();
        }

        public tblManufacturer Find(int v)
        {
            var a = dbset.Find(v);
            return a;
        }

        public IEnumerable<tblManufacturer> find(tblManufacturer v)
        {
            throw new NotImplementedException();
        }
        
        public void remove(tblManufacturer entity)
        {
            throw new NotImplementedException();
        }

        public string Search(string s)
        {
            throw new NotImplementedException();
        }
    }
}