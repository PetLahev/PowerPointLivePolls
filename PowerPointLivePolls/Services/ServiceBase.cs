using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace PowerPointLivePolls.Services
{
    /// <summary>Provide common function for all service implementations</summary>
    public abstract class ServiceBase
    {
        private IServiceManager _srvMngr;
        
        /// <summary>Used for testing</summary>
        internal IServiceManager ConnectionManager
        {
            get { return _srvMngr ?? new ServiceManager();}
            set {_srvMngr = value;}
        }
 
        /// <summary>Connects to service and returns response as string</summary>
        /// <param name="url">full URL to get data from</param>
        /// <returns>response as string or null</returns>
        internal virtual string  GetProjectData(string url)
        {
            return ConnectionManager.GetProjectData(url);
        }

        internal virtual string GetProjects(string url)
        {
            return ConnectionManager.GetProjectData(url);
        }

    }
}
