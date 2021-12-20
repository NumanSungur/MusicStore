using AutoMapper;
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
    public class OrderDetailsManager : IOrderDetailsService
    {
        private readonly IUnitOfWorks works;
        private readonly IMapper mapper;
        public OrderDetailsManager(IUnitOfWorks _works, IMapper _mapper)
        {
            works = _works;
            mapper = _mapper;
        }
        public IResult Add(OrderDetailsDto data)
        {
            try
            {
                works.OrderDetailsRepository.Add(mapper.Map<OrderDetails>(data));
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
                works.OrderDetailsRepository.Delete(works.OrderDetailsRepository.GetByIdFirst(x => x.Id == Id));
                works.SaveChanges();
                return new Result(ResultStatus.Success, "Silme Başarılı");
            }
            catch (Exception)
            {
                return new Result(ResultStatus.Error, "Silme Başarısız");
            }
        }
        public IDataResult<IList<OrderDetailsDto>> GetAll(int Id)
        {
            IList<OrderDetailsDto> data = new List<OrderDetailsDto>();
            foreach (var item in works.OrderDetailsRepository.GetAll(x => x.OrdersId == Id))
            {
                data.Add(mapper.Map<OrderDetailsDto>(item));
            }
            if (data.Count > 0)
            {
                return new DataResult<IList<OrderDetailsDto>>(ResultStatus.Success, data.Count() + "Kayıt Listelendi", data);
            }
            else
            {
                return new DataResult<IList<OrderDetailsDto>>(ResultStatus.Info, " Kayıt Bulunamadı", null);
            }
        }
        public IDataResult<OrderDetailsDto> GetByIdFirst(int Id)
        {
            var data = works.OrderDetailsRepository.GetByIdFirst(x => x.Id == Id);
            if (data != null)
            {
                return new DataResult<OrderDetailsDto>(ResultStatus.Success, "1 Kayıt Getirildi.", mapper.Map<OrderDetailsDto>(data));
            }
            else
            {
                return new DataResult<OrderDetailsDto>(ResultStatus.Info, "Kayıt Bulunamadı.", null);
            }           
        }
        public IResult Update(OrderDetailsDto data)
        {
            try
            {
                works.OrderDetailsRepository.Update(mapper.Map<OrderDetails>(data));
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
