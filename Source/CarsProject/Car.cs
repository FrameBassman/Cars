namespace CarsProject
{
    using CarsProject.Exceptions;

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
        /// This value is displayed speed of car
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
        private bool ValidateSpeed(int speed)
        {
            if (speed > MaxSpeed)
            {
                return false;
            }
            if (speed < MinSpeed)
            {
                return false;
            }

            return true;
        }

        #endregion

    }
}
