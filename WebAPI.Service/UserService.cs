using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Common.Interface.Authentication;
using WebAPI.Common.Interface.IRepository;
using WebAPI.Common.Model;

namespace WebAPI.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _iUserRepository;
        private readonly IJWTManagerService _iJWTManagerService;
        public UserService(IUserRepository iUserRepository, IJWTManagerService iJWTManagerService)
        {
            this._iUserRepository = iUserRepository;
            this._iJWTManagerService = iJWTManagerService;
        }
        public async Task<Tokens> Authenticate(UserLogin login)
        {
            if(await _iUserRepository.DoesUserExist(login))
            {
                var token = _iJWTManagerService.GenerateToken(login);
                return token;
            }
            return null;
        }
    }
}
