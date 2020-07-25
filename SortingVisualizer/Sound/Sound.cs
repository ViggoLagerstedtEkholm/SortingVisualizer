using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer.Sound
{
    public class Sound
    {
        private SoundPlayer SoundPlayer;
        public Sound()
        {
            SoundPlayer = new SoundPlayer(@"C:\Users\Viggo\Desktop\music\Flight Facilities - Hold Me Down (feat. Stee Downes).wav");
        }
        public void Play()
        {
            SoundPlayer.Play();
        }

        public void Stop()
        {
            SoundPlayer.Stop();
        }
    }
}
