using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace PowerPointLivePolls.BusinessObjects
{
    public class Result
    {
        public string Name { get; set; }
        [JsonProperty(PropertyName="Result")]
        public string Value { get; set; }
        public double Users { get; set; }
        public string Color { get; set; }
        public List<object> CrossedAnswers { get; set; }
    }
}
