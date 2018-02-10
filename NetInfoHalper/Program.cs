﻿using NetInfoCore;
using NetInfoCore.DTOS;
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

                foreach (ProcessDTO a in b)
            {
                Console.WriteLine("ID = :"+ a.Id  + "Executable Path =: "+ a.ExecutablePath + "Process NAme ====" + a.Name + "PARENT PID +++++ ====" + a.ParentPID);
            }

            var c = Processes.getProcessPath(832);

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");

            Console.WriteLine(c.Path);



            Console.ReadKey();
        }
    }
}
