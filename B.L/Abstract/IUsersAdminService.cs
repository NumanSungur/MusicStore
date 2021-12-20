using Cores.Results.Abstract;
using Entitiess.DTO;
using System.Collections.Generic;

namespace B.L.Abstract
{
    public interface IUsersAdminService
    {
        IDataResult<IList<UsersAdminDto>> GetAll();
        IDataResult<UsersAdminDto> GetById(int Id);
        IResult Add(UsersAdminDto data);
        IResult Update(UsersAdminDto data);
        IResult Delete(int Id);
        IDataResult<UsersAdminDto> Login(string Email,string Password);
    }
}
