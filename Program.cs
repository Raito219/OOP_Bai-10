/*****************************
Mã sinh viên: 202418836
Họ tên: Nguyễn Vũ Quang Anh
******************************/
using System;

namespace SmartHome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            HomeConfiguration cfg = HomeConfiguration.Instance;
            cfg.HomeName = "Nhà QA";
            Console.WriteLine("Cấu hình: " + cfg.HomeName + " | Đèn ngủ: " + cfg.NightLightLevel + "%");
            Console.WriteLine();

            // T1: Tạo light, fan, door
            IDevice light = DeviceFactory.Create("light", "Đèn phòng khách");
            IDevice fan   = DeviceFactory.Create("fan",   "Quạt trần");
            IDevice doorD = DeviceFactory.Create("door",  "Cửa chính");
            ILockable door = (ILockable)doorD;

            bool t1 = light is SmartLight && fan is SmartFan && doorD is SmartDoor;
            Console.WriteLine("T1 " + (t1 ? "Đạt" : "Thất bại") + ": Factory trả về đúng kiểu đối tượng");

            // T2: Tạo loại camera chưa hỗ trợ
            try
            {
                IDevice cam = DeviceFactory.Create("camera", "Camera1");
                Console.WriteLine("T2 Thất bại: không có ngoại lệ");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("T2 Đạt: " + ex.Message);
            }

            // T3: Kiểm tra Singleton
            HomeConfiguration cfg2 = HomeConfiguration.Instance;
            bool t3 = Object.ReferenceEquals(cfg, cfg2);
            Console.WriteLine("T3 " + (t3 ? "Đạt" : "Thất bại") + ": hai biến cùng tham chiếu một đối tượng");

            SmartHomeFacade facade = new SmartHomeFacade(light, fan, door);

            // T4: Gọi GoToWork()
            Console.WriteLine("\n--- T4: Gọi GoToWork() ---");
            facade.GoToWork();

            // T5: Gọi GoToSleep()
            Console.WriteLine("\n--- T5: Gọi GoToSleep() ---");
            facade.GoToSleep();
        }
    }
}