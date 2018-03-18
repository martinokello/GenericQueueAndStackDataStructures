using System;
using FitsMe.Test.StackAndQueue.Interfaces;

namespace FitsMe.Test.StackAndQueue.Services
{
    public class Queue<T> : IQueue<T>
    {
        private DoubleNode<T> _front { get; set; }
        private DoubleNode<T> _back { get; set; }
        /// <summary>
        /// Peeks at the next available item and returns it without removing it.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public T Peek()
        {
            try
            {
                return _front.Value;
            }
            catch
            {
                throw new InvalidOperationException();
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
            if (_front != null)
            {
                value = _front.Value;
                return true;
            }
            value = default(T);
            return false;
        }

        /// <summary>
        /// Enqueues the specified item.
        /// </summary>
        /// <param name="item">The item to enqueue.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Enqueue(T item)
        {
            var newItem = new DoubleNode<T> { Value = item };

            if(_back != null)
            {
                newItem.RightLink = _back;
                _back.LeftLink = newItem;
                _back = newItem;
            }
            else
            {
                _front = _back = newItem;
            }
        }

        /// <summary>
        /// Removes the item at the front of the queue and returns it.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public T Dequeue()
        {
            try
            {
                var result = _front.Value;
                _front = _front.LeftLink;
                 return result;
            }
            catch
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Tries to dequeue an item. If there is an item available, the method
        /// returns <c>true</c> and the <see cref="!:item" /> parameter contains the
        /// dequeued item. Otherwise the method returns false.
        /// </summary>
        /// <param name="item">The dequeued item if available.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool TryDequeue(out T item)
        {
            if (_front != null)
            {
                item = _front.Value;
                _front = _front.LeftLink;
                return true;
            }
            item = default(T);
            return false;
        }


    }
}