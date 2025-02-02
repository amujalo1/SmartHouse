using SmartHouse.Composite;
using SmartHouse.Controlers;
using System;

namespace SmartHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            //  client
            SmartHouse smartKuca = new SmartHouse("MojDom", "m13jas352");
            Device kucnoGrijanje = new Grijanje("gr1n1","kucno grijanje", true);
            smartKuca.Add(kucnoGrijanje);

            smartKuca.NadjiUredjaj<Grijanje>("gr1n1")?.PostaviZeljenuTemperaturu(32);
            Device rasvjeta = new Osvjetljenje("os1n1", "vanjsa rasvjeta",false);
            SigurnosniSustav Osmica = new SigurnosniSustav("osa1", "sigurnosni uredjaj", true);
            Osmica.AktivirajKameru();

            smartKuca.Add(rasvjeta);
            smartKuca.Add(Osmica);
            smartKuca.NadjiUredjaj<Osvjetljenje>("os1n1")?.PodesiJacinuSvjetla(100);

            Soba soba1 = new Soba("Dnevni boravak", "s1");
            ISmartComponent televizija = new TV("tv1", "televizija dnevni", true);
            ISmartComponent klima = new HVAC("kl1", "klima dnevni", true);
            ISmartComponent svjetlo1 = new Osvjetljenje("os2n1", "svjetlo dnevni", true);
            ISmartComponent grijanje1 = new Grijanje("gr2n1", "dnevno grijanje", true);

            soba1.Add(televizija);
            soba1.Add(klima);
            soba1.Add(svjetlo1);
            soba1.Add(grijanje1);

            soba1.NadjiUredjaj<TV>("tv1")?.PromeniKanal(10);
            soba1.NadjiUredjaj<Device>("kl1")?.TurnOff();

            Kuhinja soba2 = new Kuhinja("Kuhinja", "k1");
            ISmartComponent grijanje2 = new Grijanje("gr2n2", "kuhinsko grijanje", true);
            ISmartComponent plinBojler = new Device("pl1", "plin kuhinja", false);

            soba2.Add(grijanje2);
            soba2.Add(plinBojler);

            soba1.Add(soba2);
            soba1.NadjiSoba<Kuhinja>("k1")?.PreheatOven(250);

            Soba soba3 = new SpavacaSoba("Spavaca soba", "sp1");
            ISmartComponent klimaSpavaca = new HVAC("kl2", "klima spavaca", true);
            ISmartComponent svjetlo3 = new Osvjetljenje("os3n1", "svjetlo spavaca", true);
            ISmartComponent grijanje3 = new Grijanje("gr3n1", "dnevno spavaca", true);

            soba3.Add(klimaSpavaca);
            soba3.Add(svjetlo3);
            soba3.Add(grijanje3);

            Soba soba4 = new KupatiloSoba("Kupatilo", "WC1");
            ISmartComponent ventilacija = new HVAC("kl2", "ventilacija WC", true);
            ISmartComponent svjetlo4 = new Osvjetljenje("os4n1", "svjetlo WC", true);

            soba4.Add(ventilacija);
            soba4.Add(svjetlo4);

            smartKuca.Add(soba1);
            smartKuca.Add(soba3);
            smartKuca.Add(soba4);


            Console.WriteLine("smartKuca: ");
            Console.WriteLine("-----------------------------------------");
            smartKuca.prikazDetalja();
            Console.WriteLine("-----------------------------------------");

            

        }
    }
}
