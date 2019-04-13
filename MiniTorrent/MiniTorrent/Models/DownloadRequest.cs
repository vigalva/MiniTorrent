using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Web;

namespace MiniTorrent.Models
{
    public class DownloadRequest
    {
        private User uploadUser;
        private string namefile;
        private string downloadPath;



        public DownloadRequest(User uploadUser, string namefile,String downloadPath)
        {
            this.uploadUser = uploadUser;
            this.namefile = namefile;
            this.downloadPath = downloadPath;

            Task task = new Task(StartDownload);
            task.Start();
        }

        private void StartDownload()
        {
            AsynchronousClient.StartClient(uploadUser.IP,namefile,downloadPath);
        }
    }
}