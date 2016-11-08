using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Manage
{
    public class FileManage:IFileManageServices
    {
        private readonly string pathRemoteResource;
        private readonly string pathLocalResource;
        private readonly WebClient _webClient;


        //public FileManage(string pathRemoteResource, string pathLocalResource)
        //{
        //    this.pathRemoteResource = pathRemoteResource;
        //    this.pathLocalResource = pathLocalResource;
        //}

        public FileManage(WebClient webclient, string pathRemoteResource, string pathLocalResource)
        {
            _webClient = webclient;
            this.pathRemoteResource = pathRemoteResource;
            this.pathLocalResource = pathLocalResource;
        }


        public void DownloadFile(string fileName)
        {
            using (_webClient)
            {
                var localPath = pathLocalResource + "" + fileName;
                var remoteResource = pathRemoteResource + "" + fileName;

                _webClient.DownloadFile(remoteResource, localPath);
            }
        }


        public void DownloadFiles(List<String> fileNameList)
        {
            using (_webClient)
            {
                foreach (var fileName in fileNameList)
                {
                    var localPath = pathLocalResource + "" + fileName;
                    var remoteResource = pathRemoteResource + "" + fileName;

                    _webClient.DownloadFile(remoteResource, localPath);
                }
            }
        }

        public List<string[]> getFiles(List<string> pathList)
        {
           var list = new List<string[]>();

            foreach (var path in pathList)
            {
                list.Add(System.IO.File.ReadAllLines(path));
            }


            return list;
        }
    }
}
