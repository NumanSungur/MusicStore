using Cores.Results.Abstract;
using Entitiess.DTO;
using System.Collections.Generic;

namespace B.L.Abstract
{
    public interface IOrderNotesService
    {
        IDataResult<IList<OrderNotesDto>> GetAll(int Id);
        OrderNotesDto GetByIdFirst(int Id);
        IResult Add(OrderNotesDto data);
        IResult Update(OrderNotesDto data);
        IResult Delete(int Id);
    }
}
