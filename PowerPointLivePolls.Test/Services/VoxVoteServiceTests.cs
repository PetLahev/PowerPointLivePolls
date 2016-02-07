using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPointLivePolls.Services;
using Moq;

namespace PowerPointLivePolls.Test.Services
{
    [TestClass]
    public class VoxVoteServiceTests
    {
        [TestMethod]
        public void GetVoxData()
        {
            var manager = new Mock<IServiceManager>();
            manager.Setup(x => x.GetProjectData(It.IsAny<string>())).Returns("");

            VoxVoteService test = new VoxVoteService(manager.Object);
            //test.GetVoxData("");
        }
    }
}
