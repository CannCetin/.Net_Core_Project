using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class UserManager : IUserService
	{
		IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		public List<AppUser> GetList()
		{
			return _userDal.GetListAll();
		}

        public List<AppUser> GetUserById(int id)
        {
            return _userDal.GetListAll(x => x.Id == id);
        }

        public void TAdd(AppUser t)
		{
            _userDal.Insert(t);
        }

		public void TDelete(AppUser t)
		{
			throw new NotImplementedException();
		}

		public AppUser TGetById(int id)
		{
			return _userDal.GetById(id);
		}

		public void TUpdate(AppUser t)
		{
			_userDal.Update(t);
		}
	}
}
