using GestiontrendCoins.FormAñadir;
using GestiontrendCoins.FormEditar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiontrendCoins.Navegacion
{
    internal class NavegacionService
    {
        public void AbrirNuevoArt()
        {
            AnadirForm anadir= new AnadirForm();
            anadir.ShowDialog();
        }
        public void AbrirEditarForm()
        {
            EditarForm editar= new EditarForm();
            editar.ShowDialog();
        }

    }
}
