


using System.Collections.Generic;

namespace Infrastructure.AppManage.Interfaces
{
    public interface IFileManageServices
    {
        void DownloadFile(string fileName);
        void DownloadFiles(List<string> filenameList);
        List<string[]> getFiles(List<string> pathList);



    }
}
