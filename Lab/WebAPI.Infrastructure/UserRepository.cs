using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Common.Configuration;
using WebAPI.Common.Entities;
using WebAPI.Common.Interface.IRepository;
using WebAPI.Common.Model;

namespace WebAPI.Infrastructure
{
    public class UserRepository : IUserRepository
    {   
        private readonly Configurations _configuration;
        public UserRepository(Configurations configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> DoesUserExist(UserLogin user)
        {
            using (var connection = new SqlConnection(_configuration.DbConnection))
            {
                var sql = $"SELECT [Id],[UserName],[Name],[Email],[Password],[CreatedDate]" +
                    $" FROM [Dockerization].[dbo].[UserInfo] where [UserName] = @UserName and [Password] = @Password";
                var values = new
                {
                    UserName = user.UserName,
                    Password = user.Password
                };
                var result = await connection.QueryAsync<UserInfo>(sql, values);
                return result.Count() > 0;
            }
        }
    }
}
