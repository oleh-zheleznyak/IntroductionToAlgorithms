using System;
using System.Xml.Serialization;

namespace IntroductionToAlgorithms.Visuals
{
    public class Edge
    {
        public Edge() { }

        public Edge(Vertice source, Vertice target, string label)
        {
            Source = source;
            Target = target;
            Label = label;
        }
        [XmlIgnore]
        public Vertice Source { get; set; }

        [XmlAttribute(AttributeName = "Source")]
        public string SourceId { get { return Source.Id; } set { throw new NotSupportedException(); } }

        [XmlIgnore]
        public Vertice Target { get; set; }

        [XmlAttribute(AttributeName = "Target")]
        public string TargetId { get { return Target.Id; } set { throw new NotSupportedException(); } }

        [XmlAttribute(AttributeName = "Label")]
        public string Label { get; set; }
    }
}