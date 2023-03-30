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
    KyCongChiTiet_NgayNghi INT,
    KyCongChiTiet_CongChuNhat INT,
    KyCongChiTiet_NgayCongThucTe INT,
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
-- Bảng Ứng lương
CREATE VIEW DS_UngLuong AS
SELECT UngLuong_ID, UngLuong_Ngay, UngLuong_NhanVien, UngLuong_SoTien, UngLuong_GhiChu
FROM UngLuong
WHERE UngLuong_TrangThaiXoa = 0
GO

-- Bảng PhongBan
CREATE VIEW DS_Phongban AS
SELECT PhongBan_MaPB, PhongBan_TenPB
FROM PhongBan
GO

-- Bảng PhanQuyen
CREATE VIEW DS_Quyen AS
SELECT PhanQuyen_TenQuyen
FROM PhanQuyen
GO

-- Bảng TaiKhoan
CREATE VIEW DS_TaiKhoan AS
SELECT TaiKhoan_SoTK, TaiKhoan_MatKhau, TaiKhoan_NhanVien
FROM TaiKhoan
GO
-- Bảng Kỳ Công
CREATE VIEW DS_KyCong AS
SELECT KyCong_MaKyCong , KyCong_Nam ,KyCong_Thang ,KyCong_SoNgayCong 
FROM KyCong
WHERE KyCong_TrangThaiXoa = 0
GO

-- Bảng Châm Công
CREATE VIEW View_ChamCong AS
SELECT ChamCong_ID, ChamCong_GioVao, ChamCong_GioRa, ChamCong_Ngay, ChamCong_GhiChu ,ChamCong_NhanVien,ChamCong_KyCong
FROM ChamCong
GO
--Bảng Kỳ công Chi tiết
CREATE VIEW View_KyCongChiTiet AS
SELECT KyCongChiTiet_NhanVien, KyCongChiTiet_KyCong, KyCongChiTiet_D1, KyCongChiTiet_D2, KyCongChiTiet_D3, KyCongChiTiet_D4,
KyCongChiTiet_D5, KyCongChiTiet_D6, KyCongChiTiet_D7 ,KyCongChiTiet_D8 ,KyCongChiTiet_D9,KyCongChiTiet_D10,KyCongChiTiet_D11 ,KyCongChiTiet_D12,
KyCongChiTiet_D13,KyCongChiTiet_D14,KyCongChiTiet_D15 ,KyCongChiTiet_D16,KyCongChiTiet_D17,KyCongChiTiet_D18,KyCongChiTiet_D19,KyCongChiTiet_D20,
KyCongChiTiet_D21, KyCongChiTiet_D22,KyCongChiTiet_D23, KyCongChiTiet_D24, KyCongChiTiet_D25,KyCongChiTiet_D26,KyCongChiTiet_D27,KyCongChiTiet_D28,
KyCongChiTiet_D29,KyCongChiTiet_D30,KyCongChiTiet_D31,KyCongChiTiet_NgayNghi, KyCongChiTiet_CongChuNhat, KyCongChiTiet_TongNgayCong
FROM KyCongChiTiet
GO
--Bảng Kỳ Công Chấm Công
CREATE VIEW View_ChamCongKyCong AS
SELECT ChamCong.ChamCong_ID, ChamCong.ChamCong_NhanVien, ChamCong.ChamCong_GioVao, ChamCong.ChamCong_GioRa, ChamCong.ChamCong_Ngay, KyCong.KyCong_Thang, KyCong.KyCong_Nam
FROM ChamCong
JOIN KyCongChiTiet ON ChamCong.ChamCong_NhanVien = KyCongChiTiet.KyCongChiTiet_NhanVien AND ChamCong.ChamCong_KyCong = KyCongChiTiet.KyCongChiTiet_KyCong
JOIN KyCong ON KyCongChiTiet.KyCongChiTiet_KyCong = KyCong.KyCong_MaKyCong;
GO
------------------------------------------- Trigger ----------------------------------------
-- Bảng Ứng lương
CREATE TRIGGER TGR_UngLuong
ON UngLuong
INSTEAD OF INSERT
AS
BEGIN
  DECLARE @maxid int = 0
  SELECT @maxid = MAX(UngLuong_ID) FROM UngLuong
  IF @maxid IS NULL SET @maxid = 1;
  ELSE SET @maxid = @maxid + 1;
  INSERT INTO UngLuong (UngLuong_ID)
  VALUES(@maxid)
  UPDATE UngLuong
  SET UngLuong_Ngay = i.UngLuong_Ngay, UngLuong_SoTien=i.UngLuong_SoTien, UngLuong_TrangThaiXoa=i.UngLuong_TrangThaiXoa, UngLuong_GhiChu=i.UngLuong_GhiChu, UngLuong_NhanVien=i.UngLuong_NhanVien, UngLuong_KyCong=i.UngLuong_KyCong
  FROM inserted i
  WHERE UngLuong.UngLuong_ID = @maxid
  PRINT N'Đã thêm ứng lương có mã là: '+ CAST(@maxid AS VARCHAR)
END;
GO

-- Bảng PhongBan
CREATE TRIGGER TGR_PhongBan
On PhongBan
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @maxid int = 0
    SELECT @maxid = MAX(PhongBan_MaPB) FROM PhongBan
    IF @maxid IS NULL SET @maxid = 1
    ELSE SET @maxid = @maxid + 1
    INSERT INTO PhongBan (PhongBan_MaPB)
    VALUES (@maxid)
    UPDATE PhongBan
    SET PhongBan_TenPB = i.PhongBan_TenPB, PhongBan_TG_NhanChuc = i.PhongBan_TG_NhanChuc, PhongBan_TruongPhong = i.PhongBan_TruongPhong
    FROM inserted i
    WHERE PhongBan.PhongBan_MaPB = @maxid
    PRINT N'Đã thêm phòng ban có mã là: '+ CAST(@maxid AS VARCHAR)
END;
GO

-- Bảng PhanQuyen
CREATE TRIGGER TGR_PhanQuyen
On PhanQuyen
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @maxid int = 0
    SELECT @maxid = MAX(PhanQuyen_ID) FROM PhanQuyen
    IF @maxid IS NULL SET @maxid = 1
    ELSE SET @maxid = @maxid + 1
    INSERT INTO PhanQuyen (PhanQuyen_ID)
    VALUES(@maxid)
    UPDATE PhanQuyen
    SET PhanQuyen_TenQuyen = i.PhanQuyen_TenQuyen
    FROM inserted i
    WHERE PhanQuyen.PhanQuyen_ID = @maxid
    PRINT N'Đã thêm phân quyền có mã là: '+ CAST(@maxid AS VARCHAR)
END;
GO

-- Bảng TaiKhoan
CREATE TRIGGER TGR_TaiKhoan
On TaiKhoan
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @checkid int
    SELECT @checkid = i.TaiKhoan_SoTK FROM inserted i
    IF NOT EXISTS(SELECT * FROM TaiKhoan WHERE TaiKhoan_SoTK = @checkid)
    INSERT INTO TaiKhoan (TaiKhoan_SoTK, TaiKhoan_MatKhau, TaiKhoan_NhanVien, TaiKhoan_PhanQuyen)
    SELECT i.TaiKhoan_SoTK, (CONVERT(VARCHAR(32), HashBytes('MD5', i.TaiKhoan_MatKhau), 2)), i.TaiKhoan_NhanVien, i.TaiKhoan_PhanQuyen FROM inserted i
    ELSE
    PRINT N'Số tài khoản: '+ CAST(@checkid AS VARCHAR)+N' đã tồn tại.'
END;
GO
-- Kiểm tra xem tháng được truyền vào có đúng không
CREATE TRIGGER trg_Insert_KyCong
ON KyCong
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE inserted.KyCong_Thang < 1 OR inserted.KyCong_Thang > 12)
    BEGIN
        RAISERROR('Giá trị của KyCong_Thang phải nằm trong khoảng từ 1 đến 12', 16, 1)
        ROLLBACK TRANSACTION
    END
END
GO
-- Kiểm tra Ngày nghỉ và tổng ngày công
CREATE TRIGGER TR_KyCongChiTiet ON KyCongChiTiet
AFTER INSERT, UPDATE
AS
BEGIN
    -- Kiểm tra các giá trị mới của KyCongChiTiet
    IF EXISTS (
        SELECT *
        FROM inserted i
        INNER JOIN KyCong kc ON i.KyCongChiTiet_KyCong = kc.KyCong_MaKyCong
        WHERE i.KyCongChiTiet_NgayNghi >= 0
            AND i.KyCongChiTiet_TongNgayCong >= 0
            AND i.KyCongChiTiet_TongNgayCong <= kc.KyCong_SoNgayCong
    )
    BEGIN
        -- Nếu có giá trị không hợp lệ, rollback transaction và hiển thị thông báo lỗi
        RAISERROR('Giá trị không hợp lệ', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END
END
GO
--kiểm tra xem Ngày được truyền vào có đúng không
CREATE TRIGGER [TenTrigger]
ON [dbo].[ChamCong]
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT *
        FROM inserted
        WHERE ChamCong_Ngay < 1 OR ChamCong_Ngay > 31
    )
    BEGIN
        RAISERROR('Ngày chấm công không hợp lệ', 16, 1)
        ROLLBACK TRANSACTION
    END
END
GO
--Kiểm tra các giá trị giá trị các cột từ KyCongChiTiet_D1 đến KyCongChiTiet_D31 của bản ghi mới được thêm 
--hoặc cập nhật có nằm trong tập hợp giá trị ('X', 'V', 'CN') hay không. 
CREATE TRIGGER Trigger_KyCongChiTiet_KiemTraGiaTri
ON KyCongChiTiet
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT *
        FROM inserted
        WHERE NOT (
            inserted.KyCongChiTiet_D1 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D2 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D3 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D4 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D5 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D6 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D7 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D8 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D9 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D10 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D11 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D12 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D13 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D14 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D15 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D16 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D17 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D18 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D19 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D20 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D21 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D22 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D23 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D24 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D25 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D26 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D27 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D28 IN ('X', 'V', 'CN') AND
	    inserted.KyCongChiTiet_D29 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D30 IN ('X', 'V', 'CN') AND
            inserted.KyCongChiTiet_D31 IN ('X', 'V', 'CN') 
)
    )
    BEGIN
        -- Nếu có giá trị không hợp lệ, rollback transaction và hiển thị thông báo lỗi
        RAISERROR('Giá trị không hợp lệ', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;
END;
GO
-------------------------------------------  Data ------------------------------------------
--Bảng Hệ số lương
INSERT INTO HeSoLuong (HeSoLuong_ID, HeSoLuong_Ten, HeSoLuong_GiaTri)
VALUES (1, N'Bậc 1', 1.07), 
(2, N'Bậc 2', 1.13), 
(3, N'Bậc 3', 1.19), 
(4, N'Bậc 4', 1.42);
GO

--Bảng Hợp đồng
INSERT INTO HopDong (HopDong_NgayBatDau, HopDong_NgayKetThuc,
    HopDong_LanKy, HopDong_NoiDung, HopDong_LuongCanBan, HopDong_HeSoLuong, HopDong_NhanVien)
VALUES
('1/1/2019','1/1/2021', 1, 'A',3.250,1,(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen=N'Nguyễn Văn Phát')),
('3/1/2018','3/1/2021', 1, 'A',3.250,1,(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Huỳnh Văn Bá')),
('3/1/2019','3/1/2021', 1, 'A',3.250,1,(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Nguyễn Thị Hà')),
('1/1/2019','1/1/2021', 1, 'A',3.250,1,(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Nguyễn Thị Hạ')),
('11/1/2019','1/11/2021', 1, 'A',3.250,1,(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Huỳnh Văn Ba')),
('11/1/2019','1/11/2021', 1, 'A',3.250,1,(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Huỳnh Văn Vũ')),
('12/1/2019','12/1/2021', 1, 'A',3.250,1,(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Nguyễn Văn Khánh')),
('12/1/2019','12/1/2021', 1, 'A',3.250,1,(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Nguyễn Văn Ba')),
('12/1/2019','12/1/2021', 1, 'A',3.250,1,(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Nguyễn Công Huynh')),
('12/1/2019','12/1/2021', 1, 'A',3.250,1,(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Nguyễn Phát Tài')),
('11/1/2019','11/1/2021', 1, 'A',3.250,1,(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Lý Tiến Thành')),
('12/1/2019','12/1/2021', 1, 'A',3.250,1,(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Mai Thành Chung')),
('11/1/2019','11/1/2021', 1, 'A',3.250,1,(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Mai Trọng Khánh')),
('1/1/2019','1/1/2021', 1, 'A',3.250,1,(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Quách Đình Trường Thi')),
('1/1/2019','1/1/2021', 1, 'A',3.250,1,(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Quách Diệu Khánh')),
('1/1/2019','1/1/2021', 1, 'A',3.250,1,(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Phan Thanh Lâm')),
('1/1/2019','1/1/2021', 1, 'A',3.250,1,(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Đinh Bảo Long')),
('1/1/2019','1/1/2021', 1, 'A',3.250,1,(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Huỳnh Thị My')),
('1/1/2019','1/1/2021', 1, 'A',3.250,1,(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Võ Thị Phước')),
('1/1/2019','1/1/2021', 1, 'A',3.250,1,(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Mai Hoàng Hương'));
GO

--Bảng Nhân Viên
INSERT INTO NhanVien(
    NhanVien_HoTen, NhanVien_SDT,NhanVien_CCCD,
    NhanVien_GioiTinh, NhanVien_HinhAnh, NhanVien_DiaChi, NhanVien_NgaySinh, 
    NhanVien_ChucVu, NhanVien_PhongBan)
VALUES
(N'Nguyễn Văn Phát', '0337079124', '049000123233', N'Nam',NULL, N'44/2 đường số 3, Linh Tây, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID FROM CHUCVU WHERE ChucVu_TenCV =N'Giám đốc' ), (SELECT PhongBan_MaPB FROM PhongBan WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
(N'Huỳnh Văn Bá', '0313139871', '003001943441', N'Nam', NULL, N'13 Luỹ Bán Bích, Tân Phú, TPHCM' , '1/1/2001', (SELECT ChucVu_ID FROM CHUCVU WHERE ChucVu_TenCV =N'Nhân viên' ), (SELECT PhongBan_MaPB FROM PhongBan WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
(N'Nguyễn Thị Hà', '0312888122', '000321212932', N'Nữ',NULL, N'91 Tam Hà, Tam Phú, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID FROM CHUCVU WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB FROM PhongBan WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
(N'Nguyễn Thị Hạ', '0312834122', '000398912932', N'Nữ',NULL, N'3 Tam Hà, Tam Phú, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID FROM CHUCVU WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB FROM PhongBan WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
(N'Huỳnh Văn Ba', '0313139871', '003001943441', N'Nam',NULL, N'137 Luỹ Bán Bích, Tân Phú, TPHCM', '1/1/2001', (SELECT ChucVu_ID FROM CHUCVU WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB FROM PhongBan WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
(N'Huỳnh Văn Vũ', '0319199871', '003111943441', N'Nam',NULL, N'198 Luỹ Bán Bích, Tân Phú, TPHCM', '1/1/2001', (SELECT ChucVu_ID FROM CHUCVU WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB FROM PhongBan WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
(N'Nguyễn Văn Khánh', '0324079124', '049008923233', N'Nam',NULL, N'44/7 đường số 3, Linh Tây, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID FROM CHUCVU WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB FROM PhongBan WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
(N'Nguyễn Văn Ba', '0339079124', '049000912233', N'Nam',NULL, N'48/2 đường số 9, Linh Trung, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID FROM CHUCVU WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB FROM PhongBan WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
(N'Nguyễn Công Huynh', '0337079192', '049000129233', N'Nam',NULL, N'42/2 đường số 3, Linh Tây, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID FROM CHUCVU WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB FROM PhongBan WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
(N'Nguyễn Phát Tài' , '0127079124', '049120123233', N'Nam',NULL, N'41/4 đường số 1, Linh Tây, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID FROM CHUCVU WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB FROM PhongBan WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
(N'Lý Tiến Thành', '0337098124', '049000192233', N'Nam',NULL, N'14/2 đường số 8, Linh Chiểu, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID FROM CHUCVU WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB FROM PhongBan WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
(N'Mai Thành Chung', '0391079124', '049000913233', N'Nam',NULL, N'19 đường số 4, Linh Đông, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID FROM CHUCVU WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB FROM PhongBan WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
(N'Mai Trọng Khánh', '0891079124', '049111913233', N'Nam',NULL, N'29 đường số 4, Linh Đông, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID FROM CHUCVU WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB FROM PhongBan WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
(N'Quách Đình Trường Thi', '0891079124', '049000913233', N'Nam',NULL, N'111 đường số 4, Linh Đông, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID FROM CHUCVU WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB FROM PhongBan WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
(N'Quách Diệu Khánh', '0312079124', '049009013233', N'Nam',NULL, N'90 đường số 2, Linh Đông, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID FROM CHUCVU WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB FROM PhongBan WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
(N'Phan Thanh Lâm', '0399019124', '049123913233', N'Nam',NULL, N'19 đường số 9, Linh Đông, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID FROM CHUCVU WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB FROM PhongBan WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
(N'Đinh Bảo Long', '0391123124', '049000192233', N'Nam', NULL,N'19 đường số 2, Linh Đông, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID FROM CHUCVU WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB FROM PhongBan WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
(N'Huỳnh Thị My', '0312179124', '049002113233', N'Nữ', NULL,N'122 đường số 9, Linh Đông, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID FROM CHUCVU WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB FROM PhongBan WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
(N'Võ Thị Phước', '0123079124', '049000913233', N'Nữ',NULL, N'119/2 đường số 9, Linh Đông, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID FROM CHUCVU WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB FROM PhongBan WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
(N'Mai Hoàng Hương', '0123900124', '073000913233',N'Nữ',NULL, N'18/2 Phạm Văn Đồng, Linh Trung, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID FROM CHUCVU WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB FROM PhongBan WHERE PhongBan_TenPB=N'Phòng Hành Chính'));
GO
---
INSERT INTO KyCong(KyCong_Nam, KyCong_Thang, KyCong_SoNgayCong, KyCong_TrangThaiXoa)
VALUES 
(2022, 6, 26, 0),
(2022, 7, 26, 0),
(2022, 8, 27, 0),
(2022, 9, 26, 0),
(2022, 10, 26, 0),
(2022, 11, 26, 0),
(2022, 12, 27, 0),
(2023, 1, 26, 0),
(2023, 2, 24, 0),
(2023, 3, 27, 0),
(2023, 4, 25, 0),
(2023, 5, 27, 0);
Go

-- Bảng kỳ công chi tiết
INSERT INTO KyCongChiTiet(KyCongChiTiet_NhanVien, KyCongChiTiet_KyCong, KyCongChiTiet_D1, KyCongChiTiet_D2, KyCongChiTiet_D3, KyCongChiTiet_D4,
KyCongChiTiet_D5, KyCongChiTiet_D6, KyCongChiTiet_D7 ,KyCongChiTiet_D8 ,KyCongChiTiet_D9,KyCongChiTiet_D10,KyCongChiTiet_D11 ,KyCongChiTiet_D12,
KyCongChiTiet_D13,KyCongChiTiet_D14,KyCongChiTiet_D15 ,KyCongChiTiet_D16,KyCongChiTiet_D17,KyCongChiTiet_D18,KyCongChiTiet_D19,KyCongChiTiet_D20,
KyCongChiTiet_D21, KyCongChiTiet_D22,KyCongChiTiet_D23, KyCongChiTiet_D24, KyCongChiTiet_D25,KyCongChiTiet_D26,KyCongChiTiet_D27,KyCongChiTiet_D28,
KyCongChiTiet_D29,KyCongChiTiet_D30,KyCongChiTiet_D31,KyCongChiTiet_NgayNghi, KyCongChiTiet_CongChuNhat, KyCongChiTiet_TongNgayCong)
VALUES
(1, 1, 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', NUll, 0, 4, 31),
(2, 1, 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', NUll, 0, 4, 31),
(3, 1, 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', NUll, 0, 4, 31),
(4, 1, 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', NUll, 0, 4, 31),
(5, 1, 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', NUll, 0, 4, 31),
(6, 2, 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 0, 4, 31),
(7, 2,'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 0, 4, 31),
(8, 2,'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 0, 4, 31),
(9, 2,'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 0, 4, 31),
(10, 2,'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 'X', 'X', 'X', 'X', 'X', 'X', 'CN', 0, 4, 31);
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
GO

-- Bảng phân quyền
INSERT INTO PhanQuyen(PhanQuyen_TenQuyen)
VALUES (N'Quản trị hệ thống');
INSERT INTO PhanQuyen(PhanQuyen_TenQuyen)
VALUES (N'Nhân viên nhân sự');
GO

-- bảng TaiKhoan
INSERT INTO TaiKhoan(TaiKhoan_SoTK, TaiKhoan_MatKhau, TaiKhoan_PhanQuyen, TaiKhoan_NhanVien)
VALUES ('20110110', '123', (SELECT PhanQuyen_ID From PhanQuyen WHERE PhanQuyen_TenQuyen = N'Quản trị hệ thống'), (SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Đinh Bảo Long'))
INSERT INTO TaiKhoan(TaiKhoan_SoTK, TaiKhoan_MatKhau, TaiKhoan_PhanQuyen, TaiKhoan_NhanVien)
VALUES ('20110111', '123', (SELECT PhanQuyen_ID From PhanQuyen WHERE PhanQuyen_TenQuyen = N'Quản trị hệ thống'), (SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Mai Hoàng Hương'))
INSERT INTO TaiKhoan(TaiKhoan_SoTK, TaiKhoan_MatKhau, TaiKhoan_PhanQuyen, TaiKhoan_NhanVien)
VALUES ('20110112', '123', (SELECT PhanQuyen_ID From PhanQuyen WHERE PhanQuyen_TenQuyen = N'Nhân viên nhân sự'), (SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Mai Trọng Khánh'))
INSERT INTO TaiKhoan(TaiKhoan_SoTK, TaiKhoan_MatKhau, TaiKhoan_PhanQuyen, TaiKhoan_NhanVien)
VALUES ('20110113', '123', (SELECT PhanQuyen_ID From PhanQuyen WHERE PhanQuyen_TenQuyen = N'Nhân viên nhân sự'), (SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Nguyễn Thị Hạ'))
INSERT INTO TaiKhoan(TaiKhoan_SoTK, TaiKhoan_MatKhau, TaiKhoan_PhanQuyen, TaiKhoan_NhanVien)
VALUES ('20110114', '123', (SELECT PhanQuyen_ID From PhanQuyen WHERE PhanQuyen_TenQuyen = N'Nhân viên nhân sự'), (SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen=N'Nguyễn Văn Phát'))
GO

-- Bảng phòng ban
INSERT INTO PhongBan(PhongBan_TenPB, PhongBan_TruongPhong, PhongBan_TG_NhanChuc)
VALUES (N'Phòng Hành Chính',(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Huỳnh Văn Vũ'), '2020-5-22');
INSERT INTO PhongBan(PhongBan_TenPB, PhongBan_TruongPhong, PhongBan_TG_NhanChuc)
VALUES (N'Phòng Tài chính Kế toán', (SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Huỳnh Thị My'), '2022-6-19');
INSERT INTO PhongBan(PhongBan_TenPB, PhongBan_TruongPhong, PhongBan_TG_NhanChuc)
VALUES (N'Phòng Kế hoạch Kinh doanh', (SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Mai Hoàng Hương'), '2021-1-1');
GO

-- Bảng ứng lương
INSERT INTO UngLuong (UngLuong_Ngay, UngLuong_SoTien, UngLuong_TrangThaiXoa, UngLuong_GhiChu, UngLuong_NhanVien, UngLuong_KyCong)
VALUES (1, 2500.0, 'FALSE', N'Ứng lương đầu kỳ',(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen=N'Nguyễn Văn Phát'), (SELECT KyCong_MaKyCong FROM KyCong WHERE KyCong_Nam = 2022 AND KyCong_Thang = 6));
INSERT INTO UngLuong (UngLuong_Ngay, UngLuong_SoTien, UngLuong_TrangThaiXoa, UngLuong_GhiChu, UngLuong_NhanVien, UngLuong_KyCong)
VALUES (1, 500.0, 'FALSE', N'Ứng lương đầu kỳ',(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Huỳnh Văn Bá'),(SELECT KyCong_MaKyCong FROM KyCong WHERE KyCong_Nam = 2022 AND KyCong_Thang = 7));
INSERT INTO UngLuong (UngLuong_Ngay, UngLuong_SoTien, UngLuong_TrangThaiXoa, UngLuong_GhiChu, UngLuong_NhanVien, UngLuong_KyCong)
VALUES (1, 200.0, 'FALSE', N'Ứng lương đầu kỳ',(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Nguyễn Thị Hà'), (SELECT KyCong_MaKyCong FROM KyCong WHERE KyCong_Nam = 2022 AND KyCong_Thang = 8));
INSERT INTO UngLuong (UngLuong_Ngay, UngLuong_SoTien, UngLuong_TrangThaiXoa, UngLuong_GhiChu, UngLuong_NhanVien, UngLuong_KyCong)
VALUES (15, 2000.0, 'FALSE', N'Ứng lương giữa kỳ',(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Nguyễn Thị Hạ'), (SELECT KyCong_MaKyCong FROM KyCong WHERE KyCong_Nam = 2022 AND KyCong_Thang = 9));
INSERT INTO UngLuong (UngLuong_Ngay, UngLuong_SoTien, UngLuong_TrangThaiXoa, UngLuong_GhiChu, UngLuong_NhanVien, UngLuong_KyCong)
VALUES (15, 2500.0, 'TRUE', N'Ứng lương giữa kỳ',(SELECT NhanVien_ID FROM NhanVien WHERE NhanVien_HoTen= N'Huỳnh Văn Ba'), (SELECT KyCong_MaKyCong FROM KyCong WHERE KyCong_Nam = 2022 AND KyCong_Thang = 10));
GO

--Bảng Tăng Ca--


INSERT INTO dbo.TangCa
(
    TangCa_NgayTangCa,
    TangCa_SoGio,
    TangCa_NhanVien,
    TangCa_LoaiTangCa,
	TangCa_KyCong
)
VALUES
(	13, 
    2, 
    (SELECT NhanVien_ID FROM dbo.NhanVien WHERE NhanVien_HoTen = N'Nguyễn Văn Phát'),
    (SELECT LoaiTangCa_ID FROM dbo.LoaiTangCa WHERE LoaiTangCa_TenLoai = N'Ngày Nghỉ'),
	(SELECT KyCong_MaKyCong FROM dbo.KyCong WHERE KyCong_Thang = 6 AND KyCong_Nam=2022)
),
(	NULL, 
    NULL, 
    (SELECT NhanVien_ID FROM dbo.NhanVien WHERE NhanVien_HoTen = N'Huỳnh Văn Bá'),
    NULL,
	(SELECT KyCong_MaKyCong FROM dbo.KyCong WHERE KyCong_Thang = 7 AND KyCong_Nam=2022)
),
(	10, 
    1, 
    (SELECT NhanVien_ID FROM dbo.NhanVien WHERE NhanVien_HoTen = N'Nguyễn Thị Hà'),
    (SELECT LoaiTangCa_ID FROM dbo.LoaiTangCa WHERE LoaiTangCa_TenLoai = N'Ca Tối'),
	(SELECT KyCong_MaKyCong FROM dbo.KyCong WHERE KyCong_Thang = 8 AND KyCong_Nam=2022)
),
(	15, 
    2.5, 
    (SELECT NhanVien_ID FROM dbo.NhanVien WHERE NhanVien_HoTen = N'Nguyễn Thị Hạ'),
    (SELECT LoaiTangCa_ID FROM dbo.LoaiTangCa WHERE LoaiTangCa_TenLoai = N'Ngày Lễ'),
	(SELECT KyCong_MaKyCong FROM dbo.KyCong WHERE KyCong_Thang = 9 AND KyCong_Nam=2022)
),
(	20, 
    4, 
    (SELECT NhanVien_ID FROM dbo.NhanVien WHERE NhanVien_HoTen = N'Huỳnh Văn Vũ'),
    (SELECT LoaiTangCa_ID FROM dbo.LoaiTangCa WHERE LoaiTangCa_TenLoai = N'Ngày Nghỉ'),
	(SELECT KyCong_MaKyCong FROM dbo.KyCong WHERE KyCong_Thang = 10 AND KyCong_Nam=2022)
),
(	28, 
    1.5, 
    (SELECT NhanVien_ID FROM dbo.NhanVien WHERE NhanVien_HoTen = N'Nguyễn Văn Khánh'),
    (SELECT LoaiTangCa_ID FROM dbo.LoaiTangCa WHERE LoaiTangCa_TenLoai = N'Ca Tối'),
	(SELECT KyCong_MaKyCong FROM dbo.KyCong WHERE KyCong_Thang = 11 AND KyCong_Nam=2022)
),
(	1, 
    3, 
    (SELECT NhanVien_ID FROM dbo.NhanVien WHERE NhanVien_HoTen = N'Nguyễn Văn Ba'),
    (SELECT LoaiTangCa_ID FROM dbo.LoaiTangCa WHERE LoaiTangCa_TenLoai = N'Ngày Lễ'),
	(SELECT KyCong_MaKyCong FROM dbo.KyCong WHERE KyCong_Thang = 12 AND KyCong_Nam=2022)
),
(	NULL, 
    NULL, 
    (SELECT NhanVien_ID FROM dbo.NhanVien WHERE NhanVien_HoTen = N'Nguyễn Công Huynh'),
    NULL,
	(SELECT KyCong_MaKyCong FROM dbo.KyCong WHERE KyCong_Thang = 1 AND KyCong_Nam=2023)
),
(	30, 
    5, 
    (SELECT NhanVien_ID FROM dbo.NhanVien WHERE NhanVien_HoTen = N'Nguyễn Phát Tài'),
    (SELECT LoaiTangCa_ID FROM dbo.LoaiTangCa WHERE LoaiTangCa_TenLoai = N'Ngày Nghỉ'),
	(SELECT KyCong_MaKyCong FROM dbo.KyCong WHERE KyCong_Thang = 2 AND KyCong_Nam=2023)
),
(	NULL, 
    NULL, 
    (SELECT NhanVien_ID FROM dbo.NhanVien WHERE NhanVien_HoTen = N'Lý Tiến Thành'),
    NULL,
	(SELECT KyCong_MaKyCong FROM dbo.KyCong WHERE KyCong_Thang = 3 AND KyCong_Nam=2023)
),
(	21, 
    3, 
    (SELECT NhanVien_ID FROM dbo.NhanVien WHERE NhanVien_HoTen = N'Mai Thành Chung'),
    (SELECT LoaiTangCa_ID FROM dbo.LoaiTangCa WHERE LoaiTangCa_TenLoai = N'Ca Tối'),
	(SELECT KyCong_MaKyCong FROM dbo.KyCong WHERE KyCong_Thang = 4 AND KyCong_Nam=2023)
),
(	11, 
    3.5, 
    (SELECT NhanVien_ID FROM dbo.NhanVien WHERE NhanVien_HoTen = N'Mai Trọng Khánh'),
    (SELECT LoaiTangCa_ID FROM dbo.LoaiTangCa WHERE LoaiTangCa_TenLoai = N'Ngày Lẽ'),
	(SELECT KyCong_MaKyCong FROM dbo.KyCong WHERE KyCong_Thang = 5 AND KyCong_Nam=2023)
)

GO

--Bảng Chức Vụ--
INSERT INTO dbo.ChucVu
(
    ChucVu_ID,
    ChucVu_TenCV
)
VALUES
(   1,   -- ChucVu_ID - int
    N'Giám Đốc' -- ChucVu_TenCV - nvarchar(50)
    ),
(   2,   -- ChucVu_ID - int
    N'Phó Giám Đốc Hành Chính' -- ChucVu_TenCV - nvarchar(50)
    ),
(   3,   -- ChucVu_ID - int
    N'Phó Giám Đốc Kinh Doanh' -- ChucVu_TenCV - nvarchar(50)
    ),
(   4,   -- ChucVu_ID - int
    N'Trưởng Phòng Hành Chính' -- ChucVu_TenCV - nvarchar(50)
    ),
(   5,   -- ChucVu_ID - int
    N'Trưởng Phòng Tài Chính' -- ChucVu_TenCV - nvarchar(50)
    ),
(   6,   -- ChucVu_ID - int
    N'Trưởng Phòng Kế Hoạch' -- ChucVu_TenCV - nvarchar(50)
    ),
(   7,   -- ChucVu_ID - int
    N'Trưởng Nhóm' -- ChucVu_TenCV - nvarchar(50)
    ),
(   8,   -- ChucVu_ID - int
    N'Trưởng Nhóm' -- ChucVu_TenCV - nvarchar(50)
    ),
(   9,   -- ChucVu_ID - int
    N'Nhân Viên' -- ChucVu_TenCV - nvarchar(50)
    ),
(   10,   -- ChucVu_ID - int
    N'Nhân Viên' -- ChucVu_TenCV - nvarchar(50)
    )

--View trigger ChucVu,TangCa,LoaiTangCa--
GO


CREATE VIEW v_ChucVu AS
SELECT * FROM dbo.ChucVu;

go


CREATE VIEW v_NhanVienCoTangCa AS
SELECT * FROM dbo.TangCa
WHERE TangCa_NgayTangCa IS NOT NULL



go
CREATE VIEW v_LoaiTangCa AS
SELECT * FROM dbo.LoaiTangCa;


GO

CREATE TRIGGER ThemNVTangCa
ON dbo.TangCa
FOR INSERT
AS
BEGIN
	DECLARE @day INT =0;
	SELECT @day = TangCa_NgayTangCa FROM dbo.TangCa
	IF(@day <=0 or @day >31)
		ROLLBACK TRAN
END

GO
 
-- ============= Giao Dien ===============
-- <Kha>
-- 1. NV
-- 2. hopDong
-- 3. HSL

-- <Quang>
-- BangLuong
-- UngLuong
-- TangCa

-- <Tuan>
-- KyCong
-- KyCongChiTiet
-- ChamCong <import excel>

-- <Dung>
-- LoaiTangCa
-- ChucVu
-- PhongBan
-- TK
-- PhanQuyen
-- thêm đăng nhập
