CREATE DATABASE Move_Ofertas;
GO

--DROP DATABASE Move_Ofertas;
--GO

USE Move_Ofertas;
GO

--Tipo Usuario

CREATE TABLE TIPOUSUARIO (
	idTipoUsuario TINYINT PRIMARY KEY IDENTITY,
	nomeTipoUsuario VARCHAR(70) UNIQUE NOT NULL
);
GO

--Situação

CREATE TABLE SITUACAO (
	idSituacao TINYINT PRIMARY KEY IDENTITY,
	nomeSituação VARCHAR(70) UNIQUE NOT NULL
);
GO

--Categoria

CREATE TABLE CATEGORIA (
	idCategoria SMALLINT PRIMARY KEY IDENTITY,
	nomeCategoria VARCHAR(70) UNIQUE NOT NULL
);
GO

--Usuario

CREATE TABLE USUARIO (
	idUsuario INT PRIMARY KEY IDENTITY,
	idTipoUsuario TINYINT FOREIGN KEY REFERENCES TIPOUSUARIO(idTipoUsuario),
	nomeUsuario VARCHAR(100) NOT NULL,
	email VARCHAR(256) NOT NULL,
	senha VARCHAR(18) NOT NULL
);
GO

--Empresa

CREATE TABLE EMPRESA (
	idEmpresa INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES USUARIO(idUsuario),
	nomeEmpresa VARCHAR(100) UNIQUE NOT NULL,
	razaoSocial VARCHAR(100) UNIQUE NOT NULL,
	endereco VARCHAR(150) UNIQUE NOT NULL,
	CNPJ CHAR(14) UNIQUE NOT NULL,
	telefone VARCHAR(13) UNIQUE NOT NULL
);
GO

--Cliente

CREATE TABLE CLIENTE (
	idCliente INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES USUARIO(idUsuario),
	nomeCliente VARCHAR(100) UNIQUE NOT NULL, 
	dataNascimento DATETIME NOT NULL,
	CPF CHAR(12) UNIQUE NOT NULL,
	RG CHAR(9) UNIQUE NOT NULL,
	telefone VARCHAR(12), 
	endereco VARCHAR(150) UNIQUE NOT NULL
);
GO

--Oferta

CREATE TABLE OFERTA (
	idOferta INT PRIMARY KEY IDENTITY,
	idCategoria SMALLINT FOREIGN KEY REFERENCES CATEGORIA(idCategoria),
	idEmpresa INT FOREIGN KEY REFERENCES EMPRESA(idEmpresa),
	idSituacao TINYINT FOREIGN KEY REFERENCES SITUACAO(idSituacao),
	nomeProduto VARCHAR(160) NOT NULL,
	valor MONEY NOT NULL,
	quantidade VARCHAR(50) NOT NULL,
	dataFabricacao DATE NOT NULL,
	dataValidade DATE,
	descricao VARCHAR(260) NOT NULL
);
GO

--Reserva

CREATE TABLE RESERVA (
	idReserva INT PRIMARY KEY IDENTITY,
	idCliente INT FOREIGN KEY REFERENCES CLIENTE(idCliente),
	idSituacao TINYINT FOREIGN KEY REFERENCES SITUACAO(idSituacao),
	idOferta INT FOREIGN KEY REFERENCES OFERTA(idOferta),
	dataReserva DATETIME NOT NULL
);
GO

--Imagem Ofertas

CREATE TABLE IMAGEMOFERTA (
	id INT PRIMARY KEY identity(1,1),
	idOferta INT NOT NULL UNIQUE FOREIGN KEY REFERENCES OFERTA(idOferta),
	binario VARBINARY(MAX) NOT NULL,
	mimeType VARCHAR(30) NOT NULL,
	nomeArquivo VARCHAR(250) NOT NULL,
	data_inclusao DATETIME DEFAULT GETDATE() NULL
);
GO