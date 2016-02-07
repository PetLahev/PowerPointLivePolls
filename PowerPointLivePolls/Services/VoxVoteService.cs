using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;

namespace PowerPointLivePolls.Services
{
    public class VoxVoteService : ServiceBase
    {        
        private readonly string _baseUrl = "https://api.voxvote.com/";
        
        public VoxVoteService() {}

        internal VoxVoteService(IServiceManager mngr)
        {
            ConnectionManager = mngr;
        }

        internal override string GetProjectData(string url)
        {
            //string url = String.Format("{0}{1}{2}", _baseUrl, "project/EventSummary?Id=", id);
            //var test = GetProjectData(url); 
            return null;
        }

        internal override string GetProjects(string url)
        {
            return base.GetProjects(url);
        }

        //internal virtual void GetEventData()
        //{
        //    var response = ""; // _srvMngr.GetProjectData("cf6f844b-955a-46bc-9ab0-a50a007f2252");
        //    if (string.IsNullOrWhiteSpace(response)) throw new Exceptions.ServiceException("Could not get any data!");

        //    var data = JsonConvert.DeserializeObject<BusinessObject.RootObject>(response);
        //    if (data == null) throw new Exceptions.ServiceException("No data returned for given project");

        //    Core.ChartPOC charting = new Core.ChartPOC(data, Globals.ThisAddIn.Application.ActivePresentation);
        //    charting.AddChart();

        //}

    }
}
