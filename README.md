# API E-Commerce
## 1º Passo, criar o arquivo de interface com o nome IItemProdutoRepository
### Dentro da interface criar os metodos (CRUD):
#### metodo de lista --> ListarTodos(),
#### metodos de busca por id --> BuscarPorId(int id),
#### metodo para cadastrar --> Cadastrar (ItemPedido itemPedido)
#### metodo para atualizar --> Atualizar (int id, ItemPedido itemPedido)
#### metodo para deletar --> Deletar (int id)
## 2º Passo criar o arquivo de classe repository com o nome ItemPedidoRepository 
#### Dentro do repository fazer a heranca da interface e implementar os metodos (Listar e cadastrar)
#### Criar o contrutor temPedidoRepository para fazer a Injecao de dependencia
## 3º Passo, no program.cs configurar a injecao de indepedencia para o controller AddTransient()
## 4º Passo, criar o arquivo controlle (vazio)
#### Dentro do arquivo controller declarar a interface IItemPedidoRepository para pode fazer o crud e implementar a injecao de dependencia.
#### implementar os verbos (GET, POST...) com os retornos de sucesso ou erro.

Correcao
1 - Cria a Interface

    -Definir metodos CRUD
    
2 - Criar o Repository

    - Herdar da interface
    
    - Implementar a Interface
    
    - Criar a variavel de contexto
    
    - Injetar o contexto
    
    - Implementar Metodos
    
3 - Configurar Injecao de Dependencia (Program.cs)

4 - Criar a Classe Controller

    -Injetar o Repository
    
    -Criar Metodos do CRUD
    
      -Listar
      
      -Cadastrar
      
      -Deletar
      
      -Editar
      
5 - (Opcional) - Configurar swagger




