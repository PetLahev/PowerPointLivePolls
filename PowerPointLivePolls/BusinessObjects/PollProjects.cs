using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PowerPointLivePolls.BusinessObjects
{
    [XmlRoot]
    public class PollProjects
    {
        /// <summary>Sets/Gets list of projects</summary>
        [XmlArrayItem("Project")]
        public List<PollProject> Projects { get; set; }

    }
}
