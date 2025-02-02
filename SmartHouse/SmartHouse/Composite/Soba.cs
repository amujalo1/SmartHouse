using SmartHouse.Controlers;

namespace SmartHouse.Composite
{
    public class Soba : ISmartComponent
    {
        protected string NazivSobe;
        private readonly string IDSobe;

        public Soba(string nazivSobe, string idSobe)
        {
            NazivSobe = nazivSobe;
            IDSobe = idSobe;
        }

        public bool isEqualId(string id) { return IDSobe.Equals(id); }

        public override void prikazDetalja()
        {
            Console.WriteLine($"+ ID: {IDSobe},Prostorija: {NazivSobe}");
            foreach (var component in _components)
            {
                component.prikazDetalja();     
            }
        }

        public void sveIskljuci()
        {
            foreach (var component in _components)
            {
                (component as Device)?.TurnOff();
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

                if (component is Soba soba)
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
                if (component is T specificDevice && (specificDevice as Soba)?.isEqualId(id) == true)
                {
                    return specificDevice;
                }
            }
            Console.WriteLine($"Soba sa ID: {id} nije pronadjen!");
            return null;
        }

    }
}