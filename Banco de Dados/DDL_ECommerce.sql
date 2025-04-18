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
NomeCompleto VARCHAR (150) NOT NULL, --NOT NULL e uma forma que torna o preenchimento obrigatorio 
Email VARCHAR (100) NOT NULL UNIQUE, --Unique e uma restricao para informar que nenhum email pode se repetir no banco
Telefone VARCHAR(20),
Endereco VARCHAR(255),
Senha VARCHAR(255) NOT NULL,
DataCadastro DATE
);

CREATE TABLE Pedido(
IdPedido INT PRIMARY KEY IDENTITY,
DataPedido DATE NOT NULL,
Status VARCHAR (20) NOT NULL,
ValorTotal DECIMAL (18,6),
--FOREIGN KEY --> Coluna que identifica a chave estrangeira de cliente
--REFERENCES --> Para referenciar a tabela Cliente
IdCliente INT FOREIGN KEY REFERENCES Cliente(IdCliente) NOT NULL
);

CREATE TABLE Pagamento(
IdPagamento INT PRIMARY KEY IDENTITY,
IdPedido INT FOREIGN KEY REFERENCES Pedido(IdPedido) NOT NULL,
FormaPagamento VARCHAR (30) NOT NULL,
Status VARCHAR (20) NOT NULL,
Data DATETIME NOT NULL
);

CREATE TABLE Produto(
IdProduto INT PRIMARY KEY IDENTITY,
Nome VARCHAR (150) NOT NULL,
Descricao VARCHAR (255),
Preco DECIMAL (18,6) NOT NULL,
EstoqueDisponivel INT NOT NULL,
Categoria VARCHAR (100) NOT NULL,
Imagem VARCHAR (255)
);

CREATE TABLE ItemPedido(
IdItemPedido INT PRIMARY KEY IDENTITY,
Quantidade INT NOT NULL,
IdPedido INT FOREIGN KEY REFERENCES Pedido(IdPedido) NOT NULL,
IdProduto INT FOREIGN KEY REFERENCES Produto(IdProduto) NOT NULL
);

/*
DROP TABLE ItemPedido;
DROP TABLE Pagamento;
DROP TABLE Produto;
DROP TABLE Pedido;
DROP TABLE Cliente;
*/

--Exemplo de alterar a tabela e colunas sem a necessidade de deletar a tabela
--ALTER TABLE Cliente ALTER COLUMN NomeCompleto VARCHAR (150) NOT NULL

-- DML --> Criar, alterar ou apagar dados
-- DML --> Data Manipulation Language


--DQL --> Ver os dados
--DQL --> Data Query Language