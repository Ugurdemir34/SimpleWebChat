using SimpleWebChat.Business.Abstract;
using SimpleWebChat.DataAccess.Abstract;
using SimpleWebChat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebChat.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Add(User user)
        {
            _userDal.Add(user);
        }
        public User GetById(int id)
        {
           return _userDal.Get(i => i.Id == id);
        }
        public List<User> GetUserList()
        {
            return _userDal.GetList();
        }
    }
}
