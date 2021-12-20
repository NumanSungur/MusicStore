using Cores.Results.Abstract;
using Entitiess.DTO;
using System.Collections.Generic;

namespace B.L.Abstract
{
    public interface IOrderDetailsService
    {
        IDataResult<IList<OrderDetailsDto>> GetAll(int Id);
        IDataResult<OrderDetailsDto> GetByIdFirst(int Id);
        IResult Add(OrderDetailsDto data);
        IResult Update(OrderDetailsDto data);
        IResult Delete(int Id);
    }
}
