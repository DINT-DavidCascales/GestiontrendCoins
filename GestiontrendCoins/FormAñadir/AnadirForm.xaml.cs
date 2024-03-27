using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestiontrendCoins.FormAñadir
{
    /// <summary>
    /// Lógica de interacción para AnadirForm.xaml
    /// </summary>
    public partial class AnadirForm : Window
    {
        private AnadirFormVM vm;
        public AnadirForm()
        {
            InitializeComponent();
            vm= new AnadirFormVM();
            DataContext = vm;
        }

        private void AceptarBoton_Click(object sender, RoutedEventArgs e)
        {
            if (vm.AñadirArticulo())
            {
                DialogResult = true;
            }
        }
    }
}
