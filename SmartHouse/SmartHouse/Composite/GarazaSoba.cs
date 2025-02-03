using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Composite
{
    public class GarazaSoba : Objekat
    {
        public bool HasCar { get; private set; }
        public GarazaSoba(string nazivSobe, string idSobe, bool hasCar = false) : base(nazivSobe, idSobe)
        {
            HasCar = hasCar;
        }


        public override void prikazDetalja()
        {
            Console.WriteLine($"Prostorija: {Naziv} (Garaza)");
            Console.WriteLine($"Ima Auto: {(HasCar ? "Da" : "Ne")}");
            Console.WriteLine($"Broj uređaja: {_components.Count}");
            base.prikazDetalja();
        }
    }
}
