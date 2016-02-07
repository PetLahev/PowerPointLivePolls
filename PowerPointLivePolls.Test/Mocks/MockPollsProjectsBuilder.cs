using System.Collections;
using System.Collections.Generic;
using Microsoft.Office.Core;
using Moq;
using PPT = Microsoft.Office.Interop.PowerPoint;

namespace PowerPointLivePolls.Test.Mocks
{
    internal class MockPollsProjectsBuilder
    {        
        private readonly Mock<PPT.Presentation> _ppt;
        private Mock<CustomXMLParts> _mockXmlParts;
        
        private IList<CustomXMLPart> _parts = new List<CustomXMLPart>();
        private IList<string> _projects = new List<string>();

        public MockPollsProjectsBuilder()
        {
            _ppt = CreatePptMock();            
        }

        public Mock<PPT.Presentation> Build()
        {
            return _ppt;
        }

        public int CustomPartsCount
        {
            get { return _parts == null ? 0 : _parts.Count; }
        }

        /// <summary>Add a new PollLiveData ns to existing custom parts</summary>
        /// <param name="id"></param>
        public void AddOnePollProject(string id)
        {
            _parts = new List<CustomXMLPart>();
            string projectBase = string.Format("<Project><Id>{0}</Id></Project>", id);
            _projects.Add(projectBase);

            string projectXml = string.Join("", _projects);
            string xml = string.Format("<PollProjects xmlns:lp=\"LivePollsData\"><Projects>{0}</Projects></PollProjects>",projectXml);
            
            var mappingList = new List<CustomXMLPrefixMapping>();
            mappingList.Add(GetPollNs.Object);

            var mappings = CreateNsManager(mappingList);

            var part = new Mock<CustomXMLPart>();
            part.SetupGet(p => p.XML).Returns(xml);
            part.SetupGet(p => p.NamespaceManager).Returns(() => mappings.Object);
            part.Setup(m => m.Delete()).Callback(() => _parts.RemoveAt(0));
            _parts.Add(part.Object);
            
            _mockXmlParts = CreateCustomXmlParts();
            _ppt.Setup(x => x.CustomXMLParts).Returns(() => _mockXmlParts.Object);
        }

        /// <summary>Creates fake XMl part without our mappings</summary>
        /// <returns></returns>
        private Mock<PPT.Presentation> CreatePptMock()
        {
            var ppt = new Mock<PPT.Presentation>();
            var mapping = new Mock<CustomXMLPrefixMapping>();
            var mappingList = new List<CustomXMLPrefixMapping>();

            mapping.SetupGet(x => x.NamespaceURI).Returns("Namespace1");            
            mappingList.Add(mapping.Object);
            var mappings = CreateNsManager(mappingList);

            var part = new Mock<CustomXMLPart>();
            part.SetupGet(x => x.XML).Returns("<Fake></Fake>");
            part.SetupGet(x => x.NamespaceManager).Returns(() => mappings.Object);
            part.Setup(m => m.Delete()).Callback(() => _parts.RemoveAt(0));
            _parts.Add(part.Object);

            _mockXmlParts = CreateCustomXmlParts();                                  
            ppt.Setup(x => x.CustomXMLParts).Returns(() => _mockXmlParts.Object);
            
            return ppt;
        }

        private Mock<CustomXMLParts> CreateCustomXmlParts()
        {
            var result = new Mock<CustomXMLParts>();

            result.SetupGet(x => x.Parent).Returns(() =>_ppt);
            result.SetupGet(x => x.Count).Returns(() => _parts.Count);
            result.Setup(x => x.GetEnumerator()).Returns(() => _parts.GetEnumerator());
            result.As<IEnumerable>().Setup(x => x.GetEnumerator()).Returns(() => _parts.GetEnumerator());
            result.Setup(x => x[It.IsAny<int>()]).Returns<int>(value => _parts[value-1]);
                        
            return result;
        }
        
        private Mock<CustomXMLPrefixMappings> CreateNsManager(IList<CustomXMLPrefixMapping> mappings)
        {
            var result = new Mock<CustomXMLPrefixMappings>();

            result.SetupGet(x => x.Parent).Returns(_ppt);
            result.SetupGet(x => x.Count).Returns(() => mappings.Count);
            result.Setup(x => x.GetEnumerator()).Returns(() => mappings.GetEnumerator());
            result.As<IEnumerable>().Setup(x => x.GetEnumerator()).Returns(() => mappings.GetEnumerator());

            return result;
        }

        private Mock<CustomXMLPrefixMapping> GetPollNs
        {
            get
            {
                var mapping = new Mock<CustomXMLPrefixMapping>();
                mapping.SetupGet(m => m.NamespaceURI).Returns("LivePollsData");
                return mapping;
            }
        }

    }
}
