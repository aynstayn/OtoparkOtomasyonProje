using System;
using System.Collections.Generic;
using System.Linq;


namespace OtoparkOtomasyonu
{
    class Program
    {
        public static List<Otomobil> Otomobiller = new List<Otomobil>();
        public static List<Bisiklet> Bisikletler = new List<Bisiklet>();
        public static ParkYeri Otopark = new ParkYeri();
        public static int MenuCiz()
        {
            Console.WriteLine("\nOtoparkımıza Hoş Geldiniz!");
            Console.WriteLine("İşlem yapmak için aşağıdaki menüyü kullanabilirsiniz.");
            Console.WriteLine("1- Araç Park Et");
            Console.WriteLine("2- Aracı Parktan Çıkar");
            Console.WriteLine("3- Araçları Göster");
            Console.WriteLine("4- Otoparkı Göster");
            Console.WriteLine("5- Uygulamayı Kapat");
            Console.Write("\tSeçiminiz (1-5): ");
            int secim = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            return secim;
        }

        public static int AracGirisi()
        {
            Console.WriteLine("Otoparkımıza Hoş Geldiniz!");
            Console.WriteLine("1- Otomobil");
            Console.WriteLine("2- Bisiklet");
            Console.Write("Lütfen girecek aracın cinsini seçiniz: ");
            int aracTipi = Convert.ToInt32(Console.ReadLine());
            if (aracTipi == 1)
            {
                Otomobil otomobil = new Otomobil();
                Console.Write("\tOtomobil Plakası: ");
                otomobil.Plaka = Console.ReadLine();
                Console.Write("\tOtomobil Markası: ");
                otomobil.Marka = Console.ReadLine();
                Console.Write("\tOtomobil Modeli: ");
                otomobil.Model = Console.ReadLine();
                Console.Write("\tOtomobil Rengi: ");
                otomobil.Renk = Console.ReadLine();
                Console.Write("\tOtomobil Sahibi Adı Soyadı: ");
                string[] adSoyad = Console.ReadLine().Split(' ');
                otomobil.Sahip = new Sahip(adSoyad[0], adSoyad[1]);

                ParkEtmeDurumu parkDurumu = ParkEtmeDurumu.BASARISIZ;
                while (parkDurumu != ParkEtmeDurumu.BASARILI)
                {
                    Otopark.Yazdir();
                    parkDurumu = Otopark.AracParkEt(otomobil);
                    if (parkDurumu == ParkEtmeDurumu.BASARILI)
                    {
                        otomobil.FisNo = "O" + (Otomobiller.Count() + 1).ToString();
                        Otomobiller.Add(otomobil);
                        Console.WriteLine("Aracınız başarıyla park edildi.");
                        Console.WriteLine("Fiş numaranız: " + otomobil.FisNo);
                        Console.WriteLine("Bu numarayı kaybetmeyin! Çıkarken bunu kullanmalısınız.");
                        Console.WriteLine("Giriş Zamanı: " + otomobil.GirisZamani.ToString("dd.MM.yy HH:mm:ss"));
                        Otopark.Yazdir();
                        return 1;
                    }
                    else
                    {
                        Console.WriteLine("[HATA] Otomobil park edilemez.");
                    }
                }
            }
            else if (aracTipi == 2)
            {
                Bisiklet bisiklet = new Bisiklet();

                Console.Write("\tBisiklet Markası: ");
                bisiklet.Marka = Console.ReadLine();
                Console.Write("\tBisiklet Rengi: ");
                bisiklet.Renk = Console.ReadLine();
                Console.Write("\tBisiklet Sahibi Adı Soyadı: ");
                string[] adSoyad = Console.ReadLine().Split(' ');
                bisiklet.Sahip = new Sahip(adSoyad[0], adSoyad[1]);

                ParkEtmeDurumu parkDurumu = ParkEtmeDurumu.BASARISIZ;
                while (parkDurumu != ParkEtmeDurumu.BASARILI)
                {
                    Otopark.Yazdir();
                    parkDurumu = Otopark.AracParkEt(bisiklet);
                    if (parkDurumu == ParkEtmeDurumu.BASARILI)
                    {
                        bisiklet.FisNo = "B" + (Bisikletler.Count() + 1).ToString();
                        Bisikletler.Add(bisiklet);
                        Console.WriteLine("Aracınız  başarıyla park edildi.");
                        Console.WriteLine("Fiş numaranız: " + bisiklet.FisNo);
                        Console.WriteLine("Bu numarayı kaybetmeyin! Çıkarken bunu kullanmalısınız.");
                        Console.WriteLine("Giriş Zamanı: " + bisiklet.GirisZamani.ToString("dd.MM.yy HH:mm:ss"));
                        Otopark.Yazdir();
                        return 1;
                    }
                    else
                    {
                        Console.WriteLine("[HATA] Otomobil park edilemez.");
                    }
                }
            }
            else
            {
                return -1;
            }
            return 1;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                int kullaniciMenuSecimi = MenuCiz();
                if (kullaniciMenuSecimi == 1)
                {
                    int sonuc = AracGirisi();
                    if (sonuc == -1)
                    {
                        Console.WriteLine("[HATA] Araç girişi yapılamadı.");
                    }
                    else if (sonuc == 1)
                    {
                        continue;
                    }
                }
                else if (kullaniciMenuSecimi == 2)
                {
                    AracCikisi();
                }
                else if (kullaniciMenuSecimi == 3)
                {
                    AraclariGoster();
                }
                else if (kullaniciMenuSecimi == 4)
                {
                    Otopark.Yazdir();
                    Console.WriteLine("Park Halindeki Araç Sayısı: {0}", Otopark.ParkHalindekiAracSayisi);
                }
                else if (kullaniciMenuSecimi == 5) //4 secildiyse
                {
                    Console.Write("\tÇıkmak istediğinize emin misiniz? [E-H]: ");
                    char secim = Convert.ToChar(Console.ReadLine());
                    if (secim == 'E' || secim == 'e')
                    {
                        Console.WriteLine("Hoşçakalın.");
                        System.Environment.Exit(1); //uygulamadan çık.
                    }
                    else if (secim == 'H' || secim == 'h')
                    {
                        Console.WriteLine("Hoşçakalın.");
                        System.Environment.Exit(1); //uygulamadan çık.
                    }
                    else
                    {
                        Console.WriteLine("[HATA] Hatalı seçim yaptınız... Lütfen tekrar deneyin.\n\n");
                        kullaniciMenuSecimi = MenuCiz();
                    }
                }
                else
                {
                    Console.WriteLine("[HATA] Hatalı seçim yaptınız... Lütfen tekrar deneyin.\n\n");
                    kullaniciMenuSecimi = MenuCiz();
                }
            }
        }

        private static void AracCikisi()
        {
            if (Otomobiller.Count() <= 0 && Bisikletler.Count() <= 0)
            {
                Console.WriteLine("[HATA] İçeride hiç araç yok.\n\n");
                return;
            }

            Console.Write("\tLütfen çıkışını yapmak istediğiniz aracın Fiş Numarasını giriniz: ");
            string fisNo = Console.ReadLine();
            if (fisNo.Substring(0, 1) == "O")
            {
                Otomobil cikisYapacakOtomobil = new Otomobil();
                foreach (Otomobil otomobil in Otomobiller)
                {
                    if (otomobil.FisNo == fisNo)
                    {
                        cikisYapacakOtomobil = otomobil;
                        break;
                    }
                }

                Console.WriteLine("Otomobil Bilgileri: ");
                cikisYapacakOtomobil.CikisYap();
                cikisYapacakOtomobil.Yazdir();
                Otopark.AracCikis(cikisYapacakOtomobil);
                Otomobiller.Remove(cikisYapacakOtomobil);
                Console.WriteLine("Çıkışınız yapıldı.");
                Console.WriteLine("Lütfen vezneye borcunuzu ödeyiniz.");
                Console.WriteLine("İyi yolculuklar dileriz.");
            }
            else if (fisNo.Substring(0, 1) == "B")
            {
                Bisiklet cikisYapacakBisiklet = new Bisiklet();
                foreach (Bisiklet bisiklet in Bisikletler)
                {
                    if (bisiklet.FisNo == fisNo)
                    {
                        cikisYapacakBisiklet = bisiklet;
                        break;
                    }
                }

                Console.WriteLine("Bisiklet Bilgileri: ");
                cikisYapacakBisiklet.CikisYap();
                cikisYapacakBisiklet.Yazdir();
                Otopark.AracCikis(cikisYapacakBisiklet);
                Bisikletler.Remove(cikisYapacakBisiklet);
                Console.WriteLine("Çıkışınız yapıldı.");
                Console.WriteLine("Lütfen vezneye borcunuzu ödeyiniz.");
                Console.WriteLine("İyi yolculuklar dileriz.");
                Otopark.Yazdir();
            }
            else
            {
                Console.WriteLine("Fiş NO O veya B ile başlamalıdır.");
            }
        }

        private static void AraclariGoster()
        {
            Console.WriteLine("Otomobiller:");
            if (Otomobiller.Count > 0)
            {
                foreach (Otomobil otomobil in Otomobiller)
                {
                    otomobil.Yazdir();
                }
            }
            else
            {
                Console.WriteLine("[BİLGİ] İçeride hiç otomobil yok.");
            }

            Console.WriteLine("Bisikletler:");
            if (Bisikletler.Count > 0)
            {
                foreach (Bisiklet bisiklet in Bisikletler)
                {
                    bisiklet.Yazdir();
                }
            }
            else
            {
                Console.WriteLine("[BİLGİ] İçeride hiç bisiklet yok.");
            }

        }
    }

    struct Sahip
    {
        public Sahip(string isim, string soyisim)
        {
            Isim = isim;
            Soyisim = soyisim;
        }

        public string Isim { get; set; }
        public string Soyisim { get; set; }
    }

    enum ParkEtmeDurumu
    {
        BASARISIZ = 0,
        BASARILI = 1
    }

    class ParkYeri
    {
        public List<Arac> ParkYerleri { get; } = new List<Arac>();
        public int ParkHalindekiAracSayisi { get; set; } = 0;

        public ParkEtmeDurumu AracParkEt(Arac arac)
        {
            if (ParkHalindekiAracSayisi <= 10)
            {
                ParkYerleri.Add(arac);
                ParkHalindekiAracSayisi++; //arac giriş yaptı
                return ParkEtmeDurumu.BASARILI;
            }
            else
            {
                return ParkEtmeDurumu.BASARISIZ;
            }
        }
        public void AracCikis(Arac arac)
        {
            ParkYerleri.Remove(arac);
            ParkHalindekiAracSayisi--; //arac çıkış yaptı
        }
        public void Yazdir()
        {
            Console.WriteLine("Otoparktaki araç sayısı: {0}", ParkHalindekiAracSayisi);
        }
    }
    class Arac
    {
        public Sahip Sahip { get; set; }
        public int ParkYeri { get; set; }
        public DateTime GirisZamani { get; set; } = DateTime.Now;
        public DateTime CikisZamani { get; set; }
        public string FisNo { get; set; }
        public void CikisYap()
        {
            CikisZamani = DateTime.Now;
        }
        public virtual void Yazdir()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("\tFiş NO: {0,25}", FisNo);
        }
    }

    class Otomobil : Arac
    {
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Renk { get; set; }
        public const double Ucret = 20;

        public double UcretHesapla()
        {
            return Ucret;
        }

        public override void Yazdir()
        {
            base.Yazdir();
            Console.WriteLine("\tPlakası: {0,25}", Plaka);
            Console.WriteLine("\tMarka: {0,25}", Marka);
            Console.WriteLine("\tModel: {0,25}", Model);
            Console.WriteLine("\tRenk: {0,25}", Renk);
            Console.WriteLine("\tGiriş: {0,25}", GirisZamani.ToString("dd.MM.yy HH:mm:ss"));
            if (CikisZamani > GirisZamani)
            {
                Console.WriteLine("\tÇıkış: {0,25}", CikisZamani.ToString("dd.MM.yy HH:mm:ss"));
            }
            Console.WriteLine("\tAnlık Borç: {0,25} TL", Math.Round(UcretHesapla(), 5));
        }
    }

    class Bisiklet : Arac
    {
        public string Marka { get; set; }
        public string Renk { get; set; }
        public const double Ucret = 10;
        public double UcretHesapla()
        {
            return Ucret;
        }

        public override void Yazdir()
        {
            Console.WriteLine("\tMarka: {0,25}", Marka);
            Console.WriteLine("\tRenk: {0,25}", Renk);
            Console.WriteLine("\tGiriş: {0,25}", GirisZamani.ToString("dd.MM.yy HH:mm:ss"));
            if (CikisZamani > GirisZamani)
            {
                Console.WriteLine("\tÇıkış: {0,25}", CikisZamani.ToString("dd.MM.yy HH:mm:ss"));
            }
            Console.WriteLine("\tAnlık Borç: {0,25} TL", Math.Round(UcretHesapla(), 5));
        }
    }
}
