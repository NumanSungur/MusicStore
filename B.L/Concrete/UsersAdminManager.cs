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
    public class UsersAdminManager : IUsersAdminService
    {
        private readonly IUnitOfWorks works;
        private readonly IMapper mapper;
        public UsersAdminManager(IUnitOfWorks _works, IMapper _mapper)
        {
            works = _works;
            mapper = _mapper;
        }
        public IResult Add(UsersAdminDto data)
        {
            try
            {
                works.UsersAdminRepository.Add(mapper.Map<UsersAdmin>(data));
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
                works.UsersAdminRepository.Delete(works.UsersAdminRepository.GetByIdFirst(x => x.Id == Id));
                works.SaveChanges();
                return new Result(ResultStatus.Success, "Silme Başarılı");
            }
            catch (Exception)
            {
                return new Result(ResultStatus.Error, "Silme Başarısız");
            }
        }
        public IDataResult<IList<UsersAdminDto>> GetAll()
        {
            IList<UsersAdminDto> data = new List<UsersAdminDto>();
            foreach (var item in works.UsersAdminRepository.GetAll())
            {
                data.Add(mapper.Map<UsersAdminDto>(item));
            }
            if (data.Count > 0)
            {
                return new DataResult<IList<UsersAdminDto>>(ResultStatus.Success, data.Count() + "Kayıt Listelendi", data);
            }
            else
            {
                return new DataResult<IList<UsersAdminDto>>(ResultStatus.Info, " Kayıt Bulunamadı", null);
            }
        }
        public IDataResult<UsersAdminDto> GetById(int Id)
        {
            var data = works.UsersAdminRepository.GetByIdFirst(x => x.Id == Id);
            if (data != null)
            {
                return new DataResult<UsersAdminDto>(ResultStatus.Success, "1 Kayıt Getirildi.", mapper.Map<UsersAdminDto>(data));
            }
            else
            {
                return new DataResult<UsersAdminDto>(ResultStatus.Info, "Kayıt Bulunamadı.", null);
            }
        }

        public IDataResult<UsersAdminDto> Login(string Email, string Password)
        {
            var data = works.UsersAdminRepository.GetByIdFirst(x => x.Email == Email && x.Password == Password);
            if (data != null)
            {
                return new DataResult<UsersAdminDto>(ResultStatus.Success, "", mapper.Map<UsersAdminDto>(data));
            }
            else
            {
                return new DataResult<UsersAdminDto>(ResultStatus.Info, "Kayıt Bulunamadı.", null);
            }
        }

        public IResult Update(UsersAdminDto data)
        {
            try
            {
                works.UsersAdminRepository.Update(mapper.Map<UsersAdmin>(data));
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