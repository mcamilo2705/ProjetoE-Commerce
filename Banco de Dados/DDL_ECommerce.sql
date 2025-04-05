-- Linguagem SQL (Strutucred Query Language) - Linguagem de consulta estruturada

--TSQL (Microsoft) e PL/SQL (Oracle) --> Tem if else, funcoes

-- SQL --> Comandos
-- DDL --> Criar, Alterar ou Apagar Banco de dados e tabelas
-- DDL --> Data Definition Language
--Comando para criar um banco de dados (create database ECommerce)
--Comando para apagar o banco de dados (drop database ECommerce)
--Comando para definir o banco de dados para trabalhar (use ECommerce)
--Comando para criar uma tabela (create table Cliente), como sugestao nome sempre no 
--singular e a primeira letra maiuscula
--Comando para alter tabela (alter table)

CREATE TABLE Cliente (
--Primary Key --> Coluna que identifica os clientes
--Identity --> Gerar o id automaticamente
IdCliente INT PRIMARY KEY IDENTITY,
NomeCompleto VARCHAR (150),
Email VARCHAR (100),
Telefone VARCHAR(20),
Endereco VARCHAR(255),
DataCadastro DATE
);

CREATE TABLE Pedido(
IdPedido INT PRIMARY KEY IDENTITY,
DataPedido DATE,
Status VARCHAR (20),
ValorTotal DECIMAL (18,6),
--FOREIGN KEY --> Coluna que identifica a chave estrangeira de cliente
--REFERENCES --> Para referenciar a tabela Cliente
IdCliente INT FOREIGN KEY REFERENCES Cliente(IdCliente)
);

CREATE TABLE Pagamento(
IdPagamento INT PRIMARY KEY IDENTITY,
IdPedido INT FOREIGN KEY REFERENCES Pedido(IdPedido),
FormaPagamento VARCHAR (30),
Status VARCHAR (20),
Data DATETIME
);

CREATE TABLE Produto(
IdProduto INT PRIMARY KEY IDENTITY,
Nome VARCHAR (150),
Descricao VARCHAR (255),
Preco DECIMAL (18,6),
EstoqueDisponivel INT,
Categoria VARCHAR (100),
Imagem VARCHAR (255)
);

CREATE TABLE ItemPedido(
IdItemPedido INT PRIMARY KEY IDENTITY,
Quantidade INT,
IdPedido INT FOREIGN KEY REFERENCES Pedido(IdPedido),
IdProduto INT FOREIGN KEY REFERENCES Produto(IdProduto)
);

DROP TABLE ItemPedido;
DROP TABLE Pagamento;
DROP TABLE Produto;
DROP TABLE Pedido;
DROP TABLE Cliente;


-- DML --> Criar, alterar ou apagar dados
-- DML --> Data Manipulation Language


--DQL --> Ver os dados
--DQL --> Data Query Language