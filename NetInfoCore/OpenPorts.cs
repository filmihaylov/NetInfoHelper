﻿using NetInfoCore.DTOS;
using Newtonsoft.Json;
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
        public static List<NetUdpConnectionsDTO> getAllUdpObjects()
        {
            using (PowerShell PowershellInstance = PowerShell.Create())
            {
                List<NetUdpConnectionsDTO> netUdpConnectionDTOList = new List<NetUdpConnectionsDTO>();
                PowershellInstance.AddCommand("Get-NetUDPEndpoint");
                Collection<PSObject> PSOutput = PowershellInstance.Invoke();

                foreach (PSObject outputItem in PSOutput)
                {
                    if (outputItem != null)
                    {

                        var udpDTOOBJECT = JsonConvert.SerializeObject(outputItem.Properties.ToDictionary(k => k.Name, v => v.Value));

                        var udpDTO = JsonConvert.DeserializeObject<NetUdpConnectionsDTO>(udpDTOOBJECT);

                        if (udpDTO != null)
                        {
                            netUdpConnectionDTOList.Add(udpDTO);
                        }
                    }
                }

                return netUdpConnectionDTOList;
            }
        }


            public static List<NetTcpConnectionDTO> getAllTcpObjects()
        {
            using (PowerShell PowershellInstance = PowerShell.Create())
            {
                List<NetTcpConnectionDTO> netTcpConnectionDTOList = new List<NetTcpConnectionDTO>();
                PowershellInstance.AddCommand("Get-NetTCPConnection");
                Collection<PSObject> PSOutput = PowershellInstance.Invoke();

                foreach (PSObject outputItem in PSOutput)
                {
                    if (outputItem != null)
                    {

                        var tcpDTOOBJECT = JsonConvert.SerializeObject(outputItem.Properties.ToDictionary(k => k.Name, v => v.Value));

                        var tcpDTO = JsonConvert.DeserializeObject<NetTcpConnectionDTO>(tcpDTOOBJECT);

                        if (tcpDTO != null)
                        {
                            netTcpConnectionDTOList.Add(tcpDTO);
                        }
                    }
                }

                return netTcpConnectionDTOList;
            }
        }  
    }
}
