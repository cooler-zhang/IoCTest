create database Test

go

use Test

go

create table Product
(
	Id int primary key identity,
	Name varchar(50) not null,
	[Desc] varchar(500)
)

insert into Product(Name,[Desc]) values('Product A','Good Product');
insert into Product(Name,[Desc]) values('Product B','Good Product');