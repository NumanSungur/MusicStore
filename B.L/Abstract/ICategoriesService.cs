using Cores.Results.Abstract;
using Entitiess.DTO;
using System.Collections.Generic;

namespace B.L.Abstract
{
    public interface ICategoriesService
    {
        IDataResult<IList<CategoriesDto>> GetAll(int Id);
        IDataResult<CategoriesDto> GetByIdFirst(int Id);
        IResult Add(CategoriesDto data);
        IResult Update(CategoriesDto data);
        IResult Delete(int Id);
    }
}
