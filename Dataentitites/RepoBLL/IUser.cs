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
    public interface IUser:IRepo<tblUser>
    {
               
    }

    public class UserRepo : IUser
    {
        private DbContext context;

        public UserRepo(DbContext context)
        {
            this.context = context;
        }

        private IDbSet<tblUser> dbSet => context.Set<tblUser>();
        public IQueryable<tblUser> Entities => dbSet;

        public tblUser Find(int c)
        {
            var a = dbSet.Find(c);
            return a;
    
        }

        public string Search(string searchString)
        {
            return null;
        }

        public IQueryable<tblUser> DataSet(string filter)
        {
            return dbSet;
        }

        public void Remove(tblUser entity)
        {
            dbSet.Find(entity);
        } 
    }
}
