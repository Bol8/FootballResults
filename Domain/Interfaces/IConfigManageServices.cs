using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IConfigManageServices
    {
        string getValue(string key);
        List<string> getValues(string key);

    }
}
