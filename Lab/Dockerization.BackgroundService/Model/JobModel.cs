using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dockerization.BackgroundService.Model
{
    public class JobModel
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
      
        public string Description { get; set; }
       
        public DateTime LastRunTime { get; set; }
        public int Interval { get; set; }
    }
}
