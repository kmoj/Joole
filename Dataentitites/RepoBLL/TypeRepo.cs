using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JooleRepo;
using Dataentitites;
using System.Data.Entity;

namespace RepoBLL
{
    public interface IType:IRepo<tblType>
    {

    }
    public class TypeRepo : IType
    {
        private DbContext context;

        public TypeRepo(DbContext context)
        {
            this.context = context;
        }

        private IDbSet<tblType> dbSet => context.Set<tblType>();
        public IQueryable<tblType> Entities => dbSet;

        public tblType Find(int c)
        {
            var a = dbSet.Find(c);
            return a;

        }

        public string Search(string searchString)
        {
            return null;
        }

        public IQueryable<tblType> DataSet(string filter)
        {
            return dbSet;
        }

        public void Remove(tblType entity)
        {
            dbSet.Find(entity);
        }

        public IEnumerable<tblType> find(tblType v)
        {
            throw new NotImplementedException();
        }

        public void remove(tblType entity)
        {
            throw new NotImplementedException();
        }

        public void add(tblType entity)
        {
            throw new NotImplementedException();
        }
    }
}