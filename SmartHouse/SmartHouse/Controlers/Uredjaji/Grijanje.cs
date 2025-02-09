using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Controlers.Uredjaji
{
    public class Grijanje : Device
    {
        public double TrenutnaTemperatura { get; private set; }
        public double ZeljenaTemperatura { get; private set; }

        public Grijanje(string id, string naziv, bool isOn, int w = 1000) : base(id, naziv, isOn, w)
        {
            TrenutnaTemperatura = 20.0;
            ZeljenaTemperatura = 22.0;
        }

        public void PostaviZeljenuTemperaturu(double temperatura)
        {
            if (IsOn)
            {
                ZeljenaTemperatura = temperatura;
                Console.WriteLine($"Željena temperatura za grijanje '{Naziv}' je postavljena na {temperatura}°C.");
            }
            else
            {
                Console.WriteLine($"Grijanje '{Naziv}' mora biti uključeno da bi se postavila željena temperatura.");
            }
        }

        public void AzurirajTrenutnuTemperaturu(double temperatura)
        {
            TrenutnaTemperatura = temperatura;
            Console.WriteLine($"Trenutna temperatura za grijanje '{Naziv}' je ažurirana na {temperatura}°C.");
        }

        public override void prikazDetalja()
        {
            base.prikazDetalja();
            Console.WriteLine($" - Grijanje ID: {ID}");
            Console.WriteLine($" - Naziv: {Naziv}");
            Console.WriteLine($" - Trenutna temperatura: {TrenutnaTemperatura}°C");
            Console.WriteLine($" - Željena temperatura: {ZeljenaTemperatura}°C");
        }
    }
}
