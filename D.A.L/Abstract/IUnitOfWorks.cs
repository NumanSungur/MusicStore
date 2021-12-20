using System;

namespace D.A.L.Abstract
{
    public interface IUnitOfWorks : IDisposable
    {
        public IProductsRepository ProductsRepository { get; }
        public ICategoriesRepository CategoriesRepository { get; }
        IVariantsRepository VariantsRepository { get; }
        IPImagesRepository PImagesRepository { get; }
        ICustomersRepository CustomersRepository { get; }
        ITempBasketsRepository TempBasketsRepository { get; }
        IUsersAdminRepository UsersAdminRepository { get; }
        IOrdersRepository OrdersRepository { get; }
        IOrderDetailsRepository OrderDetailsRepository { get; }
        IOrderInformationsRepository OrderInformationsRepository { get; }
        IOrderNotesRepository OrderNotesRepository { get; }
        IAutoBasketRepository AutoBasketRepository { get; }

        void SaveChanges();
    }
}
