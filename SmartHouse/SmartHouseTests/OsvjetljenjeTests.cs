using SmartHouse.Controlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseTests
{
    public class OsvjetljenjeTests
    {
        [Fact]
        public void Osvjetljenje_DefaultValues_AreCorrect()
        {
            var osvjetljenje = new Osvjetljenje("1", "Lampa", true);
            Assert.Equal(0, osvjetljenje.JacinaSvjetla);
            Assert.Equal("#FFFFFF", osvjetljenje.bojaSvjetla);
        }

        [Theory]
        [InlineData(50, 50)]
        [InlineData(0, 0)]
        [InlineData(100, 100)]
        public void PodesiJacinuSvjetla_ValidValues_SetCorrectly(int input, int expected)
        {
            var osvjetljenje = new Osvjetljenje("1", "Lampa", true);
            osvjetljenje.PodesiJacinuSvjetla(input);
            Assert.Equal(expected, osvjetljenje.JacinaSvjetla);
        }

        [Fact]
        public void PostaviBojuOsvjetljenja_ChangesColor()
        {
            var osvjetljenje = new Osvjetljenje("1", "Lampa", true);
            osvjetljenje.PostaviBojuOsvjetljenja("#FF0000");
            Assert.Equal("#FF0000", osvjetljenje.bojaSvjetla);
        }
    }
}
