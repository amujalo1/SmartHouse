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
            ISmartComponent soba1 = new DnevnaSoba("Dnevni boravak", "123a04w1", true);
            ISmartComponent uredjaj1 = new Osvjetljenje("os1", "svijetlo plafon", true, 100);
            ISmartComponent uredjaj2 = new Termostat("te1", "termostat za bojler", true);
            ISmartComponent uredjaj3 = new Termostat("te2", "termostat za bojler2", false);

            soba1.Add(uredjaj1);
            soba1.Add(uredjaj2);
            soba1.Add(uredjaj3);
            soba1.Remove(uredjaj3);

            ISmartComponent soba2 = new Kuhinja("Kuhinja", "kuh123asd", true);
            soba1.Add(soba2);

            ISmartComponent uredjaj4 = new Termostat("te2", "termostat za bojler2", false);
            soba2.Add(uredjaj4);

            ISmartComponent soba3 = new SpavacaSoba("Spavaca", "spav123a3", false);
            soba1.Add(soba3);

            ISmartComponent uredjaj5 = new SigurnosniSustav("sig1", "brava", false);
            soba3.Add(uredjaj5);

            Console.WriteLine("Soba1: ");
            Console.WriteLine("-----------------------------------------");
            soba1.prikazDetalja();
            Console.WriteLine("-----------------------------------------");

            Console.WriteLine("Soba2: ");
            Console.WriteLine("-----------------------------------------");
            soba2.prikazDetalja();
            Console.WriteLine("-----------------------------------------");

            Console.WriteLine("Soba3: ");
            Console.WriteLine("-----------------------------------------");
            soba3.prikazDetalja();
            Console.WriteLine("-----------------------------------------");

        }
    }
}
