using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Controlers;
using Xunit;

namespace SmartHouseTests
{

    public class SigurnosniSustavTests
    {
        [Fact]
        public void SigurnosniSustav_InicijalizacijaTest()
        {
            var sustav = new SigurnosniSustav("001", "Kucni Alarm", true);

            Assert.False(sustav.AlarmAktiviran);
            Assert.False(sustav.KameraAktivna);
            Assert.True(sustav.BravaZakljucana);
        }

        [Fact]
        public void AktivirajAlarm_KadJeUkljucen_TrebaPostavitiNaTrue()
        {
            var sustav = new SigurnosniSustav("002", "Kucni Alarm", true);

            sustav.AktivirajAlarm();

            Assert.True(sustav.AlarmAktiviran);
        }

        [Fact]
        public void AktivirajAlarm_KadJeIskljucen_NeTrebaPromijenitiStanje()
        {
            var sustav = new SigurnosniSustav("003", "Kucni Alarm", false);

            sustav.AktivirajAlarm();

            Assert.False(sustav.AlarmAktiviran);
        }

        [Fact]
        public void DeaktivirajAlarm_TrebaPostavitiNaFalse()
        {
            var sustav = new SigurnosniSustav("004", "Kucni Alarm", true);
            sustav.AktivirajAlarm();

            sustav.DeaktivirajAlarm();

            Assert.False(sustav.AlarmAktiviran);
        }

        [Fact]
        public void AktivirajKameru_KadJeUkljucen_TrebaPostavitiNaTrue()
        {
            var sustav = new SigurnosniSustav("005", "Kucni Alarm", true);

            sustav.AktivirajKameru();

            Assert.True(sustav.KameraAktivna);
        }

        [Fact]
        public void AktivirajKameru_KadJeIskljucen_NeTrebaPromijenitiStanje()
        {
            var sustav = new SigurnosniSustav("006", "Kucni Alarm", false);

            sustav.AktivirajKameru();

            Assert.False(sustav.KameraAktivna);
        }

        [Fact]
        public void DeaktivirajKameru_TrebaPostavitiNaFalse()
        {
            var sustav = new SigurnosniSustav("007", "Kucni Alarm", true);
            sustav.AktivirajKameru();

            sustav.DeaktivirajKameru();

            Assert.False(sustav.KameraAktivna);
        }

        [Fact]
        public void ZakljucajBravu_TrebaPostavitiNaTrue()
        {
            var sustav = new SigurnosniSustav("008", "Kucni Alarm", true);
            sustav.OtkljucajBravu();

            sustav.ZakljucajBravu();

            Assert.True(sustav.BravaZakljucana);
        }

        [Fact]
        public void OtkljucajBravu_TrebaPostavitiNaFalse()
        {
            var sustav = new SigurnosniSustav("009", "Kucni Alarm", true);

            sustav.OtkljucajBravu();

            Assert.False(sustav.BravaZakljucana);
        }
    }

}
