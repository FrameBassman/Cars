namespace CarsProject
{
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;

    using CarsProject.Exceptions;

    /// <summary>
    /// The main form.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when speed is changed event occurs.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="eventArgs">
        /// The <see cref="EventArgs"/> instance containing the event data.
        /// </param>
        public virtual void OnSpeedChanged(object sender, EventArgs eventArgs)
        {
            this.UpdateMainForm();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when user clicks on Break button.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="EventArgs"/> instance containing the event data.
        /// </param>
        private void BreakButtonClick(object sender, EventArgs e)
        {
            try
            {
                Car.GetInstance().DownSpeed();
            }
            catch (OutLimitOfSpeedException)
            {
                MessageBox.Show("The car is stopped.");
            }
        }

        /// <summary>
        /// Called when user changes selected index from ColorDropDown list.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="EventArgs"/> instance containing the event data.
        /// </param>
        private void ColorDropDownListSelectedIndexChanged(object sender, EventArgs e)
        {
            KnownColor color = Color.FromName(this.ColorDropDownList.SelectedItem.ToString()).ToKnownColor();
            Car.GetInstance().ChangeColor(color);
            this.UpdateMainForm();
        }

        /// <summary>
        /// Called when user clicks on Gas button.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="EventArgs"/> instance containing the event data.
        /// </param>
        private void GasButtonClick(object sender, EventArgs e)
        {
            try
            {
                Car.GetInstance().UpSpeed();
            }
            catch (OutLimitOfSpeedException)
            {
                MessageBox.Show("The motor is crashed.");
            }
        }

        /// <summary>
        /// Loads <see cref="MainForm"/>.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="EventArgs"/> instance containing the event data.
        /// </param>
        private void MainFormLoad(object sender, EventArgs e)
        {
            Car currentCar = Car.GetInstance();
            currentCar.SpeedChanged += this.OnSpeedChanged;

            this.ColorDropDownList.DataSource = Enum.GetValues(typeof(KnownColor)).Cast<KnownColor>().ToList();
        }

        /// <summary>
        /// Updates <see cref="MainForm"/>.
        /// </summary>
        private void UpdateMainForm()
        {
            Car currentCar = Car.GetInstance();
            this.SpeedLabel.Text = currentCar.Speed.ToString(CultureInfo.InvariantCulture);
            this.ColorDropDownList.SelectedItem = currentCar.Color.ToString();
            this.ColorPictureBox.BackColor = Color.FromKnownColor(currentCar.Color);
        }

        #endregion
    }
}