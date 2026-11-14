using System;

namespace SmartHome
{
    public sealed class SmartHomeFacade
    {
        private readonly IDevice  light;
        private readonly IDevice  fan;
        private readonly ILockable door;

        public SmartHomeFacade(IDevice light, IDevice fan, ILockable door)
        {
            this.light = light;
            this.fan   = fan;
            this.door  = door;
        }
        
        public void GoToWork()
        {
            HomeConfiguration cfg = HomeConfiguration.Instance;
            Console.WriteLine("[" + cfg.HomeName + "] Chế độ ra ngoài");
            light.TurnOff();
            fan.TurnOff();
            door.Lock();
        }

        public void GoToSleep()
       {
            HomeConfiguration cfg = HomeConfiguration.Instance;
            Console.WriteLine("[" + cfg.HomeName + "] Chế độ ngủ (độ sáng: " + cfg.NightLightLevel + "%)");
            fan.TurnOff(); // Sửa từ fan.TurnOn() thành fan.TurnOff()
            light.TurnOn();   
            door.Lock();
        }
    }
}

