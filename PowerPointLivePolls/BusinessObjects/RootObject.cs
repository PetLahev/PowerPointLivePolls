using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerPointLivePolls.BusinessObjects
{
    public class RootObject
    {
        public string ProjectSessionId { get; set; }
        public string ProjectId { get; set; }
        public string Location { get; set; }
        public string ProjectName { get; set; }
        public string Date { get; set; }
        public List<QuestionList> QuestionList { get; set; }
        public int SentEmails { get; set; }
        public object Email { get; set; }
        public Sessions Sessions { get; set; }
        public int TotalSessions { get; set; }
    }
}
