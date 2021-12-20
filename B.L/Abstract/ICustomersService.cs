using Cores.Results.Abstract;
using Entitiess.DTO;
using System.Collections.Generic;

namespace B.L.Abstract
{
    public interface ICustomersService
    {
        IDataResult<IList<CustomersDto>> GetAll();
        IDataResult<CustomersUpdateDto> GetById(int Id);
        IDataResult<CustomersDto> Login(string Email, string Phone, string Password);
        IResult Add(CustomersUpdateDto data);
        IResult Update(CustomersUpdateDto data);
        IResult Delete(int Id);
    }
}
