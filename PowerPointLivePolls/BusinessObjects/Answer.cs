using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerPointLivePolls.BusinessObjects
{
    public class Answer
    {
        public string AnswerId { get; set; }
        public int Order { get; set; }
        public string Label { get; set; }
        public object Value { get; set; }
        public string Color { get; set; }
        public bool IsCorrect { get; set; }
        public double Weight { get; set; }
        public bool IsExclusive { get; set; }
        public int ResultsCount { get; set; }
    }
}
