using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dataentitites;
using JooleRepo;

namespace RepoBLL
{
    public interface ISearchtblCategory: Repo<tblCategory>
    {
        IEnumerable<tblCategory> GetList();
    }

    public interface ISearchtblSubCategory: Repo<tblSubCategory>
    {
        IEnumerable<tblSubCategory> GetList();
    }
    
}