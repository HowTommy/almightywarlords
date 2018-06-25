namespace AW.Core.Migration
{
    using System;

    /// <summary>
    /// Exception raised when an error occurs during a database update
    /// </summary>
    [Serializable]
    public class DatabaseUpdateException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseUpdateException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public DatabaseUpdateException(string message)
            : base(message)
        {
        }
    }
}
