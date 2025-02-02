namespace SmartHouse.Controlers
{
    // Leaf
    public class Device : ISmartComponent
    {
        protected readonly string Id;
        protected readonly string Naziv;
        protected bool IsOn;

        public Device(string id, string naziv, bool isOn)
        {
            Id = id;
            Naziv = naziv;
            IsOn = isOn;
        }

        public bool isEqualId(string id) { return Id.Equals(id); }
        public virtual void TurnOn()
        {
            IsOn = true;
        }

        public virtual void TurnOff()
        {
            IsOn = false;
        }

        public override void prikazDetalja()
        {
            Console.WriteLine($"- ID: {Id}, Uređaj: {Naziv}, Status: {(IsOn ? "Uključen" : "Isključen")}");
        }
        public virtual void Add(ISmartComponent component)
        {
            throw new NotImplementedException();
        }
        public virtual void Remove(ISmartComponent component)
        {
            throw new NotImplementedException();
        }

    }
}