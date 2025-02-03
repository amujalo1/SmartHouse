using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Composite
{
    public class DnevnaSoba : Objekat
    {
        public bool HasTV { get; private set; }

        public DnevnaSoba(string roomName, string id, bool hasTV = false) : base(roomName, id)
        {
            HasTV = hasTV;
        }

        public void WatchTV()
        {
            if (HasTV)
            {
                Console.WriteLine($"Gledanje TV-a u prostoriji '{Naziv}'.");
            }
            else
            {
                Console.WriteLine($"Prostorija '{Naziv}' nema TV.");
            }
        }

        
        public override void prikazDetalja()
        {
            Console.WriteLine($"Prostorija: {Naziv} (Dnevna soba)");
            Console.WriteLine($"Ima TV: {(HasTV ? "Da" : "Ne")}");
            Console.WriteLine($"Broj uređaja: {_components.Count}");
            base.prikazDetalja();
        }
    }
}