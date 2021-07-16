
use master
drop database web

CREATE DATABASE web 
go
use web
go


create table TaiKhoan
(
	MaTK int IDENTITY(1,1),
	TenTaiKhoan varchar(50),
	MatKhau varchar(50) not null,
	Email varchar(100),	
	CONSTRAINT PK_TaiKhoan PRIMARY KEY(MaTK),
)
create table ThongTin
(
	MaTTCN int identity(1,1),
	MaTK int,
	HoTen nvarchar(150) ,
	GioiThieu nvarchar(300),
	DiaChi nvarchar (150),
	DienThoai nvarchar(10),
	NgaySinh DATETIME,
	AnhCaNhan varchar(50),
	CONSTRAINT PK_ThongTin PRIMARY KEY(MaTTCN),
	constraint FK_TaiKhoan foreign key (MaTK) references TaiKhoan (MaTK)
);


create table BaiThi
(
	MaBaiThi int identity(1,1) ,
	TenBaiThi nvarchar(20) not null,
	AnhBia varchar(50),
	NgayLam datetime,
	MaTTCN int,
	constraint PK_BaiThi PRIMARY KEY(MaBaiThi),
	constraint FK_ThongTin foreign key (MaTTCN) references ThongTin (MaTTCN)
);

create table CTBaiThi
(
	MaBaiThi int,
	MaCauHoi int,
	DapAn int check(DapAn >0),
	constraint PK_CTBaiThi PRIMARY KEY(MaBaiThi,MaCauHoi),
	constraint FK_CTBaiThi foreign key (MaBaiThi) references BaiThi (MaBaiThi),
	constraint FK_CauHoi foreign key (MaCauHoi) references CauHoi (MaCauHoi)
);

create table CauHoi
(
	MaCauHoi int identity(1,1),
	NoiDungCauHoi nvarchar(1000) not null,
	A nvarchar(600) ,
	B nvarchar(600) ,
	C nvarchar(600) ,
	D nvarchar(600) , 
	AnhCauHoi varchar(50),
	DapAnDung int check(DapAnDung > 0),
	constraint PK_CauHoi PRIMARY KEY(MaCauHoi)
);

create table BoDe
(
	MaBoDe int identity(1,1) ,
	TenBoDe nvarchar(20) not null,
	AnhBia varchar(50),
	NgaycapNhat datetime,
	MaDanhMucBoDe int,
	constraint PK_BoDeThi PRIMARY KEY(MaBoDe),
	constraint FK_DanhMucBoDe foreign key (MaDanhMucBoDe) references DanhMucBoDe (MaDanhMucBoDe)

);
create table DanhMucBoDe
(
	MaDanhMucBoDe int identity(1,1) ,
	TenDanhMucBoDe nvarchar(20) not null,	
	constraint PK_DanhMucBoDe PRIMARY KEY(MaDanhMucBoDe)
)


INSERT TaiKhoan(TenTaiKhoan, Matkhau, Email)
VALUES (N'minhabc',N'123', '123@hgmail.com')

INSERT TaiKhoan(TenTaiKhoan, Matkhau, Email)
VALUES (N'thuabc',N'321', '321@hgmail.com')


Insert ThongTin(MaTK,HoTen,GioiThieu,DiaChi,DienThoai,NgaySinh)
values (1,N'ava',N'asda',N'ava','123456789','01/01/2000')

Insert ThongTin(MaTK,HoTen,GioiThieu,DiaChi,DienThoai,NgaySinh)
values (2,N'1aava',N'asda',N'ava','123456789','01/01/2000')


/* PhanThi */
insert DanhMucBoDe(TenDanhMucBoDe)
values (N'A1')

insert DanhMucBoDe(TenDanhMucBoDe)
values (N'A2')

insert DanhMucBoDe(TenDanhMucBoDe)
values (N'B1')

insert DanhMucBoDe(TenDanhMucBoDe)
values (N'C')


/***** DeThi ******/

insert BoDe(TenBoDe,AnhBia,NgaycapNhat,MaDanhMucBoDe)
values (N'Đề thi 01',N'de02.jpg','02/14/2021',1)

insert BoDe(TenBoDe,AnhBia,NgaycapNhat,MaDanhMucBoDe)
values (N'Đề thi 02',N'de03.png','05/12/2021',1)

insert BoDe(TenBoDe,AnhBia,NgaycapNhat,MaDanhMucBoDe)
values (N'Đề thi 03',N'de05.png','03/16/2021',1)

insert BoDe(TenBoDe,AnhBia,NgaycapNhat,MaDanhMucBoDe)
values (N'Đề thi 01',N'de02.jpg','06/05/2021',2)

insert BoDe(TenBoDe,AnhBia,NgaycapNhat,MaDanhMucBoDe)
values (N'Đề thi 02',N'de04.jpg','05/07/2021',2)

insert BoDe(TenBoDe,AnhBia,NgaycapNhat,MaDanhMucBoDe)
values (N'Đề thi 03',N'de07.jpg','05/10/2021',2)

insert BoDe(TenBoDe,AnhBia,NgaycapNhat,MaDanhMucBoDe)
values (N'Đề thi 01',N'de08.jpg','07/16/2021',3)

insert BoDe(TenBoDe,AnhBia,NgaycapNhat,MaDanhMucBoDe)
values (N'Đề thi 02',N'de01.png','02/15/2021',3)

insert BoDe(TenBoDe,AnhBia,NgaycapNhat,MaDanhMucBoDe)
values (N'Đề thi 03',N'de06.png','10/16/2021',4)

insert BoDe(TenBoDe,AnhBia,NgaycapNhat,MaDanhMucBoDe)
values (N'Đề thi 01',N'de03.png','04/25/2021',4)

/** CauHoi ****/
insert CauHoi(NoiDungCauHoi,A,B,C,D,DapAnDung)
	
	

create table admin
(
	UserAdmin varchar(30) primary key,
	PassAdmin varchar(30) not null,
	Hoten nVarchar(50)
)
Insert into admin values('admin','123456',N'Nguyen Van A')
Insert into admin values('user','654321',N'Mr A')
	
select * from ThongTin
select * from TaiKhoan


delete from TaiKhoan
delete from ThongTin
