using NearFriends.Domain.IApp;
using System;
using System.Collections.Generic;
using System.Linq;
using NearFriends.Domain.Models;

namespace CnovaTeste
{
    public class FriendApp : IFriendApp
    {
        public void CalcularDistancia(List<Friend> listaAmigos)
        {
            foreach (var item in listaAmigos)
            {
                double latitude = item.Latitude;
                double longitude = item.Longitude;

                var outrosAmigos = listaAmigos.ToList();
                outrosAmigos.Remove(item);

                foreach (var amigo in outrosAmigos)
                {
                    double distancia = DistanciaEntreDuasLocalizacoes(longitude, latitude, amigo.Longitude, amigo.Latitude);
                    amigo.Distancia = distancia;
                }

                List<Friend> amigosProximos = outrosAmigos.OrderBy(t => t.Distancia).Take(3).ToList();
                item.AmigosProximos = amigosProximos;
            }
        }
        /// <summary>
        /// Calcula a distância entre 2 pontos no plano cartesiano utilizando pitágoras.
        /// </summary>
        public double DistanciaEntreDuasLocalizacoes(double primeiraLongitude, double primeiraLatitude, double segundaLongitude, double segundaLatitude)
        {
            return Math.Sqrt(Math.Pow((segundaLatitude - primeiraLatitude),2) + Math.Pow((segundaLongitude - primeiraLongitude),2));            
        }
        
        public bool ValidarLatitudeLongitude(string latitude, string longitude)
        {
            bool validarLatitude = double.TryParse(latitude, out double latitudeValida);
            bool validarLongitude = double.TryParse(longitude, out double longitudeValida);

            if (validarLatitude && validarLongitude)
                return true;
            else
                return false;
        }
    }
}
