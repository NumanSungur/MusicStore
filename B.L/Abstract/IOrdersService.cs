using Cores.Results.Abstract;
using Entitiess.DTO;
using System.Collections.Generic;

namespace B.L.Abstract
{
    public interface IOrdersService
    {
        IDataResult<IList<OrdersUpdateListDto>> FiveTableGetAll(int Id);
        IDataResult<IList<OrdersDto>> GetAll(string Durumu);
        IDataResult<OrdersUpdateDto> GetById(int Id);
        IResult Add(OrdersUpdateDto data);
        IResult Update(OrdersUpdateDto data);
        IResult Delete(int Id);
    }
}
