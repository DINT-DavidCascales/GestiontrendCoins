using CommunityToolkit.Mvvm.Messaging.Messages;
using GestiontrendCoins.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiontrendCoins
{
    class ArticuloSeleccionadoMensaje : RequestMessage<Articulo> { }

    class EnviarArticuloAñadirMensaje : ValueChangedMessage<Articulo>
    {
        public EnviarArticuloAñadirMensaje(Articulo a) : base(a) { }
    }
    class EnviarArticuloEditarMensaje : ValueChangedMessage<Articulo>
    {
        public EnviarArticuloEditarMensaje(Articulo a) : base(a) { }
    }

}
