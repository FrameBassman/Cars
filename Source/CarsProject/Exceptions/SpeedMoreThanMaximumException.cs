using System;

namespace CarsProject
{
    /// <summary>
    /// Exception for situation when speed of car was exceeded
    /// </summary>
    public class SpeedMoreThanMaximumException : Exception
    {
        public SpeedMoreThanMaximumException()
            : base("Motor is crashed")
        {
        }
    }
}
