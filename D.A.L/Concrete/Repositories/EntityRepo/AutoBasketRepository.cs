using Cores.DataRepositories.Concrete.EntityFramework;
using D.A.L.Abstract;
using Entitiess.Concrete;
using Microsoft.EntityFrameworkCore;

namespace D.A.L.Concrete.Repositories.EntityRepo
{
    public class AutoBasketRepository : EfEntityRepository<AutoBasket>, IAutoBasketRepository
    {
        public AutoBasketRepository(DbContext context) : base(context)
        {

        }
    }
}

