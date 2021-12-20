using Cores.Results.Abstract;
using Entitiess.DTO;
using System.Collections.Generic;

namespace B.L.Abstract
{
    public interface IVariantsService
    {
        IDataResult<IList<VariantsDto>> GetAll(int Id);
        VariantsDto GetByIdFirst(int Id);
        IResult Add(VariantsDto data);
        IResult Update(VariantsDto data);
        IResult Delete(int Id);
    }
}
