using IntroductionToAlgorithms.GraphAlgorithms;

namespace IntroductionToAlgorithms.Tests.GraphAlgorithms
{
    class TestHelper
    {
        public static DirectedGraph<int> CreateSampleGraph()
        {
            var builder = new DirectedGraphBuilder<int>();

            builder.AddEdge(0, 1);
            builder.AddEdge(0, 2);
            builder.AddEdge(1, 3);
            builder.AddEdge(2, 4);

            var graph = builder.AsDirectedGraph();
            return graph;
        }
    }
}
