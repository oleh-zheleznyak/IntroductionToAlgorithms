using System.Xml.Serialization;

namespace IntroductionToAlgorithms.Visuals
{
    public class Vertice
    {
        public Vertice() { }

        public Vertice(string id, string label)
        {
            Id = id;
            Label = label;
        }
        [XmlAttribute(AttributeName ="Id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName ="Label")]
        public string Label { get; set; }
    }
}