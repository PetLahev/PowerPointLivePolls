using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPointLivePolls.Core;
using Moq;
using PPT = Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;
using System.Collections;
using PowerPointLivePolls.BusinessObjects;

namespace PowerPointLivePolls.Test.Core
{
    [TestClass]
    public class MetadataTests
    {
        [TestMethod]
        public void HasProject_DoesNotHaveData()
        {
            var ppt = new Mocks.MockPollsProjectsBuilder();
            Metadata data = new Metadata(ppt.Build().Object);
            Assert.IsFalse(data.HasProjects,"Namespace doesn't exists");
        }

        [TestMethod]
        public void HasProject_DataFound()
        {           
            var ppt = new Mocks.MockPollsProjectsBuilder();
            ppt.AddOnePollProject("1");
            
            Metadata data = new Metadata(ppt.Build().Object);            
            Assert.IsTrue(data.HasProjects, "Namespace of desired custom part was found");
        }

        [TestMethod]
        public void Serialize_DataPassed()
        {
            var ppt = new Mocks.MockPollsProjectsBuilder();
            
            var projects = new PollProjects() { Projects = new List<PollProject>() };
            projects.Projects.Add(new PollProject() { Id = "1", Name = "Project1" });
            projects.Projects.Add(new PollProject() { Id = "2", Name = "Project2" });

            Metadata data = new Metadata(ppt.Build().Object); 
            var serialized = data.Serialize(projects);

            Assert.IsNotNull(serialized, "Data passed, serialization works");
        }

        [TestMethod]
        public void Serialize_NullPasssed()
        {
            var ppt = new Mocks.MockPollsProjectsBuilder();
            
            var projects = new PollProjects() { Projects = new List<PollProject>() };
            projects.Projects.Add(new PollProject() { Id = "1", Name = "Project1" });
            projects.Projects.Add(new PollProject() { Id = "2", Name = "Project2" });

            Metadata data = new Metadata(ppt.Build().Object);
            var serialized = data.Serialize(null);

            Assert.IsNull(serialized, "Nothing passed");
        }

        [TestMethod]
        public void DeSerialize_DataPassed()
        {
            var ppt = new Mocks.MockPollsProjectsBuilder();
            var xml = "<PollProjects xmlns:lp=\"LivePollsData\"><Projects><Project><Name>Project1</Name><Id>1</Id></Project><Project><Name>Project2</Name><Id>2</Id></Project></Projects></PollProjects>";

            Metadata data = new Metadata(ppt.Build().Object);
            var deserialized = data.Deserialize(xml);

            Assert.AreEqual(2, deserialized.Projects.Count);
        }

        [TestMethod]
        public void DeSerialize_NothingPassed()
        {
            var ppt = new Mocks.MockPollsProjectsBuilder();
            var xml = "";

            Metadata data = new Metadata(ppt.Build().Object);
            var deserialized = data.Deserialize(xml);

            Assert.IsNull(deserialized);
        }

        [TestMethod]
        public void GetProjects_HasData_ReturnDataWithOneProject()
        {
            var ppt = new Mocks.MockPollsProjectsBuilder();
            ppt.AddOnePollProject("1");
            ppt.AddOnePollProject("100");

            Metadata data = new Metadata(ppt.Build().Object);
            var projects = data.GetProjects();

            Assert.AreEqual(2, projects.Projects.Count);
        }

        [TestMethod]
        public void GetProject_HasData_ReturnsTheProject()
        {
            var ppt = new Mocks.MockPollsProjectsBuilder();
            ppt.AddOnePollProject("1");
            ppt.AddOnePollProject("100");

            Metadata data = new Metadata(ppt.Build().Object);
            var project = data.GetProject("100");

            Assert.AreEqual("100", project.Id);
        }

        [TestMethod]
        public void GetProject_HasDataProjectDoesNotExists_ReturnsNull()
        {
            var ppt = new Mocks.MockPollsProjectsBuilder();
            ppt.AddOnePollProject("1");
            ppt.AddOnePollProject("100");

            Metadata data = new Metadata(ppt.Build().Object);
            var project = data.GetProject("99");

            Assert.IsNull(project);
        }

        [TestMethod]
        public void RemoveAll_HasPollData_RemovesAll()
        {
            var ppt = new Mocks.MockPollsProjectsBuilder();
            ppt.AddOnePollProject("1");
            ppt.AddOnePollProject("100");

            Metadata data = new Metadata(ppt.Build().Object);
            var result = data.RemoveAll();

            Assert.IsTrue(result, "No exception thrown");
            Assert.AreEqual(0, ppt.CustomPartsCount);
        }

    }
}
