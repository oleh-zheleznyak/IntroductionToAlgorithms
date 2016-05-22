using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IntroductionToAlgorithms.Visuals
{
    public class DgmlSerializer
    {
        public FileInfo Serialize(DirectedGraph graph)
        {
            var serializer = new XmlSerializer(typeof(DirectedGraph), "http://schemas.microsoft.com/vs/2009/dgml");

            var file = Path.Combine(Path.GetTempPath(), Path.ChangeExtension(DateTime.UtcNow.Ticks.ToString(), "dgml"));

            using (var stream = new FileStream(file, FileMode.Create))
            {
                serializer.Serialize(stream, graph);
            }

            return new FileInfo(file);
        }
    }
}
