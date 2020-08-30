using System.Xml.Serialization;

namespace IntroductionToAlgorithms.Visuals
{
    [XmlRoot(ElementName ="DirectedGraph")]
    public class DirectedGraph
    {
        [XmlAttribute(AttributeName = "Title")]
        public string Name { get; set; }

        [XmlArray(ElementName = "Nodes")]
        [XmlArrayItem(ElementName = "Node")]
        public Vertice[] Vertices { get; set; }

        [XmlArray(ElementName = "Links")]
        [XmlArrayItem(ElementName ="Link")]
        public Edge[] Edges { get; set; }

    }
}
