using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Composite
{
    public class Garaza : Soba
    {
        public bool HasCar { get; private set; }
        public Garaza(string nazivSobe, string idSobe, bool hasCar = false) : base(nazivSobe, idSobe)
        {
            HasCar = hasCar;
        }


        public override void prikazDetalja()
        {
            Console.WriteLine($"<-----[Garaza]----->");
            Console.WriteLine($"* Ima Auto: {(HasCar ? "Da" : "Ne")}");
            base.prikazDetalja();
        }

        public override void ukljuci()
        {
            Console.WriteLine($"Uključivanje svih uređaja u garaži: {Naziv}");
            base.ukljuci(); 
        }

        public override void iskljuci()
        {
            Console.WriteLine($"Isključivanje svih uređaja u garaži: {Naziv}");
            base.iskljuci(); 
        }
    }
}
