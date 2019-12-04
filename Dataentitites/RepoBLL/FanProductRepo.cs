using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Dataentitites;
using JooleRepo;

namespace RepoBLL
{
    public interface IFanProductRepo : IRepo<tblProduct>
    {
        public IQueryable<tblProduct> SearchByFilter(string s, int[] props);
    }

    public class FanProductRepo : IFanProductRepo
    {
        private DbContext context;

        public FanProductRepo(DbContext context)
        {
            this.context = context;
        }

        private IDbSet<tblProduct> dbSet => context.Set<tblProduct>();
        public IQueryable<tblProduct> Entities => dbSet;

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
            var prod = dbSet.Find(v);
            return prod;
        }

        public void remove(tblProduct entity)
        {
            throw new NotImplementedException();
        }

        public string Search(string s)
        {
            throw new NotImplementedException();
        }

        public IQueryable<tblProduct> SearchByFilter(string s, int[] props)
        {

            var list = from p in dbSet select p;
            if (!String.IsNullOrEmpty(s)){
                list = list.Where(product => product.Product_Name.Contains(s) && product.AirFlow >= props[0]
                && product.AirFlow <= props[1] && product.MaxPower >= props[2] && product.MaxPower <= props[3]
                && product.SoundAtMax >= props[4] && product.SoundAtMax <= props[5] && product.FanSweepDiameter >= props[6]
                && product.FanSweepDiameter <= props[7]
                );
            }

            return list;
        }

    }
}
