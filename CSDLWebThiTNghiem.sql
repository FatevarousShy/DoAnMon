
use master
drop database web

CREATE DATABASE web 
go
use web
go



create table TaiKhoan
(
	MaTK int IDENTITY(1,1),
	TenDangNhap varchar(50),
	MatKhau varchar(50) not null,
	Email varchar(100),	
	CONSTRAINT PK_TaiKhoan PRIMARY KEY(MaTK),
)

create table ThongTin
(
	MaTTCN int identity(1,1),
	MaTK int,
	HoTen nvarchar(150),
	GioiThieu nvarchar(300),
	DiaChi nvarchar (150),
	DienThoai nvarchar(10),
	NgaySinh DATETIME,
	AnhCaNhan varchar(50),
	CONSTRAINT PK_ThongTin PRIMARY KEY(MaTTCN),
	constraint FK_TaiKhoan foreign key (MaTK) references TaiKhoan (MaTK)
);

create table SuaDe
(
	MaSuaDe int identity(1,1),
	MaTTCN int,
	NguoiSua nvarchar(150),
	constraint PK_SuaDe PRIMARY KEY(MaSuaDe),
	constraint FK_ThongTin foreign key (MaTTCN) references ThongTin (MaTTCN)
);

create table PhanThi
(
	MaPhan int identity(1,1) ,
	TenPhan nvarchar(20) not null,
	CONSTRAINT PK_PhanThi PRIMARY KEY(MaPhan)
);

create table CTSuaDe
(
	MaSuaDe int ,
	MaDe int ,
	NgaySua datetime ,
	constraint PK_CTSuaDe primary key (MaSuaDe,MaDe),
	constraint CTSuaDe_SuaDe foreign key (MaSuaDe) references SuaDe (MaSuaDe),
	constraint CTSuaDe_DeThi foreign key (MaDe) references DeThi (MaDe)
);
create table DeThi
(
	MaDe int identity(1,1) ,
	TenDe nvarchar(20) not null,
	AnhBia varchar(50),
	NgaycapNhat datetime,
	MaPhan int,
	MaCauHoi int,
	constraint PK_DeThi PRIMARY KEY(MaDe),
	constraint FK_PhanThi foreign key (MaPhan) references PhanThi (MaPhan),
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
	DapAnDung int,
	constraint PK_CauHoi PRIMARY KEY(MaCauHoi)
);





INSERT TaiKhoan(TenDangNhap, Matkhau, Email)
VALUES (N'minhabc',N'123', '123@hgmail.com')

INSERT TaiKhoan(TenDangNhap, Matkhau, Email)
VALUES (N'thuabc',N'321', '321@hgmail.com')


Insert ThongTin(MaTK,HoTen,GioiThieu,DiaChi,DienThoai,NgaySinh)
values (1,N'ava',N'asda',N'ava','123456789','01/01/2000')

Insert ThongTin(MaTK,HoTen,GioiThieu,DiaChi,DienThoai,NgaySinh)
values (2,N'1aava',N'asda',N'ava','123456789','01/01/2000')


/* PhanThi */
insert PhanThi(TenPhan)
values (N'Phần A1')

insert PhanThi(TenPhan)
values (N'Phần A2')

/***** DeThi ******/

insert DeThi(TenDe,AnhBia,NgaycapNhat,MaPhan)
values (N'Đề thi 01',N'de02.jpg','02/14/2021',1)

insert DeThi(TenDe,AnhBia,NgaycapNhat,MaPhan)
values (N'Đề thi 02',N'de03.png','05/12/2021',1)

insert DeThi(TenDe,AnhBia,NgaycapNhat,MaPhan)
values (N'Đề thi 01',N'de02.jpg','06/05/2021',2)

insert DeThi(TenDe,AnhBia,NgaycapNhat,MaPhan)
values (N'Đề thi 03',N'de05.png','03/16/2021',1)

insert DeThi(TenDe,AnhBia,NgaycapNhat,MaPhan)
values (N'Đề thi 04',N'de04.jpg','05/07/2021',2)

insert DeThi(TenDe,AnhBia,NgaycapNhat,MaPhan)
values (N'Đề thi 02',N'de03.png','05/16/2021',2)