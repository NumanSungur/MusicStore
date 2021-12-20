using Cores.DataRepositories.Concrete.EntityFramework;
using D.A.L.Abstract;
using Entitiess.Concrete;
using Microsoft.EntityFrameworkCore;


namespace D.A.L.Concrete.Repositories.EntityRepo
{
     public class OrderNotesRepository : EfEntityRepository<OrderNotes>,IOrderNotesRepository
    {
        public OrderNotesRepository(DbContext context):base(context)
        {
                
        }
    }
}
