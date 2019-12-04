using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using Dataentitites;
using JooleRepo;
using System.Data.Entity;


namespace RepoBLL
{
    public interface ISearchtblCategory : IRepo<tblCategory>
    {
        IEnumerable<tblCategory> GetListCategory();
    }

    public interface ISearchtblSubCategory : IRepo<tblSubCategory>
    {
        IEnumerable<tblSubCategory> getSubCategoBasedOnCatego(int categoryID);
    }

    public class SearchRepo : ISearchtblCategory, ISearchtblSubCategory
    {
        DbContext Context;

        public SearchRepo(DbContext context)
        {
            this.Context = context;
        }

        public IQueryable<tblCategory> Entities => throw new NotImplementedException();

        IQueryable<tblSubCategory> IRepo<tblSubCategory>.Entities => throw new NotImplementedException();


        private List<tblCategory> CategoriesList => Context.Set<tblCategory>().ToList();
        private List<tblSubCategory> subCategoriesList => Context.Set<tblSubCategory>().ToList();

        IQueryable<tblCategory> IRepo<tblCategory>.Entities => throw new NotImplementedException();

        public IEnumerable<tblCategory> GetListCategory()
        {

            return CategoriesList;
        }

        public IEnumerable<tblSubCategory> getSubCategoBasedOnCatego(int categoryID)
        {
            return subCategoriesList.Where(p => p.Category_ID == categoryID);
        }

        public IEnumerable<tblCategory> find(tblCategory v)
        {
            var filteredList = CategoriesList.Where(current => current.Category_Name == v.Category_Name);
            return filteredList;
        }

        public IEnumerable<tblSubCategory> find(tblSubCategory v)
        {
            var filteredList = subCategoriesList.Where(current => current.SubCategory_Name == v.SubCategory_Name);
            return filteredList;
        }

        void IRepo<tblCategory>.remove(tblCategory entity)
        {
            throw new NotImplementedException();
        }

        tblCategory IRepo<tblCategory>.Find(int v)
        {
            throw new NotImplementedException();
        }

        string IRepo<tblCategory>.Search(string s)
        {
            throw new NotImplementedException();
        }

        IQueryable<tblCategory> IRepo<tblCategory>.DataSet(string s)
        {
            throw new NotImplementedException();
        }

        void IRepo<tblSubCategory>.remove(tblSubCategory entity)
        {
            throw new NotImplementedException();
        }

        tblSubCategory IRepo<tblSubCategory>.Find(int v)
        {
            throw new NotImplementedException();
        }

        string IRepo<tblSubCategory>.Search(string s)
        {
            throw new NotImplementedException();
        }

        IQueryable<tblSubCategory> IRepo<tblSubCategory>.DataSet(string s)
        {
            throw new NotImplementedException();
        }

        public void add(tblSubCategory entity)
        {
            throw new NotImplementedException();
        }

        public void add(tblCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}