using Cores.Results.Abstract;
using Entitiess.DTO;
using System.Collections.Generic;

namespace B.L.Abstract
{
    public interface IPImagesService
    {
        IDataResult<IList<PImagesDto>> GetAll(int Id);
        IDataResult<PImagesDto> GetByIdFirst(int Id);
        IResult Add(PImagesDto data);
        IResult Update(PImagesDto data);
        IResult Delete(int Id);
    }
}
