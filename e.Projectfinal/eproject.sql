drop database Eproject


Create database eproject
use eproject

create table category
(
	cat_id int primary key identity,
	cat_name varchar(50) Not Null,
)
create table brands
(
	brd_id int primary key identity,
	brd_name varchar(50) Not Null,
	cat_id int foreign key references category(cat_id)
)
create table produt
(
	pro_id int primary key identity,
	pro_name varchar(50) Not Null,
	pro_price varchar(50) not Null,
	proQuantity varchar(50) Not Null,
	cat_id int foreign key references category(cat_id),
	brd_id int foreign key references brands(brd_id)
)
drop table AddProducts

/* Category Start */
create proc insertIncatgory
(
	@cat_name varchar(50)
)
as 
begin
	insert into category
	values(@cat_name)
end
create proc UpdateIncatgory
(
	@cat_id int,
	@cat_name varchar(50)
)
as 
begin
	update category set cat_name=@cat_name
	where cat_id=@cat_id
end

delete from category where cat_id=1

truncate table  category 
create proc DeleteIncatgory
(
	@cat_id int
)
as 
begin
	delete from category where cat_id=@cat_id
end

create proc SelecttIncatgory

as 
begin
	select * from category
end

/* Brands Start */

create proc insertInBrands
(
	@brandName varchar(50),
	@cat_id int
)
as 
begin
	insert into brands
	values(@brandName,@cat_id)
end
create proc UpdateInBrands
(
	@brand_id int,
	@brand_name varchar(50),
	@cat_id int
)
as 
begin
	update brands set brd_name=@brand_name
	where brd_id=@brand_id And cat_id=@cat_id
end
create proc DeleteInBrand
(
	@brand_id int
)
as 
begin
	delete from brands where brd_id=@brand_id	
end
create proc SelectInBrand
as 
begin
	select brands.brd_id, brands.brd_name,category.cat_name,category.cat_id
	from brands
	inner join category
	on brands.cat_id=category.cat_id
end

create proc SelectInBrandByCat
	@cat_id int
as 
begin
	select brands.brd_id, brands.brd_name,category.cat_name
	from brands
	inner join category
	on brands.cat_id=category.cat_id
	where category.cat_id=@cat_id
end

/* Product Start */

create proc insertInProducts
(
	@ProductName varchar(50),
	@ProductPrice varchar(50),
	@ProductQuantity varchar(50),
	@brand_id int,
	@cat_id int
)
as 
begin
	insert into produt
	values(@ProductName,@ProductPrice,@ProductQuantity,@brand_id,@cat_id)
end


create proc UpdateInProducts
(
	@product_id int,
	@cat_id int,
	@ProductName varchar(50),
	@ProductPrice varchar(50),
	@ProductQuantity varchar(50),
	@brand_id int
	
)
as 
begin
	update produt set cat_id=@cat_id,pro_name=@ProductName,pro_price=@ProductPrice,proQuantity=@ProductQuantity,brd_id=@brand_id
	where pro_id=@product_id
end


create proc DeleteInProduct
(
	@pro_id int
)
as 
begin
	delete from produt where pro_id=@pro_id 
end

create proc SelectInProduct
as 
begin
	select produt.pro_id,produt.pro_name,produt.pro_price,produt.proQuantity,brands.brd_name,category.cat_name
	from produt
		inner join brands
		on produt.brd_id=brands.brd_id
		
		inner join category
		on produt.cat_id=category.cat_id 

end

exec SelectInProduct

create proc SelectfromSerchWise
(
	@Alpabeat varchar(100)
)
as 
begin
	select produt.pro_id,produt.pro_name,produt.pro_price,produt.proQuantity,brands.brd_name,category.cat_name
	from produt
		inner join brands
		on produt.brd_id=brands.brd_id
		
		inner join category
		on produt.cat_id=category.cat_id 
		where pro_name like @Alpabeat+'%'

end

exec SelectfromSerchWise 'b'