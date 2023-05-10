-- Tạo CSDL
CREATE DATABASE QLNS
GO
-- Sử dụng CSDL
USE QLNS
GO





------------------------------------ Thực hiện tạo bảng -----------------------------------------------
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
    NhanVien_PhongBan INT,
    NhanVien_TrangThaiXoa BIT DEFAULT 0-- UPDATE
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
    HopDong_NhanVien INT UNIQUE
);
GO
-- Bảng Hệ số lương
CREATE TABLE HeSoLuong
(
    HeSoLuong_ID INT IDENTITY(1,1) PRIMARY KEY,
    HeSoLuong_Ten NVARCHAR(10) NOT NULL,
    HeSoLuong_GiaTri FLOAT
);
GO
-- Bảng Kỳ Công
CREATE TABLE KyCong
(
    KyCong_MaKyCong INT IDENTITY(1, 1) PRIMARY KEY,
    KyCong_Nam INT,
    KyCong_Thang INT,
    KyCong_SoNgayCong INT,
    KyCong_TrangThaiXoa BIT
);
GO
-- Bảng KCCT
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
    ChamCong_GioChamCong VARCHAR(50),
    ChamCong_NhanVien INT,
    ChamCong_KyCong INT
);
GO
--Bảng Lương
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
    TaiKhoan_PhanQuyen BIT
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
GO





-------------------------------Thực hiện tạo view---------------------------------------------
-- Bảng Ứng lương
CREATE VIEW DS_UngLuong
AS
    SELECT UngLuong_ID, UngLuong_Ngay, UngLuong_NhanVien, UngLuong_SoTien, UngLuong_GhiChu
    FROM UngLuong
    WHERE UngLuong_TrangThaiXoa = 0
GO

-- Bảng PhongBan
CREATE VIEW DS_Phongban
AS
    SELECT PhongBan_MaPB, PhongBan_TenPB
    FROM PhongBan
GO

-- Bảng Kỳ Công
CREATE VIEW DS_KyCong
AS
    SELECT KyCong_MaKyCong , KyCong_Nam , KyCong_Thang , KyCong_SoNgayCong
    FROM KyCong
    WHERE KyCong_TrangThaiXoa = 0
GO

-- Bảng Châm Công
CREATE VIEW View_ChamCong
AS
    SELECT ChamCong_ID, ChamCong_Ngay , ChamCong_NhanVien, ChamCong_KyCong
    FROM ChamCong
GO
-- Bang Chuc vu
CREATE VIEW v_ChucVu
AS
    SELECT *
    FROM dbo.ChucVu;
GO
-- BẢNG NHÂN VIÊN CÓ TĂNG CA
CREATE VIEW v_NhanVienCoTangCa
AS
    SELECT *
    FROM dbo.TangCa
    WHERE TangCa_NgayTangCa IS NOT NULL
GO
-- BẢNG LOẠI TĂNG CA
CREATE VIEW v_LoaiTangCa
AS
    SELECT *
    FROM dbo.LoaiTangCa;
GO
-- Bảng Nhân Viên
CREATE VIEW v_NhanVien
AS
    SELECT *
    FROM NhanVien
    WHERE NhanVien_TrangThaiXoa = 0
GO
-- Bảng Hợp đồng
CREATE VIEW v_HopDong
AS
    SELECT *
    FROM HopDong
GO
-- Bảng Hệ số lương
CREATE VIEW v_HSL
AS
    SELECT *
    FROM HeSoLuong
GO
-- Bảng tài khoản
CREATE VIEW v_TaiKhoan
AS
    SELECT *
    FROM TaiKhoan
GO





------------------------------------------- Trigger ----------------------------------------
-- Bảng Ứng lương
CREATE TRIGGER TGR_UngLuong
ON UngLuong
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @maxid int = 0
    SELECT @maxid = MAX(UngLuong_ID)
    FROM UngLuong
    IF @maxid IS NULL SET @maxid = 1;
  ELSE SET @maxid = @maxid + 1;
    INSERT INTO UngLuong
        (UngLuong_ID)
    VALUES(@maxid)
    UPDATE UngLuong
  SET UngLuong_Ngay = i.UngLuong_Ngay, UngLuong_SoTien=i.UngLuong_SoTien, UngLuong_TrangThaiXoa=i.UngLuong_TrangThaiXoa, UngLuong_GhiChu=i.UngLuong_GhiChu, UngLuong_NhanVien=i.UngLuong_NhanVien, UngLuong_KyCong=i.UngLuong_KyCong
  FROM inserted i
  WHERE UngLuong.UngLuong_ID = @maxid
    PRINT N'Đã thêm ứng lương có mã là: '+ CAST(@maxid AS VARCHAR)
END;
GO
-- Bảng HopDong
CREATE TRIGGER TGR_AutoIncrement_HopDong
ON HopDong
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @maxid int = 0
    SELECT @maxid = MAX(HopDong_SoHD)
    FROM HopDong
    IF @maxid IS NULL SET @maxid = 1;
    ELSE SET @maxid = @maxid + 1;
    INSERT INTO HopDong
        (HopDong_SoHD, HopDong_NgayBatDau, HopDong_NgayKetThuc, HopDong_LanKy, HopDong_NoiDung, HopDong_LuongCanBan, HopDong_HeSoLuong, HopDong_NhanVien)
    SELECT @maxid, i.HopDong_NgayBatDau, i.HopDong_NgayKetThuc, i.HopDong_LanKy, i.HopDong_NoiDung, i.HopDong_LuongCanBan, i.HopDong_HeSoLuong, i.HopDong_NhanVien
    FROM inserted i
    UPDATE HopDong
    SET HopDong_NgayBatDau = i.HopDong_NgayBatDau, HopDong_NgayKetThuc = i.HopDong_NgayKetThuc, HopDong_LanKy = i.HopDong_LanKy, HopDong_NoiDung = i.HopDong_NoiDung, HopDong_LuongCanBan = i.HopDong_LuongCanBan, HopDong_HeSoLuong = i.HopDong_HeSoLuong, HopDong_NhanVien = i.HopDong_NhanVien
    FROM inserted i
    WHERE HopDong.HopDong_SoHD = @maxid
    PRINT N'Đã thêm hợp đồng có mã là: '+ CAST(@maxid AS VARCHAR)
END;
GO


-- Bảng PhongBan
CREATE TRIGGER TGR_PhongBan
On PhongBan
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @maxid int = 0
    SELECT @maxid = MAX(PhongBan_MaPB)
    FROM PhongBan
    IF @maxid IS NULL SET @maxid = 1
    ELSE SET @maxid = @maxid + 1
    INSERT INTO PhongBan
        (PhongBan_MaPB)
    VALUES
        (@maxid)
    UPDATE PhongBan
    SET PhongBan_TenPB = i.PhongBan_TenPB, PhongBan_TG_NhanChuc = i.PhongBan_TG_NhanChuc, PhongBan_TruongPhong = i.PhongBan_TruongPhong
    FROM inserted i
    WHERE PhongBan.PhongBan_MaPB = @maxid
    PRINT N'Đã thêm phòng ban có mã là: '+ CAST(@maxid AS VARCHAR)
END;
GO
-- Bảng ChucVu
CREATE TRIGGER TGR_ChucVu
ON ChucVu
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @maxid int = 0
    SELECT @maxid = MAX(ChucVu_ID)
    FROM ChucVu
    IF @maxid IS NULL SET @maxid = 1
    ELSE SET @maxid = @maxid + 1
    INSERT INTO ChucVu
        (ChucVu_ID, ChucVu_TenCV)
    SELECT
        ISNULL(i.ChucVu_ID, @maxid),
        i.ChucVu_TenCV
    FROM inserted i
END;
GO
-- Trigger tăng ID tự động cho bảng LoaiTangCa
CREATE TRIGGER TGR_LoaiTangCa
ON LoaiTangCa
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @maxid int = 0
    SELECT @maxid = MAX(LoaiTangCa_ID)
    FROM LoaiTangCa
    IF @maxid IS NULL SET @maxid = 1
ELSE SET @maxid = @maxid + 1
    INSERT INTO LoaiTangCa
        (LoaiTangCa_ID, LoaiTangCa_TenLoai, LoaiTangCa_HeSo)
    SELECT
        IIF(i.LoaiTangCa_ID IS NULL, @maxid, i.LoaiTangCa_ID),
        i.LoaiTangCa_TenLoai,
        i.LoaiTangCa_HeSo
    FROM inserted i
END;
GO
-- Bảng TaiKhoan
CREATE TRIGGER TGR_TaiKhoan
On TaiKhoan
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @checkid int
    SELECT @checkid = i.TaiKhoan_SoTK
    FROM inserted i
    IF NOT EXISTS(SELECT *
    FROM TaiKhoan
    WHERE TaiKhoan_SoTK = @checkid)
    INSERT INTO TaiKhoan
        (TaiKhoan_SoTK, TaiKhoan_MatKhau, TaiKhoan_PhanQuyen)
    SELECT i.TaiKhoan_SoTK, (CONVERT(VARCHAR(32), HashBytes('MD5', i.TaiKhoan_MatKhau), 2)), i.TaiKhoan_PhanQuyen
    FROM inserted i
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
    IF EXISTS (SELECT 1
    FROM inserted
    WHERE inserted.KyCong_Thang < 1 OR inserted.KyCong_Thang > 12)
    BEGIN
        RAISERROR('Giá trị của KyCong_Thang phải nằm trong khoảng từ 1 đến 12', 16, 1)
        ROLLBACK TRANSACTION
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
CREATE TRIGGER ThemNVTangCa
ON dbo.TangCa
FOR INSERT
AS
BEGIN
    DECLARE @day INT =0;
    SELECT @day = TangCa_NgayTangCa
    FROM dbo.TangCa
    IF(@day <=0 or @day >31)
		ROLLBACK TRAN
END
GO





-------------------------------------------  Data ------------------------------------------
--Bảng Hệ số lương
INSERT INTO HeSoLuong
    (HeSoLuong_Ten, HeSoLuong_GiaTri)
VALUES
    (N'Bậc 1', 1.07),
    (N'Bậc 2', 1.13),
    (N'Bậc 3', 1.19),
    (N'Bậc 4', 1.42);
GO
--Bảng Nhân Viên
INSERT INTO NhanVien
    (
    NhanVien_HoTen, NhanVien_SDT,NhanVien_CCCD,
    NhanVien_GioiTinh, NhanVien_HinhAnh, NhanVien_DiaChi, NhanVien_NgaySinh,
    NhanVien_ChucVu, NhanVien_PhongBan)
VALUES
    (N'Nguyễn Văn Phát', '0337079124', '049000123233', N'Nam', NULL, N'44/2 đường số 3, Linh Tây, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID
        FROM CHUCVU
        WHERE ChucVu_TenCV =N'Giám đốc' ), (SELECT PhongBan_MaPB
        FROM PhongBan
        WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
    (N'Huỳnh Văn Bá', '0313139871', '003001943441', N'Nam', NULL, N'13 Luỹ Bán Bích, Tân Phú, TPHCM' , '1/1/2001', (SELECT ChucVu_ID
        FROM CHUCVU
        WHERE ChucVu_TenCV =N'Nhân viên' ), (SELECT PhongBan_MaPB
        FROM PhongBan
        WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
    (N'Nguyễn Thị Hà', '0312888122', '000321212932', N'Nữ', NULL, N'91 Tam Hà, Tam Phú, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID
        FROM CHUCVU
        WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB
        FROM PhongBan
        WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
    (N'Nguyễn Thị Hạ', '0312834122', '000398912932', N'Nữ', NULL, N'3 Tam Hà, Tam Phú, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID
        FROM CHUCVU
        WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB
        FROM PhongBan
        WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
    (N'Huỳnh Văn Ba', '0313139871', '003001943441', N'Nam', NULL, N'137 Luỹ Bán Bích, Tân Phú, TPHCM', '1/1/2001', (SELECT ChucVu_ID
        FROM CHUCVU
        WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB
        FROM PhongBan
        WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
    (N'Huỳnh Văn Vũ', '0319199871', '003111943441', N'Nam', NULL, N'198 Luỹ Bán Bích, Tân Phú, TPHCM', '1/1/2001', (SELECT ChucVu_ID
        FROM CHUCVU
        WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB
        FROM PhongBan
        WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
    (N'Nguyễn Văn Khánh', '0324079124', '049008923233', N'Nam', NULL, N'44/7 đường số 3, Linh Tây, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID
        FROM CHUCVU
        WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB
        FROM PhongBan
        WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
    (N'Nguyễn Văn Ba', '0339079124', '049000912233', N'Nam', NULL, N'48/2 đường số 9, Linh Trung, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID
        FROM CHUCVU
        WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB
        FROM PhongBan
        WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
    (N'Nguyễn Công Huynh', '0337079192', '049000129233', N'Nam', NULL, N'42/2 đường số 3, Linh Tây, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID
        FROM CHUCVU
        WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB
        FROM PhongBan
        WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
    (N'Nguyễn Phát Tài' , '0127079124', '049120123233', N'Nam', NULL, N'41/4 đường số 1, Linh Tây, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID
        FROM CHUCVU
        WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB
        FROM PhongBan
        WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
    (N'Lý Tiến Thành', '0337098124', '049000192233', N'Nam', NULL, N'14/2 đường số 8, Linh Chiểu, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID
        FROM CHUCVU
        WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB
        FROM PhongBan
        WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
    (N'Mai Thành Chung', '0391079124', '049000913233', N'Nam', NULL, N'19 đường số 4, Linh Đông, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID
        FROM CHUCVU
        WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB
        FROM PhongBan
        WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
    (N'Mai Trọng Khánh', '0891079124', '049111913233', N'Nam', NULL, N'29 đường số 4, Linh Đông, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID
        FROM CHUCVU
        WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB
        FROM PhongBan
        WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
    (N'Quách Đình Trường Thi', '0891079124', '049000913233', N'Nam', NULL, N'111 đường số 4, Linh Đông, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID
        FROM CHUCVU
        WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB
        FROM PhongBan
        WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
    (N'Quách Diệu Khánh', '0312079124', '049009013233', N'Nam', NULL, N'90 đường số 2, Linh Đông, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID
        FROM CHUCVU
        WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB
        FROM PhongBan
        WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
    (N'Phan Thanh Lâm', '0399019124', '049123913233', N'Nam', NULL, N'19 đường số 9, Linh Đông, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID
        FROM CHUCVU
        WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB
        FROM PhongBan
        WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
    (N'Đinh Bảo Long', '0391123124', '049000192233', N'Nam', NULL, N'19 đường số 2, Linh Đông, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID
        FROM CHUCVU
        WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB
        FROM PhongBan
        WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
    (N'Huỳnh Thị My', '0312179124', '049002113233', N'Nữ', NULL, N'122 đường số 9, Linh Đông, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID
        FROM CHUCVU
        WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB
        FROM PhongBan
        WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
    (N'Võ Thị Phước', '0123079124', '049000913233', N'Nữ', NULL, N'119/2 đường số 9, Linh Đông, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID
        FROM CHUCVU
        WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB
        FROM PhongBan
        WHERE PhongBan_TenPB=N'Phòng Hành Chính')),
    (N'Mai Hoàng Hương', '0123900124', '073000913233', N'Nữ', NULL, N'18/2 Phạm Văn Đồng, Linh Trung, Thủ Đức, TPHCM', '1/1/2001', (SELECT ChucVu_ID
        FROM CHUCVU
        WHERE ChucVu_TenCV =N' Nhân viên'), (SELECT PhongBan_MaPB
        FROM PhongBan
        WHERE PhongBan_TenPB=N'Phòng Hành Chính'));
GO
--Bảng Hợp đồng
INSERT INTO HopDong
    (HopDong_NgayBatDau, HopDong_NgayKetThuc,
    HopDong_LanKy, HopDong_NoiDung, HopDong_LuongCanBan, HopDong_HeSoLuong, HopDong_NhanVien)
VALUES
    ('1/1/2019', '1/1/2021', 1, 'A', 3.250, (SELECT HeSoLuong_ID
        FROM HeSoLuong
        WHERE HeSoLuong_Ten=N'Bậc 1'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen=N'Nguyễn Văn Phát')),
    ('3/1/2018', '3/1/2021', 1, 'A', 3.250, (SELECT HeSoLuong_ID
        FROM HeSoLuong
        WHERE HeSoLuong_Ten=N'Bậc 1'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Huỳnh Văn Bá')),
    ('3/1/2019', '3/1/2021', 1, 'A', 3.250, (SELECT HeSoLuong_ID
        FROM HeSoLuong
        WHERE HeSoLuong_Ten=N'Bậc 1'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Nguyễn Thị Hà')),
    ('1/1/2019', '1/1/2021', 1, 'A', 3.250, (SELECT HeSoLuong_ID
        FROM HeSoLuong
        WHERE HeSoLuong_Ten=N'Bậc 1'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Nguyễn Thị Hạ')),
    ('11/1/2019', '1/11/2021', 1, 'A', 3.250, (SELECT HeSoLuong_ID
        FROM HeSoLuong
        WHERE HeSoLuong_Ten=N'Bậc 1'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Huỳnh Văn Ba')),
    ('11/1/2019', '1/11/2021', 1, 'A', 3.250, (SELECT HeSoLuong_ID
        FROM HeSoLuong
        WHERE HeSoLuong_Ten=N'Bậc 1'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Huỳnh Văn Vũ')),
    ('12/1/2019', '12/1/2021', 1, 'A', 3.250, (SELECT HeSoLuong_ID
        FROM HeSoLuong
        WHERE HeSoLuong_Ten=N'Bậc 1'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Nguyễn Văn Khánh')),
    ('12/1/2019', '12/1/2021', 1, 'A', 3.250, (SELECT HeSoLuong_ID
        FROM HeSoLuong
        WHERE HeSoLuong_Ten=N'Bậc 1'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Nguyễn Văn Ba')),
    ('12/1/2019', '12/1/2021', 1, 'A', 3.250, (SELECT HeSoLuong_ID
        FROM HeSoLuong
        WHERE HeSoLuong_Ten=N'Bậc 1'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Nguyễn Công Huynh')),
    ('12/1/2019', '12/1/2021', 1, 'A', 3.250, (SELECT HeSoLuong_ID
        FROM HeSoLuong
        WHERE HeSoLuong_Ten=N'Bậc 1'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Nguyễn Phát Tài')),
    ('11/1/2019', '11/1/2021', 1, 'A', 3.250, (SELECT HeSoLuong_ID
        FROM HeSoLuong
        WHERE HeSoLuong_Ten=N'Bậc 1'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Lý Tiến Thành')),
    ('12/1/2019', '12/1/2021', 1, 'A', 3.250, (SELECT HeSoLuong_ID
        FROM HeSoLuong
        WHERE HeSoLuong_Ten=N'Bậc 1'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Mai Thành Chung')),
    ('11/1/2019', '11/1/2021', 1, 'A', 3.250, (SELECT HeSoLuong_ID
        FROM HeSoLuong
        WHERE HeSoLuong_Ten=N'Bậc 1'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Mai Trọng Khánh')),
    ('1/1/2019', '1/1/2021', 1, 'A', 3.250, (SELECT HeSoLuong_ID
        FROM HeSoLuong
        WHERE HeSoLuong_Ten=N'Bậc 1'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Quách Đình Trường Thi')),
    ('1/1/2019', '1/1/2021', 1, 'A', 3.250, (SELECT HeSoLuong_ID
        FROM HeSoLuong
        WHERE HeSoLuong_Ten=N'Bậc 1'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Quách Diệu Khánh')),
    ('1/1/2019', '1/1/2021', 1, 'A', 3.250, (SELECT HeSoLuong_ID
        FROM HeSoLuong
        WHERE HeSoLuong_Ten=N'Bậc 1'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Phan Thanh Lâm')),
    ('1/1/2019', '1/1/2021', 1, 'A', 3.250, (SELECT HeSoLuong_ID
        FROM HeSoLuong
        WHERE HeSoLuong_Ten=N'Bậc 1'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Đinh Bảo Long')),
    ('1/1/2019', '1/1/2021', 1, 'A', 3.250, (SELECT HeSoLuong_ID
        FROM HeSoLuong
        WHERE HeSoLuong_Ten=N'Bậc 1'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Huỳnh Thị My')),
    ('1/1/2019', '1/1/2021', 1, 'A', 3.250, (SELECT HeSoLuong_ID
        FROM HeSoLuong
        WHERE HeSoLuong_Ten=N'Bậc 1'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Võ Thị Phước')),
    ('1/1/2019', '1/1/2021', 1, 'A', 3.250, (SELECT HeSoLuong_ID
        FROM HeSoLuong
        WHERE HeSoLuong_Ten=N'Bậc 1'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Mai Hoàng Hương'));
GO

--- Kỳ Công
INSERT INTO KyCong
    (KyCong_Nam, KyCong_Thang, KyCong_SoNgayCong, KyCong_TrangThaiXoa)
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
GO

-- Bảng loại tăng ca
INSERT INTO dbo.LoaiTangCa
    (
    LoaiTangCa_ID,
    LoaiTangCa_TenLoai,
    LoaiTangCa_HeSo
    )
VALUES
    ( 1, -- LoaiTangCa_ID - int
        N'Ngày Nghỉ', -- LoaiTangCa_TenLoai - nvarchar(20)
        2  -- LoaiTangCa_HeSo - float
    ),
    ( 2, -- LoaiTangCa_ID - int
        N'Ngày Lễ', -- LoaiTangCa_TenLoai - nvarchar(20)
        3  -- LoaiTangCa_HeSo - float
    ),
    ( 3, -- LoaiTangCa_ID - int
        N'Ca Tối', -- LoaiTangCa_TenLoai - nvarchar(20)
        1.5  -- LoaiTangCa_HeSo - float
    )
GO

-- Bảng phòng ban
INSERT INTO PhongBan
    (PhongBan_TenPB, PhongBan_TruongPhong, PhongBan_TG_NhanChuc)
VALUES
    (N'Phòng Hành Chính', (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Huỳnh Văn Vũ'), '2020-5-22');
INSERT INTO PhongBan
    (PhongBan_TenPB, PhongBan_TruongPhong, PhongBan_TG_NhanChuc)
VALUES
    (N'Phòng Tài chính Kế toán', (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Huỳnh Thị My'), '2022-6-19');
INSERT INTO PhongBan
    (PhongBan_TenPB, PhongBan_TruongPhong, PhongBan_TG_NhanChuc)
VALUES
    (N'Phòng Kế hoạch Kinh doanh', (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Mai Hoàng Hương'), '2021-1-1');
GO
-- Bảng ứng lương
INSERT INTO UngLuong
    (UngLuong_Ngay, UngLuong_SoTien, UngLuong_TrangThaiXoa, UngLuong_GhiChu, UngLuong_NhanVien, UngLuong_KyCong)
VALUES
    (1, 2500.0, 'FALSE', N'Ứng lương đầu kỳ', (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen=N'Nguyễn Văn Phát'), (SELECT KyCong_MaKyCong
        FROM KyCong
        WHERE KyCong_Nam = 2022 AND KyCong_Thang = 6));
INSERT INTO UngLuong
    (UngLuong_Ngay, UngLuong_SoTien, UngLuong_TrangThaiXoa, UngLuong_GhiChu, UngLuong_NhanVien, UngLuong_KyCong)
VALUES
    (1, 500.0, 'FALSE', N'Ứng lương đầu kỳ', (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Huỳnh Văn Bá'), (SELECT KyCong_MaKyCong
        FROM KyCong
        WHERE KyCong_Nam = 2022 AND KyCong_Thang = 7));
INSERT INTO UngLuong
    (UngLuong_Ngay, UngLuong_SoTien, UngLuong_TrangThaiXoa, UngLuong_GhiChu, UngLuong_NhanVien, UngLuong_KyCong)
VALUES
    (1, 200.0, 'FALSE', N'Ứng lương đầu kỳ', (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Nguyễn Thị Hà'), (SELECT KyCong_MaKyCong
        FROM KyCong
        WHERE KyCong_Nam = 2022 AND KyCong_Thang = 8));
INSERT INTO UngLuong
    (UngLuong_Ngay, UngLuong_SoTien, UngLuong_TrangThaiXoa, UngLuong_GhiChu, UngLuong_NhanVien, UngLuong_KyCong)
VALUES
    (15, 2000.0, 'FALSE', N'Ứng lương giữa kỳ', (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Nguyễn Thị Hạ'), (SELECT KyCong_MaKyCong
        FROM KyCong
        WHERE KyCong_Nam = 2022 AND KyCong_Thang = 9));
INSERT INTO UngLuong
    (UngLuong_Ngay, UngLuong_SoTien, UngLuong_TrangThaiXoa, UngLuong_GhiChu, UngLuong_NhanVien, UngLuong_KyCong)
VALUES
    (15, 2500.0, 'TRUE', N'Ứng lương giữa kỳ', (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Huỳnh Văn Ba'), (SELECT KyCong_MaKyCong
        FROM KyCong
        WHERE KyCong_Nam = 2022 AND KyCong_Thang = 10));
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
    ( 13,
        2,
        (SELECT NhanVien_ID
        FROM dbo.NhanVien
        WHERE NhanVien_HoTen = N'Nguyễn Văn Phát'),
        (SELECT LoaiTangCa_ID
        FROM dbo.LoaiTangCa
        WHERE LoaiTangCa_TenLoai = N'Ngày Nghỉ'),
        (SELECT KyCong_MaKyCong
        FROM dbo.KyCong
        WHERE KyCong_Thang = 6 AND KyCong_Nam=2022)
),
    ( 15,
        4,
        (SELECT NhanVien_ID
        FROM dbo.NhanVien
        WHERE NhanVien_HoTen = N'Huỳnh Văn Bá'),
        2,
        (SELECT KyCong_MaKyCong
        FROM dbo.KyCong
        WHERE KyCong_Thang = 7 AND KyCong_Nam=2022)
),
    ( 10,
        1,
        (SELECT NhanVien_ID
        FROM dbo.NhanVien
        WHERE NhanVien_HoTen = N'Nguyễn Thị Hà'),
        (SELECT LoaiTangCa_ID
        FROM dbo.LoaiTangCa
        WHERE LoaiTangCa_TenLoai = N'Ca Tối'),
        (SELECT KyCong_MaKyCong
        FROM dbo.KyCong
        WHERE KyCong_Thang = 8 AND KyCong_Nam=2022)
),
    ( 15,
        2.5,
        (SELECT NhanVien_ID
        FROM dbo.NhanVien
        WHERE NhanVien_HoTen = N'Nguyễn Thị Hạ'),
        (SELECT LoaiTangCa_ID
        FROM dbo.LoaiTangCa
        WHERE LoaiTangCa_TenLoai = N'Ngày Lễ'),
        (SELECT KyCong_MaKyCong
        FROM dbo.KyCong
        WHERE KyCong_Thang = 9 AND KyCong_Nam=2022)
),
    ( 20,
        4,
        (SELECT NhanVien_ID
        FROM dbo.NhanVien
        WHERE NhanVien_HoTen = N'Huỳnh Văn Vũ'),
        (SELECT LoaiTangCa_ID
        FROM dbo.LoaiTangCa
        WHERE LoaiTangCa_TenLoai = N'Ngày Nghỉ'),
        (SELECT KyCong_MaKyCong
        FROM dbo.KyCong
        WHERE KyCong_Thang = 10 AND KyCong_Nam=2022)
),
    ( 28,
        1.5,
        (SELECT NhanVien_ID
        FROM dbo.NhanVien
        WHERE NhanVien_HoTen = N'Nguyễn Văn Khánh'),
        (SELECT LoaiTangCa_ID
        FROM dbo.LoaiTangCa
        WHERE LoaiTangCa_TenLoai = N'Ca Tối'),
        (SELECT KyCong_MaKyCong
        FROM dbo.KyCong
        WHERE KyCong_Thang = 11 AND KyCong_Nam=2022)
),
    ( 1,
        3,
        (SELECT NhanVien_ID
        FROM dbo.NhanVien
        WHERE NhanVien_HoTen = N'Nguyễn Văn Ba'),
        (SELECT LoaiTangCa_ID
        FROM dbo.LoaiTangCa
        WHERE LoaiTangCa_TenLoai = N'Ngày Lễ'),
        (SELECT KyCong_MaKyCong
        FROM dbo.KyCong
        WHERE KyCong_Thang = 12 AND KyCong_Nam=2022)
),
    ( 10,
        0,
        (SELECT NhanVien_ID
        FROM dbo.NhanVien
        WHERE NhanVien_HoTen = N'Nguyễn Công Huynh'),
        1,
        (SELECT KyCong_MaKyCong
        FROM dbo.KyCong
        WHERE KyCong_Thang = 1 AND KyCong_Nam=2023)
),
    ( 13,
        3.5,
        (SELECT NhanVien_ID
        FROM dbo.NhanVien
        WHERE NhanVien_HoTen = N'Lý Tiến Thành'),
        2,
        (SELECT KyCong_MaKyCong
        FROM dbo.KyCong
        WHERE KyCong_Thang = 3 AND KyCong_Nam=2023)
),
    ( 21,
        3,
        (SELECT NhanVien_ID
        FROM dbo.NhanVien
        WHERE NhanVien_HoTen = N'Mai Thành Chung'),
        (SELECT LoaiTangCa_ID
        FROM dbo.LoaiTangCa
        WHERE LoaiTangCa_TenLoai = N'Ca Tối'),
        (SELECT KyCong_MaKyCong
        FROM dbo.KyCong
        WHERE KyCong_Thang = 4 AND KyCong_Nam=2023)
),
    ( 11,
        3.5,
        (SELECT NhanVien_ID
        FROM dbo.NhanVien
        WHERE NhanVien_HoTen = N'Mai Trọng Khánh'),
        (SELECT LoaiTangCa_ID
        FROM dbo.LoaiTangCa
        WHERE LoaiTangCa_TenLoai = N'Ngày Lễ'),
        (SELECT KyCong_MaKyCong
        FROM dbo.KyCong
        WHERE KyCong_Thang = 5 AND KyCong_Nam=2023)
)

GO

--Bảng Chức Vụ--
INSERT INTO dbo.ChucVu
    (
    ChucVu_ID,
    ChucVu_TenCV
    )
VALUES
    ( 1, -- ChucVu_ID - int
        N'Giám Đốc' -- ChucVu_TenCV - nvarchar(50)
    ),
    ( 2, -- ChucVu_ID - int
        N'Phó Giám Đốc Hành Chính' -- ChucVu_TenCV - nvarchar(50)
    ),
    ( 3, -- ChucVu_ID - int
        N'Phó Giám Đốc Kinh Doanh' -- ChucVu_TenCV - nvarchar(50)
    ),
    ( 4, -- ChucVu_ID - int
        N'Trưởng Phòng Hành Chính' -- ChucVu_TenCV - nvarchar(50)
    ),
    ( 5, -- ChucVu_ID - int
        N'Trưởng Phòng Tài Chính' -- ChucVu_TenCV - nvarchar(50)
    ),
    ( 6, -- ChucVu_ID - int
        N'Trưởng Phòng Kế Hoạch' -- ChucVu_TenCV - nvarchar(50)
    ),
    ( 7, -- ChucVu_ID - int
        N'Trưởng Nhóm' -- ChucVu_TenCV - nvarchar(50)
    ),
    ( 8, -- ChucVu_ID - int
        N'Nhân Viên' -- ChucVu_TenCV - nvarchar(50)
    )
GO

-- ============================================ HÀM VÀ THỦ TỤC ====================================================
-- KyCong
CREATE PROC ThemKyCong(@Nam VARCHAR(5),
    @Thang VARCHAR(2),
    @KetQua INT OUTPUT)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        INSERT INTO KyCong
        (KyCong_Nam, KyCong_Thang, KyCong_SoNgayCong, KyCong_TrangThaiXoa)
    VALUES
        (@Nam, @Thang, dbo.SoNgayCong(@Nam, @Thang), 0)
        COMMIT TRANSACTION
        SELECT @KetQua = KyCong_MaKyCong
    FROM KyCong
    WHERE KyCong_Nam = @Nam AND KyCong_Thang = @Thang
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
        ROLLBACK TRANSACTION
    END
        SET @KetQua = -1;
        THROW 51000,'Loi Them Ky Cong',1;
    END CATCH
END
GO

CREATE PROC CapNhatKyCong(@MaKyCong INT,
    @Nam INT,
    @Thang INT,
    @KetQua INT OUTPUT)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        UPDATE KyCong SET KyCong_Nam = @Nam, KyCong_Thang = @Thang WHERE KyCong_MaKyCong = @MaKyCong
        COMMIT TRANSACTION
        SET @KetQua = 1
    END TRY
    BEGIN CATCH
    IF @@TRANCOUNT > 0
    BEGIN
        ROLLBACK TRANSACTION
    END
    SET @KetQua = 0;
    THROW 51000,'Loi Cap Nhat Ky Cong',1;
    END CATCH
END
GO

CREATE PROC CapNhatTrangThaiKyCong(@Nam VARCHAR(5),
    @Thang VARCHAR(2),
    @KetQua INT OUTPUT)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        DECLARE @TrangThai INT
        SELECT @TrangThai = KyCong_TrangThaiXoa
    FROM KyCong
    WHERE KyCong_Nam = CONVERT(INT, @Nam) AND KyCong_Thang = CONVERT(INT, @Thang)
        UPDATE KyCong SET KyCong_TrangThaiXoa = CASE WHEN @TrangThai = 1 THEN 0 ELSE 1 END WHERE KyCong_Nam = CONVERT(INT, @Nam) AND KyCong_Thang = CONVERT(INT, @Thang)
        COMMIT TRANSACTION
        SET @KetQua = 1
    END TRY
    BEGIN CATCH
    IF @@TRANCOUNT > 0
    BEGIN
        ROLLBACK TRANSACTION
    END
    SET @KetQua = 0;
    THROW 51000,'Loi Cap Nhat Trang Thai Ky Cong',1;
    END CATCH
END
GO
-- KyCongChiTiet
CREATE PROC ThongKeCong(@KyCong INT,
    @ThaoTac INT,
    @KetQua INT OUTPUT)
AS
BEGIN
    DECLARE @ThongKeChiTiet TABLE (MaNhanVien INT,
        MaKyCong INT,
        HoVaTen NVARCHAR(50),
        Day1 CHAR(2),
        Day2 CHAR(2),
        Day3 CHAR(2),
        Day4 CHAR(2),
        Day5 CHAR(2),
        Day6 CHAR(2),
        Day7 CHAR(2),
        Day8 CHAR(2),
        Day9 CHAR(2),
        Day10 CHAR(2),
        Day11 CHAR(2),
        Day12 CHAR(2),
        Day13 CHAR(2),
        Day14 CHAR(2),
        Day15 CHAR(2),
        Day16 CHAR(2),
        Day17 CHAR(2),
        Day18 CHAR(2),
        Day19 CHAR(2),
        Day20 CHAR(2),
        Day21 CHAR(2),
        Day22 CHAR(2),
        Day23 CHAR(2),
        Day24 CHAR(2),
        Day25 CHAR(2),
        Day26 CHAR(2),
        Day27 CHAR(2),
        Day28 CHAR(2),
        Day29 CHAR(2),
        Day30 CHAR(2),
        Day31 CHAR(2),
        SoNgayLam INT,
        SoNgayDiLam INT,
        SoNgayNghi INT,
        SoNgayCN INT,
        TongCong INT)

    DECLARE @SoNgay INT, @Thang VARCHAR(2), @Nam VARCHAR(5), @SoNV INT, @NhanVienID INT, @Dem INT, @Check VARCHAR(50), @Giatri CHAR(2), @NgayCN INT, @NgayThuong INT

    SELECT @Thang = RIGHT('0' + CONVERT(varchar(2), KyCong_Thang), 2), @Nam = CONVERT(varchar(5), KyCong_Nam)
    FROM KyCong
    WHERE KyCong_MaKyCong = @KyCong
    SET @SoNgay = dbo.soNgayTrongThang(@Nam, @Thang)
    SELECT @SoNV = COUNT(DISTINCT ChamCong_NhanVien), @NhanVienID = MIN(ChamCong_NhanVien)
    FROM ChamCong
    WHERE ChamCong_KyCong = @KyCong
    while @NhanVienID is not null
    BEGIN
        INSERT INTO @ThongKeChiTiet
            (MaNhanVien, MaKyCong, HoVaTen)
        VALUES
            (@NhanVienID, @KyCong, (SELECT NhanVien_HoTen
                FROM NhanVien
                WHERE NhanVien_ID = @NhanVienID))
        SET @Dem = 1
        SET @NgayCN = 0
        SET @NgayThuong = 0
        while @Dem <= @SoNgay
        BEGIN
            SET @Giatri = NULL
            SELECT @Check = ChamCong_GioChamCong
            FROM ChamCong
            WHERE ChamCong_NhanVien = @NhanVienID AND ChamCong_KyCong = @KyCong AND ChamCong_Ngay = @Dem
            IF @Check != ''
                BEGIN
                IF dbo.KT_NgayTrongTuan(@Nam, @Thang, RIGHT('0'+CONVERT(VARCHAR(2), @Dem), 2)) = 1
                    BEGIN
                    SET @NgayCN = @NgayCN + 1
                    SET @Giatri = 'CN'
                END
                    ELSE
                    BEGIN
                    SET @NgayThuong = @NgayThuong + 1
                    SET @Giatri = 'X'
                END

            END
            ELSE
                BEGIN
                SET @Giatri = 'V'
            END
            UPDATE @ThongKeChiTiet SET 
                    Day1 = CASE WHEN @Dem = 1 THEN @Giatri ELSE Day1 END, Day2 = CASE WHEN @Dem = 2 THEN @Giatri ELSE Day2 END, Day3 = CASE WHEN @Dem = 3 THEN @Giatri ELSE Day3 END,
                    Day4 = CASE WHEN @Dem = 4 THEN @Giatri ELSE Day4 END, Day5 = CASE WHEN @Dem = 5 THEN @Giatri ELSE Day5 END, Day6 = CASE WHEN @Dem = 6 THEN @Giatri ELSE Day6 END,
                    Day7 = CASE WHEN @Dem = 7 THEN @Giatri ELSE Day7 END, Day8 = CASE WHEN @Dem = 8 THEN @Giatri ELSE Day8 END, Day9 = CASE WHEN @Dem = 9 THEN @Giatri ELSE Day9 END,
                    Day10 = CASE WHEN @Dem = 10 THEN @Giatri ELSE Day10 END, Day11 = CASE WHEN @Dem = 11 THEN @Giatri ELSE Day11 END, Day12 = CASE WHEN @Dem = 12 THEN @Giatri ELSE Day12 END,
                    Day13 = CASE WHEN @Dem = 13 THEN @Giatri ELSE Day13 END, Day14 = CASE WHEN @Dem = 14 THEN @Giatri ELSE Day14 END, Day15 = CASE WHEN @Dem = 15 THEN @Giatri ELSE Day15 END,
                    Day16 = CASE WHEN @Dem = 16 THEN @Giatri ELSE Day16 END, Day17 = CASE WHEN @Dem = 17 THEN @Giatri ELSE Day17 END, Day18 = CASE WHEN @Dem = 18 THEN @Giatri ELSE Day18 END,
                    Day19 = CASE WHEN @Dem = 19 THEN @Giatri ELSE Day19 END, Day20 = CASE WHEN @Dem = 20 THEN @Giatri ELSE Day20 END, Day21 = CASE WHEN @Dem = 21 THEN @Giatri ELSE Day21 END,
                    Day22 = CASE WHEN @Dem = 22 THEN @Giatri ELSE Day22 END, Day23 = CASE WHEN @Dem = 23 THEN @Giatri ELSE Day23 END, Day24 = CASE WHEN @Dem = 24 THEN @Giatri ELSE Day24 END,
                    Day25 = CASE WHEN @Dem = 25 THEN @Giatri ELSE Day25 END, Day26 = CASE WHEN @Dem = 26 THEN @Giatri ELSE Day26 END, Day27 = CASE WHEN @Dem = 27 THEN @Giatri ELSE Day27 END,
                    Day28 = CASE WHEN @Dem = 28 THEN @Giatri ELSE Day28 END, Day29 = CASE WHEN @Dem = 29 THEN @Giatri ELSE Day29 END, Day30 = CASE WHEN @Dem = 30 THEN @Giatri ELSE Day30 END,
                    Day31 = CASE WHEN @Dem = 31 THEN @Giatri ELSE Day31 END
                    WHERE MaNhanVien = @NhanVienID
            SET @Dem = @Dem + 1
        END
        UPDATE @ThongKeChiTiet SET 
            SoNgayLam = (SELECT KyCong_SoNgayCong
        FROM KyCong
        WHERE KyCong_MaKyCong = @KyCong),
            SoNgayDiLam = @NgayThuong,
            SoNgayNghi = (SELECT KyCong_SoNgayCong
        FROM KyCong
        WHERE KyCong_MaKyCong = @KyCong) - @NgayThuong,
            SoNgayCN = @NgayCN,
            TongCong = @NgayThuong + @NgayCN
            WHERE MaNhanVien = @NhanVienID
        SELECT @NhanVienID = MIN(ChamCong_NhanVien)
        FROM ChamCong
        WHERE ChamCong_NhanVien > @NhanVienID
    END
    SELECT *
    FROM @ThongKeChiTiet
    IF @ThaoTac = 0
    BEGIN
        BEGIN TRANSACTION
        BEGIN TRY
            INSERT INTO KyCongChiTiet
            (KyCongChiTiet_NhanVien, KyCongChiTiet_KyCong, KyCongChiTiet_NgayNghi, KyCongChiTiet_CongChuNhat, KyCongChiTiet_NgayCongThucTe)
        SELECT MaNhanVien, MaKyCong, SoNgayNghi, SoNgayCN, SoNgayDiLam
        FROM @ThongKeChiTiet
            COMMIT TRANSACTION
            SET @KetQua = 1
        END TRY
        BEGIN CATCH
            IF(@@TRANCOUNT > 0)
            BEGIN
            ROLLBACK TRANSACTION
        END
            SET @KetQua = 0;
            THROW 51000,'Loi Khong The Them Data Vao Bang Ky Cong Chi Tiet',1;
        END CATCH
    END
    ELSE
    BEGIN
        IF @ThaoTac = 1
        BEGIN
            BEGIN TRANSACTION
            BEGIN TRY
                UPDATE KyCongChiTiet SET KyCongChiTiet_NgayNghi = B.SoNgayNghi, KyCongChiTiet_CongChuNhat = B.SoNgayCN, KyCongChiTiet_NgayCongThucTe = B.SoNgayDiLam
                FROM KyCongChiTiet AS A INNER JOIN @ThongKeChiTiet AS B ON A.KyCongChiTiet_NhanVien = B.MaNhanVien AND A.KyCongChiTiet_KyCong = B.MaKyCong
                COMMIT TRANSACTION
                SET @KetQua = 1
            END TRY
            BEGIN CATCH
                IF(@@TRANCOUNT > 0)
                BEGIN
                ROLLBACK TRANSACTION
            END
                SET @KetQua = 0;
                THROW 51000,'Loi Khong The Cap Nhat Bang Ky Cong Chi Tiet',1;
            END CATCH
        END
    END
END
GO

CREATE PROC XoaKCCT(@MaKyCong INT,
    @KetQua INT OUTPUT)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        DELETE FROM KyCongChiTiet WHERE KyCongChiTiet_KyCong = @MaKyCong
        COMMIT TRANSACTION
        SET @KetQua = 1
    END TRY
    BEGIN CATCH
    IF @@TRANCOUNT > 0
        BEGIN
        ROLLBACK TRANSACTION
    END
    SET @KetQua = 0;
    THROW 51000,'Loi Khong The Xoa Ky Cong Chi Tiet',1;
    END CATCH
END
GO


-- ChamCong
CREATE PROC PhatSinhKyCong
    (@KyCong INT)
AS
BEGIN
    declare @idNhanVien int, @DemNgay INT, @SoNgay INT, @Thang VARCHAR(2), @Nam VARCHAR(5)
    SELECT @Thang = RIGHT('0' + CONVERT(varchar(2), KyCong_Thang), 2), @Nam = CONVERT(varchar(5), KyCong_Nam)
    FROM KyCong
    WHERE KyCong_MaKyCong = @KyCong
    SET @SoNgay = dbo.SoNgayTrongThang(@Nam, @Thang)
    select @idNhanVien = min( NhanVien_ID )
    from NhanVien
    while @idNhanVien is not null
    begin
        SET @DemNgay = 1
        while @DemNgay <= @SoNgay
        BEGIN
            INSERT INTO ChamCong
                (ChamCong_Ngay, ChamCong_GioChamCong, ChamCong_NhanVien, ChamCong_KyCong)
            VALUES
                (@DemNgay, '' , @idNhanVien, @KyCong)
            SET @DemNgay = @DemNgay + 1
        END
        select @idNhanVien = min( NhanVien_ID )
        from NhanVien
        where NhanVien_ID > @idNhanVien
    end
END;
GO

CREATE PROC XoaChamCong(@MaKyCong INT,
    @KetQua INT OUTPUT)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        DELETE FROM ChamCong WHERE ChamCong_KyCong = @MaKyCong
        COMMIT TRANSACTION
        SET @KetQua = 1
    END TRY
    BEGIN CATCH
    IF @@TRANCOUNT > 0
        BEGIN
        ROLLBACK TRANSACTION
    END
    SET @KetQua = 0;
    THROW 51000,'Loi Khong Them Xoa Du Lieu Bang Cham Cong',1;
    END CATCH
END
GO

CREATE PROC CapNhatChamCong(@NhanVien INT,
    @KyCong INT,
    @Ngay VARCHAR(2),
    @GiaTri VARCHAR(5),
    @KetQua INT OUTPUT)
AS
BEGIN
    BEGIN TRANSACTION
    IF(@GiaTri = '')
    BEGIN;
        THROW 51000,'Loi Khong The Cap Nhat Bang Cham Cong',1;
    END
    ELSE
    BEGIN
        BEGIN TRY
        UPDATE ChamCong SET ChamCong_GioChamCong = @GiaTri WHERE ChamCong_Ngay = @Ngay AND ChamCong_NhanVien = @NhanVien AND ChamCong_KyCong = @KyCong
        SET @KetQua = 1
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
    IF(@@TRANCOUNT > 0)
    BEGIN
            ROLLBACK TRANSACTION
        END
    SET @KetQua = 0;
    END CATCH
    END
END
GO
--Hàm
CREATE FUNCTION Find_MaKyCong(@Nam VARCHAR(5), @Thang VARCHAR(2))
RETURNS INT
AS
BEGIN
    DECLARE @ma INT
    SELECT @ma = KyCong_MaKyCong
    FROM KyCong
    WHERE KyCong_Nam = CONVERT(INT, @Nam) AND KyCong_Thang = CONVERT(INT, @Thang)
    RETURN @ma
END
GO

CREATE FUNCTION KT_PhatSinhKyCong(@KyCong_ID INT)
RETURNS INT
AS
BEGIN
    DECLARE @Check INT
    SELECT @Check = ChamCong_KyCong
    FROM ChamCong
    WHERE ChamCong_KyCong = @KyCong_ID
    IF @Check IS NOT NULL
    SET @Check = 1
    ELSE
    SET @Check = 0
    RETURN @Check
END
GO


CREATE FUNCTION KT_NgayTrongTuan (@Nam VARCHAR(5), @Thang VARCHAR(2), @Ngay VARCHAR(2))
RETURNS INT
AS
BEGIN
    RETURN DATEPART(w, @Nam + '-' + @Thang + '-' + @Ngay)
END
GO

CREATE FUNCTION SoNgayTrongThang(@Nam VARCHAR(5), @Thang VARCHAR(2))
RETURNS INT
AS
BEGIN
    DECLARE @SoNgay INT
    SET @SoNgay = DAY(EOMONTH(@Nam + @Thang + '01'))
    RETURN @SoNgay
END
GO

CREATE FUNCTION SoNgayCong(@Nam VARCHAR(5), @Thang VARCHAR(2))
RETURNS INT
AS
BEGIN
    DECLARE @SoNgayTrongThang INT, @SoCN INT, @Dem INT
    SET @SoNgayTrongThang = dbo.SoNgayTrongThang(@Nam, @Thang)
    SET @SoCN = 0
    SET @Dem = 1
    while @Dem <= @SoNgayTrongThang
    BEGIN
        IF dbo.KT_NgayTrongTuan(@Nam, @Thang, RIGHT('0'+CONVERT(VARCHAR(2), @Dem), 2)) = 1
        BEGIN
            SET @SoCN = @SoCN + 1
        END
        SET @Dem = @Dem + 1
    END
    RETURN @SoNgayTrongThang - @SoCN
END
GO

CREATE FUNCTION TK_KyCong(@Nam VARCHAR(5), @Thang VARCHAR(2))
RETURNS INT
AS
BEGIN
    DECLARE @MaKyCong INT, @TrangThaiXoa BIT
    SELECT @MaKyCong = KyCong_MaKyCong, @TrangThaiXoa = KyCong_TrangThaiXoa
    FROM KyCong
    WHERE KyCong_Nam = CONVERT(INT, @Nam) AND KyCong_Thang = CONVERT(INT, @Thang)
    IF @MaKyCong IS NOT NULL
        BEGIN
        IF @TrangThaiXoa = 1
            BEGIN
            RETURN -1
        -- tồn tại ở trạng thái xóa
        END
        RETURN @MaKyCong
    -- đã tồn tại ở trạng thái chưa xóa
    END
    RETURN -2
-- Không tìm thấy
END
GO
-- LoaiTangCa
CREATE PROCEDURE sp_ThemMoiLoaiTangCa
    @LoaiTangCa_TenLoai NVARCHAR(20),
    @LoaiTangCa_HeSo FLOAT
AS
BEGIN
    INSERT INTO LoaiTangCa
        ( LoaiTangCa_TenLoai, LoaiTangCa_HeSo)
    VALUES
        ( @LoaiTangCa_TenLoai, @LoaiTangCa_HeSo)
END
GO

CREATE PROCEDURE sp_XoaLoaiTangCa
    @LoaiTangCa_ID INT
AS
BEGIN
    DELETE FROM LoaiTangCa
    WHERE LoaiTangCa_ID = @LoaiTangCa_ID
END
GO

CREATE PROCEDURE sp_SuaLoaiTangCa
    @LoaiTangCa_ID INT,
    @LoaiTangCa_TenLoai NVARCHAR(20),
    @LoaiTangCa_HeSo FLOAT
AS
BEGIN
    UPDATE LoaiTangCa
    SET LoaiTangCa_TenLoai = @LoaiTangCa_TenLoai, LoaiTangCa_HeSo = @LoaiTangCa_HeSo
    WHERE LoaiTangCa_ID = @LoaiTangCa_ID
END
GO

-- ChucVu
CREATE PROCEDURE sp_ThemMoiChucVu
    @ChucVu_TenCV NVARCHAR(50)
AS
BEGIN
    INSERT INTO ChucVu
        ( ChucVu_TenCV)
    VALUES
        ( @ChucVu_TenCV)
END
GO

CREATE PROCEDURE sp_XoaChucVu
    @ChucVu_ID INT
AS
BEGIN
    DELETE FROM ChucVu
    WHERE ChucVu_ID = @ChucVu_ID
END
GO

CREATE PROCEDURE sp_SuaChucVu
    @ChucVu_ID INT,
    @ChucVu_TenCV NVARCHAR(50)
AS
BEGIN
    UPDATE ChucVu
    SET ChucVu_TenCV = @ChucVu_TenCV
    WHERE ChucVu_ID = @ChucVu_ID
END
GO

-- PhongBan
CREATE PROCEDURE sp_XoaPhongBan
    (
    @MaPB INT
)
AS
BEGIN
    DELETE FROM PhongBan WHERE PhongBan_MaPB = @MaPB;
END
GO

CREATE PROCEDURE sp_ThemPhongBan
    (
    @TenPB NVARCHAR(50),
    @TruongPhong INT,
    @TG_NhanChuc DATE
)
AS
BEGIN
    INSERT INTO PhongBan
        (PhongBan_TenPB, PhongBan_TruongPhong, PhongBan_TG_NhanChuc)
    VALUES
        (@TenPB, @TruongPhong, @TG_NhanChuc);
END
GO

CREATE PROCEDURE sp_CapNhatPhongBan
    (
    @MaPB INT,
    @TenPB NVARCHAR(50),
    @TruongPhong INT,
    @TG_NhanChuc DATE
)
AS
BEGIN
    UPDATE PhongBan SET
        PhongBan_TenPB = @TenPB,
        PhongBan_TruongPhong = @TruongPhong,
        PhongBan_TG_NhanChuc = @TG_NhanChuc
    WHERE PhongBan_MaPB = @MaPB;
END
GO

-- tìm kiếm loai tăng ca
CREATE PROCEDURE TimKiemLoaiTangCa
    @timKiem nvarchar(20)
AS
BEGIN
    BEGIN TRY
        SELECT *
    FROM LoaiTangCa
    WHERE LoaiTangCa_ID = @timKiem 
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE()
    END CATCH
END
GO

-- tìm kiếm phòng ban
CREATE PROCEDURE TimKiemPhongBan
    @maPB int
AS
BEGIN
    BEGIN TRY
        SELECT *
    FROM PhongBan
    WHERE PhongBan_MaPB = @maPB
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE()
    END CATCH
END
GO

-- Tìm kiếm chức vụ
CREATE PROCEDURE TimKiemChucVu
    @chucVu_ID int
AS
BEGIN
    BEGIN TRY
        SELECT *
    FROM ChucVu
    WHERE ChucVu_ID = @chucVu_ID
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE()
    END CATCH
END
GO

-- ThongKeNhanVienTheoPhongBan
CREATE PROCEDURE ThongKeNhanVienTheoPhongBan
    @MaPB INT
AS
BEGIN
    BEGIN TRY
        SELECT NhanVien_ID, NhanVien_HoTen, NhanVien_SDT, NhanVien_CCCD, NhanVien_GioiTinh, NhanVien_HinhAnh, NhanVien_DiaChi, NhanVien_NgaySinh, NhanVien_ChucVu
    FROM NhanVien
    WHERE NhanVien_PhongBan = @MaPB AND NhanVien_TrangThaiXoa = 0
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE()
    END CATCH
END
GO

--Thêm hợp đồng
CREATE PROCEDURE ThemHopDong
    @NgayBatDau DATE,
    @NgayKetThuc DATE,
    @LanKy INT,
    @NoiDung NVARCHAR(50),
    @LuongCanBan FLOAT,
    @HeSoLuong INT,
    @NhanVien INT
AS
BEGIN
    SET IDENTITY_INSERT HopDong ON
    INSERT INTO HopDong
        ( HopDong_NgayBatDau ,HopDong_NgayKetThuc ,
        HopDong_LanKy , HopDong_NoiDung , HopDong_LuongCanBan ,HopDong_HeSoLuong ,HopDong_NhanVien)
    VALUES
        (@NgayBatDau,
            @NgayKetThuc,
            @LanKy,
            @NoiDung ,
            @LuongCanBan,
            @HeSoLuong,
            @NhanVien);
    SET IDENTITY_INSERT HopDong OFF
END
GO

-- Xóa hợp đồng
CREATE PROCEDURE XoaHopDong
    @SoHD INT
AS
BEGIN
    DELETE FROM HopDong WHERE HopDong_SoHD = @SoHD;
END;
GO

--Sửa hợp đồng
CREATE PROCEDURE SuaHopDong
    @SoHD INT,
    @NgayBatDau DATE,
    @NgayKetThuc DATE,
    @LanKy INT,
    @NoiDung NVARCHAR(50),
    @LuongCanBan FLOAT,
    @HeSoLuong INT,
    @NhanVien INT
AS
BEGIN
    UPDATE HopDong 
    SET HopDong_NgayBatDau = @NgayBatDau,
        HopDong_NgayKetThuc = @NgayKetThuc,
        HopDong_LanKy = @LanKy,
        HopDong_NoiDung = @NoiDung,
        HopDong_LuongCanBan = @LuongCanBan,
        HopDong_HeSoLuong = @HeSoLuong,
        HopDong_NhanVien = @NhanVien
    WHERE HopDong_SoHD = @SoHD;
END;
GO

--tìm số Hợp đồng lớn nhất
CREATE PROCEDURE TimHopDongLonNhat
AS
BEGIN
    SELECT MAX(HopDong_SoHD) AS HopDong_LonNhat
    FROM HopDong;
END;
GO

-- Hàm thủ tục thêm một bản ghi vào bảng HeSoLuong
CREATE PROCEDURE sp_ThemHeSoLuong
    @HeSoLuong_Ten NVARCHAR(10),
    @HeSoLuong_GiaTri FLOAT
AS
BEGIN
    BEGIN TRY
        INSERT INTO HeSoLuong
        (HeSoLuong_Ten, HeSoLuong_GiaTri)
    VALUES
        (@HeSoLuong_Ten, @HeSoLuong_GiaTri);
        PRINT 'Thêm thành công';
    END TRY
    BEGIN CATCH
        PRINT 'Thêm thất bại';
        PRINT ERROR_MESSAGE();
    END CATCH
END;
GO

-- Hàm thủ tục xóa một bản ghi khỏi bảng HeSoLuong theo HeSoLuong_ID
CREATE PROCEDURE sp_XoaHeSoLuong
    @HeSoLuong_ID INT
AS
BEGIN
    BEGIN TRY
        DELETE FROM HeSoLuong WHERE HeSoLuong_ID = @HeSoLuong_ID;
        PRINT 'Xóa thành công';
    END TRY
    BEGIN CATCH
        PRINT 'Xóa thất bại';
        PRINT ERROR_MESSAGE();
    END CATCH
END;
GO

-- Hàm thủ tục sửa một bản ghi trong bảng HeSoLuong theo HeSoLuong_ID
CREATE PROCEDURE sp_SuaHeSoLuong
    @HeSoLuong_ID INT,
    @HeSoLuong_Ten NVARCHAR(10),
    @HeSoLuong_GiaTri FLOAT
AS
BEGIN
    BEGIN TRY
        UPDATE HeSoLuong SET HeSoLuong_Ten = @HeSoLuong_Ten, HeSoLuong_GiaTri = @HeSoLuong_GiaTri WHERE HeSoLuong_ID = @HeSoLuong_ID;
        PRINT 'Sửa thành công';
    END TRY
    BEGIN CATCH
        PRINT 'Sửa thất bại';
        PRINT ERROR_MESSAGE();
    END CATCH
END;
GO

-- UngLuong
CREATE FUNCTION UngLuong_HienThi()
RETURNS TABLE
AS
RETURN (
    SELECT ul.UngLuong_ID, ul.UngLuong_Ngay, ul.UngLuong_SoTien, ul.UngLuong_TrangThaiXoa, ul.UngLuong_GhiChu, nv.NhanVien_HoTen, kc.KyCong_Nam, kc.KyCong_Thang
FROM UngLuong ul
    INNER JOIN KyCong kc ON kc.KyCong_MaKyCong = ul.UngLuong_KyCong
    INNER JOIN NhanVien nv ON nv.NhanVien_ID = ul.UngLuong_NhanVien
WHERE ul.UngLuong_TrangThaiXoa = 0
)
GO

CREATE PROC [ungluongtheoid]
    @ma_id INT
AS
SELECT *
FROM UngLuong_HienThi() ul
WHERE ul.UngLuong_ID=@ma_id 
GO
CREATE PROC [LayThongtinUngLuong]
AS
SELECT *
FROM dbo.UngLuong_HienThi()
GO

CREATE PROCEDURE [ThemUngLuong]
    @ngay INT,
    @tien FLOAT,
    @ghichu NVARCHAR(50),
    @nhanvien NVARCHAR(50),
    @nam INT,
    @thang INT,
    @ketqua INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @nhanvien_id INT, @kycong_makycon INT

    SELECT @nhanvien_id = NhanVien_ID
    FROM NhanVien
    WHERE NhanVien_HoTen = @nhanvien
    SELECT @kycong_makycon = kc.KyCong_MaKyCong
    FROM KyCong kc
    WHERE kc.KyCong_Nam = @nam AND kc.KyCong_Thang = @thang

    IF NOT EXISTS(SELECT *
    FROM UngLuong
    WHERE UngLuong_Ngay = @ngay AND UngLuong_NhanVien = @nhanvien_id AND UngLuong_KyCong = @kycong_makycon)
    BEGIN
        BEGIN TRANSACTION;

        BEGIN TRY
            INSERT INTO UngLuong
            (UngLuong_Ngay, UngLuong_SoTien, UngLuong_TrangThaiXoa, UngLuong_GhiChu, UngLuong_NhanVien, UngLuong_KyCong)
        VALUES
            (
                @ngay,
                @tien,
                0,
                @ghichu,
                @nhanvien_id,
                @kycong_makycon
            );
			SET @ketqua=1;
            COMMIT TRANSACTION;
        END TRY

        BEGIN CATCH
            ROLLBACK TRANSACTION;
			SET @ketqua=0;

        END CATCH
    END
END

GO
CREATE PROC [SuaUngLuong]
    @id INT,
    @ngay INT,
    @tien FLOAT,
    @ghichu NVARCHAR(50),
    @nhanvien NVARCHAR(50),
    @nam INT,
    @thang INT
AS
UPDATE UngLuong
 SET UngLuong_Ngay = @ngay, 
 UngLuong_SoTien=@tien, 
 UngLuong_GhiChu = @ghichu, 
 UngLuong_NhanVien = (SELECT NhanVien_ID
FROM NhanVien
WHERE NhanVien_HoTen = @nhanvien),
 UngLuong_KyCong = (SELECT kc.KyCong_MaKyCong
FROM KyCong kc
WHERE kc.KyCong_Nam = @nam AND kc.KyCong_Thang = @thang)
 WHERE UngLuong_ID = @id
GO

CREATE PROC [XoaUngLuong]
    @id INT
AS
UPDATE UngLuong
SET UngLuong_TrangThaiXoa = 1 WHERE UngLuong_ID = @id
GO

CREATE PROC [LuuXoaUngLuong]
    @id INT
AS
IF EXISTS(SELECT *
FROM UngLuong
WHERE UngLuong_ID = @id AND UngLuong_TrangThaiXoa = 1)
BEGIN
    DELETE FROM UngLuong WHERE UngLuong_ID = @id AND UngLuong_TrangThaiXoa = 1
END
GO

CREATE PROC [HuyXoaUngLuong]
    @id INT
AS
UPDATE UngLuong
SET UngLuong_TrangThaiXoa = 0 WHERE UngLuong_ID = @id
GO

-- TangCa
CREATE FUNCTION TangCa_HienThi()
RETURNS TABLE
AS
RETURN (
    SELECT TC.TangCa_ID, TC.TangCa_NgayTangCa, TC.TangCa_SoGio, NV.NhanVien_HoTen, LTC.LoaiTangCa_TenLoai, kc.KyCong_Thang, kc.KyCong_Nam
FROM TangCa TC
    INNER JOIN NhanVien NV ON TC.TangCa_NhanVien = NV.NhanVien_ID
    INNER JOIN LoaiTangCa LTC ON TC.TangCa_LoaiTangCa = LTC.LoaiTangCa_ID
    INNER JOIN KyCong kc ON kc.KyCong_MaKyCong = TC.TangCa_KyCong
)
GO
CREATE PROC LayThongtinTangCa
AS
SELECT *
FROM dbo.TangCa_HienThi() tc
GO

CREATE PROC [SuaTangCa]
    @id INT,
    @ngay INT,
    @gio FLOAT,
    @tennv NVARCHAR(50),
    @tenloaitc NVARCHAR(50),
    @thangkycong INT,
    @namkycong INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @nhanvien_id INT;
    DECLARE @loaitc_id INT;
    -- Kiểm tra xem có bản ghi nào trong bảng TangCa trùng với các giá trị truyền vào không
    IF EXISTS (SELECT *
    FROM TangCa
    WHERE TangCa_NgayTangCa = @ngay
        AND TangCa_NhanVien = (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen = @tennv)
        AND TangCa_KyCong = (SELECT kc.KyCong_MaKyCong
        FROM KyCong kc
        WHERE kc.KyCong_Thang = @thangkycong AND kc.KyCong_Nam = @namkycong))
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
        UPDATE TangCa
        SET TangCa_NgayTangCa = @ngay, 
            TangCa_SoGio = @gio, 
            TangCa_NhanVien = (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen = @tennv), 
            TangCa_LoaiTangCa = (SELECT ltc.LoaiTangCa_ID
        FROM LoaiTangCa ltc
        WHERE ltc.LoaiTangCa_TenLoai = @tenloaitc),
            TangCa_KyCong = (SELECT kc.KyCong_MaKyCong
        FROM KyCong kc
        WHERE kc.KyCong_Thang = @thangkycong AND kc.KyCong_Nam = @namkycong)
        WHERE TangCa_ID = @id;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
    END

END
GO

CREATE PROC [tangcatheoid]
    @ma_id INT
AS
SELECT *
FROM dbo.TangCa_HienThi() tc
WHERE tc.TangCa_ID=@ma_id 
GO

CREATE PROCEDURE [ThemTangCa]
    @ngay INT,
    @gio FLOAT,
    @tennv NVARCHAR(50),
    @tenloaitc NVARCHAR(50),
    @thangkycong INT,
    @namkycong INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @nhanvien_id INT;
    DECLARE @loaitc_id INT;

    -- Kiểm tra xem dữ liệu đã tồn tại hay chưa
    IF EXISTS (SELECT *
    FROM TangCa
    WHERE TangCa_NgayTangCa = @ngay
        AND TangCa_NhanVien = (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen = @tennv)
        AND TangCa_KyCong = (SELECT kc.KyCong_MaKyCong
        FROM KyCong kc
        WHERE kc.KyCong_Thang = @thangkycong AND kc.KyCong_Nam = @namkycong))
    BEGIN;
        THROW 51000, 'Dữ liệu đã tồn tại',1;
        RETURN;
    END

    -- Lấy ID của loại tăng ca
    SELECT @loaitc_id = LoaiTangCa_ID
    FROM LoaiTangCa
    WHERE LoaiTangCa_TenLoai = @tenloaitc;
    IF(@loaitc_id IS NULL)
        THROW 50000, 'Không tìm thấy loại tăng ca', 1;

    BEGIN TRANSACTION;
    BEGIN TRY
        INSERT INTO TangCa
        (TangCa_NgayTangCa, TangCa_SoGio, TangCa_NhanVien, TangCa_LoaiTangCa, TangCa_KyCong)
    VALUES
        (
            @ngay,
            @gio,
            (SELECT NhanVien_ID
            FROM NhanVien
            WHERE NhanVien_HoTen = @tennv),
            @loaitc_id,
            (SELECT kc.KyCong_MaKyCong
            FROM KyCong kc
            WHERE kc.KyCong_Thang = @thangkycong AND kc.KyCong_Nam = @namkycong)
        );
        COMMIT TRANSACTION;
    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END

GO
CREATE PROC [XoaTangCa]
    @id INT
AS
DELETE FROM TangCa WHERE TangCa_ID = @id

GO

-- BangLuong
CREATE PROC TinhLuong
    @MaKyCong INT
AS
BEGIN
    DECLARE @NhanVienID INT, @SoNgayLyThuyet INT, @LuongCB FLOAT, @HeSoLuong FLOAT , @giotangca FLOAT
    DECLARE @ThucTe INT, @CongCN INT, @LuongUng FLOAT, @PhuCap FLOAT, @LuongNhanDuoc FLOAT, @LuongThucLanh FLOAT, @UngLuong FLOAT, @TangCa FLOAT, @LuongCN FLOAT, @LuongThuong FLOAT
    SET @PhuCap = 556
    SELECT @NhanVienID = MIN(KyCongChiTiet_NhanVien)
    FROM KyCongChiTiet
    WHERE KyCongChiTiet_KyCong = @MaKyCong
    SELECT @SoNgayLyThuyet = KyCong_SoNgayCong
    FROM KyCong
    WHERE KyCong_MaKyCong = @MaKyCong
    while @NhanVienID IS NOT NULL
    BEGIN
        SELECT @ThucTe = KyCongChiTiet_NgayCongThucTe, @CongCN = KyCongChiTiet_CongChuNhat
        FROM KyCongChiTiet
        WHERE KyCongChiTiet_KyCong = @MaKyCong AND KyCongChiTiet_NhanVien = @NhanVienID
        SELECT @LuongCB = HopDong_LuongCanBan, @HeSoLuong = HopDong_HeSoLuong
        FROM HopDong
        WHERE HopDong_NhanVien = @NhanVienID
        -- SELECT @SoGio = SUM(TangCa_SoGio) FROM TangCa WHERE TangCa_KyCong = @MaKyCong AND TangCa_NhanVien = @NhanVienID 
        SET @LuongThuong = @ThucTe * (@LuongCB * @HeSoLuong)/@SoNgayLyThuyet * 1000
        SET @LuongCN = COALESCE(@CongCN,0) * 2 * (@LuongCB * @HeSoLuong)/@SoNgayLyThuyet * 1000
        SELECT @UngLuong = COALESCE(SUM(ul.UngLuong_SoTien),0)
        FROM UngLuong ul
        WHERE ul.UngLuong_NhanVien = @NhanVienID AND ul.UngLuong_KyCong = @MaKyCong AND ul.UngLuong_TrangThaiXoa = 0
        SELECT @giotangca = COALESCE(SUM(tc.TangCa_SoGio*ltc.LoaiTangCa_HeSo),0)
        FROM TangCa tc, LoaiTangCa ltc
        WHERE tc.TangCa_NhanVien = @NhanVienID AND tc.TangCa_KyCong = @MaKyCong AND
            tc.TangCa_LoaiTangCa = ltc.LoaiTangCa_ID
        SET @TangCa = @giotangca * (@LuongCB * @HeSoLuong)/@SoNgayLyThuyet * 1000 / 8
        SET @LuongNhanDuoc = @LuongThuong + @LuongCN  + @PhuCap + @TangCa
        SET @LuongThucLanh = @LuongNhanDuoc * 0.895 - @UngLuong
        MERGE INTO BangLuong AS target
        USING (SELECT @NhanVienID AS BangLuong_NhanVien, @MaKyCong AS BangLuong_KyCong) AS source
        ON target.BangLuong_NhanVien = source.BangLuong_NhanVien AND target.BangLuong_KyCong = source.BangLuong_KyCong
        WHEN MATCHED THEN
             UPDATE SET BangLuong_LuongNgayThuong = @LuongThuong,
               BangLuong_LuongNgayCN = @LuongCN,
               BangLuong_TangCa = @TangCa,
               BangLuong_UngLuong = @UngLuong,
               BangLuong_PhuCap = @PhuCap,
               BangLuong_LuongNhanDuoc = @LuongNhanDuoc,
               BangLuong_ThucLanh = CEILING(@LuongThucLanh)
        WHEN NOT MATCHED THEN
            INSERT (BangLuong_NhanVien, BangLuong_KyCong, BangLuong_LuongNgayThuong, BangLuong_LuongNgayCN, BangLuong_TangCa, BangLuong_UngLuong, BangLuong_PhuCap, BangLuong_LuongNhanDuoc, BangLuong_ThucLanh)
            VALUES (@NhanVienID, @MaKyCong, @LuongThuong, @LuongCN, @TangCa, @UngLuong, @PhuCap, @LuongNhanDuoc, CEILING(@LuongThucLanh));

        SELECT @NhanVienID = MIN(KyCongChiTiet_NhanVien)
        FROM KyCongChiTiet
        WHERE KyCongChiTiet_NhanVien > @NhanVienID AND KyCongChiTiet_KyCong = @MaKyCong
    END
END
GO

CREATE FUNCTION Luong_HienThi(@Nam INT,@Thang INT)
RETURNS TABLE
AS
RETURN (
    SELECT nv.NhanVien_HoTen, kc.KyCong_Thang, kc.KyCong_Nam, bl.BangLuong_LuongNgayThuong, bl.BangLuong_LuongNgayCN, bl.BangLuong_TangCa, bl.BangLuong_UngLuong, bl.BangLuong_PhuCap, bl.BangLuong_LuongNhanDuoc, bl.BangLuong_ThucLanh
FROM BangLuong bl
    INNER JOIN NhanVien nv ON bl.BangLuong_NhanVien = nv.NhanVien_ID
    INNER JOIN KyCong kc ON kc.KyCong_MaKyCong = bl.BangLuong_KyCong
WHERE kc.KyCong_Nam = @Nam AND kc.KyCong_Thang = @Thang
)
GO

CREATE PROC hienthiluong
    @Nam INT ,
    @Thang INT
AS
SELECT *
FROM Luong_HienThi(@Nam,@Thang)
GO

CREATE PROC xoaluongtheokycong
    @MaKyCong INT
AS
BEGIN
    DELETE FROM BangLuong 
WHERE BangLuong_KyCong = @MaKyCong
END
GO

--Thêm mới nhân viên
CREATE PROCEDURE ThemNhanVien
    @HoTen NVARCHAR(50),
    @SDT CHAR(10),
    @CCCD CHAR(12),
    @GioiTinh NVARCHAR(3),
    @HinhAnh IMAGE,
    @DiaChi NVARCHAR(50),
    @NgaySinh DATE,
    @ChucVu INT,
    @PhongBan INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        IF NOT EXISTS (SELECT *
    FROM NhanVien
    WHERE NhanVien_CCCD = @CCCD)
        BEGIN
        INSERT INTO NhanVien
            (NhanVien_HoTen, NhanVien_SDT, NhanVien_CCCD, NhanVien_GioiTinh, NhanVien_HinhAnh, NhanVien_DiaChi, NhanVien_NgaySinh, NhanVien_ChucVu, NhanVien_PhongBan)
        VALUES
            (@HoTen, @SDT, @CCCD, @GioiTinh, @HinhAnh, @DiaChi, @NgaySinh, @ChucVu, @PhongBan);
    END
        ELSE
        BEGIN;
        THROW 50001, 'CCCD đã tồn tại trong hệ thống!', 1;
    END
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH;
END
GO

--Thủ tục Xoá nhân viên
CREATE PROCEDURE XoaNhanVien
    @NhanVienID INT,
    @Message NVARCHAR(100) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Message = '';

    BEGIN TRY
        UPDATE NhanVien SET NhanVien_TrangThaiXoa = 1 WHERE NhanVien_ID = @NhanVienID
        SET @Message = 'Xoá nhân viên thành công!';
    END TRY
    BEGIN CATCH
        SET @Message = 'Lỗi khi xoá nhân viên!';
    END CATCH;
END
GO

--Thủ tục Update nhân viên 
CREATE PROCEDURE CapNhatNhanVien
    @NhanVienID INT,
    @HoTen NVARCHAR(50),
    @SDT CHAR(10),
    @CCCD CHAR(12),
    @GioiTinh NVARCHAR(3),
    @HinhAnh IMAGE,
    @DiaChi NVARCHAR(50),
    @NgaySinh DATE,
    @ChucVu INT,
    @PhongBan INT
AS
BEGIN
    SET NOCOUNT ON;
    DEclare @Message nvarchar(10);
    SET @Message = '';

    BEGIN TRY
        UPDATE NhanVien SET
            NhanVien_HoTen = @HoTen,
            NhanVien_SDT = @SDT,
            NhanVien_CCCD = @CCCD,
            NhanVien_GioiTinh = @GioiTinh,
            NhanVien_HinhAnh = @HinhAnh,
            NhanVien_DiaChi = @DiaChi,
            NhanVien_NgaySinh = @NgaySinh,
            NhanVien_ChucVu = @ChucVu,
            NhanVien_PhongBan = @PhongBan
        WHERE NhanVien_ID = @NhanVienID;

        SET @Message = 'Cập nhật thông tin nhân viên thành công!';
    END TRY
    BEGIN CATCH
        SET @Message = 'Lỗi khi cập nhật thông tin nhân viên!';
    END CATCH;
END
GO

--Thủ tục tìm kiếm nhân viên theo tên
CREATE PROCEDURE TimKiemNhanVien
    @Ten NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM NhanVien
    WHERE NhanVien_HoTen LIKE '%'+@Ten+'%';
END
GO


--Thủ tục tìm kiếm HD
CREATE PROCEDURE TimKiemHopDong
    @SoHD INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM HopDong
    WHERE HopDong_SoHD = @SoHD
END
GO
--------------------------------THỰC HIỆN TẠO USER PHÂN QUYỀN----------------------------------
-- Tạo rule
USE QLNS
GO
EXEC sp_addrole 'QuanLyTaiLieu' -- role nhân viên quản lý tài liệu
GO
EXEC sp_addrole 'QuanLyChamCong' -- role nhân viên quản lý chấm công
GO

-- Thêm quyền vào role QuanLyTaiLieu
-- NhanVien
GRANT SELECT ON NhanVien TO QuanLyTaiLieu
GRANT EXECUTE ON ThemNhanVien TO QuanLyTaiLieu
GRANT EXECUTE ON XoaNhanVien TO QuanLyTaiLieu
GRANT EXECUTE ON CapNhatNhanVien TO QuanLyTaiLieu
GRANT EXECUTE ON TimKiemNhanVien TO QuanLyTaiLieu
GRANT SELECT ON v_NhanVien TO QuanLyTaiLieu
-- -- HopDong
GRANT SELECT ON HopDong TO QuanLyTaiLieu
GRANT EXECUTE ON ThemHopDong TO QuanLyTaiLieu
GRANT EXECUTE ON SuaHopDong TO QuanLyTaiLieu
GRANT EXECUTE ON XoaHopDong TO QuanLyTaiLieu
GRANT EXECUTE ON TimKiemHopDong TO QuanLyTaiLieu
GRANT EXECUTE ON TimHopDongLonNhat TO QuanLyTaiLieu
-- -- HeSoLuong
GRANT SELECT ON HeSoLuong TO QuanLyTaiLieu
GRANT EXECUTE ON sp_ThemHeSoLuong TO QuanLyTaiLieu
GRANT EXECUTE ON sp_XoaHeSoLuong TO QuanLyTaiLieu
GRANT EXECUTE ON sp_SuaHeSoLuong TO QuanLyTaiLieu
-- -- PhongBan
GRANT SELECT ON PhongBan To QuanLyTaiLieu
GRANT EXECUTE ON sp_ThemPhongBan TO QuanLyTaiLieu
GRANT EXECUTE ON sp_XoaPhongBan TO QuanLyTaiLieu
GRANT EXECUTE ON sp_CapNhatPhongBan TO QuanLyTaiLieu
GRANT EXECUTE ON TimKiemPhongBan TO QuanLyTaiLieu
GRANT EXECUTE ON ThongKeNhanVienTheoPhongBan TO QuanLyTaiLieu
-- -- ChucVu
GRANT EXECUTE ON sp_ThemMoiChucVu TO QuanLyTaiLieu
GRANT EXECUTE ON sp_XoaChucVu TO QuanLyTaiLieu
GRANT EXECUTE ON TimKiemChucVu TO QuanLyTaiLieu
GRANT EXECUTE ON sp_SuaChucVu TO QuanLyTaiLieu
GRANT SELECT ON ChucVu TO QuanLyTaiLieu
-- LoaiTangCa
GRANT SELECT ON LoaiTangCa To QuanLyTaiLieu
GRANT EXECUTE ON sp_ThemMoiLoaiTangCa TO QuanLyTaiLieu
GRANT EXECUTE ON sp_XoaLoaiTangCa TO QuanLyTaiLieu
GRANT EXECUTE ON sp_SuaLoaiTangCa TO QuanLyTaiLieu
GRANT EXECUTE ON TimKiemLoaiTangCa TO QuanLyTaiLieu

-- Thêm quyền vào role QuanLyChamCong
-- NhanVien
GRANT SELECT ON NhanVien To QuanLyChamCong
-- KyCong
GRANT SELECT ON DS_KyCong TO QuanLyChamCong
GRANT SELECT ON KyCong To QuanLyChamCong
GRANT EXECUTE ON ThemKyCong TO QuanLyChamCong
GRANT EXECUTE ON CapNhatKyCong TO QuanLyChamCong
GRANT EXECUTE ON CapNhatTrangThaiKyCong TO QuanLyChamCong
-- -- KyCongChiTiet
GRANT EXECUTE ON ThongKeCong TO QuanLyChamCong
GRANT EXECUTE ON XoaKCCT TO QuanLyChamCong
-- -- ChamCong
GRANT EXECUTE ON PhatSinhKyCong TO QuanLyChamCong
GRANT EXECUTE ON XoaChamCong TO QuanLyChamCong
GRANT EXECUTE ON CapNhatChamCong TO QuanLyChamCong
GRANT EXECUTE ON Find_MaKyCong TO QuanLyChamCong
GRANT EXECUTE ON KT_PhatSinhKyCong TO QuanLyChamCong
GRANT EXECUTE ON KT_NgayTrongTuan TO QuanLyChamCong
-- GRANT EXECUTE ON SoNgayCong TO QuanLyChamCong
GRANT EXECUTE ON TK_KyCong TO QuanLyChamCong
GRANT EXECUTE ON SoNgayTrongThang TO QuanLyChamCong
-- -- BangLuong
GRANT EXECUTE ON TinhLuong TO QuanLyChamCong
GRANT EXECUTE ON hienthiluong TO QuanLyChamCong
GRANT EXECUTE ON xoaluongtheokycong TO QuanLyChamCong
-- TangCa
GRANT EXECUTE ON LayThongtinTangCa TO QuanLyChamCong
GRANT EXECUTE ON [SuaTangCa] TO QuanLyChamCong
GRANT EXECUTE ON [tangcatheoid] TO QuanLyChamCong
GRANT EXECUTE ON [ThemTangCa] TO QuanLyChamCong
GRANT EXECUTE ON [XoaTangCa] TO QuanLyChamCong
-- LoaiTangCa
GRANT SELECT ON LoaiTangCa To QuanLyChamCong
-- -- UngLuong
GRANT EXECUTE ON [ungluongtheoid] TO QuanLyChamCong
GRANT EXECUTE ON [LayThongtinUngLuong] TO QuanLyChamCong
GRANT EXECUTE ON [ThemUngLuong] TO QuanLyChamCong
GRANT EXECUTE ON [SuaUngLuong] TO QuanLyChamCong
GRANT EXECUTE ON [XoaUngLuong] TO QuanLyChamCong
-- GRANT EXECUTE ON [LuuXoaUngLuong] TO QuanLyTaiLieu
GO
--Kiểm tra dữ liệu đăng nhập
CREATE FUNCTION Login(@TK VARCHAR(50), @Pass VARCHAR(32))
RETURNS INT
AS
BEGIN
    DECLARE @Quyen INT
    SELECT @Quyen = TaiKhoan_PhanQuyen
    FROM TaiKhoan
    WHERE TaiKhoan_SoTK = @TK AND TaiKhoan_MatKhau = CONVERT(VARCHAR(32), HashBytes('MD5', @Pass), 2)
    IF(@Quyen IS NULL)
    RETURN -1
    RETURN @Quyen
END
GO
--Tạo TK truy cập login
CREATE LOGIN guestHRM WITH PASSWORD = 'guestHRM', CHECK_POLICY = OFF
GO
USE QLNS
GO
CREATE USER guestHRM FOR LOGIN guestHRM
GO
GRANT EXECUTE ON dbo.Login TO guestHRM
GO
--Them login và user
CREATE PROCEDURE ThemTaiKhoan
    @SoTK VARCHAR(50),
    @MatKhau VARCHAR(32),
    @PhanQuyen BIT,
    @Loai BIT
-- 1 tailieu, 0 chamcong
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        INSERT INTO TaiKhoan
        (TaiKhoan_SoTK, TaiKhoan_MatKhau, TaiKhoan_PhanQuyen)
    VALUES
        (@SoTK, @MatKhau, @PhanQuyen);

        DECLARE @sql NVARCHAR(255) = N'CREATE LOGIN ' + QUOTENAME(@SoTK) + N' WITH PASSWORD = ' + QUOTENAME(@MatKhau, '''') + N', CHECK_POLICY = OFF ;'
        + N' USE ' + QUOTENAME('QLNS') + ';' 
        + N' CREATE USER ' + QUOTENAME(@SoTK) + N' FOR LOGIN ' + QUOTENAME(@SoTK);
        EXEC sp_executesql @sql;

        IF(@PhanQuyen = 1) -- admin
        BEGIN
        DECLARE @sqlAdmin NVARCHAR(255)
        SET @sqlAdmin = N'ALTER SERVER ROLE sysadmin ADD MEMBER ' + QUOTENAME(@SoTK) + N';';
        EXEC sp_executesql @sqlAdmin;
    END
        ELSE
        BEGIN
        If(@PhanQuyen = 0) -- nhan vien
            BEGIN
            DECLARE @sqlUser NVARCHAR(255)
            IF(@Loai = 1)
            BEGIN
                SET @sqlUser = N'sp_addrolemember QuanLyTaiLieu, ' + QUOTENAME(@SoTK) + N';';
                EXEC sp_executesql @sqlUser;
            END
                    ELSE
                    BEGIN
                IF(@Loai = 0)
                        BEGIN
                    -- kycong, kycongchitiet, chamcong
                    SET @sqlUser = N'sp_addrolemember QuanLyChamCong, ' + QUOTENAME(@SoTK) + N';';
                    EXEC sp_executesql @sqlUser;
                END
            END
        END
    END
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        IF(@@TRANCOUNT > 0)
        BEGIN
        ROLLBACK TRANSACTION
    END;
        THROW 51000, 'Co loi khong the thuc hien them tai khoan', 1
    END CATCH
END
GO
-- Xóa tài khoản
CREATE PROCEDURE XoaTaiKhoan
    @SoTK VARCHAR(50)
AS
BEGIN
    DELETE FROM TaiKhoan WHERE TaiKhoan_SoTK = @SoTK;
END
GO

CREATE PROCEDURE XoaNguoiDung
    @SoTK VARCHAR(50)
AS
BEGIN
    DECLARE @Name NVARCHAR(50);
    SELECT @Name = name
    FROM sys.server_principals
    WHERE name = @SoTK;

    IF @Name IS NOT NULL
    BEGIN
        EXEC XoaTaiKhoan @SoTK
        --
        DECLARE @SPID INT;
        DECLARE @sqlUser NVARCHAR(255)
        SELECT @SPID = MIN(session_id)
        FROM sys.dm_exec_sessions
        WHERE login_name = @SoTK;
        while @SPID IS NOT NULL
        BEGIN
            SET @sqlUser = N'KILL ' + (CONVERT(VARCHAR(10), @SPID)) + N';'
            EXEC sp_executesql @sqlUser;
            --LOOP
            SELECT @SPID = MIN(session_id)
            FROM sys.dm_exec_sessions
            WHERE login_name = @SoTK AND session_id > @SPID
        END
        --
        SET @sqlUser = N'DROP USER ' + QUOTENAME(@SoTK) + N'; ' + 
        N'DROP LOGIN ' + QUOTENAME(@SoTK)+ N'; ';
        EXEC sp_executesql @sqlUser;
    END
    ELSE
    BEGIN;
        THROW 51000, 'Nguoi dung nay khong ton tai', 1;
    END
END
GO

-- Chinh sửa mật khẩu
CREATE PROCEDURE SuaThongTinTaiKhoan
    @SoTK VARCHAR(50),
    @MatKhau VARCHAR(32) = NULL
AS
BEGIN
    UPDATE TaiKhoan SET
        TaiKhoan_MatKhau = COALESCE((CONVERT(VARCHAR(32), HashBytes('MD5', @MatKhau), 2)), TaiKhoan_MatKhau)
    WHERE TaiKhoan_SoTK = @SoTK;
END
GO

CREATE PROCEDURE SuaMatKhauTaiKhoanDangNhap
    @SoTK VARCHAR(50),
    @MatKhau VARCHAR(32)
AS
BEGIN
    IF EXISTS (SELECT *
    FROM sys.server_principals
    WHERE name = @SoTK)
    BEGIN
        EXEC SuaThongTinTaiKhoan @SoTK, @MatKhau
        DECLARE @sqlUser NVARCHAR(255)
        SET @sqlUser = N'ALTER LOGIN ' + QUOTENAME(@SoTK) + N' WITH PASSWORD = '+ QUOTENAME(@MatKhau, '''') + N' ;';
        EXEC sp_executesql @sqlUser;
    END
    ELSE
    BEGIN;
        THROW 51000, 'Nguoi dung nay khong ton tai', 1;
    END
END
GO
--Thực hiện tạo các login và user ban đầu cho hệ thống
EXEC ThemTaiKhoan '20110110', '123', 1, 0 -- quyền admin
GO
EXEC ThemTaiKhoan '20110111', '123', 0, 1 -- nhân viên tài liệu
GO
EXEC ThemTaiKhoan '20110112', '123', 0, 0 -- nhân viên chấm công
GO

