using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IMPUESTOS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(txtIngreso.Text, out double ingreso) || ingreso < 0)
            {
                MessageBox.Show("Por favor, ingrese un monto de sueldo válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            double fonavi = 0, impRenta = 0, afp = 0;

            if (chkFonavi.IsChecked == true) fonavi = ingreso * 0.08;
            if (chkRenta.IsChecked == true) impRenta = ingreso * 0.05;
            if (chkAfp.IsChecked == true) afp = ingreso * 0.12;

            double totalAPagar = ingreso - (fonavi + impRenta + afp);

            lblFonavi.Text = $"Fonavi: S/. {fonavi:F2}";
            lblRenta.Text = $"Imp. Renta: S/. {impRenta:F2}";
            lblAfp.Text = $"A.F.P.: S/. {afp:F2}";
            lblTotal.Text = $"Total a Pagar: S/. {totalAPagar:F2}";
        }
    }
}