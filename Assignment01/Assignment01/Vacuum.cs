using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment01
{
    public class Vacuum : Appliance

    {
        public string Grade { get; set; }
        public int BatteryVoltage { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\nGrade: {Grade}\nBattery Voltage: {BatteryVoltage} V";
        }
    }
}
