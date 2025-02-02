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
        public bool KameraAktivna { get; private set; }
        public bool BravaZakljucana { get; private set; }

        public SigurnosniSustav(string id, string naziv, bool isOn) : base(id, naziv, isOn)
        {
            AlarmAktiviran = false;
            KameraAktivna = false;
            BravaZakljucana = true;
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

        public void AktivirajKameru()
        {
            if (IsOn)
            {
                KameraAktivna = true;
                Console.WriteLine($"Kamera sigurnosnog sustava '{Naziv}' je aktivirana.");
            }
            else
            {
                Console.WriteLine($"Sigurnosni sustav '{Naziv}' mora biti uključen da bi kamera radila.");
            }
        }

        public void DeaktivirajKameru()
        {
            KameraAktivna = false;
            Console.WriteLine($"Kamera sigurnosnog sustava '{Naziv}' je deaktivirana.");
        }

        public void ZakljucajBravu()
        {
            BravaZakljucana = true;
            Console.WriteLine($"Pametna brava sigurnosnog sustava '{Naziv}' je zaključana.");
        }

        public void OtkljucajBravu()
        {
            BravaZakljucana = false;
            Console.WriteLine($"Pametna brava sigurnosnog sustava '{Naziv}' je otključana.");
        }

        public override void prikazDetalja()
        {
            base.prikazDetalja();
            Console.WriteLine($"- Sigurnosni Sustav ID: {Id}");
            Console.WriteLine($"- Naziv: {Naziv}");
            Console.WriteLine($"- Alarm: {(AlarmAktiviran ? "Aktiviran" : "Nije aktiviran")}");
            Console.WriteLine($"- Kamera: {(KameraAktivna ? "Aktivna" : "Neaktivna")}");
            Console.WriteLine($"- Brava: {(BravaZakljucana ? "Zaključana" : "Otključana")}");
        }
    }
}
