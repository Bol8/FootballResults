using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Manage
{
    public class FileConfigManage:IConfigManageServices
    {
       
        public FileConfigManage() { }


        public string getValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public List<string> getValues(string key)
        {
            return ConfigurationManager.AppSettings[key].Split(';').Select(x => x.Trim()).ToList();
        }
    }
}
