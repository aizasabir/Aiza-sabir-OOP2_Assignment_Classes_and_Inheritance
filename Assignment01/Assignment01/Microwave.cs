using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment01
{
    public class Microwave : Appliance
    {
        public decimal Capacity { get; set; }
        public char RoomType { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\nCapacity: {Capacity} cu.ft\nRoom Type: {RoomType}";
        }
    }
}
