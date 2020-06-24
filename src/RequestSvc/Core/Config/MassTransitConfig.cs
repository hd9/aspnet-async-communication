using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestSvc.Core.Config
{
    public class MassTransitConfig
    {
        public string Host { get; set; }
        public string Queue { get; set; }
    }
}
