using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Web;

namespace MiniTorrent.Models
{
    public class UploadRequestHandler 
    {
      
      

        public UploadRequestHandler()
        {
            Task task = new Task(StartListening);
            task.Start();
        }

        private void StartListening()
        {
            AsynchronousSocketListener.StartListening();

        }
    }
}