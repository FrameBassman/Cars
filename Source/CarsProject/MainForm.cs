namespace CarsProject
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;

    using CarsProject.Exceptions;

    /// <summary>
    ///     The main form.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields

        /// <summary>
        ///     The car.
        /// </summary>
        private Car car;

        /// <summary>
        /// </summary>
        private List<KnownColor> listOfColorsForCar;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainForm" /> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Updated current speed of car
        /// </summary>
        public virtual void OnSpeedChanged(object sender, EventArgs eventArgs)
        {
            this.UpdateMainForm(this.car);
        }

        #endregion

        #region Methods

        /// <summary>
        ///     The break button click.
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="e">
        ///     The e.
        /// </param>
        private void BreakButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.car.DownSpeed();
            }
            catch (OutLimitOfSpeedException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        ///     Updated current color of car
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColourDropDown_ListSelectedIndexChanged(object sender, EventArgs e)
        {
            KnownColor color;
            Enum.TryParse(this.ColourDropDownList.SelectedItem.ToString(), true, out color);
            this.car.ChangeColour(color);
            this.UpdateMainForm(this.car);
        }

        /// <summary>
        ///     The gas button click.
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="e">
        ///     The e.
        /// </param>
        private void GasButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.car.UpSpeed();
            }
            catch (OutLimitOfSpeedException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        ///     The main form load.
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="e">
        ///     The e.
        /// </param>
        private void MainFormLoad(object sender, EventArgs e)
        {
            this.car = new Car();
            this.car.SpeedChanged += this.OnSpeedChanged;
            this.listOfColorsForCar = new List<KnownColor>();

            foreach (KnownColor color in Enum.GetValues(typeof(KnownColor)).Cast<KnownColor>())
            {
                this.listOfColorsForCar.Add(color);
            }

            this.ColourDropDownList.DataSource = this.listOfColorsForCar;
            this.car.ChangeColour(this.listOfColorsForCar[0]);
            this.ColourPictureBox.BackColor = Color.FromKnownColor(this.car.Colour);
            this.UpdateMainForm(this.car);
        }

        /// <summary>
        ///     The update main form.
        /// </summary>
        /// <param name="currentCar">
        ///     The current car.
        /// </param>
        private void UpdateMainForm(Car currentCar)
        {
            this.SpeedLabel.Text = currentCar.Speed.ToString(CultureInfo.InvariantCulture);
            this.ColourDropDownList.SelectedItem = currentCar.Colour.ToString();
            this.ColourPictureBox.BackColor = Color.FromKnownColor(currentCar.Colour);
        }

        #endregion
    }
}