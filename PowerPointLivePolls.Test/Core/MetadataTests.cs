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
            ppt.AddOnePollProject(new string[] { "1" });
            
            Metadata data = new Metadata(ppt.Build().Object);            
            Assert.IsTrue(data.HasProjects, "Namespace of desired custom part was found");
        }
               
        [TestMethod]
        public void GetProjects_HasData_ReturnDataWithOneProject()
        {
            var ppt = new Mocks.MockPollsProjectsBuilder();
            ppt.AddOnePollProject(new string[] { "1", "100" });

            Metadata data = new Metadata(ppt.Build().Object);
            var projects = data.GetProjects();

            Assert.AreEqual(2, projects.Projects.Count);
        }

        [TestMethod]
        public void GetProject_HasData_ReturnsTheProject()
        {
            var ppt = new Mocks.MockPollsProjectsBuilder();
            ppt.AddOnePollProject(new string[] { "1", "100" });
            
            Metadata data = new Metadata(ppt.Build().Object);
            var project = data.GetProject("100");

            Assert.AreEqual("100", project.Id);
        }

        [TestMethod]
        public void GetProject_HasDataProjectDoesNotExists_ReturnsNull()
        {
            var ppt = new Mocks.MockPollsProjectsBuilder();
            ppt.AddOnePollProject(new string[] { "1", "100" });

            Metadata data = new Metadata(ppt.Build().Object);
            var project = data.GetProject("99");

            Assert.IsNull(project);
        }

        [TestMethod]
        public void RemoveAll_HasPollData_RemovesAll()
        {
            var ppt = new Mocks.MockPollsProjectsBuilder();
            ppt.AddOnePollProject(new string[] { "1", "100" });

            Metadata data = new Metadata(ppt.Build().Object);
            var result = data.RemoveAll();

            Assert.IsTrue(result, "No exception thrown");
            Assert.AreEqual(0, ppt.CustomPartsCount);
        }

    }
}
