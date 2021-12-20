using Cores.DataRepositories.Concrete.EntityFramework;
using D.A.L.Abstract;
using Entitiess.Concrete;
using Microsoft.EntityFrameworkCore;

namespace D.A.L.Concrete.Repositories.EntityRepo
{
    public class TempBasketsRepository : EfEntityRepository<TempBaskets>, ITempBasketsRepository 
    {
        public TempBasketsRepository(DbContext context):base(context)
        {
                
        }
    }
}
