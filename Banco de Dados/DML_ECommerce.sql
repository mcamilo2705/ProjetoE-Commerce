 --DML --> Inserir, alterar ou apagar dados
-- Comando para inserir dados (INSERT INTO)
Use ECommerce

insert into Produto (Nome, Descricao, Preco, EstoqueDisponivel, Categoria, Imagem) 
values 
('Mouse', 'Mouse logitech recarregavel', 99.90, 50, 'Informatica', ''),
('Teclado', 'Mouse logitech recarregavel bluetooth', 209.55, 100, 'Informatica', '')

insert into Cliente (NomeCompleto, Email, Telefone,Endereco,DataCadastro)
values 
('Marcos Silva', 'mcamilo25@gmail.com', '011991958877', 'Rua niteroi, 500 - Sao Paulo/SP', '01/04/2023'),
('Beatriz Silva', 'bia@gmail.com', '011987948877', 'Rua Para, 124 - Sao Paulo/SP', '01/04/2025')

insert into Pedido (DataPedido, Status, ValorTotal,IdCliente)
values 
('05/04/2023', 'Pagamento',99.90 , 1),
('01/05/2025', 'Pagamento',309.45 , 1),
('07/04/2025', 'Pendente', 209.55 , 2)

insert into Pagamento (IdPedido, FormaPagamento, Status, Data)
values
(1, 'Cartao credito', 'Aprovado', '05/04/2023'),
(2, 'PIX', 'Aprovado', '01/05/2025'),
(3, 'Boleto', ' Pendente', '07/04/2025')

insert into ItemPedido (Quantidade, IdPedido, IdProduto)
values
(1, 1, 1),
(1, 2, 1),
(1, 2, 2),
(1, 3, 2 )

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