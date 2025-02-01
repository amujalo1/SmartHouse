using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Composite
{
    public class DnevnaSoba : Soba
    {
        // Dodatna svojstva
        public bool HasTV { get; private set; }

        // Konstruktor
        public DnevnaSoba(string roomName, string id, bool hasTV = false) : base(roomName, id)
        {
            HasTV = hasTV;
        }

        // Metoda za uključivanje TV-a
        public void WatchTV()
        {
            if (HasTV)
            {
                Console.WriteLine($"Gledanje TV-a u prostoriji '{NazivSobe}'.");
            }
            else
            {
                Console.WriteLine($"Prostorija '{NazivSobe}' nema TV.");
            }
        }

        // Implementacija apstraktne metode za prikaz informacija o prostoriji
        
        public override void prikazDetalja()
        {
            Console.WriteLine($"Prostorija: {NazivSobe} (Dnevna soba)");
            Console.WriteLine($"Ima TV: {(HasTV ? "Da" : "Ne")}");
            Console.WriteLine($"Broj uređaja: {_components.Count}");
            base.prikazDetalja();
        }
    }
}