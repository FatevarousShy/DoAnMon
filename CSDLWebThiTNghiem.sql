use master
/*drop database web*/

drop table TaiKhoan;

CREATE DATABASE web
go 
use web

SET IDENTITY_INSERT dbo.TaiKhoan ON



create table TaiKhoan
(
	MaTK int IDENTITY(1,1) PRIMARY KEY,
	/*HoTen nvarchar(50) not null,*/
	TenDangNhap varchar(50),
	MatKhau varchar(50) not null,
	/*GioiTinh nvarchar(5) ,
	DiaChi nvarchar(100) ,
	DienThoai varchar(50) ,*/
	Email varchar(100),
)

SET IDENTITY_INSERT TaiKhoan OFF

create table CauHoi
(
	MaCauHoi int IDENTITY(1,1) primary key,
	NoiDungCauHoi nvarchar(1000) not null,
	A nvarchar(600) ,
	B nvarchar(600) ,
	C nvarchar(600) ,
	D nvarchar(600) , 
	DapAnDung int 
);

create table BaiThi
(
	MaBaiThi varchar(20) primary key,
	Diem int check(Diem>=0),
	DapAn int ,
	MaCauHoi int ,
	constraint BaiThi_CauHoi foreign key (MaCauHoi) references CauHoi (MaCauHoi)
);

create table DeThi
(
	MaDe varchar(20) primary key,
	TenDe nvarchar(20) not null,
	MaBaiThi varchar(20),
	constraint DeThi_BaiThi foreign key (MaBaiThi) references BaiThi (MaBaiThi)
);

create table PhanThi
(
	MaPhan varchar(20) primary key,
	TenPhan nvarchar(20) not null,
	MaDe varchar(20),
	constraint PhanThi_DeThi foreign key (MaDe) references DeThi (MaDe)
);

create table CTDeThi
(
	MaPhan varchar(20) ,
	MaDe varchar(20) ,
	SoLuong int check(SoLuong>0),
	GiaDe decimal(18,0) check(GiaDe>=0),
	constraint PK_CTDeThi primary key (MaPhan,MaDe),
	constraint CTDeThi_PhanThi foreign key (MaPhan) references PhanThi (MaPhan),
	constraint CTDeThi_DeThi foreign key (MaDe) references DeThi (MaDe)
);

create table CTBaiThi
(
	MaBaiThi varchar(20) ,
	MaCauHoi int ,
	SoCauHoi int check(SoCauHoi>0),
	TenBaiThi nvarchar(20) not null,
	constraint PK_CTBaiThi primary key (MaBaiThi,MaCauHoi),
	constraint CTDeThi_BaiThi foreign key (MaBaiThi) references BaiThi (MaBaiThi),
	constraint CTDeThi_CauHoi foreign key (MaCauHoi) references CauHoi (MaCauHoi)
);

INSERT TaiKhoan(TenDangNhap, Matkhau, Email)
VALUES (N'123',N'123', '123@hgmail.com')

INSERT TaiKhoan(TenDangNhap, Matkhau, Email)
VALUES (N'321',N'321', '321@hgmail.com')
