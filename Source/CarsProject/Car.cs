namespace CarsProject
{
    using System;
    using System.Drawing;

    using CarsProject.Exceptions;

    /// <summary>
    /// The car which can ride, change speed and color.
    /// </summary>
    public class Car
    {
        #region Constants

        /// <summary>
        /// This value is displayed how much speed increases.
        /// </summary>
        private const int Delta = 20;

        /// <summary>
        /// This value is displayed max speed for car.
        /// </summary>
        private const int MaxSpeed = 200;

        /// <summary>
        /// This value is displayed min speed for car.
        /// </summary>
        private const int MinSpeed = 0;

        #endregion

        #region Static Fields

        /// <summary>
        /// The instance of the current Car.
        /// </summary>
        private static Car instance;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Prevents a default instance of the <see cref="Car"/> class from being created.
        /// </summary>
        private Car()
        {
            this.Color = KnownColor.ActiveBorder;
        }

        #endregion

        #region Public Events

        /// <summary>
        /// This event raised when speed changed.
        /// </summary>
        public event EventHandler SpeedChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets color of current car.
        /// </summary>
        public KnownColor Color { get; private set; }

        /// <summary>
        /// Gets speed of current car.
        /// </summary>
        public int Speed { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the instance to the current Car.
        /// </summary>
        /// <returns>
        /// Instance of the current Car.
        /// </returns>
        public static Car GetInstance()
        {
            return instance ?? (instance = new Car());
        }

        /// <summary>
        /// Changes the color of the current car.
        /// </summary>
        /// <param name="color">
        /// The color to update.
        /// </param>
        public void ChangeColor(KnownColor color)
        {
            this.Color = color;
        }

        /// <summary>
        /// Decreases the speed of the current car on <see cref="Delta"/>.
        /// </summary>
        /// <exception cref="OutLimitOfSpeedException">
        /// Throws when car has speed less than <see cref="MinSpeed"/>.
        /// </exception>
        public void DownSpeed()
        {
            if (this.ValidateSpeed(this.Speed - Delta))
            {
                this.Speed -= Delta;
                if (this.SpeedChanged != null)
                {
                    this.SpeedChanged(this, new EventArgs());
                }
            }
            else
            {
                throw new OutLimitOfSpeedException("Car is stopped.");
            }
        }

        /// <summary>
        /// Increases the speed of the current car on <see cref="Delta"/>.
        /// </summary>
        /// <exception cref="OutLimitOfSpeedException">
        /// Throws when car has speed more than <see cref="MaxSpeed"/>.
        /// </exception>
        public void UpSpeed()
        {
            if (this.ValidateSpeed(this.Speed + Delta))
            {
                this.Speed += Delta;
                if (this.SpeedChanged != null)
                {
                    this.SpeedChanged(this, new EventArgs());
                }
            }
            else
            {
                throw new OutLimitOfSpeedException("Motor is crashed.");
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Validates the speed of the current Car.
        /// </summary>
        /// <param name="speed">
        /// The speed to validate.
        /// </param>
        /// <returns>
        /// <c>True</c> if speed more than MaxSpeed and less than MinSpeed, otherwise <c>False</c>.
        /// </returns>
        private bool ValidateSpeed(int speed)
        {
            return speed <= MaxSpeed && speed >= MinSpeed;
        }

        #endregion
    }
}