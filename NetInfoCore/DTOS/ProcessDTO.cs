﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetInfoCore.DTOS
{
    public class ProcessDTO
    {
        public int Id { get; set; }
        public string ExecutablePath { get; internal set; }
        public string Name { get; internal set; }
        public uint ParentPID { get; internal set; }
    }
}
