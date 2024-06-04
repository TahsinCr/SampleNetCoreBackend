﻿using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using Business.Constants;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult AddClaim(User user, OperationClaim operationClaim)
        {
            _userDal.AddClaim(user, operationClaim);
            return new SuccessResult();
        }

        public IDataResult<User> GetByMail(string email)
        {
            User? result = _userDal.Get(u => u.Email == email);

            if (result != null) return new SuccessDataResult<User>(result);
            else return new ErrorDataResult<User>(Messages.UserNotFound);
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }
    }
}
