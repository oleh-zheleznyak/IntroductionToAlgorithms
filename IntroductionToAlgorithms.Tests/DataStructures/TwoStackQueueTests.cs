using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroductionToAlgorithms.DataStructures.Tests
{
    [TestClass]
    public class TwoStackQueueTests
    {
        private TwoStackQueue<int> queue;

        [TestInitialize]
        public void TestInitialize()
        {
            queue = new TwoStackQueue<int>();
        }

        [TestMethod]
        public void Enqueue_SavesItems()
        {
            var input = new[] { 1, 2, 3 };

            input.ToList().ForEach(x => queue.Enqueue(x));

            CollectionAssert.AreEquivalent(input, queue.ToList());
        }

        [TestMethod]
        public void Dequeue_ReturnsItemsInCorrectOrder()
        {
            var input = new[] { 1, 2, 3 };

            input.ToList().ForEach(x => queue.Enqueue(x));

            var output = new List<int>(3);

            while (queue.Count > 0)
                output.Add(queue.Dequeue());

            CollectionAssert.AreEqual(input, output);
        }

        [TestMethod]
        public void TwoStackQueue_BehavesLikeAQueue()
        {
            var nativeQueue = new Queue<int>();
            var dequeueOutput = new List<Tuple<int, int>>();

            Action<int> enq = x => { queue.Enqueue(x); nativeQueue.Enqueue(x); };
            Action deq = () => { dequeueOutput.Add(Tuple.Create(queue.Dequeue(), nativeQueue.Dequeue())); };

            enq(1);
            enq(2);
            enq(3);
            deq();
            enq(4);
            enq(5);
            deq();

            CollectionAssert.AreEquivalent(nativeQueue.ToList(), queue.ToList());
            Assert.IsTrue(dequeueOutput.All(x => x.Item1 == x.Item2));
        }
    }
}