create database RentalBike
go

use RentalBike
go

create table Users(
	UserId int IDENTITY(1, 1) primary key,
	Username nvarchar(100) not null,
	Password nvarchar(100) not null,
	AccountStatus nvarchar(50) not null
)

create table Cards(
	CardId int IDENTITY(1, 1) primary key,
	UserId int not null,
	Bank nvarchar(100) not null,
	CardCode varchar(50) not null,
	Owners varchar(50) not null,
	CVV varchar(10) not null,
	DateExpired varchar(10) not null,
	AppCode varchar(50) not null,
	SecurityKey varchar(50) not null,
	FOREIGN KEY (UserId) REFERENCES Users(UserId)
)

create table Stations(
	StationId int IDENTITY(1, 1) primary key,
	NameStation nvarchar(200) not null,
	AddressStation nvarchar(200) not null,
	AreaStaion int not null,
	NumberOfBike int not null,
	Note varchar(100)
)

create table BaseBike(
	BikeId int IDENTITY(1, 1) primary key,
	StationId int not null,
	Images varchar(50),
	Category varchar(10) not null,
	Value int not null,
	QRCode nvarchar(100) not null,
	Manufacturer nvarchar(100) not null,
	BikeStatus bit not null,
	FOREIGN KEY (StationId) REFERENCES Stations (StationId)
)

create table Bikes(
	BikeId int primary key
)

create table Tandem(
	BikeId int primary key
)

create table ElectricBike(
	BikeId int primary key,
	LicensePlate nvarchar(20),
	Powers int not null,
)

create table Transactions(
	TransactionId int IDENTITY(1, 1) primary key,
	UserId int not null,
	BikeId int not null,
	Deposit int not null,
	RentalMoney int not null,
	BeginAt datetime not null,
	EndAt datetime,
	Note nvarchar(100),
	FOREIGN KEY (UserId) REFERENCES Users (UserId),
	FOREIGN KEY (BikeId) REFERENCES BaseBike (BikeId)
)
