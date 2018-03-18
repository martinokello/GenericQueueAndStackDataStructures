namespace FitsMe.Test.StackAndQueue.Interfaces
{
    public interface IStack<T> : IPeekable<T>
    {
        /// <summary>
        /// Pushes the specified item on to the stack.
        /// </summary>
        /// <param name="item">The item to push.</param>
        void Push(T item);

        /// <summary>
        /// Removes next available item from the stack and returns it.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown if an item cannot be popped.</exception>
        T Pop();

        /// <summary>
        /// Tries to pop an item. If there is an item available, the method
        /// returns <c>true</c> and the <see cref="item"/> parameter contains the 
        /// popped item. Otherwise the method returns false.
        /// </summary>
        /// <param name="item">The popped item if available.</param>
        bool TryPop(out T item);
    }
}