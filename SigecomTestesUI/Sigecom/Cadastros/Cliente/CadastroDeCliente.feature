Funcionalidade: Cadastro de Cliente
	Realizar o cadastro de um novo cliente

Cenario: Cadastro de novo cliente Pessoa Fisica com sucesso somente campos obrigatorios
Dado Que o sistema esteja aberto
E Aberto o formulario de cadastro de cliente
E Clicar no botao Novo
Quando Confirmar que o tipo de pessoa fisica ja esteja selecionado
E Preencher os campos obrigatorios
	| Campo  | Valor       |
	| Nome   | Joao Penca  |
	| CPF    | 43671566051 |
	| CEP    | 15700082    |
	| Numero | 123         |
E Clicar em gravar
Entao O nome do cliente deve aparecer na tela de pesquisa de cliente