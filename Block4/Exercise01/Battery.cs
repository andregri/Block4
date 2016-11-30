using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01
{
    public enum BatteryType { LiIon, LiPo, NiCd, NiMH, LiMetal }
    public class Battery
    {
        public string model = null;
        public double idleTime = 0; // measured in [hours.minutes]
        public double hoursTalk = 0;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double IdleTime
        {
            get { return idleTime; }
            set { idleTime = value; }
        }

        public double HoursTalk
        {
            get { return hoursTalk; }
            set { hoursTalk = value; }
        }

        public BatteryType Type { get; set; }

        public Battery(string model, double idleTime, double hoursTalk, BatteryType type = BatteryType.LiMetal)
        {
            Model = model;
            IdleTime = idleTime;
            HoursTalk = hoursTalk;
            Type = type;
        }

        public override string ToString()
        {
            string batteryInfo = "Battery Model: {0}\nBattery IdleTime: {1}\nBattery HoursTalk: {2}\nBattery Type: {3}\n";
            return string.Format(batteryInfo, Model, IdleTime, HoursTalk, Type);
        }
    }
}
