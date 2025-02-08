using SmartHouse.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseTests
{
    public class GarazaTests
    {
        [Fact]
        public void Garaza_DefaultValues_AreCorrect()
        {
            var garaza = new Garaza("Moja Garaza", "G1");
            Assert.False(garaza.HasCar);
            Assert.False(garaza.vrata);
        }

        [Fact]
        public void OtvoriVrata_ChangesState()
        {
            var garaza = new Garaza("Moja Garaza", "G1");
            garaza.otvoriVrata();
            Assert.True(garaza.vrata);
        }
    }
}
