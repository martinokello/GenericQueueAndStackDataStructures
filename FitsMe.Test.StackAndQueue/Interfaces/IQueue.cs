namespace FitsMe.Test.StackAndQueue.Interfaces
{
    public interface IQueue<T> : IPeekable<T>
    {
        /// <summary>
        /// Enqueues the specified item.
        /// </summary>
        /// <param name="item">The item to enqueue.</param>
        void Enqueue(T item);

        /// <summary>
        /// Removes the item at the front of the queue and returns it.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown if an item cannot be dequeued.</exception>
        T Dequeue();

        /// <summary>
        /// Tries to dequeue an item. If there is an item available, the method
        /// returns <c>true</c> and the <see cref="item"/> parameter contains the 
        /// dequeued item. Otherwise the method returns false.
        /// </summary>
        /// <param name="item">The dequeued item if available.</param>
        bool TryDequeue(out T item);
    }
}