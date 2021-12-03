drop database ControlDocumentos;
create database ControlDocumentos;


use [ControlDocumentos]

drop table Usuario
drop table departamentos
drop table documento

create table Usuario
(
Idempleado int IDENTITY PRIMARY KEY,
Nombre varchar(50),
Cedula varchar (30) unique,
Correo varchar (30),
Clave varchar (30),
Departamento varchar (40),
Cargo varchar (40)
);
select * from Usuario
insert into Usuario(Nombre, Cedula, Correo, Clave, Departamento, Cargo ) values ('Juan','402-98635-5','juan@juan.com','1234','ventas','vendedor')
create table departamentos

(
iddepto int IDENTITY PRIMARY KEY,
codigodepto varchar(30),
nombredepto varchar(30),
);

select * from departamentos
insert into departamentos (codigodepto, nombredepto) values ('1202','ventas')
create table documento
(
iddoc int IDENTITY PRIMARY KEY,
tipodoc varchar(30),
coddoc varchar (20),
cedulaempleado varchar (30),
fechacreacion varchar (20),
departamentoorigen varchar (30),
departamentodestino varchar (30)
);

select * from documento

CREATE PROCEDURE date_range
@fechaini VARCHAR(30),
@fechafi VARCHAR(30)
AS 
SELECT  * FROM documento WHERE  fechacreacion BETWEEN @fechaini AND @fechafi