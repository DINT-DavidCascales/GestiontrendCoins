using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using GestiontrendCoins.Modelo;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace GestiontrendCoins.FormEditar
{
    internal class EditarFormVM : ObservableObject
    {
        private ObservableCollection<String> listaTipos;

        public ObservableCollection<String> ListaTipos
        {
            get { return listaTipos; }
            set { SetProperty(ref listaTipos, value); }
        }
        private Articulo articuloSeleccionado;
        public Articulo ArticuloSeleccionado
        {
            get { return articuloSeleccionado; }
            set { SetProperty(ref articuloSeleccionado, value); }
        }
        public RelayCommand CambiarFotoCommand { get; }

        public EditarFormVM()
        {
            ListaTipos = new ObservableCollection<String>() { "Pantalones", "Camisetas", "Calzado", "Complementos" };
            CambiarFotoCommand = new RelayCommand(AbrirDialogoCambiarFoto);
            ArticuloSeleccionado = WeakReferenceMessenger.Default.Send<ArticuloSeleccionadoMensaje>();
        }

        public bool EditarArticulo()
        {
            if (ArticuloSeleccionado.Precio.ToString().All(char.IsDigit))
            {
                var img = ConversorImagen.BytesToBase64(ConversorImagen.CompressImage(ArticuloSeleccionado.Imagen));
                WeakReferenceMessenger.Default.Send(new EnviarArticuloEditarMensaje(new Articulo(ArticuloSeleccionado.Id,img, ArticuloSeleccionado.Descripcion, ArticuloSeleccionado.Precio, ArticuloSeleccionado.Tipo)));
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
            openFileDialog.Filter = "Imagenes|*.png";
            openFileDialog.Title = "Abriendo imagen";

            if (openFileDialog.ShowDialog() == true)
            {
                ArticuloSeleccionado.Imagen = new BitmapImage(new Uri(openFileDialog.FileName));
                MessageBox.Show(ConversorImagen.BytesToBase64(ConversorImagen.CompressImage(ArticuloSeleccionado.Imagen)), "Error Form Articulo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
