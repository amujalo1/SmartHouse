using Xunit;
using SmartHouse.Composite;
using System;
using SmartHouse.Controlers;

namespace SmartHouse.Tests
{
    public class SmartHouseTest
    {
        private Kuca KreirajKucuSaKomponentama()
        {
            var kuca = new Kuca("Moja Kuca", "1");
            var sprat = new Sprat("Prvi Sprat", "1.1");
            var soba = new Soba("Soba", "1.1.1");
            var kuhinja = new Kuhinja("Kuhinja", "1.1.2");
            var uredjaj = new Device("1.1.1.1", "uredjaj", true);
            var osvjetljenje = new Osvjetljenje("1.1.1.2", "svjetlo", true);

            kuca.Add(sprat);
            sprat.Add(soba);
            sprat.Add(kuhinja);
            soba.Add(uredjaj);
            kuhinja.Add(osvjetljenje);

            return kuca;
        }

        [Theory]
        [InlineData("1.1", true)]
        [InlineData("1.1.1", true)]
        [InlineData("1.1.1.1", true)]
        [InlineData("1.1.1.2", true)]
        [InlineData("2.2", false)]  // Nepostojeća komponenta
        [InlineData("1", true)]  // Glavni objekat (kuca) treba da postoji
        public void NadjiASmartKomponentuBool_Should_Work_Correctly(string id, bool expected)
        {
            var kuca = KreirajKucuSaKomponentama();

            bool result = kuca.NadjiASmartKomponentuBool(id);

            Assert.Equal(expected, result);
        }


        [Fact]
        public void Add_Should_Add_Component_Successfully()
        {
            var kuca = new Kuca("Moja Kuca", "1");
            var sprat = new Sprat("Prvi Sprat", "1.1");
            var soba = new Soba("soba", "1.1.1");
            var kuhinja = new Kuhinja("kuhinja", "1.1.2");
            var uredjaj = new Device("1.1.1.1", "uredjaj", true);
            var osvjetljenje = new Osvjetljenje("1.1.1.2", "svjetlo", true);
            kuca.Add(sprat);
            sprat.Add(soba);
            sprat.Add(kuhinja); 
            soba.Add(uredjaj);
            kuhinja.Add(osvjetljenje);

            Assert.True(kuca.NadjiASmartKomponentuBool("1.1"));
            Assert.True(sprat.NadjiASmartKomponentuBool("1.1.1"));
            Assert.True(soba.NadjiASmartKomponentuBool("1.1.1.1"));
            Assert.True(kuhinja.NadjiASmartKomponentuBool("1.1.1.2"));
            Assert.Equal(1, kuca.BrojKomponenti<Sprat>());
            Assert.Equal(2, kuca.BrojKomponenti<Soba>());
            Assert.Equal(2, kuca.BrojKomponenti<Device>());

            Assert.False(soba.NadjiASmartKomponentuBool("1.1"));
            Assert.False(sprat.NadjiASmartKomponentuBool("1"));
            Assert.False(kuhinja.NadjiASmartKomponentuBool("1.1.1.1"));
        }
        [Fact]
        public void Remove_Should_Remove_Component_Successfully()
        {
            var kuca = KreirajKucuSaKomponentama();
            //kuca.NadjiParentKomponentu("1.1.1.2")?.Remove(osvjetljenje);
            kuca.NadjiParentKomponentu("1.1.1.2")?.Remove(kuca.NadjiASmartKomponentu("1.1.1.2"));
            kuca.NadjiParentKomponentu("1.1.1.1")?.Remove(kuca.NadjiASmartKomponentu("1.1.1.1"));

            Assert.True(kuca.NadjiASmartKomponentuBool("1.1"));
            Assert.True(kuca.NadjiASmartKomponentuBool("1.1.1"));
            //False
            Assert.False(kuca.NadjiASmartKomponentuBool("1.1.1.2"));
            Assert.False(kuca.NadjiASmartKomponentuBool("1.1.1.1"));
        }
        [Fact]
        public void NadjiASmartKomponentu_Should_Find_Component()
        {
            var kuca = new Kuca("Moja Kuca", "1");
            var sprat = new Sprat("Prvi Sprat", "1.1");
            kuca.Add(sprat);

            var found = kuca.NadjiASmartKomponentu("1.1");
            Assert.NotNull(found);
            Assert.Equal(sprat, found);
        }

        [Fact]
        public void NadjiASmartKomponentu_Should_Return_Null_If_Not_Found()
        {
            var kuca = new Kuca("Moja Kuca", "1");

            var found = kuca.NadjiASmartKomponentu("1.1");
            Assert.Null(found);
        }

        [Fact]
        public void NadjiASmartKomponentuBool_Should_Return_True_If_Component_Exists()
        {
            var kuca = new Kuca("Moja Kuca", "1");
            var sprat = new Sprat("Prvi Sprat", "1.1");
            kuca.Add(sprat);

            Assert.True(kuca.NadjiASmartKomponentuBool("1.1"));
        }

        [Fact]
        public void NadjiASmartKomponentuBool_Should_Return_False_If_Component_Does_Not_Exist()
        {
            var kuca = new Kuca("Moja Kuca", "1");

            Assert.False(kuca.NadjiASmartKomponentuBool("1.1"));
        }

        [Fact]
        public void Add_Should_Throw_Exception_When_Duplicate_ID()
        {
            var kuca = new Kuca("Kuca", "1");
            var sprat1 = new Sprat("Prvi Sprat", "1.1");
            var sprat2 = new Sprat("Drugi Sprat", "1.1");
            var uredjaj = new Device("123", "uredjaj", false);
            var objekat = new Objekat("objekat", "123");

            kuca.Add(sprat1);
            sprat1.Add(uredjaj);

            Assert.Throws<InvalidOperationException>(() => kuca.Add(sprat2));
            Assert.Throws<InvalidOperationException>(() => sprat1.Add(sprat2));

            //ovo nam je najbitnije za detekciju bezkonacnog stabla!
            Assert.Throws<InvalidOperationException>(() => kuca.Add(uredjaj));
            Assert.Throws<InvalidOperationException>(() => objekat.Add(objekat));
        }

        [Fact]
        public void Add_Should_Throw_Exception_When_Invalid_Component_Type()
        {
            var soba = new Soba("Soba", "1.1.1");
            var sprat = new Sprat("Sprat", "1.1");
            var kuca = new Kuca("kuca", "1");

            Assert.Throws<InvalidOperationException>(() => soba.Add(sprat));
            Assert.Throws<InvalidOperationException>(() => soba.Add(kuca));
            Assert.Throws<InvalidOperationException>(() => kuca.Add(soba));
            Assert.Throws<InvalidOperationException>(() => sprat.Add(kuca));
        }
        [Fact]
        public void MoveTo_Should_Move_Component_To_New_Parent()
        {
            var kuca = new Kuca("Kuca", "1");
            var sprat = new Sprat("Prvi Sprat", "1.1");
            var soba = new Soba("Soba", "1.1.1");

            kuca.Add(sprat);
            sprat.Add(soba);

            var noviSprat = new Sprat("Drugi Sprat", "1.2");
            kuca.Add(noviSprat);

            var result = soba.MoveTo(noviSprat);

            Assert.NotNull(result);
            Assert.Equal(soba, noviSprat.NadjiObjekat("1.1.1"));
            Assert.NotEqual(soba, sprat.NadjiObjekat("1.1.1"));
        }

        [Fact]
        public void MoveTo_Should_Return_Null_If_Component_Not_Found()
        {
            var sprat = new Sprat("Sprat", "1.1");
            var soba = new Soba("Soba", "1.1.1");

            var noviSprat = new Sprat("Drugi Sprat", "1.2");

            var result = soba.MoveTo(noviSprat);

            Assert.Null(result);
        }
        [Fact]
        public void Iskljuci_Ukljuci_Should_TurnOff_or_TurnOn_Devices()
        {
            var kuca = KreirajKucuSaKomponentama();
            kuca.iskljuci();
            Assert.False(kuca.NadjiKomponentu<Device>("1.1.1.2")?.getStatus());
            Assert.False(kuca.NadjiKomponentu<Device>("1.1.1.1")?.getStatus());
            kuca.ukljuci();
            Assert.True(kuca.NadjiKomponentu<Device>("1.1.1.2")?.getStatus());
            Assert.True(kuca.NadjiKomponentu<Device>("1.1.1.1")?.getStatus());
        }
        [Fact]
        public void Device_Polimorfizam_Test()
        {
            Device uredaj = new SigurnosniSustav("SS01", "Glavni Alarm", true);

            Assert.True(uredaj.getStatus());
            Assert.Equal("SS01", uredaj.ID);
            Assert.Equal("Glavni Alarm", uredaj.Naziv);

            var sigurnosniSustav = Assert.IsType<SigurnosniSustav>(uredaj);
            sigurnosniSustav.AktivirajAlarm();
            Assert.True(sigurnosniSustav.AlarmAktiviran);

            sigurnosniSustav.DeaktivirajAlarm();
            Assert.False(sigurnosniSustav.AlarmAktiviran);
        }
        
        [Fact]
        public void Objekat_Polimorfizam_Test()
        {
            Objekat mojDom = new Kuca("Dom", "Sarajevo");

            Assert.Equal("Dom", mojDom.Naziv);

            var kuca = Assert.IsType<Kuca>(mojDom);
            kuca.Add(new Sprat("sprat 1", "1.1"));
            kuca.Add(new Sprat("sprat 2", "1.1.2"));

            Assert.Equal(2, kuca.BrojKomponenti<Sprat>());
        }
    }
    
}
