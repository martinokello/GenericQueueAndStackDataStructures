using System;
using System.Collections.Generic;
using System.Linq;
using FitsMe.Test.StackAndQueue.Interfaces;
using NUnit.Framework;
using FluentAssertions;
using NUnit.Framework.Constraints;

namespace FitsMe.Test.StackAndQueue.UnitTests
{
    [TestFixture]
    public class QueueTests
    {
        [Test]
        public void should_throw_when_dequeue_from_empty()
        {
            IQueue<int> queue = new Services.Queue<int>();

            Action act = () => queue.Dequeue();

            act.Should().Throw<InvalidOperationException>();
        }

        [TestCase(1)]
        [TestCase(100)]
        [TestCase(10000)]
        [TestCase(1000000)]
        public void should_allow_many_items(int itemCount)
        {
            IQueue<double> queue = new Services.Queue<double>();

            Action act = () => 
                {
                    for (int i = 0; i < itemCount; i++)
                    {
                        queue.Enqueue(1.0 / i);
                    }
                };

            act.Should().NotThrow();
        }

        [TestCase(1)]
        [TestCase(100)]
        public void should_dequeue_items_correctly(int itemCount)
        {
            IQueue<int> queue = new Services.Queue<int>();
            int[] range = Enumerable.Range(1, itemCount).ToArray();
            int[] expected = range;

            foreach(int i in range)
            {
                queue.Enqueue(i);
            }

            var actual = new int[range.Length];
            int index = 0;
            foreach (int i in range)
            {
                actual[index++] = queue.Dequeue();
            }

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void should_be_empty_after_dequeueing_all_items()
        {
            IQueue<string> queue = new Services.Queue<string>();

            var items = new[] { "Alpha", "Bravo", "Charlie", "Delta" };

            foreach (string s in items)
            {
                queue.Enqueue(s);
            }

            for (int i = 0; i < items.Length; i++)
            {
                queue.Dequeue();
            }

            queue.Invoking(q => q.Dequeue()).Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void should_return_false_when_trydequeue_from_empty()
        {
            IQueue<int> queue = new Services.Queue<int>();

            int result;
            queue.TryDequeue(out result).Should().BeFalse();
        }

        [Test]
        public void should_return_true_when_trydequeue_after_enqueue()
        {
            IQueue<int> queue = new Services.Queue<int>();
            queue.Enqueue(123);

            int dequeued;
            bool result = queue.TryDequeue(out dequeued);
                
            result.Should().BeTrue();
            dequeued.Should().Be(123);
        }

        public void should_still_contain_items_after_trydequeue()
        {
            IQueue<int> queue = new Services.Queue<int>();
            queue.Enqueue(321);

            int dequeueped;
            queue.TryDequeue(out dequeueped);

            Action act = () => queue.Dequeue();
            act.Should().NotThrow();
        }
    }
}