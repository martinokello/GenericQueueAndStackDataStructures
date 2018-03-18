namespace FitsMe.Test.StackAndQueue.Interfaces
{
    public interface IPeekable<T>
    {
        /// <summary>
        /// Peeks at the next available item and returns it without removing it.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown if an item cannot be retrieved.</exception>
        T Peek();

        /// <summary>
        /// Tries to peek at the next available item. If one is available, this method 
        /// returns <c>true</c> and stores it in the <see cref="value"/> parameter.
        /// If there is no item available, this method returns <c>false</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        bool TryPeek(out T value);
    }
}