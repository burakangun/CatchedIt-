using System;
using System.Collections.Generic;
using System.Threading;

namespace Odev5
{
    class OyuncuYonetim
    {
        List<Oyuncu> Oyuncular;

        public OyuncuYonetim()
        {
            Oyuncular = new List<Oyuncu>();
        }

        public void OyuncuEkle(Oyuncu oyuncu)
        {
            Oyuncular.Add(oyuncu);
        }
        public void Yazdir()
        {

            foreach (Oyuncu a in Oyuncular)
            {
                Console.Write(a.sira + ".");
                Console.Write(a.oyuncu + " : ");
                Console.Write(a.puan);
                Console.WriteLine();
            }

        }
    }
    class Oyuncu
    {
        public string oyuncu { get; set; }

        public int puan { get; set; }

        public int sira { get; set; }
        public Guid id { get; }
        public Oyuncu(string oyuncu, int puan, int sira)
        {
            this.oyuncu = oyuncu;
            this.puan = puan;
            this.sira = sira;
            id = Guid.NewGuid();
        }

    }
    class Oyun
    {
        List<char> girilenler = new List<char>();
        Random rnd = new Random();
        int gir;
        string aranan = "*";
        string bos = "---";
        public void Oyun9()
        {
            Console.WriteLine("{0},{1},{2}\n{3},{4},{5}\n{6},{7},{8}", bos, bos, bos, bos, bos, bos, bos, bos, aranan);
            girilenler.Add('9');
        }
        public void Oyun8()
        {
            Console.WriteLine("{0},{1},{2}\n{3},{4},{5}\n{6},{7},{8}", bos, bos, bos, bos, bos, bos, bos, aranan, bos);
            girilenler.Add('8');
        }
        public void Oyun7()
        {
            Console.WriteLine("{0},{1},{2}\n{3},{4},{5}\n{6},{7},{8}", bos, bos, bos, bos, bos, bos, aranan, bos, bos);
            girilenler.Add('7');
        }
        public void Oyun6()
        {
            Console.WriteLine("{0},{1},{2}\n{3},{4},{5}\n{6},{7},{8}", bos, bos, bos, bos, bos, aranan, bos, bos, bos);
            girilenler.Add('6');
        }
        public void Oyun5()
        {
            Console.WriteLine("{0},{1},{2}\n{3},{4},{5}\n{6},{7},{8}", bos, bos, bos, bos, aranan, bos, bos, bos, bos);
            girilenler.Add('5');
        }
        public void Oyun4()
        {
            Console.WriteLine("{0},{1},{2}\n{3},{4},{5}\n{6},{7},{8}", bos, bos, bos, aranan, bos, bos, bos, bos, bos);
            girilenler.Add('4');
        }
        public void Oyun3()
        {
            Console.WriteLine("{0},{1},{2}\n{3},{4},{5}\n{6},{7},{8}", bos, bos, aranan, bos, bos, bos, bos, bos, bos);
            girilenler.Add('3');
        }
        public void Oyun2()
        {
            Console.WriteLine("{0},{1},{2}\n{3},{4},{5}\n{6},{7},{8}", bos, aranan, bos, bos, bos, bos, bos, bos, bos);
            girilenler.Add('2');
        }

        public void Oyun1()
        {
            Console.WriteLine("{0},{1},{2}\n{3},{4},{5}\n{6},{7},{8}", aranan, bos, bos, bos, bos, bos, bos, bos, bos);
            girilenler.Add('1');
        }
        static void Main(string[] args)
        {
            OyuncuYonetim yonetim = new OyuncuYonetim();
            Oyun oyun = new Oyun();

            int sira = 1;
            Random rnd = new Random();

            Console.WriteLine("'Yakala Beni !', Oyununa Hoşgeldiniz !"); Console.WriteLine("Amaç herhangi bir karede beliren 6 yıldızın değerlerini aklında tutmaya çalışmak !");

            Console.WriteLine("-1-,-2-,-3-\n-4-,-5-,-6-\n-7-,-8-,-9-");


            while (true)
            {
                Console.WriteLine("Oyuncunun ismini giriniz : ");
                string isim = Console.ReadLine();
                Console.Clear();
                int puan = 0;
                int sayac = 0;
                for (; sayac < 6; sayac++)
                {
                    Thread thread = new Thread(new ThreadStart(() =>
                    {
                        Console.Clear();
                        int game = rnd.Next(1, 10);
                        if (game == 1)
                        {
                            oyun.Oyun1();
                        }
                        else if (game == 2)
                        {
                            oyun.Oyun2();
                        }
                        else if (game == 3)
                        {
                            oyun.Oyun3();
                        }
                        else if (game == 4)
                        {
                            oyun.Oyun4();
                        }
                        else if (game == 5)
                        {
                            oyun.Oyun5();
                        }
                        else if (game == 6)
                        {
                            oyun.Oyun6();
                        }
                        else if (game == 7)
                        {
                            oyun.Oyun7();
                        }
                        else if (game == 8)
                        {
                            oyun.Oyun8();
                        }
                        else if (game == 9)
                        {
                            oyun.Oyun9();
                        }
                    }));
                    thread.Start();
                    Thread.Sleep(1500);
                }
                Console.Clear();
                Console.WriteLine("Sayıları giriniz!  (dip dibe) -Örnek : 345986");
                string girilen = Console.ReadLine();
                int say = 0;
                foreach (char a in girilen)
                {
                    if (a == oyun.girilenler[say])
                    {
                        say++;
                        puan++;
                    }
                }
                Console.WriteLine("Puanınız :" + puan);
                Oyuncu oyuncu = new Oyuncu(isim, puan, sira);
                yonetim.OyuncuEkle(oyuncu);
                sira++;
                Console.WriteLine("Bir daha oynamak için 'E' veya 'e' yazınız ! ");
                string birdaha_oyna = Console.ReadLine();
                if (birdaha_oyna == "E" || birdaha_oyna == "e")
                {
                    oyun.girilenler.Clear();
                    continue;
                }
                else
                {
                    break;
                }

            }
            yonetim.Yazdir();


            Console.ReadLine();
        }
    }
}


