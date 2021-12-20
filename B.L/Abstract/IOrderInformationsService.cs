using Cores.Results.Abstract;
using Entitiess.DTO;
using System.Collections.Generic;

namespace B.L.Abstract
{
    public interface IOrderInformationsService
    {
        IDataResult<IList<OrderInformationsDto>> GetAll(int Id);
        IDataResult<OrderInformationsDto> GetByIdFirst(int Id);
        IResult Add(OrderInformationsDto data);
        IResult Update(OrderInformationsDto data);
        IResult Delete(int Id);
    }
}
