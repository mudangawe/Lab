using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Common.Model;

namespace WebAPI.Common.Interface.IRepository
{
    public interface IUserRepository
    {
        Task<bool> DoesUserExist(UserLogin user);
    }
}
