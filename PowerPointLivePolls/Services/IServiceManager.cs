using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerPointLivePolls.Services
{
    public interface IServiceManager
    {
        /// <summary>Gets data from service based on given ID</summary>
        string GetProjectData(string url);

    }
}
