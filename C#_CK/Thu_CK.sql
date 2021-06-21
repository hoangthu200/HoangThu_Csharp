CREATE DATABASE VoThiHoangThuDB


CREATE TABLE AdminAccount
(
	ID int IDENTITY(1,1) primary key,
	UserName  char(50) NOT NULL,
	PassWord char(100) NOT NULL,
	Status varchar(100)
)
drop table UserAccount

CREATE TABLE UserAccount
(
	ID int IDENTITY(1,1) primary key,
	UserName  char(50) NOT NULL,
	PassWord char(100) NOT NULL,
	Status varchar(100)
)

insert into UserAccount(UserName,PassWord,Status)
values('hoangthu','e10adc3949ba59abbe56e057f20f883e','Active')

CREATE TABLE Category
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(200) NOT NULL,
	Description nvarchar(200)
)
insert into Category(Name,Description)
values(N'Điện Thoại',N'Uy Tín - Chất Lượng cao')

CREATE TABLE Product
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(200) NOT NULL,
	UnitCost decimal(10,2),
	Quantity INT not null,
	Image varchar(200),
	Description nvarchar(200),
	Status int,
	IDCategory int foreign key references Category(ID)
)
select * from Product
insert into Product(Name,UnitCost,Quantity,Image,Description,Status,IDCategory)
values('Iphone 12X',10000000,1,'ip1.png','Sản phẩm mới',1,1)