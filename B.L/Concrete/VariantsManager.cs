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
    public class VariantsManager : IVariantsService
    {
        private readonly IUnitOfWorks works;
        private readonly IMapper mapper;
        public VariantsManager(IUnitOfWorks _works, IMapper _mapper)
        {
            works = _works;
            mapper = _mapper;
        }
        public IResult Add(VariantsDto data)
        {
            try
            {
                works.VariantsRepository.Add(mapper.Map<Variants>(data));
                works.SaveChanges();
                return new Result(ResultStatus.Success, "Kayıt Başarılı");
            }
            catch (Exception)
            {
                return new Result(ResultStatus.Error, "Kayıt Başarısız");
            }
        }
        public IResult Delete(int id)
        {
            try
            {
                works.VariantsRepository.Delete(works.VariantsRepository.GetByIdFirst(x => x.Id == id));
                works.SaveChanges();
                return new Result(ResultStatus.Success, "Silme Başarılı");
            }
            catch (Exception)
            {
                return new Result(ResultStatus.Error, "Silme Başarısız");
            }
        }
        public IDataResult<IList<VariantsDto>> GetAll(int Id)
        {
            IList<VariantsDto> data = new List<VariantsDto>();
            foreach (var item in works.VariantsRepository.GetAll(x => x.ProductsId == Id))
            {
                data.Add(mapper.Map<VariantsDto>(item));
            }
            if (data.Count > 0)
            {
                return new DataResult<IList<VariantsDto>>(ResultStatus.Success, data.Count() + "Kayıt Listelendi", data);
            }
            else
            {
                return new DataResult<IList<VariantsDto>>(ResultStatus.Info, " Kayıt Bulunamadı", null);
            }
        }
        public VariantsDto GetByIdFirst(int Id)
        {
            return mapper.Map<VariantsDto>(works.VariantsRepository.GetByIdFirst(x => x.Id == Id));
        }
        public IResult Update(VariantsDto data)
        {
            try
            {
                works.VariantsRepository.Update(mapper.Map<Variants>(data));
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
