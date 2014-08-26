namespace CarsProject.Exceptions
{
    using System;

    /// <summary>
    /// The exception which throws when speed is out of speed limit.
    /// </summary>
    public class OutLimitOfSpeedException : Exception
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OutLimitOfSpeedException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message that describes the error.
        /// </param>
        public OutLimitOfSpeedException(string message)
            : base(message)
        {
        }

        #endregion
    }
}