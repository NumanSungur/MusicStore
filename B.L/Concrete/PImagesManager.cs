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
    public class PImagesManager : IPImagesService
    {
        private readonly IUnitOfWorks works;
        private readonly IMapper mapper;
        public PImagesManager(IUnitOfWorks _works, IMapper _mapper)
        {
            works = _works;
            mapper = _mapper;
        }
        public IResult Add(PImagesDto data)
        {
            try
            {
                works.PImagesRepository.Add(mapper.Map<PImages>(data));
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
                works.PImagesRepository.Delete(works.PImagesRepository.GetByIdFirst(x => x.Id == Id));
                works.SaveChanges();
                return new Result(ResultStatus.Success, "Silme Başarılı");
            }
            catch (Exception)
            {
                return new Result(ResultStatus.Error, "Silme Başarısız");
            }
        }
        public IDataResult<IList<PImagesDto>> GetAll(int Id)
        {
            IList<PImagesDto> data = new List<PImagesDto>();
            foreach (var item in works.PImagesRepository.GetAll(x => x.ProductsId == Id))
            {
                data.Add(mapper.Map<PImagesDto>(item));
            }
            if (data.Count > 0)
            {
                return new DataResult<IList<PImagesDto>>(ResultStatus.Success, data.Count() + "Kayıt Listelendi", data);
            }
            else
            {
                return new DataResult<IList<PImagesDto>>(ResultStatus.Info, " Kayıt Bulunamadı", null);
            }
        }
        public IDataResult<PImagesDto> GetByIdFirst(int Id)
        {           
            var data = works.PImagesRepository.GetByIdFirst(x => x.Id == Id);
            if (data != null)
            {
                return new DataResult<PImagesDto>(ResultStatus.Success, "1 Kayıt Getirildi.", mapper.Map<PImagesDto>(data));
            }
            else
            {
                return new DataResult<PImagesDto>(ResultStatus.Info, "Kayıt Bulunamadı.", null);
            }
        }
        public IResult Update(PImagesDto data)
        {
            try
            {
                works.PImagesRepository.Update(mapper.Map<PImages>(data));
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
