using System;
using FitsMe.Test.StackAndQueue.Interfaces;

namespace FitsMe.Test.StackAndQueue.Services
{
    public class Stack<T> : IStack<T>
    {
        private Node<T> _top;
        
        /// <summary>
        /// Peeks at the next available item and returns it without removing it.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public T Peek()
        {
            try
            {
                var result = default(T);
                TestValueExists(out result);
                return result;
            }
            catch
            {
                throw new System.InvalidOperationException();
            }
        }

        /// <summary>
        /// Tries to peek at the next available item. If one is available, this method
        /// returns <c>true</c> and stores it in the <see cref="!:value" /> parameter.
        /// If there is no item available, this method returns <c>false</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool TryPeek(out T value)
        {
            try
            {
                return TestValueExists(out value);
            }
            catch
            {
                value = default(T);
                return false;
            }
        } 

        /// <summary>
        /// Pushes the specified item on to the stack.
        /// </summary>
        /// <param name="item">The item to push.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Push(T item)
        {
            var newNode = new Node<T> { Value = item };

            if(_top != null)
            {
                newNode.Link = _top;
                _top = newNode;
            }
            else
            {
                _top = newNode;
            }
        }

        /// <summary>
        /// Removes next available item from the stack and returns it.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public T Pop()
        {
            try
            {
                var forPop = _top;
                var result = default(T);
                TestValueExists(out result);
                    _top = _top.Link;
                return forPop.Value;
            }
            catch
            {
                throw new System.InvalidOperationException();
            }
        }

        /// <summary>
        /// Tries to pop an item. If there is an item available, the method
        /// returns <c>true</c> and the <see cref="!:item" /> parameter contains the
        /// popped item. Otherwise the method returns false.
        /// </summary>
        /// <param name="item">The popped item if available.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool TryPop(out T item)
        {
            try
            {
                return TestValueExists(out item);
            }
            catch
            {
                item = default(T);
                return false;
            }
        }

        private bool TestValueExists(out T value)
        {
            value = _top.Value;
            if (_top == null)
            {
                value = default(T);
                return false;
            }
            return _top != null;
        }
    }
}