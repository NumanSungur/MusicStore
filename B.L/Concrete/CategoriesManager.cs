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
    public class CategoriesManager : ICategoriesService
    {
        private readonly IUnitOfWorks works;
        private readonly IMapper mapper;
        public CategoriesManager(IUnitOfWorks _works, IMapper _mapper)
        {
            works = _works;
            mapper = _mapper;
        }
        public IResult Add(CategoriesDto data)
        {
            try
            {
                works.CategoriesRepository.Add(mapper.Map<Categories>(data));
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
                works.CategoriesRepository.Delete(works.CategoriesRepository.GetByIdFirst(x => x.Id == Id));
                works.SaveChanges();
                return new Result(ResultStatus.Success, "Silme Başarılı");
            }
            catch (Exception)
            {
                return new Result(ResultStatus.Error, "Silme Başarısız");
            }
        }
        public IDataResult<IList<CategoriesDto>> GetAll(int Id)
        {
            IList<CategoriesDto> data = new List<CategoriesDto>();
            foreach (var item in works.CategoriesRepository.GetAll(x=>x.ParentId == Id))
            {
                data.Add(mapper.Map<CategoriesDto>(item));
            }
            if (data.Count > 0)
            {
                return new DataResult<IList<CategoriesDto>>(ResultStatus.Success, data.Count() + "Kayıt Listelendi", data);
            }
            else
            {
                return new DataResult<IList<CategoriesDto>>(ResultStatus.Info, " Kayıt Bulunamadı", null);
            }
        }
        public IDataResult<CategoriesDto> GetByIdFirst(int Id)
        {
            var data = works.CategoriesRepository.GetByIdFirst(x => x.Id == Id);
            if (data != null)
            {
                return new DataResult<CategoriesDto>(ResultStatus.Success, "1 Kayıt Getirildi.", mapper.Map<CategoriesDto>(data));
            }
            else
            {
                return new DataResult<CategoriesDto>(ResultStatus.Info, "Kayıt Bulunamadı.", null);
            }
        }
        public IResult Update(CategoriesDto data)
        {
            try
            {               
                works.CategoriesRepository.Update(mapper.Map<Categories>(data));
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
