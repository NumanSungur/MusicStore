using Cores.Results.Abstract;
using Entitiess.DTO;
using System.Collections.Generic;

namespace B.L.Abstract
{
    public interface IProductsService
    {
        IDataResult<IList<ProductsDto>> GetAll();
        IDataResult<IList<ProductsDto>> GetAllFirst();
        IDataResult<IList<ProductsDto>> GetAllSecond();
        IDataResult<IList<ProductsDto>> KategoriyeGoreUrunGetirme(int CategoryId);
        IDataResult<IList<ProductsDto>> GetAllKampanya();
        IDataResult<ProductsUpdateDto> GetById(int Id);
        IResult Add(ProductsUpdateDto data);
        IResult Update(ProductsUpdateDto data);
        IResult Delete(int Id);
        IDataResult<int> SearchId(string Name,decimal Price,int Stock);
        IDataResult<IList<ProductsDto>> GetAllFooter();
    }
}
