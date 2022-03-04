USE Move_Ofertas;
GO

INSERT INTO TIPOUSUARIO(nomeTipoUsuario)
VALUES ('Empresa'),('Cliente');
GO

INSERT INTO SITUACAO(nomeSituação)
VALUES ('Aceita'),('Negada'),('Pendente');
GO

INSERT INTO CATEGORIA (nomeCategoria)
VALUES ('Alimentos'),('Esportes e Lazer'),
	   ('Eletrônicos'),('Moda e Beleza'),('Cozinha'),
       ('Limpeza'),('Domésticos'),('Acessórios para Pets');
GO

INSERT INTO USUARIO(idTipoUsuario,nomeUsuario,email,senha)
VALUES ('1','Cobasi','cobasi@email.com','123456789'),
	   ('1','Puma','puma@email.com','123456789'),
	   ('2','José','jose@email.com','987654321'),
	   ('2','Adriana','adria@email.com','987654321');
GO

INSERT INTO EMPRESA(idUsuario,nomeEmpresa,razaoSocial,endereco,CNPJ,telefone)
VALUES ('1','Cobasi','Cobasi Comercio de Produtos Basicos e Industrializados S.A.','Av. Braz Leme, 278 - Casa Verde, São Paulo - SP','53153938001694','1143800940'),
	   ('2','Puma','Puma Sports Ltda.','R. Mal. Deodoro, 2690 - Centro, São Bernardo do Campo - SP','05406034002067','1121772477');
GO

INSERT INTO CLIENTE(idUsuario,nomeCliente,RG,endereco,CPF,telefone,dataNascimento)
VALUES ('3','José','123211234','Alameda Barão de Limeira, 539 - Santa Cecilia, São Paulo - SP, 01202-001','98776556712','1191234356','01/09/2002'),
	   ('4','Adriana','877655679','R. Vitorino Carmilo, 290-382 - Barra Funda','98712363598','11987654567','02/07/2000');
GO

INSERT INTO OFERTA(idCategoria,idEmpresa,idSituacao,nomeProduto,valor,quantidade,dataFabricacao,dataValidade,descricao)
VALUES ('8','1','1','Ração','20.00','10','01/01/2022','28/02/2022','Ração de qualidade'),
	   ('4','2','1','Camiseta','50.00','20','02/01/2022','','Tamanho P'),
	   ('4','2','1','Tênis','100.00','15','01/01/2022','','Número 41');
GO

INSERT INTO RESERVA(idCliente,idSituacao,idOferta,dataReserva)
VALUES ('1','1','1','25/02/2022'),
	   ('2','1','2','25/02/2022');
GO