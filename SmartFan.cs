using System;

namespace SmartHome
{
    public class SmartFan : IDevice
    {
        private string name;

        public SmartFan(string name)
        {
            this.name = name;
        }

        public void TurnOn()
        {
            Console.WriteLine("Quạt \"" + name + "\" đã bật.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Quạt \"" + name + "\" đã tắt.");
        }
    }
}

