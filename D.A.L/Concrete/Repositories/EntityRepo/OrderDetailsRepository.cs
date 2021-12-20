using Cores.DataRepositories.Concrete.EntityFramework;
using D.A.L.Abstract;
using Entitiess.Concrete;
using Microsoft.EntityFrameworkCore;


namespace D.A.L.Concrete.Repositories.EntityRepo
{
     public class OrderDetailsRepository : EfEntityRepository<OrderDetails>,IOrderDetailsRepository
    {
        public OrderDetailsRepository(DbContext context):base(context)
        {
                
        }
    }
}
