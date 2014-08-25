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

        public void ChangeColor(KnownColor color)
        {
            this.Color = color;
        }

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

        private static Car instance;

        public static Car GetInstance()
        {
            return instance ?? (instance = new Car());
        }

        #endregion

        #region Methods

        private bool ValidateSpeed(int speed)
        {
            return speed <= MaxSpeed && speed >= MinSpeed;
        }

        #endregion
    }
}