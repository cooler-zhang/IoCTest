create database Test

go

use Test

go

create table Product
(
	Id int primary key identity,
	Name varchar(50) not null,
	CatalogId int,
	[Desc] varchar(500)
)

select * from Product;

insert into Product(Name,[Desc]) values('Product A','Good Product');
insert into Product(Name,CatalogId,[Desc]) values('Product B',1,'Good Product');

go

create table Catalog
(
	Id int primary key identity,
	Name varchar(50) not null
)

insert into Catalog(Name) values('Catalog A');