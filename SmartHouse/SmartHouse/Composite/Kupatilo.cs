using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Composite
{
    public class Kupatilo : Soba
    {
        public Kupatilo(string nazivSobe, string idSobe) : base(nazivSobe, idSobe) {}

        public override void prikazDetalja()
        {
            Console.WriteLine($"<-----[Kupatilo]----->");
            base.prikazDetalja(); 
        }

        public override void ukljuci()
        {
            Console.WriteLine($"Uključivanje svih uređaja u kupatilu: {Naziv}");
            base.ukljuci(); 
        }

        public override void iskljuci()
        {
            Console.WriteLine($"Isključivanje svih uređaja u kupatilu: {Naziv}");
            base.iskljuci();
        }
    }
}
