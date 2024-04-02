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

        private BitmapImage imagen;

        public BitmapImage Imagen
        {
            get { return imagen; }
            set { SetProperty(ref imagen, value); }
        }
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
            Imagen =  ConversorImagen.Base64ToImage(imagen);
            Descripcion = descripcion;
            Precio = precio;
            Tipo = tipo;
        }
        public Articulo(string imagen, string descripcion, int precio, string tipo)
        {
            Imagen =  ConversorImagen.Base64ToImage(imagen);
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
