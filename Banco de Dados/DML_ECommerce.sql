 --DML --> Inserir, alterar ou apagar dados
-- Comando para inserir dados (INSERT INTO)
Use ECommerce

insert into Produto (Nome, Descricao, Preco, EstoqueDisponivel, Categoria, Imagem) 
values 
('Mouse', 'Mouse logitech recarregavel', 99.90, 50, 'Informatica', ''),
('Teclado', 'Mouse logitech recarregavel bluetooth', 209.55, 100, 'Informatica', '')

insert into Cliente (NomeCompleto, Email, Telefone,Endereco, Senha, DataCadastro)
values 
('Marcos Silva', 'mcamilo25@gmail.com', '011991958877', 'Rua niteroi, 500 - Sao Paulo/SP',123456, '01/04/2023'),
('Beatriz Silva', 'bia@gmail.com', '011987948877', 'Rua Para, 124 - Sao Paulo/SP',654321, '01/04/2025')

select * from Cliente

insert into Pedido (DataPedido, Status, ValorTotal,IdCliente)
values 
('05/04/2023', 'Pagamento',99.90 , 2),
('01/05/2025', 'Pagamento',309.45 , 2),
('07/04/2025', 'Pendente', 209.55 , 3)

Select * from Pedido

select * from Pagamento

select * from Produto

insert into Pagamento (IdPedido, FormaPagamento, Status, Data)
values
(2, 'Cartao credito', 'Aprovado', '05/04/2023'),
(3, 'PIX', 'Aprovado', '01/05/2025'),
(4, 'Boleto', ' Pendente', '07/04/2025')

insert into ItemPedido (Quantidade, IdPedido, IdProduto)
values
(1, 2, 1),
(1, 3, 1),
(1, 3, 2),
(1, 4, 2 )

select * from Pagamento

update Pagamento
set Data = '2025-04-07 00:00:00.000'
where IdPagamento = 6

select * from pedido p
inner join ItemPedido ItemPedido on p.IdPedido = ItemPedido.IdPedido

update Pedido
set Status = 'Concluido'
where IdPedido in (1,2)

update Pedido
set Status = 'Processando'
where IdPedido in (3)

delete from Cliente where IdCliente = '1'

--DQL --> e o comando para visualizar os dados
select * from Pagamento
select * from Cliente
select * from ItemPedido
select * from Produto
select * from Pedido