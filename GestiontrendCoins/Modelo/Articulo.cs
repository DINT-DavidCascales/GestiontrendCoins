using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace GestiontrendCoins.Modelo
{
    class Articulo : ObservableObject
    {
        private int id;
        [JsonProperty("id")]
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string imagendb;
        public string Imagendb
        {
            get { return imagendb; }
            set { SetProperty(ref imagendb, value); }
        }
        /*
        private BitmapImage imagendb;

        public BitmapImage Imagendb
        {
            get { return imagendb; }
            set { SetProperty(ref imagendb, value); }
        }*/
        private string descripcion;
        [JsonProperty("descripcion")]

        public string Descripcion
        {
            get { return descripcion; }
            set { SetProperty(ref descripcion, value); }
        }
        private int precio;
        [JsonProperty("precio")]

        public int Precio
        {
            get { return precio; }
            set { SetProperty(ref precio, value); }
        }
        private string tipo;
        [JsonProperty("tipo")]

        public string Tipo
        {
            get { return tipo; }
            set { SetProperty(ref tipo, value); }
        }

        public Articulo()
        {

        }
        public Articulo(int id, string imagen, string descripcion, int precio, string tipo)
        {

            Id = id;
            Imagendb = imagen;
            Descripcion = descripcion;
            Precio = precio;
            Tipo = tipo;
        }
        public Articulo(string imagen, string descripcion, int precio, string tipo)
        {
            Imagendb =  imagen;
            Descripcion = descripcion;
            Precio = precio;
            Tipo = tipo;
        }
        public Articulo(string descripcion, int precio, string tipo)
        {
            Descripcion = descripcion;
            Precio = precio;
            Tipo = tipo;
        }
    }
}
