namespace SmartHouse.Controlers
{
    // Leaf
    public abstract class Device : ISmartComponent
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

        public virtual void TurnOn()
        {
            IsOn = true;
        }

        public virtual void TurnOff()
        {
            IsOn = false;
        }

        public abstract void GetStatus();

        public virtual void PrikazDetalja()
        {
            Console.WriteLine($"- ID: {Id}, Uređaj: {Naziv}, Status: {(IsOn ? "Uključen" : "Isključen")}");
        }

        
    }
}