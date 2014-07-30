namespace CarsProject
{
    using System.Windows.Forms;

    using CarsProject.Exceptions;

    public partial class MainForm : Form
    {
        Car car = new Car();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainFormLoad(object sender, System.EventArgs e)
        {
            this.SpeedLabel.Text = car.Speed.ToString();
        }

        private void BreakButtonClick(object sender, System.EventArgs e)
        {
            try
            {
                car.DownSpeed();
                this.UpadteMainForm(car);
            }
            catch (SpeedLessThanMinimumException sltme)
            {
                car.UpSpeed();
                MessageBox.Show(sltme.Message);
            }
        }

        private void GasButtonClick(object sender, System.EventArgs e)
        {
            try
            {
                car.UpSpeed();
                this.UpadteMainForm(car);
            }
            catch (SpeedMoreThanMaximumException smtme)
            {
                car.DownSpeed();
                MessageBox.Show(smtme.Message);
            }
        }

        private void UpadteMainForm(Car car)
        {
            SpeedLabel.Text = car.Speed.ToString();
        }
    }
}
