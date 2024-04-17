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

        private Articulo auxiliar;

        public RelayCommand CambiarFotoCommand { get; }


        public EditarFormVM()
        {
            ListaTipos = new ObservableCollection<String>() { "Pantalones", "Camisetas", "Calzado", "Complementos" };
            CambiarFotoCommand = new RelayCommand(AbrirDialogoCambiarFoto);

            ArticuloSeleccionado = new Articulo();

            auxiliar = WeakReferenceMessenger.Default.Send<ArticuloSeleccionadoMensaje>();

            ArticuloSeleccionado.Id = auxiliar.Id;
            ArticuloSeleccionado.Imagendb = auxiliar.Imagendb;
            ArticuloSeleccionado.ImagenBMP = auxiliar.ImagenBMP;
            ArticuloSeleccionado.Descripcion = auxiliar.Descripcion;
            ArticuloSeleccionado.Precio = auxiliar.Precio;
            ArticuloSeleccionado.Tipo = auxiliar.Tipo;

        }

        public bool EditarArticulo()
        {
             
            if (ArticuloSeleccionado.Precio.ToString().All(char.IsDigit))
            {
                // WeakReferenceMessenger.Default.Send(new EnviarArticuloEditarMensaje(new Articulo(ArticuloSeleccionado.Id,ArticuloSeleccionado.Imagendb, ArticuloSeleccionado.Descripcion, ArticuloSeleccionado.Precio, ArticuloSeleccionado.Tipo)));
                WeakReferenceMessenger.Default.Send(new EnviarArticuloEditarMensaje(ArticuloSeleccionado));
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
                ArticuloSeleccionado.Imagendb = ConversorImagen.BytesToBase64(ConversorImagen.CompressImage(new BitmapImage(new Uri(openFileDialog.FileName))));

                // Obtenemos la imagen en BitmapImage.
                ArticuloSeleccionado.ImagenBMP = ConversorImagen.Base64ToImage(ArticuloSeleccionado.Imagendb);

            }
        }
    }
}
