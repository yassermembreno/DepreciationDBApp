create database DepreciationDB
go
use DepreciationDB
go

create table Asset(
	[id] int primary key identity(1,1),
	[name] varchar(50) not null,
	[description] varchar(200) not null,
	[amount] decimal(9,2) not null,
	[amountResidual] decimal(9,2) not null,
	[Terms] int not null,
	[code] varchar(100) not null,
	[status] varchar(50) not null,
	[isActive] bit not null
)
go
create table Employee(
	[id] int primary key identity(1,1),
	[names] varchar(50) not null,
	[lastnames] varchar(50) not null,
	[address] varchar(200) not null,
	[phone] varchar(16) not null,
	[email] varchar(100) not null,
	[dni] varchar(20) not null,
	[status] varchar(50) not null
)
go
create table AssetEmployee(
	[id] int primary key identity(1,1),
	[assetId] int not null,
	[employeeId] int not null,
	[date] date not null,
	[isActive] bit not null
)
go
alter table AssetEmployee
add constraint fk_asset foreign key (assetId) 
references Asset(id)
go
alter table AssetEmployee
add constraint fk_employee foreign key (employeeId) 
references Employee(id)

