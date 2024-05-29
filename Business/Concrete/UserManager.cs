using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business;
using Core.DataAccess.EntityFramework;

namespace Business.Concrete
{
    public class UserManager : EntityManagerRepositoryBase<User>, IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal): base(userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}
