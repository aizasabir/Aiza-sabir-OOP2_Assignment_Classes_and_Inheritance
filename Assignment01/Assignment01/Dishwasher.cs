using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment01
{
    public class Dishwasher : Appliance
    {
        public string Feature { get; set; }
        public string SoundRating { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\nFeature: {Feature}\nSound Rating: {SoundRating}";
        }
    }
}
