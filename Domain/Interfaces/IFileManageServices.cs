using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFileManageServices
    {
        void DownloadFile(string fileName);
        void DownloadFiles(List<string> filenameList);
        List<string[]> getFiles(List<string> pathList);



    }
}
