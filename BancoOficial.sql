create database db_ExemploVitoria;

use db_ExemploVitoria;

CREATE TABLE tbUsuario
(
IdUsu INT PRIMARY KEY AUTO_INCREMENT,
NomeUsu VARCHAR(50) NOT NULL,
Cargo VARCHAR(50) not null,
DataNasc DATETime
);

INSERT INTO tbUsuario(NomeUsu,Cargo,DataNasc)
	VALUES('Bob', 'Monstrorista', '2019-04-16'),
    ('Emma','Cerimonialista','2000-04-17'),
    ('Gina','Limpador de Vômito','2001-01-28'),
    ('Astrogildo', 'Pentelho','2001-01-28');

UPDATE tbUsuario SET NomeUsu = 'teste', Cargo = 'teste', DataNasc = STR_TO_DATE('02/02/2020 00:00:00', '%d/%m/%Y %T') WHERE IdUsu = 3;
select * from tbUsuario;

UPDATE tbUsuario SET NomeUsu = 'Bianca', Cargo = 'Cantora', DataNasc = '09/03/2000';

UPDATE tbUsuario SET NomeUsu = 'Tereza', Cargo = 'teste', DataNasc = '2000/02/21';