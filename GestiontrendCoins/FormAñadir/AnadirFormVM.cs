using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using GestiontrendCoins.Modelo;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace GestiontrendCoins.FormAñadir
{
    class AnadirFormVM : ObservableObject
    {
        private ObservableCollection<String> listaTipos;

        public ObservableCollection<String> ListaTipos

        {
            get { return listaTipos; }
            set { SetProperty(ref listaTipos, value); }
        }

        private Articulo nuevoArticulo;
        public Articulo NuevoArticulo
        {
            get { return nuevoArticulo; }
            set { SetProperty(ref nuevoArticulo, value); }
        }
        
        public RelayCommand CambiarFotoCommand { get; }

        public AnadirFormVM()
        {
            NuevoArticulo = new Articulo();
            CambiarFotoCommand = new RelayCommand(AbrirDialogoCambiarFoto);
            ListaTipos = new ObservableCollection<String>() { "Pantalones", "Camisetas", "Calzado", "Complementos" };
        }

        public bool AñadirArticulo()
        {
            if (NuevoArticulo.Precio.ToString().All(char.IsDigit))
            {
                NuevoArticulo.Id = 0;
                //WeakReferenceMessenger.Default.Send(new EnviarArticuloAñadirMensaje(new Articulo(0,Imagendb, Descripcion, Precio, Tipo)));
                WeakReferenceMessenger.Default.Send(new EnviarArticuloAñadirMensaje(NuevoArticulo));
                return true;
            }
            else
            {
                MessageBox.Show("Error en los campos del formulario", "Error Form Articulo", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

        }

        public void AbrirDialogoCambiarFoto()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Abriendo imagendb";
            openFileDialog.Filter = "Imágenes|*.bmp; *.gif; *.jpg; *.jpeg; *.png;";

            if (openFileDialog.ShowDialog() == true)
            {
                // Obtenemos la imagen en base64.
                NuevoArticulo.Imagendb = ConversorImagen.BytesToBase64(ConversorImagen.CompressImage(new BitmapImage(new Uri(openFileDialog.FileName))));

                // Obtenemos la imagen en BitmapImage.
                // Al utilizar MVVM, la referencia es a la propiedad y no a la RUTA.
                NuevoArticulo.ImagenBMP = ConversorImagen.Base64ToImage(NuevoArticulo.Imagendb);
            }
        }
    }
}
