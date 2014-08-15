namespace CarsProject
{
    using System;
    using System.Drawing;

    using CarsProject.Exceptions;

    /// <summary>
    ///     The car.
    /// </summary>
    public class Car
    {
        #region Constants

        /// <summary>
        ///     This value is displayed how much speed increases
        /// </summary>
        private const int Delta = 20;

        /// <summary>
        ///     This value is displayed max speed for car
        /// </summary>
        private const int MaxSpeed = 200;

        /// <summary>
        ///     This value is displayed min speed for car
        /// </summary>
        private const int MinSpeed = 0;

        #endregion

        #region Public Events

        /// <summary>
        ///     This event rised when speed changed.
        /// </summary>
        public event EventHandler SpeedChanged;

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets colour of current car
        /// </summary>
        public KnownColor Colour { get; private set; }

        /// <summary>
        ///     Gets speed of current car
        /// </summary>
        public int Speed { get; private set; }

        #endregion

        #region Public Methods and Operators

        public void ChangeColour(KnownColor color)
        {
            this.Colour = color;
        }

        /// <summary>
        ///     Method for decelerate speed of car, throws exception if speed is out from limit
        /// </summary>
        public void DownSpeed()
        {
            if (this.ValidateSpeed(this.Speed - Delta))
            {
                this.Speed -= Delta;
                if (this.SpeedChanged != null)
                {
                    this.SpeedChanged.Invoke(null, new EventArgs());
                }
            }
            else
            {
                throw new OutLimitOfSpeedException("Car is stopped");
            }
        }

        /// <summary>
        ///     Method for accelerate speed of car, throws exception if speed is out from limit
        /// </summary>
        public void UpSpeed()
        {
            if (this.ValidateSpeed(this.Speed + Delta))
            {
                this.Speed += Delta;
                if (this.SpeedChanged != null)
                {
                    this.SpeedChanged.Invoke(null, new EventArgs());
                }
            }
            else
            {
                throw new OutLimitOfSpeedException("Motor is crashed");
            }
        }

        #endregion

        #region Methods

        /// <summary>
        ///     This method returns true if speed is valid
        /// </summary>
        /// <param name="speed">
        ///     The speed of car
        /// </param>
        /// <returns>
        ///     Returns true if speed is valid <see cref="bool" />.
        /// </returns>
        private bool ValidateSpeed(int speed)
        {
            return speed <= MaxSpeed && speed >= MinSpeed;
        }

        #endregion
    }
}