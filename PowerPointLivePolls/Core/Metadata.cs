using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PPT = Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;
using PowerPointLivePolls.BusinessObjects;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace PowerPointLivePolls.Core
{
    public class Metadata
    {
        private const string DEFAULT_NS = "LivePollsData";
        private readonly PPT.Presentation _ppt;

        /// <summary>Constructor</summary>
        /// <param name="presentation">a reference to the active presentation</param>
        public Metadata(PPT.Presentation presentation)
        {
            _ppt = presentation;
        }

        /// <summary>Checks if active presentation is set with live data. Must have correct namespace applied.</summary>
        /// <returns>True if is set otherwise false</returns>
        public bool HasProjects
        {
            get
            {
                var projects = GetPollCustomPart();
                return (projects != null  && projects.Count() > 0); 
            }
        }

        public void AssignToProject(string projectId)
        {
            
        }

        /// <summary>Removes project with given id from custom XML</summary>
        /// <param name="projectId">id o project to be removed</param>
        /// <returns>True if successfully removed, otherwise false</returns>
        public bool RemoveProject(string projectId)
        {
            var project = GetProject(projectId);
            if (project == null) return false;

            var projects = GetProjects();
            projects.Projects.Remove(project);
            Save(projects);
            return true;
        }

        /// <summary>Checks if project namespace exists and returns the project according to given id</summary>
        /// <param name="projectId">id of project to get</param>
        /// <returns>the project data or null</returns>
        public PollProject GetProject(string projectId)
        {
            if (!HasProjects) return null;
            var projects = GetPollCustomPart();           

            var data = Deserialize(projects.First().XML);
            if (data == null) return null;
            return data.Projects.FirstOrDefault(x => x.Id.Equals(projectId));
        }

        /// <summary>Checks if project namespace exists and returns all projects</summary>
        /// <returns>all projects in Poll namespace or null if doesn't exists</returns>
        public PollProjects GetProjects()
        {
            if (!HasProjects) return null;            
            var projects = GetPollCustomPart();
            
            var data = Deserialize(projects.First().XML);
            return data;
        }

        public bool Save(BusinessObjects.PollProjects data)
        {
            try 
	        {
                RemoveAll();
                _ppt.CustomXMLParts.Add(Serialize(data));
                return true;
	        }
	        catch (Exception)
	        {		
		        throw;
	        }
        }

        public bool RemoveAll()
        {
            try
            {
                for (int i = _ppt.CustomXMLParts.Count; i >= 1; i--)
                {
                    CustomXMLPart part = _ppt.CustomXMLParts[i];
                    bool found = false;
                    foreach (CustomXMLPrefixMapping ns in part.NamespaceManager.Cast<CustomXMLPrefixMapping>())
                    {
                        if (ns.NamespaceURI.Equals(DEFAULT_NS))
                        {
                            found = true;
                            break;
                        }
                    }

                    if (found) _ppt.CustomXMLParts[i].Delete();
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>Serializes PollProjects object to string</summary>
        /// <param name="data">to be serialized</param>
        /// <returns>serialized string or null</returns>
        public string Serialize(PollProjects data)
        {
            try
            {
                if (data == null) return null;

                XmlSerializer xsSubmit = new XmlSerializer(data.GetType());
                // set the namespace
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("lp", DEFAULT_NS);

                string xml = null;
                using (StringWriter sww = new StringWriter())
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, data, ns);
                    xml = sww.ToString(); 
                }
                
                return xml;
            }
            catch (Exception)
            {
                throw;
            }            
        }

        /// <summary>Desterilizes string to Poll Projects data</summary>
        /// <param name="data">string to be serialized</param>
        /// <returns>instance of the PollProjects data or null</returns>
        public PollProjects Deserialize(string data)
        {
            PollProjects retVal = null;
            if (string.IsNullOrWhiteSpace(data)) return retVal;            
            
            using (XmlReader reader = XmlReader.Create(new StringReader(data)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PollProjects));
                retVal = (PollProjects)serializer.Deserialize(reader);
            }
            return retVal;
        }
               
        private IEnumerable<CustomXMLPart> GetPollCustomPart()
        {   
            // couldn't get SelectByNamespace work ...
            var projects = (from cp in _ppt.CustomXMLParts.Cast<CustomXMLPart>().ToList()
                                from ns in cp.NamespaceManager.Cast<CustomXMLPrefixMapping>()
                                where ns.NamespaceURI.Equals(DEFAULT_NS)
                            select cp);            
            return projects;
        }
        
    }
}
