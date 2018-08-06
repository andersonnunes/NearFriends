using NearFriends.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearFriends.Domain.IApp
{
    public interface IFriendApp
    {
        bool ValidarLatitudeLongitude(string latitude, string longitude);
        void CalcularDistancia(List<Friend> listaAmigos);
        double DistanciaEntreDuasLocalizacoes(double primeiraLongitude, double primeiraLatitude, double segundaLongitude, double segundaLatitude);
    }
}
