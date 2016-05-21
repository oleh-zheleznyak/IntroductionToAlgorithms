using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;

namespace IntroductionToAlgorithms.Visuals.Tests
{
    [TestClass]
    public class DirectedGraphSerializationTests
    {
        [TestMethod]
        [DeploymentItem(@"TestData\SampleDgmlTest.dgml")]
        public void DirectedGraph_IsXmlSerialized_AsExpected()
        {
            var graph = new DirectedGraph();
            graph.Name = "Sample Graph";
            graph.Vertices = new Vertice[] { new Vertice("1", "A"), new Vertice("2", "B") };
            graph.Edges = new Edge[] { new Edge(graph.Vertices.First(), graph.Vertices.Last(), "V") };

            var serializer = new XmlSerializer(typeof(DirectedGraph), "http://schemas.microsoft.com/vs/2009/dgml");

            var writer = new StringWriter();
            serializer.Serialize(writer, graph);

            var actual = XDocument.Parse(writer.ToString());
            var expected = XDocument.Load(Path.Combine( Environment.CurrentDirectory, "SampleDgmlTest.dgml") );

            Assert.IsTrue(XDocument.DeepEquals(actual, expected));
        }
    }
}
