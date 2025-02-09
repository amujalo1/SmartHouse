namespace SmartHouse.Controlers
{
    // Leaf
    public class Device : ASmartComponent
    {
        protected bool IsOn;
        private int temp;

        public Device(string id, string naziv, bool isOn, int w=20) : base(naziv, id) 
        {
            IsOn = isOn;
            if (isOn) { powerConsumption = w; }
            else { powerConsumption = 0; }
            temp = w;
        }

        public override void prikazDetalja()
        {
            Console.WriteLine($"- ID: {ID}, Uređaj: {Naziv}, Status: {(IsOn ? "Uključen" : "Isključen")}");
            Console.WriteLine($"- Potrošnja energije za {Naziv}: {powerConsumption} W");
        }        

        public override void iskljuci()
        {
            powerConsumption = 0;
            IsOn = false;
        }

        public override void ukljuci()
        {
            powerConsumption = temp;
            IsOn = true;
        }

        public bool getStatus()
        {
            return IsOn;
        }

        public override int BrojKomponenti<T>()
        {
            throw new NotImplementedException();
        }
    }
}