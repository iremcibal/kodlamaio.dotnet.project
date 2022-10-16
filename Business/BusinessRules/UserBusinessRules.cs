using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class UserBusinessRules
    {
        private IUserDal _userDal;

        public UserBusinessRules(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void CheckIfUserExist(User? user)
        {
            if (user == null)
            {
                throw new Exception("User not be exist");
            }
        }

        public void CheckIfUserNotExist(User? user)
        {
            if (user != null)
            {
                throw new Exception("User already exist");
            }
        }

        public void CheckIfUserExist(int userId)
        {
            User? user = _userDal.Get(b => b.Id == userId);
            CheckIfUserExist(user);
        }

        public void CheckIfUserNameExist(string firstName)
        {
            User? user = _userDal.Get(b => b.FirstName == firstName);
            CheckIfUserNotExist(user);
        }
    }
}
