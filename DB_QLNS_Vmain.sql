-- Tạo CSDL
CREATE DATABASE QLNS
GO
-- Sử dụng CSDL
USE QLNS
GO

-- Thực hiện tạo bảng

--Bảng Nhân viên
CREATE TABLE NhanVien
(
    NhanVien_ID INT IDENTITY(1,1) PRIMARY KEY,
    NhanVien_HoTen NVARCHAR(50),
    NhanVien_SDT CHAR(10),
    NhanVien_CCCD CHAR(12),
    NhanVien_GioiTinh NVARCHAR(3),
    NhanVien_HinhAnh IMAGE,
    NhanVien_DiaChi NVARCHAR(50),
    NhanVien_NgaySinh DATE,
    NhanVien_ChucVu INT,
    NhanVien_PhongBan INT
);
GO



--Bảng Ứng lương
CREATE TABLE UngLuong
(
    UngLuong_ID INT PRIMARY KEY,
    UngLuong_Ngay INT,
    UngLuong_SoTien FLOAT,
    UngLuong_TrangThaiXoa BIT,
    UngLuong_GhiChu NVARCHAR(50),
    UngLuong_NhanVien INT,
    UngLuong_KyCong INT
);
GO

-- Bảng Hợp đồng
CREATE TABLE HopDong
(
    HopDong_SoHD INT IDENTITY(1,1) PRIMARY KEY,
    HopDong_NgayBatDau DATE,
    HopDong_NgayKetThuc DATE,
    HopDong_LanKy INT,
    HopDong_NoiDung NVARCHAR(50),
    HopDong_LuongCanBan FLOAT,
    HopDong_HeSoLuong INT,
    HopDong_NhanVien INT
);
GO
-- Bảng Hệ số lương
CREATE TABLE HeSoLuong
(
    HeSoLuong_ID INT PRIMARY KEY,
    HeSoLuong_Ten NVARCHAR(10) NOT NULL,
    HeSoLuong_GiaTri FLOAT
);
GO

CREATE TABLE KyCong
(
    KyCong_MaKyCong INT IDENTITY(1, 1) PRIMARY KEY,
    KyCong_Nam INT,
    KyCong_Thang INT,
    KyCong_SoNgayCong INT,
    KyCong_TrangThaiXoa BIT
);
GO

CREATE TABLE KyCongChiTiet
(
    KyCongChiTiet_NhanVien INT,
    KyCongChiTiet_KyCong INT,
    KyCongChiTiet_D1 VARCHAR(10),
    KyCongChiTiet_D2 VARCHAR(10),
    KyCongChiTiet_D3 VARCHAR(10),
    KyCongChiTiet_D4 VARCHAR(10),
    KyCongChiTiet_D5 VARCHAR(10),
    KyCongChiTiet_D6 VARCHAR(10),
    KyCongChiTiet_D7 VARCHAR(10),
    KyCongChiTiet_D8 VARCHAR(10),
    KyCongChiTiet_D9 VARCHAR(10),
    KyCongChiTiet_D10 VARCHAR(10),
    KyCongChiTiet_D11 VARCHAR(10),
    KyCongChiTiet_D12 VARCHAR(10),
    KyCongChiTiet_D13 VARCHAR(10),
    KyCongChiTiet_D14 VARCHAR(10),
    KyCongChiTiet_D15 VARCHAR(10),
    KyCongChiTiet_D16 VARCHAR(10),
    KyCongChiTiet_D17 VARCHAR(10),
    KyCongChiTiet_D18 VARCHAR(10),
    KyCongChiTiet_D19 VARCHAR(10),
    KyCongChiTiet_D20 VARCHAR(10),
    KyCongChiTiet_D21 VARCHAR(10),
    KyCongChiTiet_D22 VARCHAR(10),
    KyCongChiTiet_D23 VARCHAR(10),
    KyCongChiTiet_D24 VARCHAR(10),
    KyCongChiTiet_D25 VARCHAR(10),
    KyCongChiTiet_D26 VARCHAR(10),
    KyCongChiTiet_D27 VARCHAR(10),
    KyCongChiTiet_D28 VARCHAR(10),
    KyCongChiTiet_D29 VARCHAR(10),
    KyCongChiTiet_D30 VARCHAR(10),
    KyCongChiTiet_D31 VARCHAR(10),
    KyCongChiTiet_NgayNghi INT,
    KyCongChiTiet_CongChuNhat INT,
    KyCongChiTiet_TongNgayCong INT,
    CONSTRAINT PK_KyCongChiTiet PRIMARY KEY(KyCongChiTiet_NhanVien, KyCongChiTiet_KyCong)
);
GO

-- Bảng chấm công
CREATE TABLE ChamCong
(
    ChamCong_ID INT IDENTITY(1,1) PRIMARY KEY,
    ChamCong_Ngay INT,
    ChamCong_GioVao VARCHAR(50),
    ChamCong_GioRa VARCHAR(50),
    ChamCong_GhiChu NVARCHAR(255),
    ChamCong_NhanVien INT,
    ChamCong_KyCong INT
);
GO

CREATE TABLE BangLuong
(
    BangLuong_NhanVien INT,
    BangLuong_KyCong INT,
    BangLuong_LuongNgayThuong FLOAT,
    BangLuong_LuongNgayCN FLOAT,
    BangLuong_TangCa FLOAT,
    BangLuong_UngLuong FLOAT,
    BangLuong_PhuCap FLOAT,
    BangLuong_LuongNhanDuoc FLOAT,
    BangLuong_ThucLanh FLOAT,
    CONSTRAINT PK_BangLuong PRIMARY KEY(BangLuong_NhanVien, BangLuong_KyCong)
);
GO

-- Bảng loại tăng ca
CREATE TABLE LoaiTangCa
(
    LoaiTangCa_ID INT PRIMARY KEY,
    LoaiTangCa_TenLoai NVARCHAR(20),
    LoaiTangCa_HeSo FLOAT
);
GO

-- Bảng tăng ca
CREATE TABLE TangCa
(
    TangCa_ID INT IDENTITY(1,1) PRIMARY KEY,
    TangCa_NgayTangCa INT,
    TangCa_SoGio FLOAT,
    TangCa_NhanVien INT,
    TangCa_LoaiTangCa INT,
    TangCa_KyCong INT
);
GO

-- Bảng chức vụ
CREATE TABLE ChucVu
(
    ChucVu_ID INT PRIMARY KEY,
    ChucVu_TenCV NVARCHAR(50)
);
GO


-- Bảng phòng ban
CREATE TABLE PhongBan
(
    PhongBan_MaPB INT PRIMARY KEY,
    PhongBan_TenPB NVARCHAR(50),
    PhongBan_TruongPhong INT,
    PhongBan_TG_NhanChuc DATE,
);
GO

-- Bảng tài khoản
CREATE TABLE TaiKhoan
(
    TaiKhoan_SoTK VARCHAR(50) PRIMARY KEY,
    TaiKhoan_MatKhau VARCHAR(32),
    TaiKhoan_PhanQuyen INT,
    TaiKhoan_NhanVien INT
);
GO

-- Bảng Phân quyền
CREATE TABLE PhanQuyen
(
    PhanQuyen_ID INT PRIMARY KEY,
    PhanQuyen_TenQuyen NVARCHAR(20)
);
GO

---------------------------------- Thực hiện tạo Ràng buộc khóa ngoại ----------------------------------
-- Bảng nhân viên
ALTER TABLE NhanVien
ADD CONSTRAINT FK_ChucVuNhanVien FOREIGN KEY(NhanVien_ChucVu) REFERENCES ChucVu(ChucVu_ID)ON DELETE SET NULL ON UPDATE CASCADE;
ALTER TABLE NhanVien
ADD CONSTRAINT FK_PhongBanNhanVien FOREIGN KEY(NhanVien_PhongBan) REFERENCES PhongBan(PhongBan_MaPB) ON DELETE SET NULL;
-- Bảng phòng ban
ALTER TABLE PhongBan
ADD CONSTRAINT FK_NhanVienPhongBan FOREIGN KEY(PhongBan_TruongPhong) REFERENCES NhanVien(NhanVien_ID) ON DELETE SET NULL;

-- Bảng Ứng lương
ALTER TABLE UngLuong
ADD CONSTRAINT FK_NhanVienUngLuong FOREIGN KEY(UngLuong_NhanVien) REFERENCES NhanVien(NhanVien_ID) ON DELETE SET NULL;
ALTER TABLE UngLuong
ADD CONSTRAINT FK_KyCongUngLuong FOREIGN KEY(UngLuong_KyCong) REFERENCES KyCong(KyCong_MaKyCong) ON DELETE SET NULL;
-- Bảng Hợp đồng
ALTER TABLE HopDong
ADD CONSTRAINT FK_HeSoLuongHopDong FOREIGN KEY(HopDong_HeSoLuong) REFERENCES HeSoLuong(HeSoLuong_ID) ON DELETE SET NULL ON UPDATE CASCADE;
ALTER TABLE HopDong
ADD CONSTRAINT FK_NhanVienHopDong FOREIGN KEY(HopDong_NhanVien) REFERENCES NhanVien(NhanVien_ID) ON DELETE SET NULL;
-- Kỳ công chi tiết
ALTER TABLE KyCongChiTiet
ADD CONSTRAINT FK_NhanVienKyCongChiTiet FOREIGN KEY(KyCongChiTiet_NhanVien) REFERENCES NhanVien(NhanVien_ID) ON DELETE CASCADE;
ALTER TABLE KyCongChiTiet
ADD CONSTRAINT FK_KyCongKyCongChiTiet FOREIGN KEY(KyCongChiTiet_KyCong) REFERENCES KyCong(KyCong_MaKyCong) ON DELETE CASCADE;
-- Bảng Lương
ALTER TABLE BangLuong
ADD CONSTRAINT FK_NhanVienBangLuong FOREIGN KEY(BangLuong_NhanVien) REFERENCES NhanVien(NhanVien_ID) ON DELETE CASCADE;
ALTER TABLE BangLuong
ADD CONSTRAINT FK_KyCongBangLuong FOREIGN KEY(BangLuong_KyCong) REFERENCES KyCong(KyCong_MaKyCong) ON DELETE CASCADE;
-- Bảng Chấm công
ALTER TABLE ChamCong
ADD CONSTRAINT FK_NhanVienChamCong FOREIGN KEY(ChamCong_NhanVien) REFERENCES NhanVien(NhanVien_ID) ON DELETE CASCADE;
ALTER TABLE ChamCong
ADD CONSTRAINT FK_KyCongChamCong FOREIGN KEY(ChamCong_KyCong) REFERENCES KyCong(KyCong_MaKyCong) ON DELETE CASCADE;
-- Bảng tăng ca
ALTER TABLE TangCa
ADD CONSTRAINT FK_NhanVienTangCa FOREIGN KEY(TangCa_NhanVien) REFERENCES NhanVien(NhanVien_ID) ON DELETE CASCADE;
ALTER TABLE TangCa
ADD CONSTRAINT FK_LoaiTangCaTangCa FOREIGN KEY(TangCa_LoaiTangCa) REFERENCES LoaiTangCa(LoaiTangCa_ID) ON DELETE SET NULL ON UPDATE CASCADE;
ALTER TABLE TangCa
ADD CONSTRAINT FK_KyCongTangCa FOREIGN KEY(TangCa_KyCong) REFERENCES KyCong(KyCong_MaKyCong) ON DELETE CASCADE;
-- Bảng tài khoản
ALTER TABLE TaiKhoan
ADD CONSTRAINT FK_NhanVienTaiKhoan FOREIGN KEY(TaiKhoan_NhanVien) REFERENCES NhanVien(NhanVien_ID) ON DELETE SET NULL;
ALTER TABLE TaiKhoan
ADD CONSTRAINT FK_PhanQuyenTaiKhoan FOREIGN KEY(TaiKhoan_PhanQuyen) REFERENCES PhanQuyen(PhanQuyen_ID) ON DELETE SET NULL ON UPDATE CASCADE;
GO

------------------------------------------- View -------------------------------------------

------------------------------------------- Trigger ----------------------------------------

-------------------------------------------  Data ------------------------------------------
--Bảng Hệ số lương
INSERT INTO HeSoLuong (HeSoLuong_ID, HeSoLuong_Ten, HeSoLuong_GiaTri)
VALUES
(1, N'Bậc 1', 1.07),
(2, N'Bậc 2', 1.13),
(3, N'Bậc 3', 1.19),
(4, N'Bậc 4', 2.42);
GO
-- Bảng kỳ công
INSERT INTO KyCong(KyCong_Nam, KyCong_Thang, KyCong_SoNgayCong, KyCong_TrangThaiXoa)
VALUES (2023, 3, 26, 0),
(2022, 7, 26, 0),
(2022, 8, 26, 0),
(2022, 9, 26, 0),
(2022, 10, 26, 0),
(2022, 11, 26, 0),
(2022, 12, 26, 0),
(2023, 1, 26, 0),
(2023, 2, 26, 0),
(2023, 3, 26, 0),
(2023, 4, 26, 0),
(2023, 5, 26, 0);
Go
-- Bảng kỳ công chi tiết
INSERT INTO KyCongChiTiet(KyCongChiTiet_NhanVien, KyCongChiTiet_KyCong, KyCongChiTiet_D1, KyCongChiTiet_D2, KyCongChiTiet_D3, KyCongChiTiet_D4,
KyCongChiTiet_D5, KyCongChiTiet_D6, KyCongChiTiet_D7 ,KyCongChiTiet_D8 ,KyCongChiTiet_D9,KyCongChiTiet_D10,KyCongChiTiet_D11 ,KyCongChiTiet_D12,
KyCongChiTiet_D13,KyCongChiTiet_D14,KyCongChiTiet_D15 ,KyCongChiTiet_D16,KyCongChiTiet_D17,KyCongChiTiet_D18,KyCongChiTiet_D19,KyCongChiTiet_D20,
KyCongChiTiet_D21, KyCongChiTiet_D22,KyCongChiTiet_D23, KyCongChiTiet_D24, KyCongChiTiet_D25,KyCongChiTiet_D26,KyCongChiTiet_D27,KyCongChiTiet_D28,
KyCongChiTiet_D29,KyCongChiTiet_D30,KyCongChiTiet_D31,KyCongChiTiet_NgayNghi, KyCongChiTiet_CongChuNhat, KyCongChiTiet_TongNgayCong)
VALUES
(1, 1, 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 0, 4, 31),
(1, 2, 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 0, 4, 31),
(1, 3, 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 0, 4, 31),
(1, 4,'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 0, 4, 31),
(1, 5, 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 0, 4, 31),
(1, 6, 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 0, 4, 31),
(1, 7,'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 0, 4, 31),
(1, 8, 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 0, 4, 31),
(1, 9, 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 0, 4, 31),
(1, 10, 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 0, 4, 31);
Go
-- Bảng chấm công
INSERT INTO ChamCong(ChamCong_Ngay, ChamCong_GioVao, ChamCong_GioRa, ChamCong_GhiChu, ChamCong_NhanVien, ChamCong_KyCong)
VALUES
    ('01', '08:00:00', '16:30:00', N'Làm việc bình thường', 1, 1),
    ('01', '08:30:00', '17:00:00', N'Đi muộn 30 phút', 1, 1),
    ('02', '08:00:00', '16:30:00', N'Làm việc bình thường', 1, 1),
    ('02', '08:30:00', '17:00:00', N'Đi muộn 30 phút', 1, 1),
    ('03', '08:00:00', '16:30:00', N'Làm việc bình thường', 1, 2),
    ('03', '08:30:00', '17:00:00', N'Đi muộn 30 phút', 1, 1),
    ('04', '08:00:00', '16:30:00', N'Làm việc bình thường', 1, 1),
    ('04', '08:30:00', '17:00:00', N'Đi muộn 30 phút', 1, 2),
    ('05', '08:00:00', '16:30:00', N'Làm việc bình thường', 1, 1),
    ('05', '08:30:00', '17:00:00', N'Đi muộn 30 phút', 1, 1);
Go

-- Bảng loại tăng ca
INSERT INTO dbo.LoaiTangCa
(
    LoaiTangCa_ID,
    LoaiTangCa_TenLoai,
    LoaiTangCa_HeSo
)
VALUES
(   1,    -- LoaiTangCa_ID - int
    N'Ngày Nghỉ', -- LoaiTangCa_TenLoai - nvarchar(20)
    2  -- LoaiTangCa_HeSo - float
    ),
(   2,    -- LoaiTangCa_ID - int
    N'Ngày Lễ', -- LoaiTangCa_TenLoai - nvarchar(20)
    3  -- LoaiTangCa_HeSo - float
    ),
(   3,    -- LoaiTangCa_ID - int
    N'Ca Tối', -- LoaiTangCa_TenLoai - nvarchar(20)
    1.5  -- LoaiTangCa_HeSo - float
    )