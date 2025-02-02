using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Composite
{
    public class Kuhinja : Soba
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
                Console.WriteLine($"Pećnica u prostoriji '{NazivSobe}' zagrijava se na {temperature}°C.");
            }
            else
            {
                Console.WriteLine($"Prostorija '{NazivSobe}' nema pećnicu.");
            }
        }

        public override void prikazDetalja()
        {
            Console.WriteLine($"Prostorija: {NazivSobe} (Kuhinja)");
            Console.WriteLine($"Ima pećnicu: {(HasOven ? "Da" : "Ne")}");
            Console.WriteLine($"Broj uređaja: {_components.Count}");
            base.prikazDetalja();
        }

       
    }
}