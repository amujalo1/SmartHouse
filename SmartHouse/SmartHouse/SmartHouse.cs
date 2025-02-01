using SmartHouse.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public class SmartHouse
    {
        /*
        private List<Soba> sobe { get; set; }
        public SmartHouse()
        {
            sobe = new List<Soba>();
        }
        public void DodajSobu(Soba soba)
        {
            sobe.Add(soba);
            Console.WriteLine($"Dodana je prostorija: {soba.NazivSobe}");
        }
        public void UkloniSobu(Soba soba)
        {
            Soba temp = sobe.Find(x => x.IDSobe == soba.IDSobe);
            if (temp != null)
            {
                sobe.Remove(temp);
                Console.WriteLine($"Ukonjena je prostorija: '{soba.NazivSobe}'");
            }
            else
            {
                Console.WriteLine($"Prostorija '{soba.NazivSobe}' nije pronađena.");
            }
        }

        public void ControlDevice(string IDSobe, string deviceId, bool command)
        {
            Soba room = sobe.Find(r => r.IDSobe == IDSobe);
            if (room != null)
            {
                room.ControlDevice(deviceId, command);
            }
            else
            {
                Console.WriteLine($"Prostorija ID:'{IDSobe}' nije pronađena.");
            }
        }

        public void UkupniPrikazStatusa()
        {
            Console.WriteLine("Status pametne kuce:");
            foreach (var soba in sobe)
            {
                Console.WriteLine($"Prostorija: {soba.NazivSobe}");
                foreach (var device in soba.devices)
                {
                    Console.WriteLine($"  Uređaj: {device.Naziv}, Status: {device.GetStatus()}");
                }
            }
        }*/
    }
}
