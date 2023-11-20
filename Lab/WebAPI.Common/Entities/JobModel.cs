using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Common.Entities
{
    public class JobModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime LastRunTime { get; set; }

        [Required]
        [Range(1, 60)]
        public int Interval { get; set; }
    }
}
