﻿using NetInfoCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetInfoHalper
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tcpOpenPortsList = OpenPorts.getAllPortsAsStringList();

            foreach(var p in tcpOpenPortsList)
            {
                Console.WriteLine(p);
            }

            Console.ReadKey();
        }
    }
}