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

        public bool isEqualId(string id) { return ID.Equals(id); }

        public override void prikazDetalja()
        {
            Console.WriteLine($"+ ID: {ID},Prostorija: {Naziv}");
            foreach (var component in _components)
            {
                component.prikazDetalja();     
            }
        }

        public T? NadjiUredjaj<T>(string id) where T : class
        {
            foreach (var component in _components)
            {
                if (component is T specificDevice && (specificDevice as Device)?.isEqualId(id)==true)
                {
                    return specificDevice;
                }

                if (component is Objekat soba)
                {
                    var result = soba.NadjiUredjaj<T>(id);
                    if (result != null) return result;
                }
            }
            Console.WriteLine($"Uredjaj sa ID: {id} nije pronadjen!");
            return null;
        }

        public T? NadjiSoba<T>(string id) where T : class
        {
            foreach (var component in _components)
            {
                if (component is T specificDevice && (specificDevice as Objekat)?.isEqualId(id) == true)
                {
                    return specificDevice;
                }
            }
            Console.WriteLine($"Soba sa ID: {id} nije pronadjen!");
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