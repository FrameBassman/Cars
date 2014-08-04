// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Car.cs" company="Noname">
//   
// </copyright>
// <summary>
//   The car.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CarsProject
{
    using System.Collections.Generic;

    using CarsProject.Exceptions;

    /// <summary>
    /// The car.
    /// </summary>
    public class Car
    {
        #region Fields

        /// <summary>
        /// This value is displayed how much speed increases
        /// </summary>
        private const int Delta = 20;

        /// <summary>
        /// This value is displayed max speed for car
        /// </summary>
        private const int MaxSpeed = 200;

        /// <summary>
        /// This value is displayed min speed for car
        /// </summary>
        private const int MinSpeed = 0;

        /// <summary>
        /// Get speed of current car
        /// </summary>
        public int Speed { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Method for accelerate speed of car, throws exception if speed is out from limit
        /// </summary>
        public void UpSpeed()
        {
            if (this.ValidateSpeed(this.Speed + Delta))
            {
                this.Speed += Delta;
            }
            else
            {
                throw new OutLimitOfSpeedException("Motor is crashed");
            }
        }

        /// <summary>
        /// Method for decelerate speed of car, throws exception if speed is out from limit
        /// </summary>
        public void DownSpeed()
        {
            if (this.ValidateSpeed(this.Speed - Delta))
            {
                this.Speed -= Delta;
            }
            else
            {
                throw new OutLimitOfSpeedException("Car is stopped");
            }
        }

        /// <summary>
        /// This method returns true if speed is valid
        /// </summary>
        /// <param name="speed">
        /// The speed of car
        /// </param>
        /// <returns>
        /// Returns true if speed is valid <see cref="bool"/>.
        /// </returns>
        private bool ValidateSpeed(int speed)
        {
            return speed < MaxSpeed && speed > MinSpeed;
        }

        #endregion

        #region Events

        /// <summary>
        /// The car engine handler.
        /// </summary>
        /// <param name="messageForCaller">
        /// The message for caller.
        /// </param>
        public delegate void CarEngineHandler(string messageForCaller);

        /// <summary>
        /// The list of handlers.
        /// </summary>
        private CarEngineHandler listOfHandlers;

        /// <summary>
        /// The register with car engine.
        /// </summary>
        /// <param name="methodToCall">
        /// The method to call.
        /// </param>
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            this.listOfHandlers = methodToCall;
        }

        #endregion
    }
}
