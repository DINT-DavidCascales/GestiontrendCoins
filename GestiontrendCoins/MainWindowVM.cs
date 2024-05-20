using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using GestiontrendCoins.ApiRest;
using GestiontrendCoins.Modelo;
using GestiontrendCoins.Navegacion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace GestiontrendCoins
{
    class MainWindowVM : ObservableObject
    {
        private Articulo articuloSeleccionado;
        public Articulo ArticuloSeleccionado
        {
            get { return articuloSeleccionado; }
            set { SetProperty(ref articuloSeleccionado, value); }
        }

        private ObservableCollection<Articulo> articulos;
        public ObservableCollection<Articulo> Articulos
        {
            get { return articulos; }
            set { SetProperty(ref articulos, value); }
        }
        private PeticionesApi peticiones;
        public RelayCommand EliminarCommand { get; }
        public RelayCommand AñadirCommand { get; }
        public RelayCommand EditarCommand { get; }
        private NavegacionService navegacionService;

        public MainWindowVM()
        {
            navegacionService =new NavegacionService();
            peticiones = new PeticionesApi();
            Articulos = peticiones.GetArticulos();
            foreach (var articulo in Articulos)
            {
                articulo.ImagenBMP = ConversorImagen.Base64ToImage(articulo.Imagendb);
            }
            EliminarCommand = new RelayCommand(EliminarArticulo);
            AñadirCommand = new RelayCommand(AbrirFormAddArt);
            EditarCommand = new RelayCommand(AbrirFormEditArt);

            WeakReferenceMessenger.Default.Register<MainWindowVM, ArticuloSeleccionadoMensaje>(this, (r, m) =>
            {
                m.Reply(ArticuloSeleccionado);
            });
            WeakReferenceMessenger.Default.Register<MainWindowVM, EnviarArticuloAñadirMensaje>(this, (r, m) =>
            {
                if (peticiones.PostArticulo(m.Value).IsSuccessful)
                {
                    Articulos = peticiones.GetArticulos();
                    foreach (var articulo in Articulos)
                    {
                        articulo.ImagenBMP = ConversorImagen.Base64ToImage(articulo.Imagendb);
                    }
                }
                else
                {
                    MessageBox.Show("Error al añadir un articulo " + peticiones.PostArticulo(m.Value).ErrorMessage, "Error Añadir Articulo", MessageBoxButton.OK, MessageBoxImage.Error);
                    Articulos = peticiones.GetArticulos();
                    foreach (var articulo in Articulos)
                    {
                        articulo.ImagenBMP = ConversorImagen.Base64ToImage(articulo.Imagendb);
                    }
                }
                
            });

            WeakReferenceMessenger.Default.Register<MainWindowVM, EnviarArticuloEditarMensaje>(this, (r, m) =>
            {
                if (peticiones.PutArticulo(m.Value).IsSuccessful)
                {
                    Articulos = peticiones.GetArticulos();
                    foreach (var articulo in Articulos)
                    {
                        articulo.ImagenBMP = ConversorImagen.Base64ToImage(articulo.Imagendb);
                    }

                }
                else
                {
                    MessageBox.Show("Error al editar un articulo ", "Error Editar Articulo", MessageBoxButton.OK, MessageBoxImage.Error);
                    Articulos = peticiones.GetArticulos();
                    foreach (var articulo in Articulos)
                    {
                        articulo.ImagenBMP = ConversorImagen.Base64ToImage(articulo.Imagendb);
                    }
                }
            });
        }
        public void AbrirFormAddArt()
        {
            navegacionService.AbrirNuevoArt();
        }
        public void AbrirFormEditArt()
        {
            navegacionService.AbrirEditarForm();
        }
        public void EliminarArticulo()
        {
            if (ArticuloSeleccionado != null)
            {
                MessageBoxResult result = MessageBox.Show("Estás seguro de querer eliminar el artículo " + ArticuloSeleccionado.Descripcion, "Eliminar Articulo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    peticiones.DeleteArticulo(ArticuloSeleccionado.Id);
                    Articulos = peticiones.GetArticulos();
                    foreach (var articulo in Articulos)
                    {
                        articulo.ImagenBMP = ConversorImagen.Base64ToImage(articulo.Imagendb);
                    }
                }
            }
            else
            {
                MessageBox.Show("No has seleccionado ningun artículo", "Error Eliminar Articulo", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
