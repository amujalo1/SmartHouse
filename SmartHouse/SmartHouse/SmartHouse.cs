using SmartHouse.Composite;
using SmartHouse.Controlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public class SmartHouse : ISmartComponent
    {
        private readonly string NazivKuce;
        private readonly string IDKuce;
        public SmartHouse(string nazivKuce, string idKuce) 
        { 
            NazivKuce = nazivKuce;
            IDKuce = idKuce;
        }
        public override void prikazDetalja()
        {
            Console.WriteLine($"ID: {IDKuce},Prostorija: {NazivKuce}");
            foreach (var component in _components)
            {
                component.prikazDetalja();
            }
        }

        public T? NadjiUredjaj<T>(string id) where T : class
        {
            foreach (var component in _components)
            {
                if (component is T specificDevice && (specificDevice as Device)?.isEqualId(id) == true)
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
