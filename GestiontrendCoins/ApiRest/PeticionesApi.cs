using GestiontrendCoins.Modelo;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace GestiontrendCoins.ApiRest
{
    class PeticionesApi
    {
        public ObservableCollection<Articulo> GetArticulos()
        {
            RestClient client = new RestClient(Properties.Settings.Default.urlApiLocal);
            var request = new RestRequest("articulos",Method.Get);
            RestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<ObservableCollection<Articulo>>(response.Content);
        }

        public Articulo GetArticulo(int id)
        {
            RestClient client = new RestClient(Properties.Settings.Default.urlApiLocal);
            var request = new RestRequest($"articulos/{id}", Method.Get);
            RestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<Articulo>(response.Content);
        }

        public RestResponse PostArticulo(Articulo nuevoArticulo)
        {
            var cliente = new RestClient(Properties.Settings.Default.urlApiLocal);
            var request = new RestRequest("articulos",Method.Post);
            string data = JsonConvert.SerializeObject(nuevoArticulo);
            request.AddParameter("application/json", data,ParameterType.RequestBody);
            var response = cliente.Execute(request);
            Thread.Sleep(1000);
            return response;
        }
        public RestResponse PutArticulo(Articulo actualizaArticulo)
        {
            var cliente = new RestClient(Properties.Settings.Default.urlApiLocal);
            var request = new RestRequest("articulos", Method.Put);
            string data = JsonConvert.SerializeObject(actualizaArticulo);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            var response = cliente.Execute(request);
            Thread.Sleep(1000);
            return response;
        }
        public RestResponse DeleteArticulo(int id)
        {
            var cliente = new RestClient(Properties.Settings.Default.urlApiLocal);
            var request = new RestRequest($"articulos/{id}", Method.Delete);
            var response = cliente.Execute(request);
            return response;
        }
    }
}
