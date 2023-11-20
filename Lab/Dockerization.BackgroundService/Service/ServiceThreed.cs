using Dockerization.BackgroundService.Helpers;
using Dockerization.BackgroundService.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dockerization.BackgroundService.Service
{
    public class ServiceThreed
    {
        private async Task<List<JobModel>> GetJobs() 
        {
            var token = await Authenticate();
            if (token == null)
                throw new Exception("unable to Authenticate");
            var httpresponse = await HttpRequest.HttpGet("https://localhost:44330/api/Jobs", token);
            if(httpresponse.IsSuccessStatusCode)
            {
                var result = await httpresponse.Content.ReadAsStringAsync();
                var JobModels = JsonConvert.DeserializeObject<List<JobModel>>(result);
                return JobModels;
            }
            throw new Exception($"unable to obtain Jobs error: {httpresponse.StatusCode}");
            
        }

        public async Task ExucuteJobs()
       {
            var jobs = await GetJobs();
            var seatherFeedback = new List<WeatherFeedback>();
            foreach (var job in jobs)
            {
                WaitHandle[] waitHandles = new WaitHandle[job.Interval];
                for(var index = 0; index < waitHandles.Count(); index++)
                {
                    var handle = new EventWaitHandle(false, EventResetMode.ManualReset);
                    var thread = new Thread(async () =>
                    {
                        seatherFeedback.Add(await GetJobInfor());
                    });
                    waitHandles[index] = handle;
                    thread.Start();
                }
                WaitHandle.WaitAll(waitHandles);
                Repository.AddWeatherFeedBack(seatherFeedback, job.Id);
            }
          
        }

        private async Task<WeatherFeedback> GetJobInfor()
        {
            var httpresponse = await HttpRequest.HttpGet("https://api.weather.gov/", null);
            if (httpresponse.IsSuccessStatusCode)
            {
                var result = await httpresponse.Content.ReadAsStringAsync();
                var JobModels = JsonConvert.DeserializeObject<WeatherFeedback>(result);
                return JobModels;
            }
            return null;
           
        }

        private async Task<string> Authenticate()
        {
            var content = JsonConvert.SerializeObject(new UserLogin()
            {
                UserName = "Mudangawe",
                Password = "123456789"

            });

            var httpresponse = await HttpRequest.HttpPost("https://localhost:44330/api/Authenticate", content);
            if (httpresponse.IsSuccessStatusCode)
            {
                var result = await httpresponse.Content.ReadAsStringAsync();
                var JobModels = JsonConvert.DeserializeObject<Tokens>(result);
                return JobModels.Token;
            }
            return null;
        }
    }
}
