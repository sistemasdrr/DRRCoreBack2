using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRCore.Domain.Entities.SqlCoreContext
{
    public class Settings
    {
        public string SecretKey { get; set; }
        public string System { get; set; }
        public string SubSystem { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SessionTime { get; set; }
    }
}
