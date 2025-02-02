using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Controlers
{
    public class HVAC : Device
    {
        public int BrzinaVentilatora { get; private set; } 
        public double TrenutnaTemperatura { get; private set; }
        public double ZeljenaTemperatura { get; private set; }

        public HVAC(string id, string naziv, bool isOn) : base(id, naziv, isOn)
        {
            BrzinaVentilatora = 0; 
            TrenutnaTemperatura = 20.0;
            ZeljenaTemperatura = 22.0;
        }

        public void PostaviBrzinu(int brzina)
        {
            if (IsOn)
            {
                if (brzina >= 0 && brzina <= 3)
                {
                    BrzinaVentilatora = brzina;
                    Console.WriteLine($"Brzina ventilatora za '{Naziv}' postavljena na {brzina}.");
                }
                else
                {
                    Console.WriteLine("Nevažeća vrednost brzine. Dozvoljene vrednosti su od 0 do 3.");
                }
            }
            else
            {
                Console.WriteLine($"KlimaVentilacija '{Naziv}' mora biti uključena da bi se promenila brzina ventilatora.");
            }
        }

        public void PostaviZeljenuTemperaturu(double temperatura)
        {
            if (IsOn)
            {
                ZeljenaTemperatura = temperatura;
                Console.WriteLine($"Željena temperatura za '{Naziv}' postavljena na {temperatura}°C.");
            }
            else
            {
                Console.WriteLine($"KlimaVentilacija '{Naziv}' mora biti uključena da bi se postavila željena temperatura.");
            }
        }

        public void AzurirajTrenutnuTemperaturu(double temperatura)
        {
            TrenutnaTemperatura = temperatura;
            Console.WriteLine($"Trenutna temperatura za '{Naziv}' ažurirana na {temperatura}°C.");
        }

        public override void prikazDetalja()
        {
            base.prikazDetalja();
            Console.WriteLine($"- KlimaVentilacija ID: {Id}");
            Console.WriteLine($"- Naziv: {Naziv}");
            Console.WriteLine($"- Brzina ventilatora: {BrzinaVentilatora}");
            Console.WriteLine($"- Trenutna temperatura: {TrenutnaTemperatura}°C");
            Console.WriteLine($"- Željena temperatura: {ZeljenaTemperatura}°C");
        }
    }
}
