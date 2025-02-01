using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Controlers
{
    public class SigurnosniSustav : Device
    {
        public bool AlarmAktiviran { get; private set; }

        public SigurnosniSustav(string id, string naziv, bool isOn) : base(id, naziv, isOn)
        {
            AlarmAktiviran = false;
        }

        public void AktivirajAlarm()
        {
            if (IsOn)
            {
                AlarmAktiviran = true;
                Console.WriteLine($"Alarm sigurnosnog sustava '{Naziv}' je aktiviran!");
            }
            else
            {
                Console.WriteLine($"Sigurnosni sustav '{Naziv}' mora biti uključen da bi se aktivirao alarm.");
            }
        }

        public void DeaktivirajAlarm()
        {
            if (AlarmAktiviran)
            {
                AlarmAktiviran = false;
                Console.WriteLine($"Alarm sigurnosnog sustava '{Naziv}' je deaktiviran.");
            }
            else
            {
                Console.WriteLine($"Alarm sigurnosnog sustava '{Naziv}' nije aktiviran.");
            }
        }

        public override void GetStatus()
        {
            Console.WriteLine($"- Sigurnosni Sustav ID: {Id}");
            Console.WriteLine($"- Naziv: {Naziv}");
            Console.WriteLine($"- Trenutni status: {(IsOn ? "Uključen" : "Isključen")}");
            Console.WriteLine($"- Alarm: {(AlarmAktiviran ? "Aktiviran" : "Nije aktiviran")}");
        }

        public override void prikazDetalja()
        {
            base.PrikazDetalja();
            Console.WriteLine($"Alarm: {(AlarmAktiviran ? "Aktiviran" : "Nije aktiviran")}");
        }
    }
}