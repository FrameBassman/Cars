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
    /// The main form.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields

        #endregion

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

        public virtual void OnSpeedChanged(object sender, EventArgs eventArgs)
        {
            this.UpdateMainForm();
        }

        #endregion

        #region Methods

        private void BreakButtonClick(object sender, EventArgs e)
        {
            try
            {
                Car.GetInstance().DownSpeed();
            }
            catch (OutLimitOfSpeedException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ColorDropDownListSelectedIndexChanged(object sender, EventArgs e)
        {
            KnownColor color = Color.FromName(this.ColorDropDownList.SelectedItem.ToString()).ToKnownColor();
            Car.GetInstance().ChangeColor(color);
            this.UpdateMainForm();
        }


        private void ColorDropDownCreated(object sender, EventArgs e)
        {
            var availableColors = new List<KnownColor>();
            foreach (KnownColor color in Enum.GetValues(typeof(KnownColor)).Cast<KnownColor>())
            {
                availableColors.Add(color);
            }
            this.ColorDropDownList.DataSource = availableColors;
        }


        private void GasButtonClick(object sender, EventArgs e)
        {
            try
            {
                Car.GetInstance().UpSpeed();
            }
            catch (OutLimitOfSpeedException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        /// </param>
        private void MainFormLoad(object sender, EventArgs e)
        {
            Car currentCar = Car.GetInstance();
            currentCar.SpeedChanged += this.OnSpeedChanged;
            this.ColorPictureBox.BackColor = Color.FromKnownColor(currentCar.Color);
            this.UpdateMainForm();
        }


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