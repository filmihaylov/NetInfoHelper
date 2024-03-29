﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetInfoCore.DTOS
{
    public class NetTcpConnectionDTO
    {
        public string LocalAddress { get; set; }
        public string LocalPort { get; set; }
        public string RemoteAddress { get; set; }
        public string RemotePort { get; set; }
        public string State { get; set; }
        public string OwningProcess { get; set; }
    }
}
