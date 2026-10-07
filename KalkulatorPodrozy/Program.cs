using System;

namespace KalkulatorPodrozyApp
{
    /********************************************************
      * nazwa klasy: KalkulatorPodrozy
      * opis klasy: Klasa reprezentuje kalkulator obliczający całkowity
      *              koszt przejazdu samochodem oraz koszt na pasażera.
      * pola: Dystans - dystans trasy w kilometrach (double)
      *       Spalanie - średnie zużycie paliwa na 100 km (double)
      *       CenaPaliwa - cena za 1 litr paliwa w zł (double)
      *       LiczbaPasazerow - liczba osób podróżujących (int)
      * autor: Kacper Dondzik
      ********************************************************/
    public class KalkulatorPodrozy
    {
        public double Dystans { get; set; }
        public double Spalanie { get; set; }
        public double CenaPaliwa { get; set; }
        public int LiczbaPasazerow { get; set; }


        public KalkulatorPodrozy(double dystans, double spalanie, double cenaPaliwa, int liczbaPasazerow)
        {
            Dystans = dystans;
            Spalanie = spalanie;
            CenaPaliwa = cenaPaliwa;
            LiczbaPasazerow = liczbaPasazerow;
        }


        public bool CzyDanePoprawne()
        {
            return Dystans > 0 && Spalanie > 0 && CenaPaliwa > 0;
        }


        public double ObliczIloscPaliwa()
        {
            return (Dystans * Spalanie) / 100.0;
        }


        public double ObliczCalkowityKoszt()
        {
            return ObliczIloscPaliwa() * CenaPaliwa;
        }


        public double ObliczKosztNaPasazera()
        {
            double calkowityKoszt = ObliczCalkowityKoszt();
            if (LiczbaPasazerow <= 0)
            {
                return calkowityKoszt;
            }
            return calkowityKoszt / LiczbaPasazerow;
        }


        public string PobierzPodsumowanie()
        {
            if (!CzyDanePoprawne())
            {
                return "Niepoprawne dane wejściowe!";
            }

            return $"--- PODSUMOWANIE TRASY ---\n" +
                   $"Dystans: {Dystans} km | Spalanie: {Spalanie} l/100km | Cena: {CenaPaliwa:F2} zł\n" +
                   $"Pasażerowie: {LiczbaPasazerow}\n" +
                   $"Zużyte paliwo: {ObliczIloscPaliwa():F2} l\n" +
                   $"Całkowity koszt: {ObliczCalkowityKoszt():F2} zł\n" +
                   $"Koszt na osobę: {ObliczKosztNaPasazera():F2} zł";
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            KalkulatorPodrozy kalkulator = new KalkulatorPodrozy(200, 10, 6.50, 4);

            Console.WriteLine(kalkulator.PobierzPodsumowanie());
            Console.ReadLine();
        }
    }
}