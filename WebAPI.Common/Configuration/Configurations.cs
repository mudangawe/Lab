using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Common.Configuration
{
    public class Configurations
    {
        public readonly IConfiguration _iConfiguration;
        public Configurations(IConfiguration _iConfiguration) {
            this._iConfiguration = _iConfiguration;

            DbConnection = _iConfiguration.GetConnectionString("localDb");
            JWTKey = _iConfiguration["JWT:Issuer"];
            JWTAudience = _iConfiguration["JWT:Audience"];
        }
        public string DbConnection { get; set; }
        public string JWTKey { get; set; }
        public string JWTAudience { get; set; }
    }
}
