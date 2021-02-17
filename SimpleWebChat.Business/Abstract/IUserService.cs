using SimpleWebChat.Entities.Concrete;
using SimpleWebChat.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebChat.Business.Abstract
{
    public interface IUserService
    {
        User GetById(int id);
        void Add(User user);
        List<User> GetUserList();
        User Login(UserForLoginDto userForLOginDto);
        void Delete(User user);
        string GetUserNameById(int id);
        void Update(User user);
    }
}
