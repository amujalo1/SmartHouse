using SmartHouse.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SmartHouseTests
{
    public class SpavacaSobaTests
    {
        [Fact]
        public void SpavacaSoba_DefaultValues_AreCorrect()
        {
            var soba = new SpavacaSoba("Spavaca", "S1");
            Assert.False(soba.HasAlarm);
            Assert.Equal("", soba.AlarmTime);
        }

        [Fact]
        public void SetAlarm_ChangesTime_WhenAlarmExists()
        {
            var soba = new SpavacaSoba("Spavaca", "S1", true);
            DateTime time = new DateTime(2024, 2, 1, 7, 0, 0);
            soba.SetAlarm(time);
            Assert.Equal(time.ToString(), soba.AlarmTime);
        }
    }
}
