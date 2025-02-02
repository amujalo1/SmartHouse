using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Controlers
{
    public class PametniZvucnik : Device
    {
        public int Glasnoća { get; private set; }
        public bool JeLiSviranjeAktivno { get; private set; }
        public string TrenutnaPjesma { get; private set; }

        public PametniZvucnik(string id, string naziv, bool isOn) : base(id, naziv, isOn)
        {
            Glasnoća = 50;
            JeLiSviranjeAktivno = false;
            TrenutnaPjesma = "";
        }

        public void PustiMuziku(string pjesma)
        {
            if (IsOn)
            {
                TrenutnaPjesma = pjesma;
                JeLiSviranjeAktivno = true;
                Console.WriteLine($"Pametni zvučnik '{Naziv}' svira pjesmu: {pjesma}.");
            }
            else
            {
                Console.WriteLine($"Pametni zvučnik '{Naziv}' mora biti uključen za reprodukciju muzike.");
            }
        }

        public void ZaustaviMuziku()
        {
            if (JeLiSviranjeAktivno)
            {
                JeLiSviranjeAktivno = false;
                Console.WriteLine($"Pametni zvučnik '{Naziv}' je zaustavio reprodukciju muzike.");
            }
            else
            {
                Console.WriteLine($"Pametni zvučnik '{Naziv}' ne svira muziku trenutno.");
            }
        }

        public void PromijeniGlasnocu(int novaGlasnoća)
        {
            if (novaGlasnoća >= 0 && novaGlasnoća <= 100)
            {
                Glasnoća = novaGlasnoća;
                Console.WriteLine($"Glasnoća pametnog zvučnika '{Naziv}' postavljena na {novaGlasnoća}%.");
            }
            else
            {
                Console.WriteLine("Glasnoća mora biti između 0 i 100.");
            }
        }

        public override void prikazDetalja()
        {
            base.prikazDetalja();
            Console.WriteLine($" - Pametni zvučnik ID: {Id}");
            Console.WriteLine($" - Naziv: {Naziv}");
            Console.WriteLine($" - Glasnoća: {Glasnoća}%");
            Console.WriteLine($" - Trenutna pjesma: {(JeLiSviranjeAktivno ? TrenutnaPjesma : "Nema reprodukcije")}");
        }
    }
}