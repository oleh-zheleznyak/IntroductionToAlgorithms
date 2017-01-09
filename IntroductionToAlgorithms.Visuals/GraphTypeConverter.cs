using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace IntroductionToAlgorithms.Visuals
{
    public class GraphTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType.GetTypeInfo().IsGenericType && sourceType.GetGenericTypeDefinition() == typeof(GraphAlgorithms.DirectedGraph<>))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(DirectedGraph))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            throw new NotImplementedException();

            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            throw new NotImplementedException();

            return base.ConvertTo(context, culture, value, destinationType);
        }

        public DirectedGraph Convert<T>(GraphAlgorithms.DirectedGraph<T> graph)
            where T : IEquatable<T>
        {
            var result = new DirectedGraph();

            var counter = 0;

            var map = graph.Vertices.ToDictionary(x => x, x => new Vertice(counter++.ToString(), x.ToString()));

            result.Vertices = map.Values.ToArray();
            result.Edges = graph.Edges.Select(x => new Edge(map[x.Item1], map[x.Item2], null)).ToArray();

            return result;
        }

        public override bool IsValid(ITypeDescriptorContext context, object value)
        {
            throw new NotImplementedException();

            return base.IsValid(context, value);
        }
    }
}
