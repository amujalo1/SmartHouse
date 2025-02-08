namespace SmartHouse.Controlers
{
    // Leaf
    public class Device : ASmartComponent
    {
        protected bool IsOn;

        public Device(string id, string naziv, bool isOn) : base(naziv, id) 
        {
            IsOn = isOn;
        }

        public override void prikazDetalja()
        {
            Console.WriteLine($"- ID: {ID}, Uređaj: {Naziv}, Status: {(IsOn ? "Uključen" : "Isključen")}");
        }        

        public override void iskljuci()
        {
            IsOn = false;
        }

        public override void ukljuci()
        {
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