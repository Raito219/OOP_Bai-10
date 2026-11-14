# Hệ Thống Điều Khiển Nhà Thông Minh Mini (Smart Home Mini)

Bài thực hành số 10 — Môn Lập trình Hướng đối tượng (OOP) bằng ngôn ngữ C# (.NET). 
Hệ thống mô phỏng ứng dụng điều khiển một ngôi nhà thông minh với ba loại thiết bị (`SmartLight`, `SmartFan`, `SmartDoor`), tập trung áp dụng ba mẫu thiết kế phần mềm: **Factory**, **Singleton** và **Facade**.

---

## 1. Cấu trúc mã nguồn

| Tên tệp | Thành phần / Pattern | Vai trò và trách nhiệm chính |
| :--- | :--- | :--- |
| `IDevice.cs` | Abstraction (Interface) | Khai báo hành vi bật (`TurnOn`) và tắt (`TurnOff`) chung cho mọi thiết bị. |
| `ILockable.cs` | Abstraction (Interface) | Khai báo hành vi khóa (`Lock`) và mở khóa (`Unlock`) tách riêng cho thiết bị có ổ khóa. |
| `SmartLight.cs` | Concrete Device | Cài đặt thiết bị đèn thông minh (thực thi `IDevice`). |
| `SmartFan.cs` | Concrete Device | Cài đặt thiết bị quạt thông minh (thực thi `IDevice`). |
| `SmartDoor.cs` | Concrete Device | Cài đặt thiết bị cửa thông minh (thực thi đồng thời `IDevice` và `ILockable`). |
| `DeviceFactory.cs` | **Factory Pattern** | Lớp tĩnh khởi tạo thiết bị dựa trên chuỗi phân loại và trả về kiểu trừu tượng `IDevice`. |
| `HomeConfiguration.cs` | **Singleton Pattern** | Quản lý cấu hình dùng chung của ngôi nhà (`HomeName`, `NightLightLevel`) qua một thể hiện duy nhất. |
| `SmartHomeFacade.cs` | **Facade Pattern** | Cung cấp giao diện điều khiển mức cao cho các kịch bản sinh hoạt (`GoToWork`, `GoToSleep`). |
| `Program.cs` | Client & Test Runner | Khởi tạo hệ thống và chạy tự động các tình huống kiểm thử từ `T1` đến `T5`. |

---

## 2. Hướng dẫn cài đặt và chạy chương trình

1. Đảm bảo máy tính đã cài đặt **.NET SDK** (phiên bản 8.0 trở lên).
2. Mở cửa sổ dòng lệnh (Terminal / Command Prompt) tại thư mục gốc chứa tệp `.csproj`.
3. Thực thi lệnh sau để biên dịch và chạy chương trình:
   ```bash
   dotnet run
