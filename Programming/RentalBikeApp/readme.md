---
### RentalBikeApp

---
##### Ứng dụng giúp người dùng thuê xe dễ dàng hơn

### Công nghệ sử dụng
    Visual Studio 2019
    C# Winform Core

### Các thư viện sử dụng trong chương trình
- Microsoft.EntityFrameworkCore.SqlServer - version 5.0.0
- Newtonsoft.Json - version 12.0.3

### Sử dụng
##### Sau khi clone từ git về, chuyển đến file RentalBikeApp.csproj, thêm đoạn sau vào thẻ <Project> và rebuild chương trình

    <ItemGroup>
		<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="5.0.0" />
		<PackageReference Include="Newtonsoft.Json" Version="12.0.3" />
    </ItemGroup>
    
##### chuyển đến file config.cs, thay đổi các thông tin SOURCE, NAME_DATABASE, USERNAME, PASSWORD cho phù hợp

### Chức năng chính
- xem thông tin bãi xe, thông tin chi tiết của xe trước khi muốn thuê xe
- hỗ trợ tính toán thời gian thuê xe, phí thuê xe
- hỗ trợ thanh toán qua thẻ ngân hàng

### Tài liệu tham khảo
