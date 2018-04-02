using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Tests
{
    [TestClass]
    public class StackAndQueueTests
    {
        [TestMethod]
        public void StackTests()
        {
            RunStack(new Stack<int>(3));
        }

        [TestMethod]
        public void QueueTests()
        {
            RunQueue(new Queue<int>(3));
        }

        [TestMethod]
        public void QueueBasedOnStackTests()
        {
            RunQueue(new QueueBasedOnStack<int>(3));
        }

        [TestMethod]
        public void StackBasedOnQueueTests()
        {
            RunStack(new StackBasedOnQueue<int>(3));
        }

        private void RunStack(IStack<int> stack)
        {
            var iteration = 1;

            while (iteration <= 3)
            {
                Assert.ThrowsException<InvalidOperationException>(() => stack.Pop());

                stack.Push(1);
                stack.Push(2);
                stack.Push(3);

                Assert.ThrowsException<InvalidOperationException>(() => stack.Push(4));

                Assert.AreEqual(3, stack.Pop());
                Assert.AreEqual(2, stack.Pop());
                Assert.AreEqual(1, stack.Pop());

                Assert.ThrowsException<InvalidOperationException>(() => stack.Pop());

                iteration++;
            }
        }

        private void RunQueue(IQueue<int> queue)
        {
            var iteration = 1;

            while (iteration <= 3)
            {
                Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());

                queue.Enqueue(1);
                queue.Enqueue(2);
                queue.Enqueue(3);

                Assert.ThrowsException<InvalidOperationException>(() => queue.Enqueue(4));

                Assert.AreEqual(1, queue.Dequeue());
                Assert.AreEqual(2, queue.Dequeue());
                Assert.AreEqual(3, queue.Dequeue());

                Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());

                iteration++;
            }
        }
    }
}
