drop database if exists eazyDiary;
create database eazyDiary;
use eazyDiary;

create table tasks(
id int auto_increment primary key not null,
nome varchar(120),
descricao varchar(120),
incremento varchar(120),
dateInit DATETIME,
dateEnd DATETIME
);

insert into tasks (nome, descricao, incremento, dateInit, dateEnd) values ("Teste", "Teste", "Teste", '2002-01-20  23:59:59', '2002-01-20 23:59:59');
select * from tasks;
