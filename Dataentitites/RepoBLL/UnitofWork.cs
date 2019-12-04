using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RepoBLL
{

    interface Iunitofwork
    {
        IUser users { get;  } 
        IManufacturer manu { get; }

        IProductType prodtype { get; }
        IProduct products { get; }
        IType types { get; }
    }

    public class UnitofWork: DbContext,Iunitofwork
    {
        private readonly DbContext context;
        
        public UnitofWork(DbContext context)
        {
            this.context = context;
        }

        public IUser users => new UserRepo(context);
        public ISearchtblCategory categorySearch => new SearchRepo(context);
        public ISearchtblSubCategory subCategorySearch => new SearchRepo(context);

        public IManufacturer manu => new ManufacturerRepo(context);

        public IProductType prodtype => new ProductTypeRepo(context);
        public IProduct products => new ProductRepo(context);
        public IType types => new TypeRepo(context);

    }
}