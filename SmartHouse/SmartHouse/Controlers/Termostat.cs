using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Controlers
{
    public class Termostat : Device
    {
        public double TrenutnaTemperatura { get; private set; }
        public double ZeljenaTemperatura { get; private set; }

        public Termostat(string id, string naziv, bool isOn) : base(id, naziv, isOn)
        {
            TrenutnaTemperatura = 20.0; 
            ZeljenaTemperatura = 22.0; 
        }

        public void PostaviZeljenuTemperaturu(double temperatura)
        {
            if (IsOn)
            {
                ZeljenaTemperatura = temperatura;
                Console.WriteLine($"Željena temperatura za termostat '{Naziv}' je postavljena na {temperatura}°C.");
            }
            else
            {
                Console.WriteLine($"Termostat '{Naziv}' mora biti uključen da bi se postavila željena temperatura.");
            }
        }

        public void AzurirajTrenutnuTemperaturu(double temperatura)
        {
            TrenutnaTemperatura = temperatura;
            Console.WriteLine($"Trenutna temperatura za termostat '{Naziv}' je ažurirana na {temperatura}°C.");
        }

        public override void GetStatus()
        {
            Console.WriteLine($"- Termostat ID: {Id}");
            Console.WriteLine($"- Naziv: {Naziv}");
            Console.WriteLine($"- Trenutni status: {(IsOn ? "Uključen" : "Isključen")}");
            Console.WriteLine($"- Trenutna temperatura: {TrenutnaTemperatura}°C");
            Console.WriteLine($"- Željena temperatura: {ZeljenaTemperatura}°C");
        }

        public override void prikazDetalja()
        {
            base.PrikazDetalja();
            Console.WriteLine($"Trenutna temperatura: {TrenutnaTemperatura}°C");
            Console.WriteLine($"Željena temperatura: {ZeljenaTemperatura}°C");
        }
    }
}
