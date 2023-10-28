create database Farmacia2021
go
use Farmacia2021

create table Productos
(
Id int identity (1,1) primary key,
Nombre varchar(100),
Laboratorio varchar(100),
Descripcion varchar(150),
Precio float,
Stock int
)

insert into Productos values ('Amox','Patito','500mg','700','15')
select *from Productos
go

create proc MostrarProducto
as
select *from Productos
go

create proc AgregarProducto
@nombre varchar(100),
@laboratorio varchar(100),
@descripcion varchar(150),
@precio float,
@stock int
as
insert into Productos values (@nombre,@laboratorio,@descripcion,@precio,@stock)
go


create proc EliminarProducto
@idprod int
as
delete from Productos where Id=@idprod
go

create proc ModificarProducto
@nombre varchar(100),
@laboratorio varchar(100),
@descripcion varchar(150),
@precio float,
@stock int,
@id int
as
update Productos set Nombre=@nombre, Laboratorio=@laboratorio,Descripcion=@descripcion,Precio=@precio,Stock=@stock where Id=@id
go


create proc BuscarProducto
@nombre varchar (200)
as
select * from Productos where Nombre like @nombre + '%'
go