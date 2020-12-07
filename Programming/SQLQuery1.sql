create database RentalBike
go

use RentalBike
go

create table Cards(
	CardId int IDENTITY(1, 1) primary key,
	Bank nvarchar(100) not null,
	ExpirationDate datetime default getdate(),
	SecurityCode nvarchar(10) not null,
	PrivateToken nvarchar(100) not null,
	Note nvarchar(100)
)

create table Users(
	UserId int IDENTITY(1, 1) primary key,
	CardId int not null,
	UserName nvarchar(200) not null,
	Age int not null,
	AccountName nvarchar(100) not null,
	AccountPassword nvarchar(100) not null,
	CusAddress nvarchar(200) not null,
	Email nvarchar(100) not null,
	Phone nvarchar(100) not null,
	Gender nvarchar(10) not null,
	AccountStatus nvarchar(50) not null,
	FOREIGN KEY (CardId) REFERENCES Cards (CardId)
)

create table Stations(
	StationId int IDENTITY(1, 1) primary key,
	NameStation nvarchar(200) not null,
	AddressStation nvarchar(200) not null,
	AreaStaion int not null,
	NumberOfBike int not null,
	Note varchar(100)
)

create table Bikes(
	BikeId int IDENTITY(1, 1) primary key,
	StationId int not null,
	QRCode nvarchar(100) not null,
	Category nvarchar(20) not null,
	LicensePlate nvarchar(20),
	Manufacturer nvarchar(100) not null,
	BikeStatus bit not null,
	FOREIGN KEY (StationId) REFERENCES Stations (StationId)
)

create table Transactions(
	TransactionId int IDENTITY(1, 1) primary key,
	UserId int not null,
	BikeId int not null,
	Deposit int not null,
	RentalMoney int not null,
	TotalTimeRent int not null,
	DateTransaction datetime default getdate(),
	Note nvarchar(100),
	FOREIGN KEY (UserId) REFERENCES Users (UserId),
	FOREIGN KEY (BikeId) REFERENCES Bikes (BikeId)
)


use RentalBike
go

insert into Cards(Bank, ExpirationDate, SecurityCode, PrivateToken)
values ('ABank','2022-10-10','564987','xyz'),
('BBank','2022-11-10','521221','xyz'),
('CBank','2022-7-10','451221','xyz'),
('DBank','2022-6-10','956131','xyz');

insert into Users(CardId ,UserName, Age, AccountName, AccountPassword, CusAddress, Email, Phone, Gender, AccountStatus)
values (2,N'Ngô Minh Quang',21,'minhquang','quang',N'Hà Nội','quang.nm173326@gmail.com','0986868686','Nam',N'Bị khóa'),
(1,N'Phạm Hồng Phúc',21,'hongphuc','phuc',N'Hà Nội','phuc.ph@gmail.com','0969696969','Nam',N'Bình thường'),
(4,N'Sư Hữu Vũ Quang',22,'vuquang','quang',N'Hà Nội','quang.shv@gmail.com','0988888888','Nam',N'Bình thường'),
(3,N'Trần Minh Quang',21,'minhquang1','quang',N'Hà Nội','quang.tm@gmail.com','0966666666','Nam',N'Bình thường');

insert into Stations(NameStation, AddressStation, AreaStaion, NumberOfBike)
values ('B',N'Hà Nội',1,50),
('T',N'Đà Nẵng',2,30),
('N',N'Hồ Chí Minh',3,40);

insert into Bikes( StationId, QRCode, Category, LicensePlate, Manufacturer, BikeStatus)
values (1,'***',N'xe đạp điện','34-B1 15-28', 'X', 0),
(2,'***',N'xe đạp đôi','', 'Y', 0),
(3,'***',N'xe đạp thường','', 'Z', 0);

insert into Transactions(UserId, BikeId, Deposit, RentalMoney, TotalTimeRent, DateTransaction)
values (3,1,20000000,50000, 60, 2020-11-10),
(4,3,1000000,50000, 120, 2020-11-10),
(1,2,2000000,20000, 60, 2020-11-10);