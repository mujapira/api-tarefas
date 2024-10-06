
<h1>API de Tarefas - Backend</h1>
Esta é a API desenvolvida para gerenciar tarefas do <a href="https://github.com/mujapira/Tarefas">sistema de tarefas.</a> Ela faz parte de um projeto full-stack, onde 
o front-end foi desenvolvido utilizando React, e o backend é responsável por gerenciar operações de criação, recuperação, atualização e exclusão de tarefas, além de funcionalidades de gerenciamento de sessão.
<br/>
<br/>
🔨 Principais funcionalidades

 - API RESTful para manipulação de tarefas
 - Suporte à criação, atualização e exclusão de tarefas
 - Gerenciamento de sessões com ID exclusivo (GUID)
 - Integração com banco de dados SQL Server para armazenamento persistente
 - Tratamento de erros centralizado e respostas padronizadas
 
<br/>

🚀 Tecnologias utilizadas

- .NET 8
- Entity Framework
- SQL Server

<br/>

🛠 Funcionalidades da API - Endpoints principais

<h4>Tarefas</h4>

- GET /api/tarefas - Lista todas as tarefas associadas a uma sessão.
- POST /api/tarefas - Cria uma nova tarefa com base nos dados fornecidos.
- PUT /api/tarefas/:id - Atualiza uma tarefa existente identificada pelo seu ID.
- DELETE /api/tarefas/:id - Exclui uma tarefa específica pelo ID fornecido.

<h4>Sessões</h4>

- POST /api/sessions - Cria uma nova sessão e armazena o SessionId como cookie no navegador.
- GET /api/sessions/{SessionId} - Recupera uma sessão específica e atualiza o SessionId no cookie.
- GET /api/sessions/validity - Verifica a validade de uma sessão ativa a partir do cookie SessionId.
- DELETE /api/sessions - Encerra a sessão atual e remove o cookie SessionId.

📦 Como rodar o projeto:
Clone este repositório:

```bash
git clone https://github.com/mujapira/api-tarefas.git
Configure as variáveis de ambiente, incluindo as credenciais do banco de dados.
```
Suba o container do banco de dados SQL Server e da aplicação utilizando Docker
