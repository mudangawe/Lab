using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Common.Model
{
    public class UserLogin
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
