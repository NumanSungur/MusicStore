﻿using Cores.Results.Abstract;
using Entitiess.DTO;
using System.Collections.Generic;

namespace B.L.Abstract
{
    public interface ITempBasketsService
    {
        IDataResult<IList<TempBasketsDto>> GetAll(int CookiesID);
        IDataResult<TempBasketsDto> GetById(int Id);
        IResult SepetArttırEksilt(int Id, bool islem);
        IResult AddUpdate(int ProductId, int CookiesID, int VaryantID);
        IResult Delete(int Id);
        IResult AutoBasketUpdate(AutoBasketDto data);
        IDataResult<AutoBasketDto> GetByIdAuto(int Id);
    }
}
