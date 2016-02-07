using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace PowerPointLivePolls.Services
{
    /// <summary>
    /// Responsible for communicating to service
    /// Keep it simple, no business logic here!
    /// </summary>
    public class ServiceManager : IServiceManager
    {   
        string IServiceManager.GetProjectData(string url)
        {
            var client = new WebClient();
            var content = client.DownloadString(url);
            return content.ToString();
        }
    }
}
