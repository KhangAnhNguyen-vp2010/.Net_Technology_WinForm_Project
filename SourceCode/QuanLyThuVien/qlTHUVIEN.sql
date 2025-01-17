﻿create database QL_THUVIEN

USE QL_THUVIEN

CREATE TABLE TACGIA
(
	MATG CHAR(10) NOT NULL,
	TENTG NVARCHAR(255),
	NGAYSINH DATE,
	TIEUSU NVARCHAR(255),
	HINHANH_TG NVARCHAR(500),
	CONSTRAINT PK_TACGIA PRIMARY KEY (MATG)
)

CREATE TABLE NHAXUATBAN
(
	MANXB CHAR(10) NOT NULL,
	TENNXB NVARCHAR(255),
	DIACHI_NXB NVARCHAR(255),
	LIENHE NVARCHAR(500),
	CONSTRAINT PK_NHAXUATBAN PRIMARY KEY (MANXB)
)


CREATE TABLE THELOAI
(
	MALOAI CHAR(10) NOT NULL,
	TENLOAI NVARCHAR(255),
	MOTA NVARCHAR(255),
	CONSTRAINT PK_THELOAI PRIMARY KEY(MALOAI)
)

CREATE TABLE NHANVIEN
(
	MANV CHAR(10) NOT NULL,
	TENNV NVARCHAR(255),
	GIOITINH NVARCHAR(5),
	NGAYSINH DATE,
	DIACHI_NV NVARCHAR(255),
	PHONE CHAR(10),
	HINHANH_NV CHAR(500),
	CONSTRAINT PK_NHANVIEN PRIMARY KEY (MANV)
)

CREATE TABLE SACH
(
	MASH CHAR(10) NOT NULL,
	TENSH NVARCHAR(255),
	MATG CHAR(10),
	MANXB CHAR(10),
	MALOAI CHAR(10),
	NAMXUATBAN INT,
	TINHTRANG NVARCHAR(30),
	HINHANH_SACH CHAR(500),
	CONSTRAINT PK_SACH PRIMARY KEY (MASH),
	CONSTRAINT FK_SACH_TACGIA FOREIGN KEY (MATG) REFERENCES TACGIA(MATG),
	CONSTRAINT FK_SACH_NHAXUATBAN FOREIGN KEY (MANXB) REFERENCES NHAXUATBAN(MANXB),
	CONSTRAINT FK_SACH_THELOAI FOREIGN KEY (MALOAI) REFERENCES THELOAI(MALOAI),
)

CREATE TABLE DOCGIA
(
	MADG CHAR(10) NOT NULL,
	TENDG NVARCHAR(255),
	GIOITINH NVARCHAR(5),
	NGAYSINH DATE,
	DIACHI_DG NVARCHAR(255),
	EMAIL CHAR(100),
	PHONE CHAR(10),
	NGAYDANGKY DATE,
	CONSTRAINT PK_DOCGIA PRIMARY KEY (MADG)
)

CREATE TABLE PHIEUMUON
(
	MAPM CHAR(10) NOT NULL,
	MADG CHAR(10) UNIQUE,
	NGAYLAP DATE,
	CONSTRAINT PK_PHIEUMUON PRIMARY KEY (MAPM),
	CONSTRAINT FK_CHITIETPM_DOCGIA FOREIGN KEY (MADG) REFERENCES DOCGIA(MADG),
)

CREATE TABLE CHITIETPM
(
	MAPM CHAR(10) NOT NULL,	
	MASH CHAR(10) NOT NULL,	
	NGAYMUON DATE NOT NULL,
	HANTRA DATE,
	NGAYTRA_THUCTE DATE,
	TRANGTHAI NVARCHAR(30),
	MANV_PHUTRACH CHAR(10),
	CONSTRAINT PK_CHITIETPM PRIMARY KEY (MAPM, MASH, NGAYMUON),
	CONSTRAINT FK_CHITIETPM_SACH FOREIGN KEY (MASH) REFERENCES SACH(MASH),
	CONSTRAINT FK_CHITIETPM_PHIEUMUON FOREIGN KEY (MAPM) REFERENCES PHIEUMUON(MAPM),
	CONSTRAINT FK_CHITIETPM_NHANVIEN FOREIGN KEY (MANV_PHUTRACH) REFERENCES NHANVIEN(MANV)
)

CREATE TABLE PHIEUPHAT
(
	MAPM CHAR(10) NOT NULL,
	MADG CHAR(10) NOT NULL,
	MASH CHAR(10) NOT NULL,
	NGAYLAP DATE,
	TIENPHAT MONEY,
	PP_STATUS NVARCHAR(30),
	CONSTRAINT PK_PHIEUPHAT PRIMARY KEY (MAPM, MADG, MASH),
	CONSTRAINT FK_PHIEUPHAT_PHIEUMUON FOREIGN KEY (MAPM) REFERENCES PHIEUMUON(MAPM),
	CONSTRAINT FK_PHIEUPHAT_DOCGIA FOREIGN KEY (MADG) REFERENCES DOCGIA(MADG),
	CONSTRAINT FK_PHIEUPHAT_SACH FOREIGN KEY (MASH) REFERENCES SACH(MASH)
)

CREATE TABLE _USER_
(
	TENTAIKHOAN CHAR(10) NOT NULL,
	MATKHAU NVARCHAR(100),
	VAITRO NVARCHAR(30),
	NGAYTAO DATE,
	LAST_LOGIN DATE,
	CONSTRAINT PK_USER PRIMARY KEY (TENTAIKHOAN),
	CONSTRAINT FK_USER_NHANVIEN FOREIGN KEY (TENTAIKHOAN) REFERENCES NHANVIEN(MANV)
)


----- TRIIGER
---- KIEM TRA NXB
--LIEN HE NXB
CREATE TRIGGER KIEM_TRA_NXB_LIENHE ON NHAXUATBAN
FOR INSERT, UPDATE
AS
BEGIN
    DECLARE @INVALID_DATA INT;

    -- Kiểm tra dữ liệu không phải số hoặc không đủ 10 ký tự trong cột PHONE
    SET @INVALID_DATA = (
        SELECT COUNT(*)
        FROM INSERTED
        WHERE (LIENHE LIKE '%[^0-9]%' OR LEN(LIENHE) != 10) AND LEN(LIENHE) > 0
    );

    -- Nếu phát hiện dữ liệu không hợp lệ, ngắt thao tác và thông báo lỗi
    IF @INVALID_DATA > 0
    BEGIN    
        PRINT 'Cot LIENHE phai chua dung 10 ky tu so'
		ROLLBACK TRAN
    END
END;

---- KIEM TRA NHAN VIEN
---PHONE NHANVIEN
CREATE TRIGGER KIEM_TRA_NHANVIEN_PHONE ON NHANVIEN
FOR INSERT, UPDATE
AS
BEGIN
    DECLARE @INVALID_DATA INT;

    -- Kiểm tra dữ liệu không phải số hoặc không đủ 10 ký tự trong cột PHONE
    SET @INVALID_DATA = (
        SELECT COUNT(*)
        FROM INSERTED
        WHERE (PHONE LIKE '%[^0-9]%' OR LEN(PHONE) != 10) AND LEN(PHONE) > 0
    );

    -- Nếu phát hiện dữ liệu không hợp lệ, ngắt thao tác và thông báo lỗi
    IF @INVALID_DATA > 0
    BEGIN    
        PRINT 'Cot PHONE phai chua dung 10 ky tu so'
		ROLLBACK TRAN
    END
END;


----- KIEM TRA SACH
--- NAMXUATBAN SACH
CREATE TRIGGER KIEM_TRA_SACH_NAMXUATBAN ON SACH
FOR INSERT, UPDATE
AS
BEGIN
    DECLARE @INVALID_DATA INT;

    -- Kiểm tra xem NAMXUATBAN có phải là năm hợp lệ hay không
    SET @INVALID_DATA = (
        SELECT COUNT(*)
        FROM INSERTED
        WHERE NAMXUATBAN < 1000 OR NAMXUATBAN > 9999
    );

    -- Nếu có giá trị không hợp lệ, hủy thao tác và trả về lỗi
    IF @INVALID_DATA > 0
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR (N'NAMXUATBAN phải là năm hợp lệ (ví dụ: 2024).', 16, 1);
    END
END;

--- SET TINHTRANG SACH
CREATE TRIGGER SET_SACH_TINHTRANG ON SACH
FOR INSERT
AS
BEGIN
	UPDATE SACH
	SET TINHTRANG = N'Chưa được mượn'
	WHERE MASH IN (SELECT MASH FROM inserted)
END


---- KIEM TRA DOC GIA
--PHONE DOCGIA
CREATE TRIGGER KIEM_TRA_DOCGIA_PHONE ON DOCGIA
FOR INSERT, UPDATE
AS
BEGIN
    DECLARE @INVALID_DATA INT;

    -- Kiểm tra dữ liệu không phải số hoặc không đủ 10 ký tự trong cột PHONE
    SET @INVALID_DATA = (
        SELECT COUNT(*)
        FROM INSERTED
        WHERE (PHONE LIKE '%[^0-9]%' OR LEN(PHONE) != 10) AND LEN(PHONE) > 0
    );

    -- Nếu phát hiện dữ liệu không hợp lệ, ngắt thao tác và thông báo lỗi
    IF @INVALID_DATA > 0
    BEGIN    
        PRINT 'Cot PHONE phai chua dung 10 ky tu so'
		ROLLBACK TRAN
    END
END;

----- EMAIL DOC GIA
CREATE TRIGGER KIEMTRA_DOCGIA_EMAIL ON DOCGIA
FOR INSERT, UPDATE
AS
BEGIN
    DECLARE @INVALID_EMAIL INT;

    -- Kiểm tra định dạng email bằng biểu thức chính quy
    SET @INVALID_EMAIL = (
        SELECT COUNT(*)
        FROM INSERTED
        WHERE EMAIL NOT LIKE '%_@__%.__%'
    );

    -- Nếu có giá trị không hợp lệ, hủy thao tác và trả về lỗi
    IF @INVALID_EMAIL > 0
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR (N'Địa chỉ email không hợp lệ. Vui lòng nhập lại.', 16, 1);
    END
END;

--- SET PHIEUMUON
CREATE TRIGGER SET_PHIEUMUON_NGAYLAP ON PHIEUMUON
FOR INSERT
AS
BEGIN
	UPDATE PHIEUMUON
	SET NGAYLAP = GETDATE()
	WHERE MAPM IN (SELECT MAPM FROM inserted)
END

---- KIEM TRA CHITIETPM
---- SET PHIEUMUON
CREATE TRIGGER SET_CHITIETPM_TRANGTHAI ON CHITIETPM
FOR INSERT
AS
BEGIN
	IF (SELECT TINHTRANG FROM SACH WHERE MASH IN (SELECT MASH FROM inserted)) = N'Đã được mượn'
	BEGIN	
		PRINT N'Cuốn sách này đã được mượn'
		ROLLBACK TRAN
	END
	ELSE
	BEGIN
		UPDATE CHITIETPM
		SET TRANGTHAI = N'Đang mượn'
		WHERE MAPM IN (SELECT MAPM FROM inserted)
		AND MASH IN (SELECT MASH FROM inserted)

		UPDATE SACH
		SET TINHTRANG = N'Đã được mượn'
		WHERE MASH IN (SELECT MASH FROM inserted)
	END 
END;

------KIEM TRA PHIEUPHAT
--- SET PHIEUPHAT
CREATE TRIGGER SET_PHIEUPHAT_NGAYLAP_TIENPHAT_STATUS ON PHIEUPHAT
FOR INSERT
AS
BEGIN
	UPDATE PHIEUPHAT
	SET TIENPHAT = 5000
	WHERE MAPM IN (SELECT MAPM FROM inserted)
	AND MADG IN (SELECT MADG FROM inserted)
	AND MASH IN (SELECT MASH FROM inserted)

	UPDATE PHIEUPHAT
	SET PP_STATUS = N'Chưa thanh toán'
	WHERE MAPM IN (SELECT MAPM FROM inserted)
	AND MADG IN (SELECT MADG FROM inserted)
	AND MASH IN (SELECT MASH FROM inserted)
END


--- TRIGGER USER
CREATE TRIGGER NGAYTAO_USER ON _USER_
FOR INSERT
AS
BEGIN
	UPDATE _USER_
	SET NGAYTAO = GETDATE()
	WHERE TENTAIKHOAN IN (SELECT TENTAIKHOAN FROM inserted)
END

----- THEM DU LIEU -----
INSERT INTO TACGIA
VALUES
('TG001', N'Gabriel García Márquez', '1927-06-03', N'Là nhà văn người Colombia', 'TG001.jpg'),
('TG002', N'Virginia Woolf', '1882-01-25', N'Tác giả người Anh', 'TG002.jpg'),
('TG003', N'Haruki Murakami ', '1949-01-12', N'Nhà văn người Nhật Bản', 'TG003.jpg'),
('TG004', N'Jane Austen', '1775-12-16', N'Là nhà văn người Anh', 'TG004.jpg'),
('TG005', N'Leo Tolstoy', '1828-09-09', N'Tác giả người Nga', 'TG005.jpg'),
('TG006', N'George Orwell', '1903-06-25', N'Nhà văn và nhà báo người Anh', 'TG006.jpg'),
('TG007', N'Franz Kafka', '1883-07-03', N'Nhà văn người Áo gốc Do Thái', 'TG007.jpg'),
('TG008', N'Margaret Atwood', '1939-11-18', N'Nhà văn người Canada', 'TG008.jpg'),
('TG009', N'Chinua Achebe', '1930-11-16', N'Tác giả người Nigeria', 'TG009.jpg'),
('TG010', N'Isabel Allende', '1942-08-02', N'Nhà văn người Chile', 'TG010.jpg');

INSERT INTO NHAXUATBAN
VALUES
('NXB001', N'Nhà xuất bản Trẻ', N'12 Nguyễn Thị Minh Khai, Quận 1, TP. Hồ Chí Minh', N'0283930331'),
('NXB002', N'Nhà xuất bản Giáo dục Việt Nam', N'81 Trần Hưng Đạo, Hoàn Kiếm, Hà Nội', N'0243822362'),
('NXB003', N'Nhà xuất bản Kim Đồng', N'55 Quang Trung, Hai Bà Trưng, Hà Nội', N'0243943434'),
('NXB004', N'Nhà xuất bản Văn học', N'48 Trần Hưng Đạo, Hoàn Kiếm, Hà Nội', N'0243822055'),
('NXB005', N'Penguin Random House', N'1745 Broadway, New York, NY, USA', N'1212782900');

INSERT INTO THELOAI
VALUES
('L001', N'Tiểu thuyết', N'Thể loại văn học hư cấu dài, kể về những câu chuyện chi tiết.'),
('L002', N'Khoa học viễn tưởng', N'Thể loại tập trung vào công nghệ, không gian, hoặc tương lai.'),
('L003', N'Văn học thiếu nhi', N'Thể loại dành cho trẻ em với nội dung đơn giản và giàu hình ảnh.');

INSERT INTO SACH
VALUES
('SH001', N'Trăm năm cô đơn', 'TG001', 'NXB001', 'L001', 1967, NULL, 'SH001.jpg'),
('SH002', N'Ngọn hải đăng', 'TG002', 'NXB002', 'L001', 1927, NULL, 'SH002.jpg'),
('SH003', N'Rừng Nauy', 'TG003', 'NXB003', 'L001', 1987, NULL, 'SH003.jpg'),
('SH004', N'Kiêu hãnh và định kiến', 'TG004', 'NXB001', 'L001', 1813, NULL, 'SH004.jpg'),
('SH005', N'Chiến tranh và hòa bình', 'TG005', 'NXB002', 'L001', 1869, NULL, 'SH005.jpg'),
('SH006', N'1984', 'TG006', 'NXB003', 'L002', 1949, NULL, 'SH006.jpg'),
('SH007', N'Hóa thân', 'TG007', 'NXB004', 'L002', 1915, NULL, 'SH007.jpg'),
('SH008', N'Chuyện người tùy nữ', 'TG008', 'NXB005', 'L001', 1985, NULL, 'SH008.jpg'),
('SH009', N'Mọi thứ sụp đổ', 'TG009', 'NXB001', 'L001', 1958, NULL, 'SH009.jpg'),
('SH010', N'Ngôi nhà của những linh hồn', 'TG010', 'NXB002', 'L001', 1982, NULL, 'SH010.jpg'),
('SH011', N'Đường tới những vì sao', 'TG003', 'NXB003', 'L002', 2009, NULL, 'SH011.jpg'),
('SH012', N'Lũ trẻ nhà Beezus và Ramona', 'TG008', 'NXB004', 'L003', 1955, NULL, 'SH012.jpg'),
('SH013', N'Thợ săn truyện cổ tích', 'TG006', 'NXB005', 'L003', 1932, NULL, 'SH013.jpg'),
('SH014', N'Mật mã Da Vinci', 'TG003', 'NXB001', 'L002', 2003, NULL, 'SH014.jpg'),
('SH015', N'Nhà giả kim', 'TG004', 'NXB002', 'L001', 1988, NULL, 'SH015.jpg');

INSERT INTO DOCGIA
VALUES
('DG001', N'Nguyễn Thị Mai', N'Nữ', '1990-05-10', N'123 Nguyễn Thị Minh Khai, Quận 3, TP.HCM', 'mai.nguyen@gmail.com', '0123456789', '2024-11-01'),
('DG002', N'Trần Minh Tâm', N'Nam', '1995-08-15', N'456 Hồ Tùng Mậu, Quận 12, TP.HCM', 'tamttran@gmail.com', '0987654321', '2024-11-01'),
('DG003', N'Lê Quang Huy', N'Nam', '1988-03-20', N'789 Cách Mạng Tháng 8, Quận 10, TP.HCM', 'huy.le@gmail.com', '0911223344', '2024-11-01'),
('DG004', N'Phạm Lan Anh', N'Nữ', '1992-07-12', N'321 Phan Văn Trị, Quận Gò Vấp, TP.HCM', 'lananh.pham@gmail.com', '0933445566', '2024-11-01'),
('DG005', N'Hoàng Quân', N'Nam', '2000-11-25', N'654 Võ Thị Sáu, Quận 1, TP.HCM', 'quan.hoang@gmail.com', '0977889900', '2024-11-01');

INSERT INTO NHANVIEN 
VALUES 
('NV001', N'Nguyễn Văn A', N'Nam', '1985-03-15', N'789 Đường XYZ, Quận 3', '0123456789', 'staff_Nam.jpg'),
('NV002', N'Trần Thị B', N'Nữ', '1990-07-22', N'321 Đường ABC, Quận 4', '0987654321', 'staff_Nu.jpg');

insert into PHIEUMUON
values('PM001', 'DG001', NULL);

insert into PHIEUMUON
values('PM002', 'DG002', NULL);

insert into _USER_
values
('NV001', '123', 'staff', null, null),
('NV002', '456', 'manager', null, null);

select * from NHAXUATBAN
select * from THELOAI
select * from SACH
select * from TACGIA
select * from PHIEUMUON
select * from CHITIETPM
select * from PHIEUPHAT
select * from NHANVIEN
select * from DOCGIA
select * from _USER_

CREATE VIEW REPORT_PHIEUMUON
AS
	SELECT PHIEUMUON.MAPM, MADG, MASH, NGAYLAP, NGAYMUON, HANTRA, NGAYTRA_THUCTE, TRANGTHAI, MANV_PHUTRACH
	FROM PHIEUMUON, CHITIETPM
	WHERE PHIEUMUON.MAPM = CHITIETPM.MAPM

CREATE VIEW REPORT_PHIEUPHAT
AS
	SELECT *
	FROM PHIEUPHAT

CREATE VIEW REPORT_NHANSU
AS
	SELECT NHANVIEN.MANV, TENNV, GIOITINH, NGAYSINH, DIACHI_NV, PHONE, VAITRO, LAST_LOGIN
	FROM NHANVIEN, _USER_
	WHERE NHANVIEN.MANV  = _USER_.TENTAIKHOAN

delete from NHAXUATBAN
delete from THELOAI
delete from SACH
delete from TACGIA
delete from PHIEUMUON
delete from CHITIETPM
delete from PHIEUPHAT
delete from NHANVIEN
delete from DOCGIA
delete from _USER_



-----Backup-----
alter database QL_THUVIEN
SET RECOVERY FULL

USE master;

BACKUP DATABASE QL_THUVIEN
TO DISK = 'C:\Users\lenovo\OneDrive\Desktop\ql_thuvien.bak'
WITH INIT, DESCRIPTION = 'Backup db ql_thuvien'

BACKUP DATABASE QL_THUVIEN
TO DISK = 'C:\Users\lenovo\OneDrive\Desktop\ql_thuvien_diff.bak'
WITH DIFFERENTIAL

------RESTORE------
BACKUP LOG QL_THUVIEN
TO DISK='E:\QL_THUVIEN_TAILLOG1.TRN'
WITH NO_TRUNCATE

RESTORE DATABASE QL_THUVIEN
FROM DISK='E:\QL_THUVIEN.bak'
WITH NORECOVERY

RESTORE DATABASE QL_THUVIEN
FROM DISK='E:\QL_THUVIEN_DIF2.bak'
WITH NORECOVERY

RESTORE DATABASE QL_THUVIEN
FROM DISK='E:\QL_THUVIEN_LOG2.trn'
WITH NORECOVERY

RESTORE DATABASE QL_THUVIEN
FROM DISK='E:\QL_THUVIEN_TAILLOG1.TRN'
WITH RECOVERY