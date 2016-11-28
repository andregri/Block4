using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01
{
    public class GSM
    {
        private string model = null;
        private string manufacturer = null;
        private double price = 0;
        private string owner = null;
        private Battery battery;
        private Display display;
        private List<Call> callHistory = new List<Call>();
        static GSM samsungGalaxyS7;

        public string Model
        {
            get { return model; }
            private set { model = value; }
        }
        public string Manufacturer
        {
            get { return manufacturer; }
            private set { manufacturer = value; }
        }
        public double Price
        {
            get { return price; }
            private set
            {
                if (price >= 0)
                    price = value;
                else
                    throw new ArgumentOutOfRangeException("Invalid Argument: Price must be a positive number");
            }
        }
        public string Owner
        {
            get { return owner; }
            private set { owner = value; }
        }

        public GSM(string model, string manufacturer, double price, string owner, string batteryModel,
            double batteryIdleTime, double batteryHoursTalk, BatteryType batteryType, double displaySize,
            uint displayColors)
        {
            Model = model;
            Manufacturer = manufacturer;
            Price = price;
            Owner = owner;
            battery = new Battery(batteryModel, batteryIdleTime, batteryHoursTalk, batteryType);
            display = new Display(displaySize, displayColors);
        }

        public GSM(string model, string manufacturer, double price, string owner, Battery battery, Display display)
            : this(model, manufacturer, price, owner, battery.Model, battery.IdleTime, battery.HoursTalk, 0,display.Size, display.Colors) { }

        public GSM(string model, string manufacturer, double price, string owner, string batteryModel,
            double batteryIdleTime, double batteryHoursTalk)
            : this(model, manufacturer, price, owner, batteryModel, batteryIdleTime, batteryHoursTalk, 0, 0, 0) { }

        public GSM(string model, string manufacturer, double price, string owner)
            : this(model, manufacturer, price, owner, null, 0, 0, 0, 0, 0) { }

        public GSM(string model, string manufacturer, double price)
          : this(model, manufacturer, price, null, null, 0, 0, 0, 0, 0) { }

        static GSM()
        {
            samsungGalaxyS7 = new GSM("GalaxyS7", "Samsung", 519.90, "Mr.Robot", new Battery(null, 217.40, 22, BatteryType.LiPo), new Display(5.1, 167000000));
        }


    }
}
