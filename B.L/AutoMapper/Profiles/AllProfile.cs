using AutoMapper;
using Entitiess.Concrete;
using Entitiess.DTO;

namespace B.L.AutoMapper.Profiles
{
    public class AllProfile : Profile
    {
        public AllProfile()
        {
            CreateMap<ProductsUpdateDto, Products>();
            CreateMap<Products, ProductsUpdateDto>();
            CreateMap<Products, ProductsDto>();

            CreateMap<PImagesDto, PImages>();
            CreateMap<PImages, PImagesDto>();

            CreateMap<VariantsDto, Variants>();
            CreateMap<Variants, VariantsDto>();

            CreateMap<CategoriesDto, Categories>();
            CreateMap<Categories, CategoriesDto>();

            CreateMap<CustomersUpdateDto, Customers>();
            CreateMap<Customers, CustomersUpdateDto>();
            CreateMap<Customers, CustomersDto>();

            CreateMap<OrdersUpdateDto, Orders>();
            CreateMap<Orders, OrdersUpdateDto>();
            CreateMap<Orders, OrdersDto>();
            CreateMap<OrdersUpdateListDto, Orders>();
            CreateMap<Orders, OrdersUpdateListDto>();

            CreateMap<OrderDetailsDto, OrderDetails>();
            CreateMap<OrderDetails, OrderDetailsDto>();

            CreateMap<OrderInformationsDto, OrderInformations>();
            CreateMap<OrderInformations, OrderInformationsDto>();

            CreateMap<OrderNotesDto, OrderNotes>();
            CreateMap<OrderNotes, OrderNotesDto>();

            CreateMap<TempBasketsDto, TempBaskets>();
            CreateMap<TempBaskets, TempBasketsDto>();

            CreateMap<UsersAdminDto, UsersAdmin>();
            CreateMap<UsersAdmin, UsersAdminDto>();

            CreateMap<AutoBasketDto, AutoBasket>();    
            CreateMap<AutoBasket, AutoBasketDto>();
        }
    }
}
