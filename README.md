# API de Gerenciamento de Clientes

Esta API permite gerenciar clientes, contatos e endereços.

## Endpoints

### Cliente

#### GET /clientes

Lista todos os clientes cadastrados.

```http
GET /clientes

GET /clientes?nome={nome}&email={email}&cpf={cpf}&rg={rg}
Filtra os clientes por nome, email, CPF e RG.

GET /clientes?nome=Joao&email=joao@example.com&cpf=12345678901&rg=12345678
```

#### POST /clientes
Adiciona um novo cliente.

```http
POST /clientes
Content-Type: application/json

{
    "nome": "Joao da Silva",
    "email": "joao@example.com",
    "cpf": "12345678901",
    "rg": "12345678"
}
```

PUT /clientes/{id}
Atualiza as informações de um cliente existente.

```http
PUT /clientes/1
Content-Type: application/json

{
    "nome": "Joao da Silva",
    "email": "joao.silva@example.com",
    "cpf": "12345678901",
    "rg": "12345678"
}
```
DELETE /clientes/{id}
Exclui um cliente existente.

```http
DELETE /clientes/1
```

Contato
POST /contatos
Adiciona um novo contato.

```http
POST /contatos
Content-Type: application/json

{
    "tipo": "Residencial",
    "ddd": "11",
    "telefone": "123456789",
    "clienteId": 1
}
```

PUT /contatos/{id}
Atualiza as informações de um contato existente.

```http
PUT /contatos/1
Content-Type: application/json

{
    "tipo": "Comercial",
    "ddd": "11",
    "telefone": "987654321",
    "clienteId": 1
}
```

DELETE /contatos/{id}
Exclui um contato existente.

```http
DELETE /contatos/1
```

Endereco
POST /enderecos
Adiciona um novo endereço.

```http
POST /enderecos
Content-Type: application/json

{
    "tipo": "Entrega",
    "cep": "12345-678",
    "logradouro": "Rua Principal",
    "numero": "123",
    "bairro": "Centro",
    "cidade": "São Paulo",
    "estado": "SP",
    "referencia": "Próximo ao mercado"
    "clienteid":1
}
```

PUT /enderecos/{id}
Atualiza as informações de um endereço existente.

```http
PUT /enderecos/1
Content-Type: application/json

{
    "tipo": "Entrega",
    "cep": "12345-678",
    "logradouro": "Rua Principal",
    "numero": "123",
    "bairro": "Centro",
    "cidade": "São Paulo",
    "estado": "SP",
    "referencia": "Próximo ao mercado",
    "clienteid": 1
}
```

DELETE /enderecos/{id}
Exclui um endereço existente.
```http
DELETE /enderecos/1
```
