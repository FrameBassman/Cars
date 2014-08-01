using System;

namespace CarsProject.Exceptions
{
    class OutLimitOfSpeedException : Exception
    {
        public OutLimitOfSpeedException(string message)
            : base(message)
        {
        }
    }
}
