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
    ChamCong_GioChamCong VARCHAR(50),
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
    TaiKhoan_NhanVien INT UNIQUE
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

-- Bảng PhanQuyen
CREATE VIEW DS_Quyen
AS
    SELECT PhanQuyen_TenQuyen
    FROM PhanQuyen
GO

-- Bảng TaiKhoan
CREATE VIEW DS_TaiKhoan
AS
    SELECT TaiKhoan_SoTK, TaiKhoan_MatKhau, TaiKhoan_NhanVien
    FROM TaiKhoan
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

--Bảng Kỳ Công Chấm Công
CREATE VIEW View_ChamCongKyCong
AS
    SELECT ChamCong.ChamCong_ID, ChamCong.ChamCong_NhanVien, ChamCong.ChamCong_Ngay, KyCong.KyCong_Thang, KyCong.KyCong_Nam
    FROM ChamCong
        JOIN KyCongChiTiet ON ChamCong.ChamCong_NhanVien = KyCongChiTiet.KyCongChiTiet_NhanVien AND ChamCong.ChamCong_KyCong = KyCongChiTiet.KyCongChiTiet_KyCong
        JOIN KyCong ON KyCongChiTiet.KyCongChiTiet_KyCong = KyCong.KyCong_MaKyCong;
GO

-- Bang Chuc vu , Nhan Vien, LoaiTangCa
CREATE VIEW v_ChucVu
AS
    SELECT *
    FROM dbo.ChucVu;

go


CREATE VIEW v_NhanVienCoTangCa
AS
    SELECT *
    FROM dbo.TangCa
    WHERE TangCa_NgayTangCa IS NOT NULL
GO

CREATE VIEW v_LoaiTangCa
AS
    SELECT *
    FROM dbo.LoaiTangCa;
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

-- Bảng PhanQuyen
CREATE TRIGGER TGR_PhanQuyen
On PhanQuyen
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @maxid int = 0
    SELECT @maxid = MAX(PhanQuyen_ID)
    FROM PhanQuyen
    IF @maxid IS NULL SET @maxid = 1
    ELSE SET @maxid = @maxid + 1
    INSERT INTO PhanQuyen
        (PhanQuyen_ID)
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
    SELECT @checkid = i.TaiKhoan_SoTK
    FROM inserted i
    IF NOT EXISTS(SELECT *
    FROM TaiKhoan
    WHERE TaiKhoan_SoTK = @checkid)
    INSERT INTO TaiKhoan
        (TaiKhoan_SoTK, TaiKhoan_MatKhau, TaiKhoan_NhanVien, TaiKhoan_PhanQuyen)
    SELECT i.TaiKhoan_SoTK, (CONVERT(VARCHAR(32), HashBytes('MD5', i.TaiKhoan_MatKhau), 2)), i.TaiKhoan_NhanVien, i.TaiKhoan_PhanQuyen
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

--ChucVu, TangCa, LoaiTangCa-- ??????????????????????????????????????????
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
    (HeSoLuong_ID, HeSoLuong_Ten, HeSoLuong_GiaTri)
VALUES
    (1, N'Bậc 1', 1.07),
    (2, N'Bậc 2', 1.13),
    (3, N'Bậc 3', 1.19),
    (4, N'Bậc 4', 1.42);
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
    ('1/1/2019', '1/1/2021', 1, 'A', 3.250, 1, (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen=N'Nguyễn Văn Phát')),
    ('3/1/2018', '3/1/2021', 1, 'A', 3.250, 1, (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Huỳnh Văn Bá')),
    ('3/1/2019', '3/1/2021', 1, 'A', 3.250, 1, (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Nguyễn Thị Hà')),
    ('1/1/2019', '1/1/2021', 1, 'A', 3.250, 1, (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Nguyễn Thị Hạ')),
    ('11/1/2019', '1/11/2021', 1, 'A', 3.250, 1, (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Huỳnh Văn Ba')),
    ('11/1/2019', '1/11/2021', 1, 'A', 3.250, 1, (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Huỳnh Văn Vũ')),
    ('12/1/2019', '12/1/2021', 1, 'A', 3.250, 1, (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Nguyễn Văn Khánh')),
    ('12/1/2019', '12/1/2021', 1, 'A', 3.250, 1, (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Nguyễn Văn Ba')),
    ('12/1/2019', '12/1/2021', 1, 'A', 3.250, 1, (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Nguyễn Công Huynh')),
    ('12/1/2019', '12/1/2021', 1, 'A', 3.250, 1, (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Nguyễn Phát Tài')),
    ('11/1/2019', '11/1/2021', 1, 'A', 3.250, 1, (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Lý Tiến Thành')),
    ('12/1/2019', '12/1/2021', 1, 'A', 3.250, 1, (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Mai Thành Chung')),
    ('11/1/2019', '11/1/2021', 1, 'A', 3.250, 1, (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Mai Trọng Khánh')),
    ('1/1/2019', '1/1/2021', 1, 'A', 3.250, 1, (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Quách Đình Trường Thi')),
    ('1/1/2019', '1/1/2021', 1, 'A', 3.250, 1, (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Quách Diệu Khánh')),
    ('1/1/2019', '1/1/2021', 1, 'A', 3.250, 1, (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Phan Thanh Lâm')),
    ('1/1/2019', '1/1/2021', 1, 'A', 3.250, 1, (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Đinh Bảo Long')),
    ('1/1/2019', '1/1/2021', 1, 'A', 3.250, 1, (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Huỳnh Thị My')),
    ('1/1/2019', '1/1/2021', 1, 'A', 3.250, 1, (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Võ Thị Phước')),
    ('1/1/2019', '1/1/2021', 1, 'A', 3.250, 1, (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Mai Hoàng Hương'));
GO

---
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

-- Bảng phân quyền
INSERT INTO PhanQuyen
    (PhanQuyen_TenQuyen)
VALUES
    (N'Quản trị hệ thống');
INSERT INTO PhanQuyen
    (PhanQuyen_TenQuyen)
VALUES
    (N'Nhân viên nhân sự');
GO

-- bảng TaiKhoan
INSERT INTO TaiKhoan
    (TaiKhoan_SoTK, TaiKhoan_MatKhau, TaiKhoan_PhanQuyen, TaiKhoan_NhanVien)
VALUES
    ('20110110', '123', (SELECT PhanQuyen_ID
        From PhanQuyen
        WHERE PhanQuyen_TenQuyen = N'Quản trị hệ thống'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Đinh Bảo Long'))
INSERT INTO TaiKhoan
    (TaiKhoan_SoTK, TaiKhoan_MatKhau, TaiKhoan_PhanQuyen, TaiKhoan_NhanVien)
VALUES
    ('20110111', '123', (SELECT PhanQuyen_ID
        From PhanQuyen
        WHERE PhanQuyen_TenQuyen = N'Quản trị hệ thống'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Mai Hoàng Hương'))
INSERT INTO TaiKhoan
    (TaiKhoan_SoTK, TaiKhoan_MatKhau, TaiKhoan_PhanQuyen, TaiKhoan_NhanVien)
VALUES
    ('20110112', '123', (SELECT PhanQuyen_ID
        From PhanQuyen
        WHERE PhanQuyen_TenQuyen = N'Nhân viên nhân sự'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Mai Trọng Khánh'))
INSERT INTO TaiKhoan
    (TaiKhoan_SoTK, TaiKhoan_MatKhau, TaiKhoan_PhanQuyen, TaiKhoan_NhanVien)
VALUES
    ('20110113', '123', (SELECT PhanQuyen_ID
        From PhanQuyen
        WHERE PhanQuyen_TenQuyen = N'Nhân viên nhân sự'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen= N'Nguyễn Thị Hạ'))
INSERT INTO TaiKhoan
    (TaiKhoan_SoTK, TaiKhoan_MatKhau, TaiKhoan_PhanQuyen, TaiKhoan_NhanVien)
VALUES
    ('20110114', '123', (SELECT PhanQuyen_ID
        From PhanQuyen
        WHERE PhanQuyen_TenQuyen = N'Nhân viên nhân sự'), (SELECT NhanVien_ID
        FROM NhanVien
        WHERE NhanVien_HoTen=N'Nguyễn Văn Phát'))
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

--Bảng Kỳ Công Chi Tiết

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
        N'Trưởng Nhóm' -- ChucVu_TenCV - nvarchar(50)
    ),
    ( 9, -- ChucVu_ID - int
        N'Nhân Viên' -- ChucVu_TenCV - nvarchar(50)
    ),
    ( 10, -- ChucVu_ID - int
        N'Nhân Viên' -- ChucVu_TenCV - nvarchar(50)
    )

GO
-- ============= hàm và thủ tục ===============
-- <Kha>
-- 1. NV
-- 2. hopDong
-- 3. HSL

-- <Quang>

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
    BEGIN
        RAISERROR('Dữ liệu đã tồn tại', 16, 1);
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
        SET @LuongNhanDuoc = @LuongThuong + @LuongCN - @UngLuong + @PhuCap + @TangCa
        SET @LuongThucLanh = @LuongNhanDuoc * 0.895
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
@Nam INT ,@Thang INT
AS
SELECT *
FROM Luong_HienThi(@Nam,@Thang)

GO

-- <Tuan>
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
    THROW 51000,'Loi Khong The Cap Nhat Bang Cham Cong',1;
    END CATCH
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
-- <Dung>
-- LoaiTangCa

CREATE PROCEDURE sp_ThemMoiLoaiTangCa
    @LoaiTangCa_ID INT,
    @LoaiTangCa_TenLoai NVARCHAR(20),
    @LoaiTangCa_HeSo FLOAT
AS
BEGIN
    INSERT INTO LoaiTangCa
        (LoaiTangCa_ID, LoaiTangCa_TenLoai, LoaiTangCa_HeSo)
    VALUES
        (@LoaiTangCa_ID, @LoaiTangCa_TenLoai, @LoaiTangCa_HeSo)
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
    @ChucVu_ID INT,
    @ChucVu_TenCV NVARCHAR(50)
AS
BEGIN
    INSERT INTO ChucVu
        (ChucVu_ID, ChucVu_TenCV)
    VALUES
        (@ChucVu_ID, @ChucVu_TenCV)
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
CREATE PROCEDURE sp_ThemPhongBan
    (
    @MaPB INT,
    @TenPB NVARCHAR(50),
    @TruongPhong INT,
    @TG_NhanChuc DATE
)
AS
BEGIN
    INSERT INTO PhongBan
        (PhongBan_MaPB, PhongBan_TenPB, PhongBan_TruongPhong, PhongBan_TG_NhanChuc)
    VALUES
        (@MaPB, @TenPB, @TruongPhong, @TG_NhanChuc);
END
GO

CREATE PROCEDURE sp_XoaPhongBan
    (
    @MaPB INT
)
AS
BEGIN
    DELETE FROM PhongBan WHERE PhongBan_MaPB = @MaPB;
END
GO

ALTER PROCEDURE sp_ThemPhongBan
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
-- TK

CREATE PROCEDURE ThemTaiKhoan
    @SoTK VARCHAR(50),
    @MatKhau VARCHAR(32),
    @PhanQuyen INT,
    @NhanVien INT
AS
BEGIN
    INSERT INTO TaiKhoan
        (TaiKhoan_SoTK, TaiKhoan_MatKhau, TaiKhoan_PhanQuyen, TaiKhoan_NhanVien)
    VALUES
        (@SoTK, @MatKhau, @PhanQuyen, @NhanVien);
END
GO

CREATE PROCEDURE XoaTaiKhoan
    @SoTK VARCHAR(50)
AS
BEGIN
    DELETE FROM TaiKhoan WHERE TaiKhoan_SoTK = @SoTK;
END

GO

CREATE PROCEDURE SuaThongTinTaiKhoan
    @SoTK VARCHAR(50),
    @MatKhau VARCHAR(32) = NULL,
    @PhanQuyen INT = NULL,
    @NhanVien INT = NULL
AS
BEGIN
    UPDATE TaiKhoan SET
        TaiKhoan_MatKhau = COALESCE(@MatKhau, TaiKhoan_MatKhau),
        TaiKhoan_PhanQuyen = COALESCE(@PhanQuyen, TaiKhoan_PhanQuyen),
        TaiKhoan_NhanVien = COALESCE(@NhanVien, TaiKhoan_NhanVien)
    WHERE TaiKhoan_SoTK = @SoTK;
END
GO

-- PhanQuyen

CREATE PROCEDURE ThemMoiPhanQuyen
    @TenQuyen NVARCHAR(20)
AS
BEGIN
    INSERT INTO PhanQuyen
        (PhanQuyen_TenQuyen)
    VALUES(@TenQuyen)
END;
GO
--Xóa một bản ghi khỏi bảng PhanQuyen dựa trên PhanQuyen_ID:
CREATE PROCEDURE XoaPhanQuyen
    @PhanQuyen_ID INT
AS
BEGIN
    DELETE FROM PhanQuyen
WHERE PhanQuyen_ID = @PhanQuyen_ID
END;
GO
--Cập nhật một bản ghi trong bảng PhanQuyen dựa trên PhanQuyen_ID:
CREATE PROCEDURE CapNhatPhanQuyen
    @PhanQuyen_ID INT,
    @TenQuyen NVARCHAR(20)
AS
BEGIN
    UPDATE PhanQuyen
SET PhanQuyen_TenQuyen = @TenQuyen
WHERE PhanQuyen_ID = @PhanQuyen_ID
END;
GO
CREATE VIEW vw_PhanQuyen
AS
    SELECT PhanQuyen_ID, PhanQuyen_TenQuyen
    FROM PhanQuyen
GO
-- tìm kiếu loai tăng ca
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
-- Tìm kiếm tài khoản
CREATE PROCEDURE TimKiemTaiKhoan
    @timKiem VARCHAR(50)
AS
BEGIN
    BEGIN TRY
        SELECT *
    FROM TaiKhoan
    WHERE TaiKhoan_SoTK = @timKiem OR TaiKhoan_NhanVien = @timKiem
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE()
    END CATCH
END
GO
-- Tìm kiếm Phân quyền
CREATE PROCEDURE TimKiemPhanQuyen
    @phanQuyen_ID int = NULL,
    @phanQuyen_TenQuyen nvarchar(20) = NULL
AS
BEGIN
    BEGIN TRY
        SELECT *
    FROM PhanQuyen
    WHERE (@phanQuyen_ID IS NULL OR PhanQuyen_ID = @phanQuyen_ID)
        AND (@phanQuyen_TenQuyen IS NULL OR PhanQuyen_TenQuyen LIKE '%' + @phanQuyen_TenQuyen + '%')
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE()
    END CATCH
END
GO
-- thống kê nhân viên theo phòng ban
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
