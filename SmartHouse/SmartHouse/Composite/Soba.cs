using SmartHouse.Controlers;

namespace SmartHouse.Composite
{
    public class Soba : ISmartComponent
    {
        protected readonly string NazivSobe;
        private readonly string IDSobe;

        public Soba(string nazivSobe, string idSobe)
        {
            NazivSobe = nazivSobe;
            IDSobe = idSobe;
        }


        public override void prikazDetalja()
        {
            Console.WriteLine($"ID: {IDSobe},Prostorija: {NazivSobe}");
            foreach (var component in _components)
            {
                component.prikazDetalja();     
            }
        }
    }
}