
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Infrastructure.AppManage.Interfaces;

namespace Infrastructure.AppManage.Manage
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
