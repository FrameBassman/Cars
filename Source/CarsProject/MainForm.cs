namespace CarsProject
{
    using System.Globalization;
    using System.Windows.Forms;

    using CarsProject.Exceptions;

    public partial class MainForm : Form
    {
        private Car car;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainFormLoad(object sender, System.EventArgs e)
        {
            car = new Car();
            UpadteMainForm(car);
        }

        private void BreakButtonClick(object sender, System.EventArgs e)
        {
            try
            {
                car.DownSpeed();
                this.UpadteMainForm(car);
            }
            catch (OutLimitOfSpeedException olose)
            {
                MessageBox.Show(olose.Message);
            }
        }

        private void GasButtonClick(object sender, System.EventArgs e)
        {
            try
            {
                car.UpSpeed();
                this.UpadteMainForm(car);
            }
            catch (OutLimitOfSpeedException olose)
            {
                MessageBox.Show(olose.Message);
            }
        }

        private void UpadteMainForm(Car currentCar)
        {
            SpeedLabel.Text = currentCar.Speed.ToString(CultureInfo.InvariantCulture);
        }
    }
}
