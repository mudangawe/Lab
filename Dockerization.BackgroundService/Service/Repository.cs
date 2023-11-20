using Dapper;
using Dockerization.BackgroundService.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dockerization.BackgroundService.Service
{
    static class Repository
    {
        public static int AddWeatherFeedBack(List<WeatherFeedback> weatherFeedbacks, int JobId)
        {
			var sql = "INSERT INTO [dbo].[WeatherFeedBack]([Status],[JobId],[DateAdded])" +
				   "VALUES(@Status,@JobId,@DateAdded)";
			using (var connection = new SqlConnection(""))
            {
                var values = new List<object>();
                weatherFeedbacks.ForEach(x =>
                {
                    values.Add(new
                    {
                        Status = x.Status,
                        JobId = JobId,
                        DateAdded = DateTime.Now
                    });
                }
                );
				var rowsAffected = connection.Execute(sql, values);
                return rowsAffected;
			}
        }
    }
}
