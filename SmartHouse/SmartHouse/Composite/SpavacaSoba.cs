using SmartHouse.Controlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Composite
{
    public class SpavacaSoba : Soba
    {
        public bool HasAlarm { get; private set; }
        public string AlarmTime { get; private set; } = string.Empty;

        public SpavacaSoba(string roomName, string id,bool hasAlarm = false) : base(roomName, id)
        {
            HasAlarm = hasAlarm;
        }

        public void SetAlarm(DateTime time)
        {
            if (HasAlarm)
            {
                Console.WriteLine($"Alarm postavljen u prostoriji '{Naziv}' za {time.ToShortTimeString()}.");
                AlarmTime = time.ToString();
            }
            else
            {
                Console.WriteLine($"Prostorija '{Naziv}' nema alarm.");
            }
        }

        public override void prikazDetalja()
        {
            Console.WriteLine($"<-----[Spavaća soba]----->");
            Console.WriteLine($"* Ima alarm: {(HasAlarm ? "Da" : "Ne")}, vrijeme alarma: {AlarmTime}");
            base.prikazDetalja();
        }   
    }
}