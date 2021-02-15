using SimpleWebChat.Core.DataAccess.EntityFramework;
using SimpleWebChat.DataAccess.Abstract;
using SimpleWebChat.DataAccess.Concrete.EntityFramework.Contexts;
using SimpleWebChat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebChat.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ChatContext>, IUserDal
    {
        
    }
}
