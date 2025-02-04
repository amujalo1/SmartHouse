﻿using SmartHouse.Controlers;
using System.ComponentModel;

namespace SmartHouse.Composite
{
    //Composite
    public class Objekat : ASmartComponent
    {

        protected List<ASmartComponent> _components = new List<ASmartComponent>();

        public virtual void Add(ASmartComponent component)
        {
            // Provjera da li komponenta već postoji u stablu
            Objekat? root = NadjiKucu();
            if (root != null && root.NadjiASmartKomponentuBool(component.ID))
            {
                Console.WriteLine($"Greška: Komponenta sa ID: {component.ID} već postoji u stablu!");
                return;
            }
            component.Parent = this;  
            _components.Add(component);
        }
        public virtual void Remove(ASmartComponent component)
        {
            _components.Remove(component);
        }

        

        public Objekat(string nazivSobe, string idSobe) : base(nazivSobe, idSobe) { }

        public override void prikazDetalja()
        {
            Console.WriteLine($"+ ID: {ID},Prostorija: {Naziv}");
            foreach (var component in _components)
            {
                component.prikazDetalja();     
            }
        }
        public virtual T? NadjiKomponentu<T>(string id) where T : ASmartComponent
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

        public virtual Objekat? NadjiParentKomponentu(string id)
        {
            return NadjiKomponentu<Objekat>(id)?.Parent;
        }

        public virtual Objekat? NadjiObjekat(string id)
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

        public virtual ASmartComponent? NadjiASmartKomponentu(string id)
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

        public virtual bool NadjiASmartKomponentuBool(string id)
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



        public virtual bool MoveTo(string id, Objekat noviObjekat)
        {
            var parent = NadjiParentKomponentu(id);
            if (parent != null)
            {
                var component = parent._components.FirstOrDefault(c => c.isEqualId(id));
                if (component != null)
                {
                    parent.Remove(component);
                    noviObjekat.Add(component);
                    Console.WriteLine($"Komponenta sa ID: {id} je premještena u {noviObjekat.Naziv}");
                    return true;
                }
            }
            Console.WriteLine($"Komponenta sa ID: {id} nije pronađena ili nije premještena!");
            return false;
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
}