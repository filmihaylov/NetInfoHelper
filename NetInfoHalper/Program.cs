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
            var b = Processes.getAllProcessDTOS();
            foreach(var a in b)
            {
                Console.Write(a.Id);
                Console.WriteLine("-------------"+a.Name);
            }

            Console.ReadKey();
        }
    }
}
