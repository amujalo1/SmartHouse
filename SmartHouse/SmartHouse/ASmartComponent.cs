﻿using SmartHouse.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    // Component
    public abstract class ASmartComponent
    {
        public string Naziv { get; protected set; }
        public string ID { get; protected set; }

        public Objekat? Parent { get; set; }
        public ASmartComponent(string naziv, string Id)
        {
            Naziv = naziv;
            ID = Id;
        }
        public virtual Objekat? NadjiKucu()
        {
            Objekat? parent = (Objekat?)this;

            while (parent != null && parent.Parent != null)
            {
                parent = parent.Parent;
            }

            return parent;
        }

        public abstract void prikazDetalja();
        public abstract void iskljuci();
        public abstract void ukljuci();

        public bool isEqualId(string id) { return ID.Equals(id); }


    }
}
