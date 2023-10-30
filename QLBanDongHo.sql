--create database QLBanDongHo
--drop database QLBanDongHo
-- Tạo bảng tAnhSP

CREATE TABLE tAnhSP (
    MaSP int NOT NULL,
    TenFileAnh char(100) NOT NULL,
    ViTri smallint NULL,
    PRIMARY KEY (MaSP, TenFileAnh)
)

-- Tạo bảng tChatLieu
CREATE TABLE tChatLieu (
    MaChatLieu char(25) NOT NULL,
    ChatLieu nvarchar(150) NULL,
    PRIMARY KEY (MaChatLieu)
)-- Tạo bảng tUser
CREATE TABLE tUser (
    username char(100) NOT NULL,
    password char(256) NOT NULL,
    LoaiUser int NULL,
    PRIMARY KEY (username)
)
-- Tạo bảng tKhachHang
CREATE TABLE tKhachHang (
    MaKhanhHang INT IDENTITY(1,1) NOT NULL,
    username char(100) NULL,
    TenKhachHang nvarchar(100) NULL,
    NgaySinh date NULL,
    SoDienThoai char(15) NULL,
    DiaChi nvarchar(150) NULL,
    LoaiKhachHang tinyint NULL,
    AnhDaiDien char(100) NULL,
    GhiChu nvarchar(100) NULL,
    PRIMARY KEY (MaKhanhHang),
    FOREIGN KEY (username) REFERENCES tUser (username)
);

-- Tạo các bảng tKich
-- Tạo bảng tKichThuoc
CREATE TABLE tKichThuoc (
    MaKichThuoc char(25) NOT NULL,
    KichThuoc nchar(150) NULL,
    PRIMARY KEY (MaKichThuoc)
);

-- Tạo bảng tLoaiDT
CREATE TABLE tLoaiDT (
    MaDT char(25) NOT NULL,
    TenLoai nvarchar(100) NULL,
    PRIMARY KEY (MaDT)
);

-- Tạo bảng tLoaiSP
CREATE TABLE tLoaiSP (
    MaLoai char(25) NOT NULL,
    Loai nvarchar(100) NULL,
	TenFileAnh NVARCHAR(255) 
    PRIMARY KEY (MaLoai)
);

-- Tạo bảng tMauSac
CREATE TABLE tMauSac (
    MaMauSac char(25) NOT NULL,
    TenMauSac nvarchar(100) NULL,
    PRIMARY KEY (MaMauSac)
);

-- Tạo bảng tNhanVien
CREATE TABLE tNhanVien (
    MaNhanVien INT IDENTITY(1,1) NOT NULL,
    username char(100) NULL,
    TenNhanVien nvarchar(100) NULL,
	GioiTinh nvarchar(10) NOT NULL,
    NgaySinh date NULL,
    SoDienThoai char(15) NULL,
    DiaChi nvarchar(150) NULL,
    ChucVu nvarchar(100) NULL,
    AnhDaiDien char(100) NULL,
    GhiChu nvarchar(100) NULL,
    PRIMARY KEY (MaNhanVien),
    FOREIGN KEY (username) REFERENCES tUser (username)
);

-- Tạo bảng tQuocGia
CREATE TABLE tQuocGia (
    MaNuoc char(25) NOT NULL,
    TenNuoc nvarchar(100) NULL,
    PRIMARY KEY (MaNuoc)
);


-- Tạo bảng tHangSX
CREATE TABLE tHangSX (
    MaHangSX char(25) NOT NULL,
    HangSX nvarchar(100) NULL,
    MaNuocThuongHieu char(25) NULL,
    PRIMARY KEY (MaHangSX),
    FOREIGN KEY (MaNuocThuongHieu) REFERENCES tQuocGia (MaNuoc)
);
-- Tạo bảng tDanhMucSP
CREATE TABLE tDanhMucSP (
    MaSP INT IDENTITY(1,1) NOT NULL,
    TenSP nvarchar(150) NULL,
    MaChatLieu char(25) NULL,
    CanNang float NULL,
    MaHangSX char(25) NULL,
    MaNuocSX char(25) NULL,
    MaDacTinh char(25) NULL,
    ThoiGianBaoHanh float NULL,
    GioiThieuSP nvarchar(max) NULL,
    ChietKhau float NULL,
    MaLoai char(25) NULL,
    MaDT char(25) NULL,
    AnhDaiDien char(100) NULL,
    GiaNhoNhat money NULL,
    GiaLonNhat money NULL,
    PRIMARY KEY (MaSP),
    FOREIGN KEY (MaChatLieu) REFERENCES tChatLieu (MaChatLieu),
    FOREIGN KEY (MaHangSX) REFERENCES tHangSX (MaHangSX),
    FOREIGN KEY (MaLoai) REFERENCES tLoaiSP (MaLoai),
    FOREIGN KEY (MaDT) REFERENCES tLoaiDT (MaDT),
    FOREIGN KEY (MaNuocSX) REFERENCES tQuocGia (MaNuoc)
);




-- Tạo bảng tHoaDonBan
CREATE TABLE tHoaDonBan (
    MaHoaDon INT IDENTITY(1,1) NOT NULL,
    NgayHoaDon datetime NULL,
    MaKhachHang INT NULL,
    MaNhanVien INT NULL,
    TongTienHD money NULL,
    GiamGiaHD float NULL,
    PhuongThucThanhToan tinyint NULL,
    MaSoThue char(100) NULL,
    ThongTinThue nvarchar(250) NULL,
    GhiChu nvarchar(100) NULL,
    PRIMARY KEY (MaHoaDon),
    FOREIGN KEY (MaKhachHang) REFERENCES tKhachHang (MaKhanhHang),
    FOREIGN KEY (MaNhanVien) REFERENCES tNhanVien (MaNhanVien)
);

-- Tạo bảng tChiTietHDB
CREATE TABLE tChiTietHDB (
    MaHoaDon INT  NOT NULL,
    MaSP INT NOT NULL,
    SoLuongBan int NULL,
    DonGiaBan money NULL,
    GiamGia float NULL,
    GhiChu nvarchar(100) NULL,
    PRIMARY KEY (MaHoaDon, MaSP),
    FOREIGN KEY (MaHoaDon) REFERENCES tHoaDonBan (MaHoaDon),
    FOREIGN KEY (MaSP) REFERENCES tDanhMucSP (MaSP)
);
CREATE TABLE tGioHang (
    MaKhachHang INT,
    MaSP INT PRIMARY KEY,
    SoLuong INT,
    GiaBan DECIMAL(10, 2),
    CONSTRAINT FK_GioHang_KhachHang FOREIGN KEY (MaKhachHang) REFERENCES tKhachHang(MaKhanhHang),
    CONSTRAINT FK_GioHang_DanhMucSP FOREIGN KEY (MaSP) REFERENCES tDanhMucSP(MaSP)
);





INSERT INTO tChatLieu (MaChatLieu, ChatLieu)
VALUES
    ('CL1', N'Bạc'),
    ('CL2', N'Nhựa'),
    ('CL3', N'Thép không gỉ'),
    ('CL4', N'Gốm sứ'),
    ('CL5', N'Kim loại mạ vàng');
 
INSERT INTO tLoaiSP (MaLoai, Loai,TenFileAnh)
VALUES
    ('LSP1', N'Đồng hồ nam',N'nam.webp'),
    ('LSP2', N'Đồng hồ nữ',N'nu.jpg'),
    ('LSP3', N'Đồng hồ cơ',N'co.webp'),
    ('LSP4', N'Đồng hồ điện tử',N'dientu.webp'),
    ('LSP5', N'Đồng hồ thông minh',N'thongminh.webp');
    -- Thêm các dòng dữ liệu khác ở đây

INSERT INTO tQuocGia (MaNuoc, TenNuoc)
VALUES
    ('QG1', N'Mỹ'),
    ('QG2', N'Nga'),
    ('QG3', N'Đức'),
    ('QG4', N'Pháp'),
    ('QG5', N'Ý'),
	('QG6', N'Hồng Kông');



INSERT INTO tHangSX (MaHangSX, HangSX, MaNuocThuongHieu)
VALUES
    ('HSX1', N'Apple', 'QG2'),
    ('HSX2', N'Samsung', 'QG2'),
	 ('HSX3', N'Garmin', 'QG5'),
    ('HSX4', N'Fossil', 'QG6'),
    ('HSX5', N'Citizen', 'QG3'),
    ('HSX6', N'Rolex', 'QG5');
INSERT INTO tKichThuoc (MaKichThuoc, KichThuoc)
VALUES
    ('KT1', N'42mm'),
    ('KT2', N'46mm'),
	('KT3', N'40mm'),
    ('KT4', N'44mm'),
    ('KT5', N'38mm');

INSERT INTO tMauSac (MaMauSac, TenMauSac)
VALUES
   ('MS1', N'Ánh Kim'),
    ('MS2', N'Trắng'),
    ('MS3', N'Bạc'),
    ('MS4', N'Đen'),
	 ('MS5', N'Xám');

INSERT INTO tLoaiDT(MaDT, TenLoai)
VALUES
    ('DT1', N'Kết nối internet'),
	('DT2', N'Cảm ứng'),
    ('DT3', N'Chống nước'),
    ('DT4', N'Đo nhịp tim'),
	('DT5', N'Bluetooth');



INSERT INTO tDanhMucSP ( TenSP, MaChatLieu, MaHangSX, MaNuocSX, MaDacTinh, ThoiGianBaoHanh, GioiThieuSP, ChietKhau, MaLoai, MaDT, AnhDaiDien, GiaNhoNhat, GiaLonNhat)
VALUES
    ( N'Đồng Hồ Olym Pianus', 'CL2', 'HSX3', 'QG3', 'DT3', 1, N'Ngay từ cái nhìn đầu tiên, Olym Pianus OP990-45ADGS-GL-X mặt xanh mang hơi thở tiểu Hublot đã ghi dấu ấn tượng với giới mộ điệu. Mặc dù có size mặt 42mm khá lớn nhưng dây cao su mềm, kích cỡ vừa phải khiến sản phẩm vẫn tạo ra sự gọn gàng trên cổ tay 15 - 18cm của nam giới', 0.15, 'LSP1', 'DT2', 'SP_1.webp', 150000000, 300000000),
    ( N'Đồng Hồ Olym Pianus', 'CL1', 'HSX4', 'QG4', 'DT4', 1, N'Dây đeo cao su của mẫu sản phẩm Olym Pianus có lợi thế là chịu được áp lực cao, chống nước tốt hơn hẳn dây kim loại và dây da nên rất phù hợp để những anh em nào theo đuổi phong cách năng động, trẻ trung sử dụng. Sau hơn 60 năm cải tiến (kể từ khi dây cao su đồng hồ trở thành xu hướng từ những năm 1960 của thế kỷ 20), giờ đây người dùng có thể yên tâm về mức độ bền bỉ, êm ái và thoáng khí của chất liệu này.', 0.1, 'LSP1', 'DT2', 'SP_2.webp', 10300000, 2500000),
    ( N'Đồng Hồ Citizen', 'CL4', 'HSX1', 'QG1', 'DT5', 2, N'Cách nhà sản xuất chọn tông đen chủ đạo cho mặt dial bên dưới để làm nổi bật các chi tiết mạ vàng phía trên được cho là một nước cờ cực kỳ thông minh. Chiếc đồng hồ bỗng chốc nâng tầm diện mạo sang trọng và trở nên thu hút nhờ những nét chấm phá đặc sắc từ bộ kim, cọc số và vành bezel mạ vàng thời trang.', 0.05, 'LSP1', 'DT5', 'SP_3.webp', 5000000, 10000000),
    ( N'Đồng Hồ Casio  EFV-600L-2AVUDF', 'CL3', 'HSX6', 'QG6', 'DT6', 2, N'Casio là một thương hiệu đồng hồ của Nhật Bản khai sinh năm 1946. Thương hiệu do ông Tadao Kashio sáng lập. Các dòng nổi bật của Casio phải kể đến như “G - Shock, Baby - G, Casio MTP,...”', 0.07, 'LSP1', 'DT1', 'SP_4.webp', 3000000, 6000000),
    ( N'Đồng Hồ Casio MTP-1375L-1AVDF', 'CL1', 'HSX3', 'QG3', 'DT3', 1, N'Anh em có niềm đam mê với các môn thể thao nhưng ngại dùng đồng hồ nhiều tính năng phức tạp và giá thành cao sẽ được thỏa mãn với model MTP-1375L-1AVDF. Phụ kiện đeo tay này “cân” được mọi phong cách và đảm bảo độ bền “khủng” đến mức khó tin.', 0.12, 'LSP1', 'DT3', 'SP_5.webp', 180000, 280000),

    ( N'Đồng Hồ Tissot', 'CL2', 'HSX4', 'QG4', 'DT4', 1, N'Phiên bản đồng hồ Tissot nữ dây da trơn và mặt dial màu trắng phối cùng vỏ case RoseGold mạ PVD thời thượng tạo nên vẻ đẹp nổi bật, thu hút. Kích thước size mặt 35mm, độ dày 9.4mm của chiếc T050.207.37.017.04 này vô cùng vừa với cổ tay nữ giới từ 15 - 17cm. ', 0.08, 'LSP2', 'DT4', 'SP_6.webp', 120000, 220000),
    ( N'Đồng Hồ Tissot T050.207.37.017.05', 'CL4', 'HSX2', 'QG2', 'DT5', 2, N'- Các dòng sản phẩm tiêu biểu: “Tissot Prx, Tissot Le Locle, Tissot Luxury, Tissot Chemin Des Tourelles, Tissot 18K Gold, Tissot T-Wave…', 0.05, 'LSP2', 'DT5', 'SP_7.webp', 5000000, 1000000),

    ( N'Đồng Hồ Orient RA-AA0B02R19B ', 'CL3', 'HSX3', 'QG6', 'DT6', 2, N'Được ra mắt lần đầu vào những năm 70, Orient SK mặt lửa với thiết kế góc cạnh, mạnh mẽ, dày dặn, chắc chắn đã chinh phục được mọi thế hệ ở thời điểm bấy giờ, đặc biệt là những thành phần thuộc tầng lớp thượng lưu. Tuy nhiên sau đó siêu phẩm này đã bị ngừng sản xuất và mãi đến năm 2015, sản phẩm bất ngờ được Orient “hồi sinh” với thiết kế tương tự bản 1970.', 0.07, 'LSP3', 'DT2', 'SP_8.webp', 3000000, 6000000),
	( N'Đồng Hồ Olym Pionus', 'CL2', 'HSX3', 'QG3', 'DT3', 1, N'Ngay từ cái nhìn đầu tiên, Olym Pianus OP990-45ADGS-GL-X mặt xanh mang hơi thở tiểu Hublot đã ghi dấu ấn tượng với giới mộ điệu. Mặc dù có size mặt 42mm khá lớn nhưng dây cao su mềm, kích cỡ vừa phải khiến sản phẩm vẫn tạo ra sự gọn gàng trên cổ tay 15 - 18cm của nam giới', 0.15, 'LSP3', 'DT2', 'SP_9.webp', 180000000, 300000000),
    ( N'Đồng Hồ GlAm Pianus', 'CL1', 'HSX4', 'QG4', 'DT4', 1, N'Dây đeo cao su của mẫu sản phẩm Olym Pianus có lợi thế là chịu được áp lực cao, chống nước tốt hơn hẳn dây kim loại và dây da nên rất phù hợp để những anh em nào theo đuổi phong cách năng động, trẻ trung sử dụng. Sau hơn 60 năm cải tiến (kể từ khi dây cao su đồng hồ trở thành xu hướng từ những năm 1960 của thế kỷ 20), giờ đây người dùng có thể yên tâm về mức độ bền bỉ, êm ái và thoáng khí của chất liệu này.', 0.1, 'LSP3', 'DT2', 'SP_9.webp', 12300000, 35000000),
    ( N'Đồng Hồ Elegant Masterpiece', 'CL4', 'HSX1', 'QG1', 'DT5', 2, N'Cách nhà sản xuất chọn tông đen chủ đạo cho mặt dial bên dưới để làm nổi bật các chi tiết mạ vàng phía trên được cho là một nước cờ cực kỳ thông minh. Chiếc đồng hồ bỗng chốc nâng tầm diện mạo sang trọng và trở nên thu hút nhờ những nét chấm phá đặc sắc từ bộ kim, cọc số và vành bezel mạ vàng thời trang.', 0.05, 'LSP3', 'DT5', 'SP_11.webp', 34000000, 54000000),
    ( N'Đồng Hồ Timeless Classic', 'CL3', 'HSX6', 'QG6', 'DT6', 2, N'Casio là một thương hiệu đồng hồ của Nhật Bản khai sinh năm 1946. Thương hiệu do ông Tadao Kashio sáng lập. Các dòng nổi bật của Casio phải kể đến như “G - Shock, Baby - G, Casio MTP,...”', 0.07, 'LSP3', 'DT1', 'SP_12.webp', 3000000, 6000000),


    ( N'Đồng Hồ Casio G-Shock GW-9400-1', 'CL1', 'HSX3', 'QG3', 'DT3', 1, N'Anh em có niềm đam mê với các môn thể thao nhưng ngại dùng đồng hồ nhiều tính năng phức tạp và giá thành cao sẽ được thỏa mãn với model MTP-1375L-1AVDF. Phụ kiện đeo tay này “cân” được mọi phong cách và đảm bảo độ bền “khủng” đến mức khó tin.', 0.12, 'LSP4', 'DT3', 'SP_13.webp', 1800000, 2800000),
    ( N'Đồng Hồ Casio Edifice EQB-900D-1A', 'CL2', 'HSX4', 'QG4', 'DT4', 1, N'Phiên bản đồng hồ Tissot nữ dây da trơn và mặt dial màu trắng phối cùng vỏ case RoseGold mạ PVD thời thượng tạo nên vẻ đẹp nổi bật, thu hút. Kích thước size mặt 35mm, độ dày 9.4mm của chiếc T050.207.37.017.04 này vô cùng vừa với cổ tay nữ giới từ 15 - 17cm. ', 0.08, 'LSP4', 'DT4', 'SP_14.webp', 1200000, 2200000),
    ( N'Đồng Hồ Casio Baby-G BGA-180-4B2', 'CL4', 'HSX2', 'QG2', 'DT5', 2, N'- Các dòng sản phẩm tiêu biểu: “Tissot Prx, Tissot Le Locle, Tissot Luxury, Tissot Chemin Des Tourelles, Tissot 18K Gold, Tissot T-Wave…', 0.05, 'LSP4', 'DT5', 'SP_15.webp', 50000000, 10000000),
    ( N'Đồng Hồ Casio Pro Trek PRW-3500-1 ', 'CL3', 'HSX3', 'QG6', 'DT6', 2, N'Được ra mắt lần đầu vào những năm 70, Orient SK mặt lửa với thiết kế góc cạnh, mạnh mẽ, dày dặn, chắc chắn đã chinh phục được mọi thế hệ ở thời điểm bấy giờ, đặc biệt là những thành phần thuộc tầng lớp thượng lưu. Tuy nhiên sau đó siêu phẩm này đã bị ngừng sản xuất và mãi đến năm 2015, sản phẩm bất ngờ được Orient “hồi sinh” với thiết kế tương tự bản 1970.', 0.07, 'LSP4', 'DT2', 'SP_15.webp', 30000000, 60000000),
	( N'Đồng Hồ Casio Vintage Collection A168WEGB-1BVT', 'CL2', 'HSX3', 'QG3', 'DT3', 1, N'Ngay từ cái nhìn đầu tiên, Olym Pianus OP990-45ADGS-GL-X mặt xanh mang hơi thở tiểu Hublot đã ghi dấu ấn tượng với giới mộ điệu. Mặc dù có size mặt 42mm khá lớn nhưng dây cao su mềm, kích cỡ vừa phải khiến sản phẩm vẫn tạo ra sự gọn gàng trên cổ tay 15 - 18cm của nam giới', 0.15, 'LSP4', 'DT2', 'SP_17.webp', 180000000, 300000000),
    ( N'Đồng Hồ Casio World Time AE1200WH-1A', 'CL1', 'HSX4', 'QG4', 'DT4', 1, N'Dây đeo cao su của mẫu sản phẩm Olym Pianus có lợi thế là chịu được áp lực cao, chống nước tốt hơn hẳn dây kim loại và dây da nên rất phù hợp để những anh em nào theo đuổi phong cách năng động, trẻ trung sử dụng. Sau hơn 60 năm cải tiến (kể từ khi dây cao su đồng hồ trở thành xu hướng từ những năm 1960 của thế kỷ 20), giờ đây người dùng có thể yên tâm về mức độ bền bỉ, êm ái và thoáng khí của chất liệu này.', 0.1, 'LSP4', 'DT2', 'SP_18.webp', 12300000, 35000000),
    ( N'Đồng Hồ Casio Illuminator LA680WGA-9', 'CL4', 'HSX1', 'QG1', 'DT5', 2, N'Cách nhà sản xuất chọn tông đen chủ đạo cho mặt dial bên dưới để làm nổi bật các chi tiết mạ vàng phía trên được cho là một nước cờ cực kỳ thông minh. Chiếc đồng hồ bỗng chốc nâng tầm diện mạo sang trọng và trở nên thu hút nhờ những nét chấm phá đặc sắc từ bộ kim, cọc số và vành bezel mạ vàng thời trang.', 0.05, 'LSP4', 'DT5', 'SP_19.webp', 34000000, 54000000),
    ( N'Đồng Hồ Casio Youth Series LRW-200H-4E2VDF', 'CL3', 'HSX6', 'QG6', 'DT6', 2, N'Casio là một thương hiệu đồng hồ của Nhật Bản khai sinh năm 1946. Thương hiệu do ông Tadao Kashio sáng lập. Các dòng nổi bật của Casio phải kể đến như “G - Shock, Baby - G, Casio MTP,...”', 0.07, 'LSP4', 'DT1', 'SP_20.webp', 3000000, 6000000),


    ( N'Đồng Hồ Fashion Forward', 'CL1', 'HSX3', 'QG3', 'DT3', 1, N'Anh em có niềm đam mê với các môn thể thao nhưng ngại dùng đồng hồ nhiều tính năng phức tạp và giá thành cao sẽ được thỏa mãn với model MTP-1375L-1AVDF. Phụ kiện đeo tay này “cân” được mọi phong cách và đảm bảo độ bền “khủng” đến mức khó tin.', 0.12, 'LSP5', 'DT3', 'SP_21.webp', 1800000, 2800000),
    ( N'Đồng Hồ Retro Revival', 'CL2', 'HSX4', 'QG4', 'DT4', 1, N'Phiên bản đồng hồ Tissot nữ dây da trơn và mặt dial màu trắng phối cùng vỏ case RoseGold mạ PVD thời thượng tạo nên vẻ đẹp nổi bật, thu hút. Kích thước size mặt 35mm, độ dày 9.4mm của chiếc T050.207.37.017.04 này vô cùng vừa với cổ tay nữ giới từ 15 - 17cm. ', 0.08, 'LSP5', 'DT4', 'SP_22.webp', 1200000, 2200000),
    ( N'Đồng Hồ Modern Minimalist', 'CL4', 'HSX2', 'QG2', 'DT5', 2, N'- Các dòng sản phẩm tiêu biểu: “Tissot Prx, Tissot Le Locle, Tissot Luxury, Tissot Chemin Des Tourelles, Tissot 18K Gold, Tissot T-Wave…', 0.05, 'LSP5', 'DT5', 'SP_23.webp', 50000000, 10000000),
    ( N'Đồng Hồ Vintage Charm ', 'CL3', 'HSX3', 'QG6', 'DT6', 2, N'Được ra mắt lần đầu vào những năm 70, Orient SK mặt lửa với thiết kế góc cạnh, mạnh mẽ, dày dặn, chắc chắn đã chinh phục được mọi thế hệ ở thời điểm bấy giờ, đặc biệt là những thành phần thuộc tầng lớp thượng lưu. Tuy nhiên sau đó siêu phẩm này đã bị ngừng sản xuất và mãi đến năm 2015, sản phẩm bất ngờ được Orient “hồi sinh” với thiết kế tương tự bản 1970.', 0.07, 'LSP5', 'DT2', 'SP_24.webp', 30000000, 60000000),
    ( N'Đồng Hồ Tech Enthusiast', 'CL1', 'HSX3', 'QG3', 'DT3', 1, N'Anh em có niềm đam mê với các môn thể thao nhưng ngại dùng đồng hồ nhiều tính năng phức tạp và giá thành cao sẽ được thỏa mãn với model MTP-1375L-1AVDF. Phụ kiện đeo tay này “cân” được mọi phong cách và đảm bảo độ bền “khủng” đến mức khó tin.', 0.12, 'LSP5', 'DT3', 'SP_25.webp', 1800000, 2800000),

    ( N'Đồng Hồ Trendsetter', 'CL2', 'HSX4', 'QG4', 'DT4', 1, N'Phiên bản đồng hồ Tissot nữ dây da trơn và mặt dial màu trắng phối cùng vỏ case RoseGold mạ PVD thời thượng tạo nên vẻ đẹp nổi bật, thu hút. Kích thước size mặt 35mm, độ dày 9.4mm của chiếc T050.207.37.017.04 này vô cùng vừa với cổ tay nữ giới từ 15 - 17cm. ', 0.08, 'LSP2', 'DT4', 'SP_26.webp', 1200000, 2200000),
    ( N'Đồng Hồ Marine Navigator', 'CL4', 'HSX2', 'QG2', 'DT5', 2, N'- Các dòng sản phẩm tiêu biểu: “Tissot Prx, Tissot Le Locle, Tissot Luxury, Tissot Chemin Des Tourelles, Tissot 18K Gold, Tissot T-Wave…', 0.05, 'LSP2', 'DT5', 'SP_27.webp', 50000000, 10000000),
    ( N'Đồng Hồ Aviation Pioneer ', 'CL3', 'HSX3', 'QG6', 'DT6', 2, N'Được ra mắt lần đầu vào những năm 70, Orient SK mặt lửa với thiết kế góc cạnh, mạnh mẽ, dày dặn, chắc chắn đã chinh phục được mọi thế hệ ở thời điểm bấy giờ, đặc biệt là những thành phần thuộc tầng lớp thượng lưu. Tuy nhiên sau đó siêu phẩm này đã bị ngừng sản xuất và mãi đến năm 2015, sản phẩm bất ngờ được Orient “hồi sinh” với thiết kế tương tự bản 1970.', 0.07, 'LSP2', 'DT2', 'SP_28.webp', 30000000, 60000000),
	( N'Đồng Hồ Classic Heritage', 'CL2', 'HSX3', 'QG3', 'DT3', 1, N'Ngay từ cái nhìn đầu tiên, Olym Pianus OP990-45ADGS-GL-X mặt xanh mang hơi thở tiểu Hublot đã ghi dấu ấn tượng với giới mộ điệu. Mặc dù có size mặt 42mm khá lớn nhưng dây cao su mềm, kích cỡ vừa phải khiến sản phẩm vẫn tạo ra sự gọn gàng trên cổ tay 15 - 18cm của nam giới', 0.15, 'LSP2', 'DT2', 'SP_29.webp', 180000000, 300000000);

   


INSERT INTO tAnhSP (MaSP, TenFileAnh)
VALUES
    (1, 'SP_1_1.webp'),
    (1, 'SP_1_2.webp'),
    (1, 'SP_1_3.webp'),
    (1, 'SP_1_4.webp'),
    (2, 'SP_2_1.webp'),
    (2, 'SP_2_2.webp'),
    (2, 'SP_2_3.webp'),
    (2, 'SP_2_4.webp'),
    (3, 'SP_3_1.webp'),
    (3, 'SP_3_2.webp'),
    (3, 'SP_3_3.webp'),
    (3, 'SP_3_4.webp'),
    (4, 'SP_4_1.webp'),
    (4, 'SP_4_2.webp'),
    (4, 'SP_4_3.webp'),
    (4, 'SP_4_4.webp'),
    (5, 'SP_5_1.webp'),
    (5, 'SP_5_2.webp'),
    (5, 'SP_5_3.webp'),
    (5, 'SP_5_4.webp'),
	(6, 'SP_6_1.webp'),
    (6, 'SP_6_2.webp'),
    (6, 'SP_6_3.webp'),
    (6, 'SP_6_4.webp'),
    (7, 'SP_7_1.webp'),
    (7, 'SP_7_2.webp'),
    (7, 'SP_7_3.webp'),
    (7, 'SP_7_4.webp'),
    (8, 'SP_8_1.webp'),
    (8, 'SP_8_2.webp'),
    (8, 'SP_8_3.webp'),
    (8, 'SP_8_4.webp'),
    (9, 'SP_9_1.webp'),
    (9, 'SP_9_2.webp'),
    (9, 'SP_9_3.webp'),
    (9, 'SP_9_4.webp'),
    (10, 'SP_10_1.webp'),
    (10, 'SP_10_2.webp'),
    (10, 'SP_10_3.webp'),
    (10, 'SP_10_4.webp'),
    (11, 'SP_11_1.webp'),
    (11, 'SP_11_2.webp'),
    (11, 'SP_11_3.webp'),
    (11, 'SP_11_4.webp'),
    (12, 'SP_12_1.webp'),
    (12, 'SP_12_2.webp'),
    (12, 'SP_12_3.webp'),
    (12, 'SP_12_4.webp'),
    (13, 'SP_13_1.webp'),
    (13, 'SP_13_2.webp'),
    (13, 'SP_13_3.webp'),
    (13, 'SP_13_4.webp'),
    (14, 'SP_14_1.webp'),
    (14, 'SP_14_2.webp'),
    (14, 'SP_14_3.webp'),
    (14, 'SP_14_4.webp'),
    (15, 'SP_15_1.webp'),
    (15, 'SP_15_2.webp'),
    (15, 'SP_15_3.webp'),
    (15, 'SP_15_4.webp'),
    (16, 'SP_16_1.webp'),
    (16, 'SP_16_2.webp'),
    (16, 'SP_16_3.webp'),
    (16, 'SP_16_4.webp'),
    (17, 'SP_17_1.webp'),
    (17, 'SP_17_2.webp'),
    (17, 'SP_17_3.webp'),
    (17, 'SP_17_4.webp'),
    (18, 'SP_18_1.webp'),
    (18, 'SP_18_2.webp'),
    (18, 'SP_18_3.webp'),
    (18, 'SP_18_4.webp'),
    (19, 'SP_19_1.webp'),
    (19, 'SP_19_2.webp'),
    (19, 'SP_19_3.webp'),
    (19, 'SP_19_4.webp'),
    (20, 'SP_20_1.webp'),
    (20, 'SP_20_2.webp'),
    (20, 'SP_20_3.webp'),
    (20, 'SP_20_4.webp'),
	 (21, 'SP_21_1.webp'),
    (21, 'SP_21_2.webp'),
    (21, 'SP_21_3.webp'),
    (21, 'SP_21_4.webp'),
    (22, 'SP_22_1.webp'),
    (22, 'SP_22_2.webp'),
    (22, 'SP_22_3.webp'),
    (22, 'SP_22_4.webp'),
    (23, 'SP_23_1.webp'),
    (23, 'SP_23_2.webp'),
    (23, 'SP_23_3.webp'),
    (23, 'SP_23_4.webp'),
    (24, 'SP_24_1.webp'),
    (24, 'SP_24_2.webp'),
    (24, 'SP_24_3.jfif'),
    (24, 'SP_24_4.jfif'),
    (25, 'SP_25_1.webp'),
    (25, 'SP_25_2.webp'),
    (25, 'SP_25_3.webp'),
    (25, 'SP_25_4.webp'),
    (26, 'SP_26_1.webp'),
    (26, 'SP_26_2.webp'),
    (26, 'SP_26_3.webp'),
    (26, 'SP_26_4.webp'),
    (27, 'SP_27_1.webp'),
    (27, 'SP_27_2.webp'),
    (27, 'SP_27_3.webp'),
    (27, 'SP_27_4.webp'),
    (28, 'SP_28_1.webp'),
    (28, 'SP_28_2.webp'),
    (28, 'SP_28_3.webp'),
    (28, 'SP_28_4.webp'),
    (29, 'SP_29_1.webp'),
    (29, 'SP_29_2.webp'),
    (29, 'SP_29_3.webp'),
    (29, 'SP_29_4.webp');
   
  



 -- Thêm thông tin người dùng từ bảng khách hàng vào bảng tUser với LoaiUser bằng 1 (người dùng thường)
INSERT INTO tUser (username, password, LoaiUser)
VALUES
    ('NguyenVanA', '12345678', 1),
    ('TranThiB', '12345678', 1),
    ('LeThanhC', '12345678', 1),
    ('PhamThiD', '12345678', 1),
    ('HuynhVanE', '12345678', 1),
    ('BuiThiF', '12345678', 1),
    ('VoThiG', '12345678', 1),
    ('NguyenThanhH', '12345678', 1),
    ('TranVanI', '12345678', 1),
    ('NguyenThiK', '12345678', 1),
    ('LeThiL', '12345678', 1),
    ('PhamVanM', '12345678', 1),
    ('HuynhThiN', '12345678', 1),
    ('BuiVanO', '12345678', 1),
    ('VoVanP', '12345678', 1),
    ('NguyenThiQ', '12345678', 1),
    ('TranVanR', '12345678', 1),
    ('NguyenVanS', '12345678', 1),
    ('LeThiT', '12345678', 1),
    ('PhamVanU', '12345678', 1),
    ('HuynhThiV', '12345678', 1),
    ('BuiVanX', '12345678', 1),
    ('VoVanY', '12345678', 1),
    ('NguyenThiZ', '12345678', 1),
	('NguyenVanC', '12345678', 2),
    ('TranThiD', '12345678', 2),
    ('NguyenVanE', '12345678', 2),
    ('NguyenThiF', '12345678', 2),
    ('TranVanG', '12345678', 2),
    ('TranThiH', '12345678', 2),
    ('LeVanI', '12345678', 2),
    ('LeThiK', '12345678', 2),
    ('PhamVanL', '12345678', 2),
    ('PhamThiM', '12345678', 2),
	 ('HuynhVanN', '12345678', 2),
    ('HuynhThiO', '12345678', 2),
	 ('LeQuangVu', '12345678', 1),
    ('VuHuuTuy', '12345678', 1),
    ('NguyenThiThuUyen', '12345678', 1),
    ('DaoMinhQuang', '12345678', 1),
    ('LeVanTung', '12345678', 1);
  
	

 

INSERT INTO tKhachHang (username, TenKhachHang, NgaySinh, SoDienThoai, DiaChi, LoaiKhachHang, AnhDaiDien, GhiChu)
VALUES
    (N'NguyenVanA', N'Nguyễn Văn A', '1990-05-10', '0123456789', N'Hà Nội', 1, 'avatar1.jpg', N'Ghi chú cho KH1'),
    (N'TranThiB', N'Trần Thị B', '1988-07-15', '0987654321', N'Hồ Chí Minh', 2, 'avatar2.jpg', N'Ghi chú cho KH2'),
    (N'LeThanhC', N'Lê Thanh C', '1995-03-20', '0123456789', N'Hải Phòng', 1, 'avatar3.jpg', N'Ghi chú cho KH3'),
    (N'PhamThiD', N'Phạm Thị D', '1987-12-05', '0987654321', N'Cần Thơ', 2, 'avatar4.jpg', N'Ghi chú cho KH4'),
    (N'HuynhVanE', N'Huỳnh Văn E', '1992-09-15', '0123456789', N'Đà Nẵng', 1, 'avatar5.jpg', N'Ghi chú cho KH5'),
    (N'BuiThiF', N'Bùi Thị F', '1998-06-25', '0987654321', N'Nha Trang', 2, 'avatar6.jpg', N'Ghi chú cho KH6'),
    (N'VoThiG', N'Võ Thị G', '1993-04-12', '0123456789', N'Quy Nhơn', 1, 'avatar7.jpg', N'Ghi chú cho KH7'),
    (N'NguyenThanhH', N'Nguyễn Thanh H', '1986-11-30', '0987654321', N'Vũng Tàu', 2, 'avatar8.jpg', N'Ghi chú cho KH8'),
    (N'TranVanI', N'Trần Văn I', '1991-08-10', '0123456789', N'Hà Nội', 1, 'avatar9.jpg', N'Ghi chú cho KH9'),
    (N'NguyenThiK', N'Nguyễn Thị K', '1989-07-05', '0987654321', N'Hồ Chí Minh', 2, 'avatar10.jpg', N'Ghi chú cho KH10'),
    (N'LeThiL', N'Lê Thị L', '1997-03-20', '0123456789', N'Hải Phòng', 1, 'avatar11.jpg', N'Ghi chú cho KH11'),
    (N'PhamVanM', N'Phạm Văn M', '1985-12-05', '0987654321', N'Cần Thơ', 2, 'avatar12.jpg', N'Ghi chú cho KH12'),
    (N'HuynhThiN', N'Huỳnh Thị N', '1994-09-15', '0123456789', N'Đà Nẵng', 1, 'avatar13.jpg', N'Ghi chú cho KH13'),
    (N'BuivanO', N'Bùi Văn O', '1999-06-25', '0987654321', N'Nha Trang', 2, 'avatar14.jpg', N'Ghi chú cho KH14'),
    (N'VoVanP', N'Võ Văn P', '1990-04-12', '0123456789', N'Quy Nhơn', 1, 'avatar15.jpg', N'Ghi chú cho KH15'),
    (N'NguyenThiZ', N'Nguyễn Thị Z', '1987-11-30', '0987654321', N'Vũng Tàu', 2, 'avatar16.jpg', N'Ghi chú cho KH16'),
    (N'TranVanR', N'Trần Văn R', '1993-08-10', '0123456789', N'Hà Nội', 1, 'avatar17.jpg', N'Ghi chú cho KH17'),
    (N'NguyenVanS', N'Nguyễn Văn S', '1986-07-05', '0987654321', N'Hồ Chí Minh', 2, 'avatar18.jpg', N'Ghi chú cho KH18'),
    (N'LeThiT', N'Lê Thị T', '1996-03-20', '0123456789', N'Hải Phòng', 1, 'avatar19.jpg', N'Ghi chú cho KH19'),
    (N'PhamVanU', N'Phạm Văn U', '1984-12-05', '0987654321', N'Cần Thơ', 2, 'avatar20.jpg', N'Ghi chú cho KH20'),
    (N'HuynhThiV', N'Huỳnh Thị V', '1995-09-15', '0123456789', N'Đà Nẵng', 1, 'avatar21.jpg', N'Ghi chú cho KH21'),
    (N'BuiVanX', N'Bùi Văn X', '2000-06-25', '0987654321', N'Nha Trang', 2, 'avatar22.jpg', N'Ghi chú cho KH22'),
    (N'VoVanY', N'Võ Văn Y', '1992-04-12', '0123456789', N'Quy Nhơn', 1, 'avatar23.jpg', N'Ghi chú cho KH23'),
    (N'NguyenThiZ', N'Nguyễn Thị Z', '1987-11-30', '0987654321', N'Vũng Tàu', 2, 'avatar24.jpg', N'Ghi chú cho KH24');

INSERT INTO tNhanVien (username, TenNhanVien, GioiTinh, NgaySinh, SoDienThoai, DiaChi, ChucVu)
VALUES
    ('NguyenVanC', N'Nguyễn Văn C', N'Nam', '1993-03-03', '111111111', N'321 Đường XYZ, TP Hà Nội', N'Nhân viên kinh doanh'),
    ('TranThiD', N'Nguyễn Thị D', N'Nữ', '1990-04-04', '222222222', N'432 Đường ABC, TP HCM', N'Nhân viên bán hàng'),
    ('NguyenVanE', N'Nguyễn Văn E', N'Nam', '1995-05-05', '333333333', N'123 Đường PQR, TP Đà Nẵng', N'Nhân viên kinh doanh'),
    ('NguyenThiF', N'Nguyễn Thị F', N'Nữ', '1992-06-06', '444444444', N'234 Đường LMN, TP Hà Nội', N'Nhân viên bán hàng'),
    ('TranVanG', N'Trần Văn G', N'Nam', '1991-01-15', '555555555', N'345 Đường XYZ, TP Hồ Chí Minh', N'Nhân viên kinh doanh'),
    ('TranThiH', N'Trần Thị H', N'Nữ', '1989-02-25', '666666666', N'456 Đường ABC, TP Đà Nẵng', N'Nhân viên bán hàng'),
    ('LeVanI', N'Lê Văn I', N'Nam', '1987-03-30', '777777777', N'567 Đường LMN, TP Hà Nội', N'Nhân viên kinh doanh'),
    ('LeThiK', N'Lê Thị K', N'Nữ', '1993-08-10', '888888888', N'678 Đường XYZ, TP Hồ Chí Minh', N'Nhân viên bán hàng'),
    ('PhamVanL', N'Phạm Văn L', N'Nam', '1994-11-21', '999999999', N'789 Đường ABC, TP Đà Nẵng', N'Nhân viên kinh doanh'),
    ('PhamThiM', N'Phạm Thị M', N'Nữ', '1996-09-02', '1010101010', N'890 Đường LMN, TP Hà Nội', N'Nhân viên bán hàng'),
    ('HuynhVanN', N'Huỳnh Văn N', N'Nam', '1997-07-07', '111111110', N'123 Đường PQR, TP Đà Nẵng', N'Nhân viên kinh doanh'),
    ('HuynhThiO', N'Huỳnh Thị O', N'Nữ', '1998-08-08', '1212121212', N'234 Đường LMN, TP Hà Nội', N'Nhân viên bán hàng');
 


INSERT INTO tHoaDonBan (NgayHoaDon, MaKhachHang, MaNhanVien, TongTienHD, GiamGiaHD, PhuongThucThanhToan, MaSoThue, ThongTinThue, GhiChu)
VALUES
    ('2023-09-24 10:30:00', '3', '3', 4800, 0.2, 1, NULL, NULL, N'Hóa đơn mua hàng lần đầu'),
    ('2023-09-25 14:15:00', '4', '4', 9000, 0.15, 2, '123456', N'Thông tin thuế', N'Hóa đơn mua hàng VIP'),
    ('2023-09-29 14:30:00', '8', '4', 7500, 0.1, 2, '246810', N'Thông tin thuế 5', N'Hóa đơn mua hàng VIP lần 3'),
    ('2023-10-25 14:15:00', '4', '4', 9000, 0.15, 2, '123456', N'Thông tin thuế', N'Hóa đơn mua hàng VIP'),
    ('2023-10-26 16:45:00', '5', '3', 3200, 0.1, 1, '789012', N'Thông tin thuế 2', N'Hóa đơn mua hàng lần thứ 3'),
    ('2023-10-27 12:30:00', '6', '4', 6500, 0.08, 2, '345678', N'Thông tin thuế 3', N'Hóa đơn mua hàng VIP lần 2'),
    ('2023-10-26 16:45:00', '5', '3', 3200, 0.1, 1, '789012', N'Thông tin thuế 2', N'Hóa đơn mua hàng lần thứ 3'),
    ('2023-10-27 12:30:00', '6', '4', 6500, 0.08, 2, '345678', N'Thông tin thuế 3', N'Hóa đơn mua hàng VIP lần 2'),
    ('2023-10-28 09:15:00', '7', '3', 4200, 0.12, 1, '987654', N'Thông tin thuế 4', N'Hóa đơn mua hàng lần thứ 4'),
    ('2023-10-29 14:30:00', '8', '4', 7500, 0.1, 2, '246810', N'Thông tin thuế 5', N'Hóa đơn mua hàng VIP lần 3'),
    ('2023-10-30 11:45:00', '9', '3', 3000, 0.05, 1, '135792', N'Thông tin thuế 6', N'Hóa đơn mua hàng lần thứ 5'),
    ('2023-10-31 10:00:00', '10', '4', 8800, 0.15, 2, '654321', N'Thông tin thuế 7', N'Hóa đơn mua hàng VIP lần 4'),
    ('2023-11-01 09:15:00', '11', '3', 3600, 0.07, 1, '112233', N'Thông tin thuế 8', N'Hóa đơn mua hàng lần thứ 6'),
    ('2023-11-02 08:30:00', '12', '4', 6900, 0.09, 2, '445566', N'Thông tin thuế 9', N'Hóa đơn mua hàng VIP lần 5'),
    ('2023-11-03 14:45:00', '13', '3', 3900, 0.1, 1, '778899', N'Thông tin thuế 10', N'Hóa đơn mua hàng lần thứ 7'),
    ('2023-11-04 11:00:00', '14', '4', 8200, 0.13, 2, '001122', N'Thông tin thuế 11', N'Hóa đơn mua hàng VIP lần 6'),
    ('2023-12-05 10:15:00', '15', '3', 4800, 0.12, 1, '334455', N'Thông tin thuế 12', N'Hóa đơn mua hàng lần thứ 8'),
    ('2023-12-06 09:30:00', '16', '4', 7200, 0.11, 2, '667788', N'Thông tin thuế 13', N'Hóa đơn mua hàng VIP lần 7'),
    ('2023-12-07 08:45:00', '17', '3', 4100, 0.08, 1, '990011', N'Thông tin thuế 14', N'Hóa đơn mua hàng lần thứ 9'),
    ('2023-12-08 07:00:00', '18', '4', 7800, 0.09, 2, '223344', N'Thông tin thuế 15', N'Hóa đơn mua hàng VIP lần 8'),
    ('2023-11-09 13:15:00', '19', '3', 4300, 0.1, 1, '556677', N'Thông tin thuế 16', N'Hóa đơn mua hàng lần thứ 10'),
    ('2023-11-10 11:30:00', '20', '4', 7500, 0.11, 2, '889900', N'Thông tin thuế 17', N'Hóa đơn mua hàng VIP lần 9'),
    ('2023-11-11 10:45:00', '21', '3', 3900, 0.07, 1, '112233', N'Thông tin thuế 18', N'Hóa đơn mua hàng lần thứ 11'),
    ('2023-08-12 09:00:00', '22', '4', 8100, 0.1, 2, '445566', N'Thông tin thuế 19', N'Hóa đơn mua hàng VIP lần 10'),
    ('2023-08-13 08:15:00', '23', '3', 4500, 0.09, 1, '778899', N'Thông tin thuế 20', N'Hóa đơn mua hàng lần thứ 12'),
    ('2023-11-14 14:30:00', '24', '4', 7400, 0.08, 2, '001122', N'Thông tin thuế 21', N'Hóa đơn mua hàng VIP lần 11');

 
INSERT INTO tChiTietHDB (MaHoaDon, MaSP, SoLuongBan, DonGiaBan, GiamGia, GhiChu)
VALUES
    ('1', '1', 2, 1200, 0.1, N''),
    ('2', '2', 1, 900, 0.05, N''),
	('3', '3', 3, 200, 0.1, N''),
	('3', '1', 2, 1200, 0.1, N'Ghi chú sản phẩm 1 cho HĐ HD3'),
    ('3', '2', 1, 900, 0.05, N'Ghi chú sản phẩm 2 cho HĐ HD3'),
    ('4', '3', 3, 200, 0.1, N'Ghi chú sản phẩm 3 cho HĐ HD4'),
    ('4', '4', 2, 150, 0.05, N'Ghi chú sản phẩm 4 cho HĐ HD4'),
    ('5', '1', 2, 1200, 0.1, N'Ghi chú sản phẩm 1 cho HĐ HD5'),
    ('5', '2', 1, 900, 0.05, N'Ghi chú sản phẩm 2 cho HĐ HD5'),
    ('6', '3', 3, 200, 0.1, N'Ghi chú sản phẩm 3 cho HĐ HD6'),
    ('6', '4', 2, 150, 0.05, N'Ghi chú sản phẩm 4 cho HĐ HD6'),
    ('7', '1', 2, 1200, 0.1, N'Ghi chú sản phẩm 1 cho HĐ HD7'),
    ('7', '2', 1, 900, 0.05, N'Ghi chú sản phẩm 2 cho HĐ HD7'),
    ('8', '4', 2, 150, 0.05, N'Ghi chú sản phẩm 4 cho HĐ HD8'),
    ('9', '1', 2, 1200, 0.1, N'Ghi chú sản phẩm 1 cho HĐ HD9'),
    ('9', '2', 1, 900, 0.05, N'Ghi chú sản phẩm 2 cho HĐ HD9'),
    ('10', '3', 3, 200, 0.1, N'Ghi chú sản phẩm 3 cho HĐ HD10'),
    ('10', '4', 2, 150, 0.05, N'Ghi chú sản phẩm 4 cho HĐ HD10'),
    ('11', '1', 2, 1200, 0.1, N'Ghi chú sản phẩm 1 cho HĐ HD11'),
    ('11', '2', 1, 900, 0.05, N'Ghi chú sản phẩm 2 cho HĐ HD11'),
    ('12', '3', 3, 200, 0.1, N'Ghi chú sản phẩm 3 cho HĐ HD12'),
    ('12', '4', 2, 150, 0.05, N'Ghi chú sản phẩm 4 cho HĐ HD12'),
    ('13', '1', 2, 1200, 0.1, N'Ghi chú sản phẩm 1 cho HĐ HD13'),
    ('13', '2', 1, 900, 0.05, N'Ghi chú sản phẩm 2 cho HĐ HD13'),
    ('14', '3', 3, 200, 0.1, N'Ghi chú sản phẩm 3 cho HĐ HD14'),
    ('14', '4', 2, 150, 0.05, N'Ghi chú sản phẩm 4 cho HĐ HD14'),
    ('15', '1', 2, 1200, 0.1, N'Ghi chú sản phẩm 1 cho HĐ HD15'),
    ('15', '2', 1, 900, 0.05, N'Ghi chú sản phẩm 2 cho HĐ HD15'),
    ('16', '1', 2, 1200, 0.1, N'Ghi chú sản phẩm 1 cho HĐ HD16'),
    ('16', '2', 1, 900, 0.05, N'Ghi chú sản phẩm 2 cho HĐ HD16'),
    ('17', '3', 3, 200, 0.1, N'Ghi chú sản phẩm 3 cho HĐ HD17'),
    ('17', '4', 2, 150, 0.05, N'Ghi chú sản phẩm 4 cho HĐ HD17'),
    ('18', '1', 2, 1200, 0.1, N'Ghi chú sản phẩm 1 cho HĐ HD18'),
    ('18', '2', 1, 900, 0.05, N'Ghi chú sản phẩm 2 cho HĐ HD18'),
    ('19', '3', 3, 200, 0.1, N'Ghi chú sản phẩm 3 cho HĐ HD19'),
    ('19', '4', 2, 150, 0.05, N'Ghi chú sản phẩm 4 cho HĐ HD19'),
    ('20', '1', 2, 1200, 0.1, N'Ghi chú sản phẩm 1 cho HĐ HD20'),
    ('20', '2', 1, 900, 0.05, N'Ghi chú sản phẩm 2 cho HĐ HD20'),
    ('21', '3', 3, 200, 0.1, N'Ghi chú sản phẩm 3 cho HĐ HD21'),
    ('21', '4', 2, 150, 0.05, N'Ghi chú sản phẩm 4 cho HĐ HD21'),
    ('22', '1', 2, 1200, 0.1, N'Ghi chú sản phẩm 1 cho HĐ HD22'),
    ('22', '2', 1, 900, 0.05, N'Ghi chú sản phẩm 2 cho HĐ HD22'),
    ('23', '3', 3, 200, 0.1, N'Ghi chú sản phẩm 3 cho HĐ HD23'),
    ('23', '4', 2, 150, 0.05, N'Ghi chú sản phẩm 4 cho HĐ HD23'),
    ('24', '1', 2, 1200, 0.1, N'Ghi chú sản phẩm 1 cho HĐ HD24'),
    ('24', '2', 1, 900, 0.05, N'Ghi chú sản phẩm 2 cho HĐ HD24'),
    ('25', '3', 3, 200, 0.1, N'Ghi chú sản phẩm 3 cho HĐ HD25'),
    ('25', '4', 2, 150, 0.05, N'Ghi chú sản phẩm 4 cho HĐ HD25'),
    ('26', '1', 2, 1200, 0.1, N'Ghi chú sản phẩm 1 cho HĐ HD26'),
    ('26', '2', 1, 900, 0.05, N'Ghi chú sản phẩm 2 cho HĐ HD26');




