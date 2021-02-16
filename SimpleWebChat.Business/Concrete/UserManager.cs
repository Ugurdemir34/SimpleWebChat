using SimpleWebChat.Business.Abstract;
using SimpleWebChat.DataAccess.Abstract;
using SimpleWebChat.Entities.Concrete;
using SimpleWebChat.Entities.Dtos;
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

        public void Delete(User user)
        {
            var userForDelete = _userDal.Get(i => i.Id == user.Id);
            _userDal.Delete(userForDelete);
        }

        public User GetById(int id)
        {
           return _userDal.Get(i => i.Id == id);
        }
        public List<User> GetUserList()
        {
            return _userDal.GetList();
        }

        public User Login(UserForLoginDto userForLOginDto)
        {
            var userToCheck = _userDal.Get(i => i.Username == userForLOginDto.Username && i.Password == userForLOginDto.Password);
            return userToCheck;
        }
    }
}
