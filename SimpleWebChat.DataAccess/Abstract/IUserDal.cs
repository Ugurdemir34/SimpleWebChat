using SimpleWebChat.Core.DataAccess;
using SimpleWebChat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebChat.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
       /* void AddUser(User user);
        void DeleteUser(User user);
        User GetUserById(int id);*/
    }
}
