namespace CarsProject
{
    using CarsProject.Exceptions;

    public class Car
    {

        #region Fields

        /// <summary>
        /// This value is displayed how much speed increases
        /// </summary>
        protected readonly int Delta = 20;

        /// <summary>
        /// This value is displayed max speed for car
        /// </summary>
        protected readonly int MaxSpeed = 200;

        /// <summary>
        /// This value is displayed min speed for car
        /// </summary>
        protected readonly int MinSpeed = 0;

        /// <summary>
        /// This value is displayed speed of car
        /// </summary>
        public int Speed = 0;

        #endregion

        #region Constructor

        public Car()
        {
            this.Speed = 0;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Method for accelerate speed of car
        /// </summary>
        /// <param name="car">Car object</param>
        /// <returns>Returns code of error</returns>
        public int UpSpeed()
        {
            this.Speed += this.Delta;
            return this.ValidateSpeed(this);
        }

        /// <summary>
        /// Method for decelerate speed of car
        /// </summary>
        /// <param name="car">Car object</param>
        /// <returns>Returns code of error</returns>
        public int DownSpeed()
        {
            this.Speed -= this.Delta;
            return this.ValidateSpeed(this);
        }

        /// <summary>
        /// This method verifies that Speed of Car has correct value
        /// </summary>
        /// <param name="car">Car object</param>
        /// <returns>Returns 0 if speed correct, 1 if speed more than maximal speed, -1 if speed less than minimal speed</returns>
        private int ValidateSpeed(Car car)
        {
            if (car.Speed > car.MaxSpeed)
            {
                throw new SpeedMoreThanMaximumException();
            }
            if (car.Speed < car.MinSpeed)
            {
                throw new SpeedLessThanMinimumException();
            }

            return 0;
        }

        #endregion

    }
}
