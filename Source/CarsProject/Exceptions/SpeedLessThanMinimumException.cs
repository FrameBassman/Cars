using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsProject.Exceptions
{
    class SpeedLessThanMinimumException : Exception
    {
        public SpeedLessThanMinimumException()
            : base("Car is stopped")
        {
        }
    }
}
