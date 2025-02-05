using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Composite
{
    public class DnevnaSoba : Objekat
    {
        public DnevnaSoba(string roomName, string id) : base(roomName, id) {}
        
        public override void prikazDetalja()
        {
            Console.WriteLine($"<-----[Dnevna soba]----->");
            base.prikazDetalja();
        }
        public override void ukljuci()
        {
            Console.WriteLine($"Uključivanje svih uređaja u Dnevnom boravku: {Naziv}");
            base.ukljuci(); 
        }

        public override void iskljuci()
        {
            Console.WriteLine($"Isključivanje svih uređaja u Dnevnom boravku: {Naziv}");
            base.iskljuci(); 
        }
    }
}