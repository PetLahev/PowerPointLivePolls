using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PowerPointLivePolls.BusinessObjects
{
    /// <summary>Specifies data about a project</summary>
    [Serializable]    
    public class PollProject : IEquatable<PollProject>
    {
        /// <summary>Sets/Gets the name of a project</summary>
        public string Name { get; set; }
        
        /// <summary>Sets/Gets the id of a project</summary>
        public string Id { get; set; }

        /// <summary>Sets/Gets list of questions for the project</summary>
        public List<QuestionList> Questions { get; set; }
       
        public bool Equals(PollProject other)
        {
            if (other == null) return false;
            return this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            PollProject emp = obj as PollProject;
            if (emp != null)
            {
                return Equals(emp);
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Id);
        }

    }
}
