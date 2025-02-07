using SmartHouse.Controlers;
using System.ComponentModel;

namespace SmartHouse.Composite
{
    //Composite
    public class Objekat : ASmartComponent
    {

        protected List<ASmartComponent> _components = new List<ASmartComponent>();

        public void Add(ASmartComponent component)
        {
            // Provjera da li komponenta već postoji u stablu
            Objekat? root = NadjiKucu();
            if (root != null && root.NadjiASmartKomponentuBool(component.ID))
            {
                Console.WriteLine($"Greška: Komponenta sa ID: {component.ID} već postoji u stablu!");
                return;
            }

            if (this is Soba && !(component is Device))
            {
                Console.WriteLine("Greška: Ako je pocetni objekat Soba, svi objekti moraju biti Device (Uredjaji)!");
                return;
            }
            if (this is Sprat && !(component is Device || component is Soba))
            {
                Console.WriteLine("Greška: Na Sprat se mogu dodavati samo Device (Uredjaji) ili sobe!");
                return;
            }
            if (this is Kuca && (component is Kuca))
            {
                Console.WriteLine("Greška: Na Kucu se mogu dodavati samo Kuce!");
                return;
            }
            component.Parent = this;  
            _components.Add(component);
        }
        public void Remove(ASmartComponent component)
        {
            _components.Remove(component);
        }

        

        public Objekat(string nazivSobe, string idSobe) : base(nazivSobe, idSobe) { }

        public override void prikazDetalja()
        {
            Console.WriteLine($"+ ID: {ID},Prostorija: {Naziv}");
            Console.WriteLine($"  Broj uređaja: {_components.Count}");
            foreach (var component in _components)
            {
                component.prikazDetalja();     
            }
        }
        public T? NadjiKomponentu<T>(string id) where T : ASmartComponent
        {
            foreach (var component in _components)
            {
                if (component is T specificComponent && specificComponent.isEqualId(id))
                {
                    return specificComponent;
                }

                if (component is Objekat soba)
                {
                    var result = soba.NadjiKomponentu<T>(id);
                    if (result != null) return result;
                }
            }

            Console.WriteLine($"Komponenta tipa {typeof(T).Name} sa ID: {id} nije pronađena!");
            return null;
        }

        //sluzi za pronalazak roditelja komponenta sa id unutar ovog (this) objekta
        public Objekat? NadjiParentKomponentu(string id)
        {
            return NadjiASmartKomponentu(id)?.Parent;
        }

        public Objekat? NadjiObjekat(string id)
        {
            foreach (var component in _components)
            {
                if (component.isEqualId(id))
                {
                    return (Objekat?)component;
                }

                if (component is Objekat soba)
                {
                    var result = soba.NadjiParentKomponentu(id);
                    if (result != null) return result;
                }
            }
            return null;
        }

        public ASmartComponent? NadjiASmartKomponentu(string id)
        {
            foreach (var component in _components)
            {
                if (component.isEqualId(id))
                {
                    return component;
                }

                if (component is Objekat soba)
                {
                    var result = soba.NadjiASmartKomponentu(id);
                    if (result != null) return result;
                }
            }
            return null;
        }

        public bool NadjiASmartKomponentuBool(string id)
        {
            foreach (ASmartComponent component in _components)
            {
                //Console.WriteLine(component.ID);
                if (component.isEqualId(id))
                {
                    return true;
                }

                if (component is Objekat soba)
                {
                    var result = soba.NadjiASmartKomponentuBool(id);
                    if (result != false) return true;
                }
            }
            return this.isEqualId(id);
        }

        public override void iskljuci()
        {
            foreach (var component in _components)
            {
                component.iskljuci();
            }
        }

        public override void ukljuci()
        {
            foreach (var component in _components)
            {
                component.ukljuci();
            }
        }
    }
    public class Soba : Objekat
    {
        public Soba(string naziv, string id) : base(naziv, id) { }
    }

    public class Sprat : Objekat
    {
        public Sprat(string naziv, string id) : base(naziv, id) { }
    }

    public class Kuca : Objekat
    {
        public Kuca(string naziv, string id) : base(naziv, id) { }
    }
}