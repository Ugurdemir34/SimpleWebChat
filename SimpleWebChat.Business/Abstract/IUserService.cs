using SimpleWebChat.Entities.Concrete;
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


    }
}
