using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestiontrendCoins.FormEditar
{
    /// <summary>
    /// Lógica de interacción para EditarForm.xaml
    /// </summary>
    public partial class EditarForm : Window
    {
        private EditarFormVM vm;
        public EditarForm()
        {
            InitializeComponent();
            vm =new EditarFormVM();
            DataContext = vm;
        }

        private void AceptarBoton_Click(object sender, RoutedEventArgs e)
        {
            if (vm.EditarArticulo())
            {
                DialogResult = true;
            }
        }
    }
}
