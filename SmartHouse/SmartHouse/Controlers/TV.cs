using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Controlers
{
    public class TV : Device
    {
        public int TrenutniKanal { get; private set; }
        public int JacinaZvuka { get; private set; }
        public bool IsMuted { get; private set; }

        public TV(string id, string naziv, bool isOn) : base(id, naziv, isOn)
        {
            TrenutniKanal = 1;
            JacinaZvuka = 10;
            IsMuted = false;
        }

        public void PromeniKanal(int kanal)
        {
            if (IsOn)
            {
                if (kanal > 0)
                {
                    TrenutniKanal = kanal;
                    Console.WriteLine($"Kanal televizora '{Naziv}' promenjen na {kanal}.");
                }
                else
                {
                    Console.WriteLine("Nevažeći broj kanala.");
                }
            }
            else
            {
                Console.WriteLine($"Televizor '{Naziv}' mora biti uključen da bi se promenio kanal.");
            }
        }

        public void PojacajZvuk()
        {
            if (IsOn && JacinaZvuka < 100)
            {
                JacinaZvuka++;
                Console.WriteLine($"Jačina zvuka povećana na {JacinaZvuka}.");
            }
        }

        public void SmanjiZvuk()
        {
            if (IsOn && JacinaZvuka > 0)
            {
                JacinaZvuka--;
                Console.WriteLine($"Jačina zvuka smanjena na {JacinaZvuka}.");
            }
        }

        public void UkljuciIskljuciMute()
        {
            if (IsOn)
            {
                IsMuted = !IsMuted;
                Console.WriteLine(IsMuted ? "Zvuk je isključen." : "Zvuk je uključen.");
            }
        }

        public override void prikazDetalja()
        {
            base.prikazDetalja();
            Console.WriteLine($" - Televizor ID: {ID}");
            Console.WriteLine($" - Naziv: {Naziv}");
            Console.WriteLine($" - Trenutni kanal: {TrenutniKanal}");
            Console.WriteLine($" - Jačina zvuka: {JacinaZvuka} {(IsMuted ? "(Muted)" : "")}");
        }
    }
}