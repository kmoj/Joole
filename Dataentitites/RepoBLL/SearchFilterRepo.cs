using Dataentitites;
using JooleRepo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;



namespace RepoBLL
{
    public interface ISearchFilterRepo:IRepo<tblProduct> 
    {
        IQueryable<tblProduct> getProductsBySubCategory(string subCategory);
        IQueryable<tblProduct> GetListByFilter(string startYear,string endYear,int minAirflow,int maxAirflow,int minPower,int maxPower,int minSound,int maxSound,int minFanDiameter, int maxFanDiameters);
    }

    public class SearchFilterRepo : ISearchFilterRepo
    {

        DbContext Context;

        public SearchFilterRepo(DbContext context)
        {
            this.Context = context;
        }

        private IDbSet<tblProduct> dbSet => Context.Set<tblProduct>();
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

        public IQueryable<tblProduct> GetListByFilter(string startYear, string endYear, int minAirflow, int maxAirflow, int minPower, int maxPower, int minSound, int maxSound, int minFanDiameter, int maxFanDiameters)
        {


          var  result = dbSet.Where(p => p.tblType.ModelYear.CompareTo(startYear) >= 0 && p.tblType.ModelYear.CompareTo(endYear) <= 0 && p.AirFLow >= 0 &&
                        p.AirFLow <= maxAirflow && p.MaxSpeedSound >= minSound && p.PowerMax >= maxPower && p.PowerMax <= minPower &&
                        p.MaxSpeedSound <= maxSound && p.SweepDiameter >= minFanDiameter && p.SweepDiameter <= maxFanDiameters);


           
            return result;
        }

        public IQueryable<tblProduct> getProductsBySubCategory(string subCategory) 
        {
            var result = dbSet.Where(p => p.tblSubCategory.SubCategory_Name == subCategory);
            return result;
        }


    }
}