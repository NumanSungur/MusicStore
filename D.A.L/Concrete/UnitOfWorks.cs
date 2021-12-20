using D.A.L.Abstract;
using D.A.L.Concrete.Contexts.EntityFramework;
using D.A.L.Concrete.Repositories.EntityRepo;

namespace D.A.L.Concrete
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly ETicaretContext context;
        private  CategoriesRepository categories;
        private  ProductsRepository products;
        private  VariantsRepository variants;
        private  PImagesRepository pImages;
        private  CustomersRepository customers;
        private  TempBasketsRepository tempBaskets;
        private  UsersAdminRepository usersAdmin;
        private  OrdersRepository orders;
        private  OrderDetailsRepository orderDetails;
        private  OrderInformationsRepository orderInformations;
        private  OrderNotesRepository orderNotes;
        private AutoBasketRepository autoBasketRepo;
        public UnitOfWorks(ETicaretContext _context)
        {
            context = _context;
        }
        public IProductsRepository ProductsRepository => products ?? new ProductsRepository(context);
        public ICategoriesRepository CategoriesRepository => categories ?? new CategoriesRepository(context);
        public IVariantsRepository VariantsRepository => variants ?? new VariantsRepository(context);
        public IPImagesRepository PImagesRepository => pImages ?? new PImagesRepository(context);
        public ICustomersRepository CustomersRepository => customers ?? new CustomersRepository(context);
        public ITempBasketsRepository TempBasketsRepository => tempBaskets ?? new TempBasketsRepository(context);
        public IUsersAdminRepository UsersAdminRepository => usersAdmin ?? new UsersAdminRepository(context);
        public IOrdersRepository OrdersRepository => orders ?? new OrdersRepository(context);
        public IOrderDetailsRepository OrderDetailsRepository => orderDetails ?? new OrderDetailsRepository(context);
        public IOrderInformationsRepository OrderInformationsRepository => orderInformations ?? new OrderInformationsRepository(context);
        public IOrderNotesRepository OrderNotesRepository => orderNotes ?? new OrderNotesRepository(context);
        public IAutoBasketRepository AutoBasketRepository => autoBasketRepo ?? new AutoBasketRepository(context);
        public void Dispose()
        {
            context.Dispose();
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
