using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Common.Configuration;
using WebAPI.Common.Entities;
using WebAPI.Common.Interface.IRepository;

namespace WebAPI.Infrastructure
{
    public class JobsRepository : IRepository<JobModel>
    {
        public readonly Configurations _iConfiguration;
        public JobsRepository(Configurations _iConfiguration) 
        {
            this._iConfiguration = _iConfiguration;
        }
        public async Task<bool> Add(JobModel obj)
        {
            var sql = "INSERT INTO [dbo].[Jobs] ([Name] ,[Description] ,[LastRunTime] ,[Interval]) " +
                "VALUES (@Name ,@Description ,@LastRunTime ,@Interval)";
            using (var connection = new SqlConnection(_iConfiguration.DbConnection))
            {
                var values = new {
                    Name = obj.Name,
                    Description = obj.Description,
                    LastRunTime = obj.LastRunTime,
                    Interval = obj.Interval,
               };
               var result = await  connection.ExecuteAsync(sql, values);
                return result > 0;
            }
           
        }

        public async Task<IEnumerable<JobModel>> GetAll()
        {
            var sql = "select * from Jobs";
            using (var connection = new SqlConnection(_iConfiguration.DbConnection))
            {
                var result = await connection.QueryAsync<JobModel>(sql);
                return result.ToList();
            }
            
        }

        public Task<bool> GetBy(Expression<Func<JobModel, bool>> obj)
        {
            throw new NotImplementedException();
        }
    }
}
