﻿using NetInfoCore.DTOS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Diagnostics;

namespace NetInfoCore
{
    public static class Processes
    {

        public static PathDTO getProcessPath(int PID)
        {
            PathDTO path = new PathDTO();
            var wmiQueryString = "SELECT ProcessId, ExecutablePath, CommandLine FROM Win32_Process";
            using (var searcher = new ManagementObjectSearcher(wmiQueryString))
            using (var results = searcher.Get())
            {
                var query = from p in Process.GetProcesses()
                            join mo in results.Cast<ManagementObject>()
                            on p.Id equals (int)(uint)mo["ProcessId"]
                            select new
                            {
                                Process = p,
                                Path = (string)mo["ExecutablePath"],
                                CommandLine = (string)mo["CommandLine"],
                            };

                foreach (var item in query)
                {
                   if (item.Process.Id == PID)
                    {
                        path.Path = item.Path;
                    }
                }
            }

            return path;
        }

        public static List<ProcessDTO> getAllProcessDTOS()
        {
            List <ProcessDTO> processList = new List<ProcessDTO>();
            var wmiQueryString = "SELECT ProcessId, ExecutablePath, Name, ParentProcessId, CommandLine FROM Win32_Process";
            using (var searcher = new ManagementObjectSearcher(wmiQueryString))
            using (var results = searcher.Get())
            {
                var query = from p in Process.GetProcesses()
                            join mo in results.Cast<ManagementObject>()
                            on p.Id equals (int)(uint)mo["ProcessId"]
                            select new
                            {
                                Process = p,
                                ParentPID = (UInt32)mo["ParentProcessId"],
                                Path = (string)mo["ExecutablePath"],
                                Name = (string)mo["Name"],
                                CommandLine = (string)mo["CommandLine"],
                            };
                foreach (var item in query)
                {
                    ProcessDTO process = new ProcessDTO();
                    process.Id = item.Process.Id;
                    process.ExecutablePath = item.Path;
                    process.Name = item.Name;
                    process.ParentPID = item.ParentPID;
                    processList.Add(process);
               
                }
            }

            return processList;
        }
    }
}
