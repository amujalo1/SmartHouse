using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Controlers
{
    public class Osvjetljenje : Device
    {
        public int JacinaSvjetla { get; private set; } 
        public string bojaSvjetla { get; private set; }
        public Osvjetljenje(string id, string naziv, bool isOn, int jacina=0, string boja = "#FFFFFF") : base(id,naziv,isOn)
        {   
            JacinaSvjetla = jacina;
            bojaSvjetla = boja;
        }

        public void PodesiJacinuSvjetla(int jacina)
        {
            if (jacina >= 0 && jacina <= 100)
            {
                JacinaSvjetla = jacina;
                Console.WriteLine($"Jačina svjetla za '{Naziv}' je postavljena na {jacina}%.");
            }
            else
            {
                Console.WriteLine($"Nevažeća vrijednost za jačinu svjetla: {jacina}%. Mora biti između 0 i 100.");
            }
        }

        public void PostaviBojuOsvjetljenja(string boja)
        {
            bojaSvjetla = boja;
            Console.WriteLine($"Postavljena boja svjetla na {bojaSvjetla}");
        }


        public override void prikazDetalja()
        {
            base.prikazDetalja();
            Console.WriteLine($" - Osvjetljenje ID: {Id}");
            Console.WriteLine($" - Naziv: {Naziv}");
            Console.WriteLine($" - Jačina svjetla: {JacinaSvjetla}%");

        }
    }
}