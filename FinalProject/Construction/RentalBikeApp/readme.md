---
### RentalBikeApp

---
##### Ứng dụng giúp người dùng thuê xe dễ dàng hơn

### Công nghệ sử dụng
    Visual Studio 2019
    C# Winform Core
    SQL Server 2019

### Cấu trúc chương trình
##### chương trình được chia thành 2 project
- RentalBikeApp: chứa mã nguồn chính của chương trình
- RentalBikeTest: chứa mã nguồn phục vụ unittest cho chương trình chính

### Các thư viện sử dụng trong chương trình
##### Các thư viện trong RentalBikeApp
- Microsoft.EntityFrameworkCore.SqlServer - version 5.0.0
- Newtonsoft.Json - version 12.0.3
##### Các thư viện trong RentalBikeTest
- nunit - version 3.12.0
- NUnit3TestAdapter -version 3.15.1
- Microsoft.NET.Test.Sdk - version 15.4.0
###### Các thư viện này sẽ tự động được include vào project RentalBikeApp khi khởi tạo project, không cần tải về
    
### Cách sử dụng
##### chuyển đến file config.cs, thay đổi CONNECT_STRING cho phù hợp
##### Thông thường, Nuget sẽ tự động tìm các thư viện còn thiếu và tải về cho đầy đủ, nhưng nếu thiếu thư viện thì có thể bật DevelopPowerShell
    cd ./Construction/RentBikeApp
    dotnet add ./UserAPI package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.0
    dotnet add ./UserAPI package Newtonsoft.Json --version 12.0.3

### Chức năng chính
- xem thông tin bãi xe, thông tin chi tiết của xe trước khi muốn thuê xe
- hỗ trợ thuê xe, tính toán thời gian thuê xe, phí thuê xe cho từng loại xe
- hỗ trợ thanh toán qua thẻ ngân hàng
### Phân công công việc
- Phạm Hồng Phúc: Thiết kế và xây dựng chức năng "Thuê xê",Thanh toán
- Sư Hữu Vũ Quang: Thiết kế và xây dựng chức năng "Trả xe"
- Ngô Minh Quang: Thiết kế và xây dựng chức năng "Xem xe và thông tin của xe"
- Trần Minh Quang: Thiết kế và xây dưng chức năng "Xe bãi xe và thông tin bãi xe"
- Các lớp Entities, Data do cả nhóm cùng nhau làm
### Công việc đã sửa
- Cập nhật lại chức năng "Tìm kiếm" vào biểu đồ trình tự
- Cập nhật phân công công việc vào file readme.md
- Đói gói sản phẩm và triển khai trên máy khác
