using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Composite
{
    public class Kuhinja : Objekat
    {
        public bool HasOven { get; private set; }

        public Kuhinja(string roomName,string id, bool hasOven = false) : base(roomName,id)
        {
            HasOven = hasOven;
        }

        public void PreheatOven(int temperature)
        {
            if (HasOven)
            {
                Console.WriteLine($"Pećnica u prostoriji '{Naziv}' zagrijava se na {temperature}°C.");
            }
            else
            {
                Console.WriteLine($"Prostorija '{Naziv}' nema pećnicu.");
            }
        }

        public override void prikazDetalja()
        {
            Console.WriteLine($"Prostorija: {Naziv} (Kuhinja)");
            Console.WriteLine($"Ima pećnicu: {(HasOven ? "Da" : "Ne")}");
            Console.WriteLine($"Broj uređaja: {_components.Count}");
            base.prikazDetalja();
        }

       
    }
}