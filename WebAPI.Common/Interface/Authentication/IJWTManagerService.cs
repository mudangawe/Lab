using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Common.Model;

namespace WebAPI.Common.Interface.Authentication
{
    public interface IJWTManagerService
    {
        Tokens GenerateToken(UserLogin user);
    }
}
