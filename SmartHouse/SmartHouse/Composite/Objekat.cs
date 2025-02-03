using SmartHouse.Controlers;

namespace SmartHouse.Composite
{
    public class Objekat : ASmartComponent
    {

        protected List<ASmartComponent> _components = new List<ASmartComponent>();

        public virtual void Add(ASmartComponent component)
        {
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