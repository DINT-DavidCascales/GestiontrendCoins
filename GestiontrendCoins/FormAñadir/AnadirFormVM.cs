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
        private string imagendb;
        public string Imagendb
        {
            get { return imagendb; }
            set { SetProperty(ref imagendb, value); }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { SetProperty(ref descripcion, value); }
        }
        private int precio;
        public int Precio
        {
            get { return precio; }
            set { SetProperty(ref precio, value); }
        }
        private string tipo;
        public string Tipo
        {
            get { return tipo; }
            set { SetProperty(ref tipo, value); }
        }
        public RelayCommand CambiarFotoCommand { get; }

        public AnadirFormVM()
        {
            CambiarFotoCommand = new RelayCommand(AbrirDialogoCambiarFoto);
            ListaTipos = new ObservableCollection<String>() { "Pantalones", "Camisetas", "Calzado", "Complementos" };
        }

        public bool AñadirArticulo()
        {
            if (Precio.ToString().All(char.IsDigit))
            {
                WeakReferenceMessenger.Default.Send(new EnviarArticuloAñadirMensaje(new Articulo(0,Imagendb, Descripcion, Precio, Tipo)));
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
            openFileDialog.Title = "Abriendo imagendb";

            if(openFileDialog.ShowDialog()==true)
            {
                Imagendb = ConversorImagen.BytesToBase64(ConversorImagen.CompressImage(new BitmapImage(new Uri(openFileDialog.FileName))));
            }
        }
    }
}
