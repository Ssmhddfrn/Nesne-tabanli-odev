using System;

namespace TekCiftUygulamasi
{
    // Kullanıcının girdisinin ne türde olduğunu belirtir
    enum GirdiTuru
    {
        Cikis,
        Sayi,
        Gecersiz
    }

    // Girdiyi okuyup türünü belirleyen sınıf
    class GirdiOkuyucu
    {
        public GirdiTuru Oku(out long sayi)
        {
            sayi = 0;

            Console.Write("Bir sayı girin, çıkmak için n/N: ");
            string girdi = (Console.ReadLine() ?? "").Trim();

            if (girdi.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                return GirdiTuru.Cikis;
            }

            if (long.TryParse(girdi, out sayi))
            {
                return GirdiTuru.Sayi;
            }

            return GirdiTuru.Gecersiz;
        }
    }

    // Sayının tek mi çift mi olduğunu belirleyen sınıf
    class TekCiftKontrolcu
    {
        public bool CiftMi(long sayi)
        {
            return sayi % 2 == 0;
        }

        public string SonucMetni(long sayi)
        {
            return CiftMi(sayi)
                ? $"{sayi} sayısı çift bir sayıdır."
                : $"{sayi} sayısı tek bir sayıdır.";
        }
    }

    // Programın akışını yöneten sınıf
    class Uygulama
    {
        private readonly GirdiOkuyucu _okuyucu = new GirdiOkuyucu();
        private readonly TekCiftKontrolcu _kontrolcu = new TekCiftKontrolcu();

        public void Calistir()
        {
            bool devam = true;

            while (devam)
            {
                GirdiTuru tur = _okuyucu.Oku(out long sayi);

                switch (tur)
                {
                    case GirdiTuru.Cikis:
                        Console.WriteLine("Program sonlandırıldı.");
                        devam = false;
                        break;

                    case GirdiTuru.Sayi:
                        Console.WriteLine(_kontrolcu.SonucMetni(sayi));
                        break;

                    default:
                        Console.WriteLine("Geçersiz, sayı ya da n,N girin.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Uygulama uygulama = new Uygulama();
            uygulama.Calistir();
        }
    }
}
