using SmartHouse.Composite;
using SmartHouse.Composite.Sobe;
using SmartHouse.Controlers;
using SmartHouse.Controlers.Uredjaji;
using System;
namespace SmartHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Objekat smartKuca = new Objekat("MojDom", "m13jas352");
            Device kucnoGrijanje = new Grijanje("gr1n1","kucno grijanje", true);
            smartKuca.Add(kucnoGrijanje);

            smartKuca.NadjiKomponentu<Grijanje>("gr1n1")?.PostaviZeljenuTemperaturu(32);
            Device rasvjeta = new Osvjetljenje("os1n1", "vanjsa rasvjeta",false);
            SigurnosniSustav Osmica = new SigurnosniSustav("osa1", "sigurnosni uredjaj", true);
            Osmica.AktivirajKameru();

            smartKuca.Add(rasvjeta);
            smartKuca.Add(Osmica);
            smartKuca.NadjiKomponentu<Osvjetljenje>("os1n1")?.PodesiJacinuSvjetla(100);

            Objekat soba1 = new DnevnaSoba("Dnevni boravak", "s1");
            ASmartComponent televizija = new TV("tv1", "televizija dnevni", true);
            ASmartComponent klima = new HVAC("kl1", "klima dnevni", true);
            ASmartComponent svjetlo1 = new Osvjetljenje("os2n1", "svjetlo dnevni", true);
            ASmartComponent grijanje1 = new Grijanje("gr2n1", "dnevno grijanje", true);

            soba1.Add(televizija);
            soba1.Add(klima);
            soba1.Add(svjetlo1);
            soba1.Add(grijanje1);

            soba1.NadjiKomponentu<TV>("tv1")?.PromeniKanal(10);
            soba1.NadjiKomponentu<Device>("kl1")?.iskljuci();

            Kuhinja soba2 = new Kuhinja("Kuhinja", "k1");
            ASmartComponent grijanje2 = new Grijanje("gr2n2", "kuhinsko grijanje", true);
            ASmartComponent plinBojler = new Device("pl1", "plin kuhinja", false);

            soba2.Add(grijanje2);
            soba2.Add(plinBojler);

            smartKuca.Add(soba2);
            //greska
            try
            {
                //ovje su 2 greske jedna jer se na sobu ne moze dodavati nova soba
                //a druga je sto se ne moze dodavati cvor koji vec postoji unutar stabla
                soba2.Add(soba1);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            

            Objekat soba3 = new SpavacaSoba("Spavaca soba", "sp1");
            ASmartComponent klimaSpavaca = new HVAC("kl2", "klima spavaca", true);
            ASmartComponent svjetlo3 = new Osvjetljenje("os3n1", "svjetlo spavaca", true);
            ASmartComponent grijanje3 = new Grijanje("gr3n1", "dnevno spavaca", true);

            soba3.Add(klimaSpavaca);
            soba3.Add(svjetlo3);
            soba3.Add(grijanje3);

            Objekat soba4 = new Kupatilo("Kupatilo", "WC1");
            ASmartComponent ventilacija = new HVAC("kl2", "ventilacija WC", true);
            ASmartComponent svjetlo4 = new Osvjetljenje("os4n1", "svjetlo WC", true);

            soba4.Add(ventilacija);
            soba4.Add(svjetlo4);

            smartKuca.Add(soba1);
            smartKuca.Add(soba3);
            smartKuca.Add(soba4);


            Console.WriteLine("smartKuca: ");
            Console.WriteLine("-----------------------------------------");
            smartKuca.prikazDetalja();
            Console.WriteLine("-----------------------------------------");

            smartKuca.iskljuci();
            Console.WriteLine("smartKuca: ");
            Console.WriteLine("-----------------------------------------");
            smartKuca.prikazDetalja();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("\n\n\n\n\n");
            
            
            Dictionary<string, Objekat> kuce = new Dictionary<string, Objekat>();
            kuce.Add("m13jas352", smartKuca);
            string input;

            void PrikaziHelp()
            {
                Console.WriteLine("Dostupne komande:");
                Console.WriteLine("help - Prikazuje sve dostupne komande");
                Console.WriteLine("dodajKucu id naziv - Dodaje novu kuću");
                Console.WriteLine("dodajSobu idKuce idSobe nazivSobe - Dodaje novu sobu u kuću");
                Console.WriteLine("dodajUredjaj idKuce idSobe idUredjaja nazivUredjaja [tip] - Dodaje novi uređaj u sobu");
                Console.WriteLine("Tree idKuce - Prikazuje strukturu kuće");
                Console.WriteLine("iskljuciSve idKuce - Isključuje sve uređaje u kući");
                Console.WriteLine("jacinaSvjetla idUredjaja jacina - Podešava jačinu svjetla uređaja");
                Console.WriteLine("exit - Izlaz iz aplikacije");
            }

            PrikaziHelp();

            while (true)
            {
                try
                {
                    Console.Write("Unesite komandu: ");
                    input = Console.ReadLine();

                    if (input.ToLower() == "exit")
                        break;

                    string[] parts = input.Split(' ');
                    if (parts.Length < 1)
                    {
                        Console.WriteLine("Neispravna komanda.");
                        continue;
                    }

                    string command = parts[0];

                    switch (command)
                    {
                        case "help":
                            PrikaziHelp();
                            break;

                        case "dodajKucu":
                            if (parts.Length < 3)
                            {
                                Console.WriteLine("Neispravna komanda. Format: dodajKucu id naziv");
                                continue;
                            }
                            kuce[parts[1]] = new Objekat(parts[2], parts[1]);
                            Console.WriteLine($"Kuća {parts[2]} dodana.");
                            break;

                        case "dodajSobu":
                            if (parts.Length < 4 || !kuce.ContainsKey(parts[1]))
                            {
                                Console.WriteLine("Neispravna komanda ili kuća nije pronađena.");
                                continue;
                            }
                            kuce[parts[1]].Add(new Objekat(parts[3], parts[2]));
                            Console.WriteLine($"Soba {parts[3]} dodana u kuću {parts[1]}.");
                            break;

                        case "dodajUredjaj":
                            if (parts.Length < 5 || !kuce.ContainsKey(parts[1]))
                            {
                                Console.WriteLine("Neispravna komanda ili kuća nije pronađena.");
                                continue;
                            }
                            Device uredjaj = DeviceFactory.CreateDevice(parts[3], parts[4], parts.Length > 5 ? parts[5] : "Device");
                            var soba = kuce[parts[1]].NadjiKomponentu<Objekat>(parts[2]);
                            if (soba != null)
                            {
                                soba.Add(uredjaj);
                                Console.WriteLine($"Uređaj {parts[4]} (tip: {parts[5]}) dodan u sobu {parts[2]}.");
                            }
                            else
                            {
                                Console.WriteLine("Soba nije pronađena.");
                            }
                            break;

                        case "Tree":
                            if (kuce.ContainsKey(parts[1]))
                                kuce[parts[1]].prikazDetalja();
                            else
                                Console.WriteLine("Kuća nije pronađena.");
                            break;

                        case "iskljuciSve":
                            if (kuce.ContainsKey(parts[1]))
                            {
                                kuce[parts[1]].iskljuci();
                                Console.WriteLine("Svi uređaji su isključeni.");
                            }
                            else
                            {
                                Console.WriteLine("Kuća nije pronađena.");
                            }
                            break;

                        case "jacinaSvjetla":
                            if (parts.Length < 3)
                            {
                                Console.WriteLine("Neispravna komanda. Format: jacinaSvjetla idUredjaja jacina");
                                continue;
                            }
                            foreach (var kuca in kuce.Values)
                            {
                                var svjetlo = kuca.NadjiKomponentu<Osvjetljenje>(parts[1]);
                                if (svjetlo != null)
                                {
                                    svjetlo.PodesiJacinuSvjetla(int.Parse(parts[2]));
                                    Console.WriteLine($"Jačina svjetla uređaja {parts[1]} postavljena na {parts[2]}.");
                                    break;
                                }
                            }
                            break;

                        default:
                            Console.WriteLine("Nepoznata komanda. Unesite 'help' za listu dostupnih komandi.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Greška: {ex.Message}");
                }
            }
        }
    }
    public static class DeviceFactory
    {
        public static Device CreateDevice(string id, string naziv, string tip)
        {
            return tip.ToLower() switch
            {
                "grijanje" => new Grijanje(id, naziv, true),
                "hvac" => new HVAC(id, naziv, true),
                "osvjetljenje" => new Osvjetljenje(id, naziv, true),
                "pametnizvucnik" => new PametniZvucnik(id, naziv, true),
                "sigurnosnisustav" => new SigurnosniSustav(id, naziv, true),
                "tv" => new TV(id, naziv, true),
                _ => new Device(id, naziv, true),
            };
        }
    }
}
