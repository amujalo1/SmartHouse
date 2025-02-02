using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    // Component
    public abstract class ISmartComponent
    {
        protected readonly List<ISmartComponent> _components = new List<ISmartComponent>();

        public abstract void prikazDetalja();

        public virtual void Add(ISmartComponent component)
        {
            _components.Add(component);
        }
        public virtual void Remove(ISmartComponent component)
        {
            _components.Remove(component);
        }
    }
}
