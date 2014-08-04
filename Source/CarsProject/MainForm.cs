// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainForm.cs" company="">
//   
// </copyright>
// <summary>
//   The main form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CarsProject
{
    using System.Globalization;
    using System.Windows.Forms;

    using CarsProject.Exceptions;

    /// <summary>
    /// The main form.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The car.
        /// </summary>
        private Car car;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The main form load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MainFormLoad(object sender, System.EventArgs e)
        {
            this.car = new Car();
            this.UpdateMainForm(this.car);
        }

        /// <summary>
        /// The break button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BreakButtonClick(object sender, System.EventArgs e)
        {
            try
            {
                this.car.DownSpeed();
                this.UpdateMainForm(this.car);
            }
            catch (OutLimitOfSpeedException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// The gas button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void GasButtonClick(object sender, System.EventArgs e)
        {
            try
            {
                this.car.UpSpeed();
                this.UpdateMainForm(this.car);
            }
            catch (OutLimitOfSpeedException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// The update main form.
        /// </summary>
        /// <param name="currentCar">
        /// The current car.
        /// </param>
        private void UpdateMainForm(Car currentCar)
        {
            this.SpeedLabel.Text = currentCar.Speed.ToString(CultureInfo.InvariantCulture);
        }
    }
}
