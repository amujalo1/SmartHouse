using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Composite
{
    public class Kuhinja : Soba
    {
        // Dodatna svojstva
        public bool HasOven { get; private set; }

        // Konstruktor
        public Kuhinja(string roomName,string id, bool hasOven = false) : base(roomName,id)
        {
            HasOven = hasOven;
        }

        // Metoda za zagrijavanje pećnice
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

        // Implementacija apstraktne metode za prikaz informacija o prostoriji
        public override void prikazDetalja()
        {
            Console.WriteLine($"Prostorija: {NazivSobe} (Kuhinja)");
            Console.WriteLine($"Ima pećnicu: {(HasOven ? "Da" : "Ne")}");
            Console.WriteLine($"Broj uređaja: {_components.Count}");
            base.prikazDetalja();
        }

       
    }
}