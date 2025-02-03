using SmartHouse.Composite;
using SmartHouse.Controlers;
using System;
namespace SmartHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            //  client
            Objekat smartKuca = new Objekat("MojDom", "m13jas352");
            Device kucnoGrijanje = new Grijanje("gr1n1","kucno grijanje", true);
            smartKuca.Add(kucnoGrijanje);

            smartKuca.NadjiUredjaj<Grijanje>("gr1n1")?.PostaviZeljenuTemperaturu(32);
            Device rasvjeta = new Osvjetljenje("os1n1", "vanjsa rasvjeta",false);
            SigurnosniSustav Osmica = new SigurnosniSustav("osa1", "sigurnosni uredjaj", true);
            Osmica.AktivirajKameru();

            smartKuca.Add(rasvjeta);
            smartKuca.Add(Osmica);
            smartKuca.NadjiUredjaj<Osvjetljenje>("os1n1")?.PodesiJacinuSvjetla(100);

            Objekat soba1 = new Objekat("Dnevni boravak", "s1");
            ASmartComponent televizija = new TV("tv1", "televizija dnevni", true);
            ASmartComponent klima = new HVAC("kl1", "klima dnevni", true);
            ASmartComponent svjetlo1 = new Osvjetljenje("os2n1", "svjetlo dnevni", true);
            ASmartComponent grijanje1 = new Grijanje("gr2n1", "dnevno grijanje", true);

            soba1.Add(televizija);
            soba1.Add(klima);
            soba1.Add(svjetlo1);
            soba1.Add(grijanje1);

            soba1.NadjiUredjaj<TV>("tv1")?.PromeniKanal(10);
            soba1.NadjiUredjaj<Device>("kl1")?.iskljuci();

            Kuhinja soba2 = new Kuhinja("Kuhinja", "k1");
            ASmartComponent grijanje2 = new Grijanje("gr2n2", "kuhinsko grijanje", true);
            ASmartComponent plinBojler = new Device("pl1", "plin kuhinja", false);

            soba2.Add(grijanje2);
            soba2.Add(plinBojler);

            soba1.Add(soba2);
            soba1.NadjiSoba<Kuhinja>("k1")?.PreheatOven(250);

            Objekat soba3 = new SpavacaSoba("Spavaca soba", "sp1");
            ASmartComponent klimaSpavaca = new HVAC("kl2", "klima spavaca", true);
            ASmartComponent svjetlo3 = new Osvjetljenje("os3n1", "svjetlo spavaca", true);
            ASmartComponent grijanje3 = new Grijanje("gr3n1", "dnevno spavaca", true);

            soba3.Add(klimaSpavaca);
            soba3.Add(svjetlo3);
            soba3.Add(grijanje3);

            Objekat soba4 = new KupatiloSoba("Kupatilo", "WC1");
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


            Dictionary<string, Objekat> kuce = new Dictionary<string, Objekat>();
            string input;

            while (true)
            {
                Console.Write("Unesite komandu: ");
                input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                string[] parts = input.Split(' ');
                if (parts.Length < 2)
                {
                    Console.WriteLine("Neispravna komanda.");
                    continue;
                }

                string command = parts[0];
                string id = parts[1];

                switch (command)
                {
                    case "dodajKucu":
                        if (parts.Length < 3)
                        {
                            Console.WriteLine("Neispravna komanda. Format: dodajKucu id naziv");
                            continue;
                        }
                        string nazivKuce = parts[2];
                        kuce[id] = new Objekat(nazivKuce, id);
                        Console.WriteLine($"Kuća {nazivKuce} dodana.");
                        break;

                    case "dodajSobu":
                        if (parts.Length < 4)
                        {
                            Console.WriteLine("Neispravna komanda. Format: dodajSobu idKuce idSobe nazivSobe");
                            continue;
                        }
                        string idSobe = parts[2];
                        string nazivSobe = parts[3];
                        if (kuce.ContainsKey(id))
                        {
                            kuce[id].Add(new Objekat(nazivSobe, idSobe));
                            Console.WriteLine($"Soba {nazivSobe} dodana u kuću .");
                        }
                        else
                        {
                            Console.WriteLine("Kuća nije pronađena.");
                        }
                        break;

                    case "dodajUredjaj":
                        if (parts.Length < 5)
                        {
                            Console.WriteLine("Neispravna komanda. Format: dodajUredjaj idKuce idSobe idUredjaja nazivUredjaja [tip]");
                            Console.WriteLine("Dostupni tipovi: Grijanje, HVAC, Osvjetljenje, PametniZvucnik, SigurnosniSustav, TV");
                            continue;
                        }

                        string idSobeUredjaj = parts[2];
                        string idUredjaja = parts[3];
                        string nazivUredjaja = parts[4];
                        string tipUredjaja = parts.Length > 5 ? parts[5] : "Device"; 

                        if (!kuce.ContainsKey(id))
                        {
                            Console.WriteLine("Kuća nije pronađena.");
                            continue;
                        }

                        Device uredjaj = null;

                        switch (tipUredjaja.ToLower())
                        {
                            case "grijanje":
                                uredjaj = new Grijanje(idUredjaja, nazivUredjaja, true);
                                break;
                            case "hvac":
                                uredjaj = new HVAC(idUredjaja, nazivUredjaja, true);
                                break;
                            case "osvjetljenje":
                                uredjaj = new Osvjetljenje(idUredjaja, nazivUredjaja, true);
                                break;
                            case "pametnizvucnik":
                                uredjaj = new PametniZvucnik(idUredjaja, nazivUredjaja, true);
                                break;
                            case "sigurnosnisustav":
                                uredjaj = new SigurnosniSustav(idUredjaja, nazivUredjaja, true);
                                break;
                            case "tv":
                                uredjaj = new TV(idUredjaja, nazivUredjaja, true);
                                break;
                            case "device":
                            default:
                                uredjaj = new Device(idUredjaja, nazivUredjaja, true);
                                break;
                        }

                        if (kuce[id].NadjiSoba<Objekat>(idSobeUredjaj) != null)
                        {
                            kuce[id].NadjiSoba<Objekat>(idSobeUredjaj).Add(uredjaj);
                            Console.WriteLine($"Uređaj {nazivUredjaja} (tip: {tipUredjaja}) dodan u sobu {idSobeUredjaj}.");
                        }
                        else
                        {
                            Console.WriteLine("Soba nije pronađena.");
                        }
                        break;

                    case "Tree":
                        if (kuce.ContainsKey(id))
                        {
                            kuce[id].prikazDetalja();
                        }
                        else
                        {
                            Console.WriteLine("Kuća nije pronađena.");
                        }
                        break;

                    case "iskljuciSve":
                        if (kuce.ContainsKey(id))
                        {
                            kuce[id].iskljuci();
                            Console.WriteLine($"Svi uređaji u kući  su isključeni.");
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
                        string jacina = parts[2];
                        foreach (var kuca in kuce.Values)
                        {
                            var svjetlo = kuca.NadjiUredjaj<Osvjetljenje>(id);
                            if (svjetlo != null)
                            {
                                svjetlo.PodesiJacinuSvjetla(int.Parse(jacina));
                                Console.WriteLine($"Jačina svjetla uređaja {id} postavljena na {jacina}.");
                                break;
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Nepoznata komanda.");
                        break;
                }
            }


        }
    }
}
