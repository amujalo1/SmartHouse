using SmartHouse.Controlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseTests
{
    public class PametniZvucnikTests
    {
        [Fact]
        public void PametniZvucnik_DefaultValues_AreCorrect()
        {
            var zvucnik = new PametniZvucnik("2", "Zvucnik", true);
            Assert.Equal(50, zvucnik.Glasnoća);
            Assert.False(zvucnik.JeLiSviranjeAktivno);
            Assert.Equal("", zvucnik.TrenutnaPjesma);
        }

        [Fact]
        public void PustiMuziku_TurnsOnMusic_WhenDeviceIsOn()
        {
            var zvucnik = new PametniZvucnik("2", "Zvucnik", true);
            zvucnik.PustiMuziku("Song 1");
            Assert.True(zvucnik.JeLiSviranjeAktivno);
            Assert.Equal("Song 1", zvucnik.TrenutnaPjesma);
        }

        [Fact]
        public void ZaustaviMuziku_StopsMusic_WhenPlaying()
        {
            var zvucnik = new PametniZvucnik("2", "Zvucnik", true);
            zvucnik.PustiMuziku("Song 1");
            zvucnik.ZaustaviMuziku();
            Assert.False(zvucnik.JeLiSviranjeAktivno);
        }
    }
}
