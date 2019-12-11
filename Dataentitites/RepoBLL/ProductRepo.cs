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
    public interface IProduct : IRepo<tblProduct>
    {
        IEnumerable<tblProduct> SearchProductByNameCateId(string name, int cateId);
    }

    public class ProductRepo : IProduct
    {
        private DbContext context;

        public ProductRepo(DbContext context)
        {
            this.context = context;
        }

        private IDbSet<tblProduct> dbSet => context.Set<tblProduct>();
        public IQueryable<tblProduct> Entities => dbSet;

        public tblProduct Find(int v)
        {
            var a = dbSet.Find(v);
            return a;
        }

        public string Search(string searchString)
        {
            string s = "";
            var list = from p in dbSet select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                list = list.Where(product => product.Product_Name.Contains(searchString));
                foreach (var product in list)
                {
                    s += product.Product_Name + " ";
                }
            }
            //var result = from product in list
            //             where product.Product_Name == searchString
            //             select product;
            return s;
        }

        public IEnumerable<tblProduct> SearchProductByNameCateId(string name, int cateId)
        {
            IEnumerable<tblProduct> res = new List<tblProduct>();
            //IDbSet<tblSubCategory> subCateDbSet = context.Set<tblSubCategory>();

            //var subCateList = (from subCate in subCateDbSet
            //                   where subCate.Category_ID == cateId
            //                   select subCate);

            var productList = (from p in dbSet select p);
            if (!String.IsNullOrEmpty(name))
            {
                productList = productList.Where(product => product.tblSubCategory.Category_ID == cateId && product.Product_Name.Contains(name));
            }
            return productList.ToList();
        }

        public IQueryable<tblProduct> DataSet(string filter)
        {
            if (!String.IsNullOrEmpty(filter))
            {
                var filterSet = from p in dbSet select p;
                filterSet = dbSet.Where(product => product.Product_Name.Contains(filter));
                return filterSet;
            }
            return dbSet;
        }

        public void Remove(tblProduct entity)
        {
            dbSet.Find(entity);
        }

        public IEnumerable<tblProduct> find(tblProduct v)
        {
            throw new NotImplementedException();
        }

        public void remove(tblProduct entity)
        {
            throw new NotImplementedException();
        }

        public void add(tblProduct entity)
        {
            throw new NotImplementedException();
        }
    }
}