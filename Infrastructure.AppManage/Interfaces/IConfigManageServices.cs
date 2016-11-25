


using System.Collections.Generic;

namespace Infrastructure.AppManage.Interfaces
{
    public interface IConfigManageServices
    {
        string getValue(string key);
        List<string> getValues(string key);

    }
}
