using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerPointLivePolls.BusinessObjects
{
    public class QuestionList
    {
        public string ProjectId { get; set; }
        public string QuestionId { get; set; }
        public int ProjectIsOpen { get; set; }
        public bool IsPreview { get; set; }
        public int Order { get; set; }
        public string QuestionText { get; set; }
        public int QuestionType { get; set; }
        public int RecordingStatus { get; set; }
        public List<Answer> Answers { get; set; }
        public List<Result> Results { get; set; }
        public object LiveQuestion { get; set; }
        public bool DisplayPCT { get; set; }
        public bool DisplayCNT { get; set; }
        public int CrossingType { get; set; }
    }
}
