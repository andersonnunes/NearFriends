using System;
using CnovaTeste;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NearFirends.UnitTest
{
    [TestClass]
    public class FriendTest
    {
        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void ValidarLatitudeELongitude()
        {
            try
            {
                FriendApp friendApp = new FriendApp();
                bool localizacaoinvalida = friendApp.ValidarLatitudeLongitude("cnova", "-46.570725");

                if (!localizacaoinvalida)
                {
                    throw new Exception("Latitude e/ou Longitude inválida.");
                }
            }
            catch (Exception)
            {
                Assert.Fail("Latitude e/ou Longitude inválida.");
            }

        }

        [TestMethod]
        public void ValidarDistancia()
        {
            double primeiraLongitude = -23.611389;
            double primeiraLatitude = -46.570725;
            double segundaLongitude = -23.611389;
            double segundaLatitude = -46.570725;

            FriendApp amigoApp = new FriendApp();
            double distancia = amigoApp.DistanciaEntreDuasLocalizacoes(primeiraLongitude, primeiraLatitude, segundaLongitude, segundaLatitude);

            Assert.AreEqual(0, distancia);
        }
    }
}
