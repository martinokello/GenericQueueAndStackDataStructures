using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using FitsMe.Test.StackAndQueue.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace FitsMe.Test.StackAndQueue.UnitTests
{
    [TestFixture]
    public class PeekableTests
    {
        [TestCaseSource(typeof(TestObjectProvider), nameof(TestObjectProvider.GetEmptyTestObjects))]
        public void should_throw_when_peeking_empty(IPeekable<int> subject)
        {
            Action act = () => subject.Peek();

            act.Should().Throw<InvalidOperationException>();
        }

        [TestCaseSource(typeof(TestObjectProvider), nameof(TestObjectProvider.GetNonEmptyTestObjects))]
        public void should_correctly_peek_item(IPeekable<string> subject, string expected)
        {
            subject.Peek().Should().Be(expected);
        }

        [TestCaseSource(typeof(TestObjectProvider), nameof(TestObjectProvider.GetEmptyTestObjects))]
        public void should_return_false_on_empty_trypeek(IPeekable<int> subject)
        {
            int value;
            subject.TryPeek(out value).Should().Be(false);
        }

        [TestCaseSource(typeof(TestObjectProvider), nameof(TestObjectProvider.GetNonEmptyTestObjects))]
        public void should_return_true_on_nonempty_trypeek(IPeekable<string> subject, string expected)
        {
            string value;
            subject.TryPeek(out value).Should().BeTrue();
            value.Should().Be(expected);
        }

        [TestCaseSource(typeof(TestObjectProvider), nameof(TestObjectProvider.GetNonEmptyTestObjects))]
        public void should_not_remove_value_on_peek(IPeekable<string> subject, string expected)
        {
            subject.Peek().Should().Be(expected);
            subject.Peek().Should().Be(expected);
        }

        private static class TestObjectProvider
        {
            public static IEnumerable<TestCaseData> GetEmptyTestObjects()
            {
                yield return new TestCaseData(new Services.Stack<int>()).SetName("{m}_stack");
                yield return new TestCaseData(new Services.Queue<int>()).SetName("{m}_queue");
            }

            public static IEnumerable<TestCaseData> GetNonEmptyTestObjects()
            {
                var stack = new Services.Stack<string>();
                stack.Push("Bravo");
                stack.Push("Alpha");
                yield return new TestCaseData(stack, "Alpha").SetName("{m}_stack");

                var queue = new Services.Queue<string>();
                queue.Enqueue("Bravo");
                queue.Enqueue("Alpha");
                yield return new TestCaseData(queue, "Bravo").SetName("{m}_queue");
            }
        }
    }
}