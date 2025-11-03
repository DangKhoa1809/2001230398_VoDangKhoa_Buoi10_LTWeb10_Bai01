--TẠO DATABASE QL_Sach--
CREATE DATABASE QL_Sach;

--DÙNG DATABASE QL_Sach--
USE QL_Sach;

--TẠO BẢNG tblKhachHang--
CREATE TABLE tblKhachHang (
	MaKhachHang INT IDENTITY(1, 1) PRIMARY KEY,
	TenKhachHang NVARCHAR(100),
	TaiKhoan NVARCHAR(50),
    	MatKhau NVARCHAR(50),
	DiaChi NVARCHAR(200),
	SoDienThoai VARCHAR(15)
);

---TẠO BẢNG tblSanPham--
CREATE TABLE tblSanPham (
	MaSanPham INT IDENTITY(1, 1) PRIMARY KEY,
	TenSanPham NVARCHAR(100),
	DonGia DECIMAL(18, 2),
	HinhAnh NVARCHAR(50),
	MoTa NVARCHAR(MAX),
	SoLuongTon INT
);

--TẠO BẢNG tblHoaDon--
CREATE TABLE tblHoaDon (
	MaHoaDon INT IDENTITY(1, 1) PRIMARY KEY,
	NgayHoaDon DATETIME,
	MaKhachHang INT,
	FOREIGN KEY (MaKhachHang) REFERENCES tblKhachHang(MaKhachHang)
);

--TẠO BẢNG tblChiTiet--
CREATE TABLE tblChiTiet (
	MaHoaDon INT,
	MaSanPham INT,
	SoLuong INT,
	PRIMARY KEY(MaHoaDon, MaSanPham),
	FOREIGN KEY (MaHoaDon) REFERENCES tblHoaDon(MaHoaDon),
	FOREIGN KEY (MaSanPham) REFERENCES tblSanPham(MaSanPham)
);

--NHẬP LIỆU BẢNG tblKhachHang--
INSERT INTO tblKhachHang (TenKhachHang, TaiKhoan, MatKhau, DiaChi, SoDienThoai) VALUES 
(N'Nguyễn Văn Trí', N'tri_nv', N'123456', N'Hà Nội', '0909123456'),
(N'Trần Thị Mai', N'mai_tt', N'238434', N'Đà Nẵng', '0912345678'),
(N'Lê Minh Châu', N'chau_lm', N'256156', N'Hồ Chí Minh', '0987654321');

--NHẬP LIỆU BẢNG tblSanPham--
INSERT INTO tblSanPham (TenSanPham, DonGia, HinhAnh, MoTa, SoLuongTon) VALUES
(N'Lẽ nào em không biết', 64200, 'lenaoemkobiet.jpg', N'Tiểu thuyết lãng mạn', 10),
(N'Đạo tình', 77000, 'daotinh.jpg', N'Truyện ngôn tình nổi tiếng', 20),
(N'Em là nhà', 58800, 'emlanha.jpg', N'Truyện hiện đại', 15),
(N'Yêu', 52200, 'yeu.jpg', N'Sách tình cảm', 30),
(N'Khu vườn ngôn từ', 71250, 'khuvuonngontinh.jpg', N'Truyện Nhật Bản', 10),
(N'Kỳ án ánh trăng', 115500, 'kyananhtrang.jpg', N'Tiểu thuyết trinh thám', 25),
(N'Người truyền ký ức', 49640, 'nguoitruyenkyuc.jpg', N'Tác phẩm giả tưởng nhân văn, kể về thế giới không còn cảm xúc', 12),
(N'Cuộc sống không giới hạn', 74000, 'cuocsongkogioihan.jpg', N'Sách truyền cảm hứng', 18);

--NHẬP LIỆU BẢNG tblHoaDon--
INSERT INTO tblHoaDon (NgayHoaDon, MaKhachHang) VALUES
('2025-10-01 14:30:00', 1),
('2025-10-05 09:45:00', 2),
('2025-10-10 20:15:00', 3);

--NHẬP LIỆU BẢNG tblChiTiet--
INSERT INTO tblChiTiet (MaHoaDon, MaSanPham, SoLuong) VALUES
(1, 1, 2),
(1, 4, 1),  
(2, 2, 1),  
(2, 7, 2), 
(3, 5, 1),  
(3, 8, 1);   

SELECT * FROM tblKhachHang;
SELECT * FROM tblSanPham;
SELECT * FROM tblHoaDon;
SELECT * FROM tblChiTiet;

ALTER TABLE tblHoaDon
ADD NgayGiao DATE;