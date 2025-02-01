using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Composite
{
    public class SpavacaSoba : Soba
    {
        // Dodatna svojstva
        public bool HasAlarm { get; private set; }

        // Konstruktor
        public SpavacaSoba(string roomName, string id,bool hasAlarm = false) : base(roomName, id)
        {
            HasAlarm = hasAlarm;
        }

        // Metoda za postavljanje alarma
        public void SetAlarm(DateTime time)
        {
            if (HasAlarm)
            {
                Console.WriteLine($"Alarm postavljen u prostoriji '{NazivSobe}' za {time.ToShortTimeString()}.");
            }
            else
            {
                Console.WriteLine($"Prostorija '{NazivSobe}' nema alarm.");
            }
        }

        // Implementacija apstraktne metode za prikaz informacija o prostoriji
        public override void prikazDetalja()
        {
            Console.WriteLine($"Prostorija: {NazivSobe} (Spavaća soba)");
            Console.WriteLine($"Ima alarm: {(HasAlarm ? "Da" : "Ne")}");
            Console.WriteLine($"Broj uređaja: {_components.Count}");
            base.prikazDetalja();
        }

        
    }
}