﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetInfoCore.DTOS
{
    public class NetUdpConnectionsDTO
    {
        public int OwningProcess { get; set; }
        public int LocalPort { get; set; }
    }
}
