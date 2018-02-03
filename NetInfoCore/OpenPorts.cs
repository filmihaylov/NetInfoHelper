﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace NetInfoCore
{
    public static class OpenPorts
    {
        public static List<string> getAllPortsAsStringList()
        {
            using (PowerShell PowershellInstance = PowerShell.Create())
            {
                List<string> psOutputStringList = new List<string>();
                PowershellInstance.AddCommand("Get-NetTCPConnection");
                Collection<PSObject> PSOutput = PowershellInstance.Invoke();

                foreach (PSObject outputItem in PSOutput)
                {


                    if (outputItem != null)
                    {

                        var netDTOOBJECT = JsonConvert.SerializeObject(outputItem.Properties.ToDictionary(k => k.Name, v => v.Value));

                        var netDTO = JsonConvert.DeserializeObject<NetTcpConnectionDTO>(netDTOOBJECT);

                        string buildTheDesiredString = null;
                        if (netDTO != null)
                        {
                             buildTheDesiredString = "Local Adress: " + netDTO.LocalAddress + ":" + netDTO.LocalPort + "|Foreign Adress: " + netDTO.RemoteAddress + ":" +
                                netDTO.RemotePort + "|State of Connection: " + netDTO.State + "|PID of spawing process:" + netDTO.OwningProcess;
                        }
                        psOutputStringList.Add(buildTheDesiredString);
                    }
                }

                return psOutputStringList;
            }
        }  
    }
}