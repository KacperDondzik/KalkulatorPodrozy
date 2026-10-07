using Microsoft.VisualStudio.TestTools.UnitTesting;
using KalkulatorPodrozyApp;

namespace KalkulatorPodrozyTests
{
    [TestClass]
    public class KalkulatorPodrozyTests
    {
        [TestMethod]
        public void Test_ObliczKosztNaPasazera_DlaZnanychDanych()
        {
            double dystans = 200;
            double spalanie = 10;
            double cena = 6.50;
            int pasazerowie = 4;
            double oczekiwanyKoszt = 32.50;

            var kalkulator = new KalkulatorPodrozy(dystans, spalanie, cena, pasazerowie);

            double wynik = kalkulator.ObliczKosztNaPasazera();

            Assert.AreEqual(oczekiwanyKoszt, wynik, 0.01);
        }
    }
}