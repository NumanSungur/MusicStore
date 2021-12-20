using B.L.Abstract;
using B.L.Concrete;
using D.A.L.Abstract;
using D.A.L.Concrete.Contexts.EntityFramework;
using D.A.L.Concrete;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using B.L.ValidationRules.FluentValidation;
using Entitiess.DTO;

namespace B.L.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection MyService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ETicaretContext>();
            serviceCollection.AddScoped<IUnitOfWorks, UnitOfWorks>();
            serviceCollection.AddScoped<ICategoriesService, CategoriesManager>();
            serviceCollection.AddScoped<ICustomersService, CustomersManager>();
            serviceCollection.AddScoped<IOrderDetailsService, OrderDetailsManager>();
            serviceCollection.AddScoped<IOrderInformationsService, OrderInformationsManager>();
            serviceCollection.AddScoped<IOrderNotesService, OrderNotesManager>();
            serviceCollection.AddScoped<IOrdersService, OrdersManager>();
            serviceCollection.AddScoped<IPImagesService, PImagesManager>();
            serviceCollection.AddScoped<IProductsService, ProductsManager>();
            serviceCollection.AddScoped<ITempBasketsService, TempBasketsManager>();
            serviceCollection.AddScoped<IUsersAdminService, UsersAdminManager>();
            serviceCollection.AddScoped<IVariantsService, VariantsManager>();            

            serviceCollection.AddSingleton<IValidator<CategoriesDto>, CategoriesValidation>();
            serviceCollection.AddSingleton<IValidator<CustomersUpdateDto>, CustomersValidation>();
            serviceCollection.AddSingleton<IValidator<OrderDetailsDto>, OrdersDetailValidation>();
            serviceCollection.AddSingleton<IValidator<OrderInformationsDto>, OrdersInformationValidation>();
            serviceCollection.AddSingleton<IValidator<OrderNotesDto>, OrdersNoteValidation>();
            serviceCollection.AddSingleton<IValidator<OrdersUpdateDto>, OrdersValidation>();
            serviceCollection.AddSingleton<IValidator<PImagesDto>, PImagesValidation>();
            serviceCollection.AddSingleton<IValidator<ProductsUpdateDto>, ProductsValidation>();
            serviceCollection.AddSingleton<IValidator<UsersAdminDto>, UsersAdminValidation>();
            serviceCollection.AddSingleton<IValidator<VariantsDto>, VariantsValidation>();           

            return serviceCollection;
        }
    }
}
