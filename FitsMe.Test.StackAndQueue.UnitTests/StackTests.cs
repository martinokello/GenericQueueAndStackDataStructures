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
    public class StackTests
    {
        [Test]
        public void should_throw_when_pop_from_empty()
        {
            IStack<int> stack = new Services.Stack<int>();

            Action act = () => stack.Pop();

            act.Should().Throw<InvalidOperationException>();
        }

        [TestCase(1)]
        [TestCase(100)]
        [TestCase(10000)]
        [TestCase(100000)]
        public void should_allow_many_items(int itemCount)
        {
            IStack<double> stack = new Services.Stack<double>();

            Action act = () => 
                {
                    for (int i = 0; i < itemCount; i++)
                    {
                        stack.Push(1.0 / i);
                    }
                };

            act.Should().NotThrow();
        }

        [TestCase(1)]
        [TestCase(100)]
        public void should_pop_items_correctly(int itemCount)
        {
            IStack<int> stack = new Services.Stack<int>();
            int[] range = Enumerable.Range(1, itemCount).ToArray();
            int[] expected = range.Reverse().ToArray();

            foreach(int i in range)
            {
                stack.Push(i);
            }

            var actual = new int[range.Length];
            int index = 0;
            foreach (int _ in range)
            {
                actual[index++] = stack.Pop();
            }

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void should_be_empty_after_popping_all_items()
        {
            IStack<string> stack = new Services.Stack<string>();

            var items = new[] { "Alpha", "Bravo", "Charlie", "Delta" };

            foreach (string s in items)
            {
                stack.Push(s);
            }

            for (int i = 0; i < items.Length; i++)
            {
                stack.Pop();
            }

            stack.Invoking(s => s.Pop()).Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void should_return_false_when_trypop_from_empty()
        {
            IStack<int> stack = new Services.Stack<int>();

            int result;
            stack.TryPop(out result).Should().BeFalse();
        }

        [Test]
        public void should_return_true_when_trypop_after_push()
        {
            IStack<int> stack = new Services.Stack<int>();
            stack.Push(123);

            int popped;
            bool result = stack.TryPop(out popped);
                
            result.Should().BeTrue();
            popped.Should().Be(123);
        }

        public void should_still_contain_items_after_trypop()
        {
            IStack<int> stack = new Services.Stack<int>();
            stack.Push(321);

            int popped;
            stack.TryPop(out popped);

            Action act = () => stack.Pop();
            act.Should().NotThrow();
        }
    }
}