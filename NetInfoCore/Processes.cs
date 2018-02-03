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
    public static class Processes
    {
        public static List<ProcessDTO> getAllProcessDTOS()
        {
            using (PowerShell PowershellInstance = PowerShell.Create())
            {
                ProcessDTO processDto = null;
                List<ProcessDTO> processDTOList = new List<ProcessDTO>();
                PowershellInstance.AddCommand("Get-Process");
                Collection<PSObject> PSOutput = PowershellInstance.Invoke();
                foreach (PSObject outputItem in PSOutput)
                {
                    if (outputItem != null)
                    {
                        Dictionary<string, object> parser = new Dictionary<string, object>();

                        foreach(var a in outputItem.Properties)
                        {
                            try
                            {
                                string b = a.Name;
                                Object c = a.Value;
                                parser.Add(a.Name, a.Value);
                               
                            }
                            catch
                            {

                            }
                        }
                        try
                        {
                            var processDTOObject = JsonConvert.SerializeObject(parser);
                            processDto = JsonConvert.DeserializeObject<ProcessDTO>(processDTOObject);
                        }
                        catch
                        {

                        }
                        if (processDto != null)
                        {
                            processDTOList.Add(processDto);
                        }
                    }
                }
                return processDTOList;
            }
        }
    }
}
