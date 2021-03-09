
--create database dbpdv;
use dbpdv;
go

if OBJECT_id('Fornecedores') IS NULL
begin
 create table Fornecedores (
	 IdFornec int identity(1,1) not null,
	 NomeFornec varchar(50) not null
	 CONSTRAINT PK_Fornecedores PRIMARY KEY (IdFornec)
 )
 end
 

if OBJECT_id('Produtos') IS NULL
begin
 create table Produtos (
	IdProduto int identity(1,1) not null,
	NomeProd varchar(50) not null,
	Quantidade decimal(10,5),
	PrecoVenda decimal(10,5),
	PrecoCusto decimal(10,5)
	CONSTRAINT PK_Produtos PRIMARY KEY (IdProduto)
 )
 end

 if object_id('Produtos_Fornecedores') is null
 begin
  create table Produtos_Fornecedores (
		IdProduto int not null,
		IdFornec int not null,
		FornecCodProd varchar(60) not null,
		FornecEanTrib varchar(14) not null,
		CONSTRAINT PK_Produtos_Fornecedores PRIMARY KEY (IdProduto, IdFornec, FornecCodProd, FornecEanTrib),
		CONSTRAINT FK_Produtos_Fornecedores_Prod FOREIGN KEY (IdProduto)
						REFERENCES Produtos (IdProduto),
		CONSTRAINT FK_Produtos_Fornecedores_Fornec FOREIGN KEY (IdFornec)
						REFERENCES Fornecedores (IdFornec)
 )
 end
 
 /*
 drop table Produtos_Fornecedores;
 drop table Fornecedores;
 drop table Produtos;
*/ 