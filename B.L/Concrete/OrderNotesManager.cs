﻿using AutoMapper;
using B.L.Abstract;
using Cores.Results.Abstract;
using Cores.Results.ComplexTypes;
using Cores.Results.Concrete;
using D.A.L.Abstract;
using Entitiess.Concrete;
using Entitiess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace B.L.Concrete
{
    public class OrderNotesManager : IOrderNotesService
    {
        private readonly IUnitOfWorks works;
        private readonly IMapper mapper;
        public OrderNotesManager(IUnitOfWorks _works, IMapper _mapper)
        {
            works = _works;
            mapper = _mapper;
        }
        public IResult Add(OrderNotesDto data)
        {
            try
            {
                works.OrderNotesRepository.Add(mapper.Map<OrderNotes>(data));
                works.SaveChanges();
                return new Result(ResultStatus.Success, "Kayıt Başarılı");
            }
            catch (Exception)
            {
                return new Result(ResultStatus.Error, "Kayıt Başarısız");
            }
        }
        public IResult Delete(int Id)
        {
            try
            {
                works.OrderNotesRepository.Delete(works.OrderNotesRepository.GetByIdFirst(x => x.Id == Id));
                works.SaveChanges();
                return new Result(ResultStatus.Success, "Silme Başarılı");
            }
            catch (Exception)
            {
                return new Result(ResultStatus.Error, "Silme Başarısız");
            }
        }
        public IDataResult<IList<OrderNotesDto>> GetAll(int Id)
        {
            IList<OrderNotesDto> data = new List<OrderNotesDto>();
            foreach (var item in works.OrderNotesRepository.GetAll(x => x.OrdersId == Id))
            {
                data.Add(mapper.Map<OrderNotesDto>(item));
            }
            if (data.Count > 0)
            {
                return new DataResult<IList<OrderNotesDto>>(ResultStatus.Success, data.Count() + "Kayıt Listelendi", data);
            }
            else
            {
                return new DataResult<IList<OrderNotesDto>>(ResultStatus.Info, "Kayıt Bulunamadı", null);
            }
        }
        public OrderNotesDto GetByIdFirst(int Id)
        {
            return mapper.Map<OrderNotesDto>(works.OrderNotesRepository.GetByIdFirst(x => x.Id == Id));
        }
        public IResult Update(OrderNotesDto data)
        {
            try
            {
                works.OrderNotesRepository.Update(mapper.Map<OrderNotes>(data));
                works.SaveChanges();
                return new Result(ResultStatus.Success, "Güncelleme Başarılı");
            }
            catch (Exception)
            {
                return new Result(ResultStatus.Error, "Güncelleme Başarısız");
            }
        }
    }
}
