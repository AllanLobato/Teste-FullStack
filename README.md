# 🧰 Lead Manager – Full Stack Challenge

Projeto desenvolvido como parte de um desafio técnico full stack, utilizando:

- ⚙️ ASP.NET Core 6 (Web API)
- ⚛️ React + Vite + TypeScript
- 🎨 TailwindCSS
- 🗄️ SQL Server (via Docker)
- 🧪 EF Core + Migrations

---

## 🖥️ Visão geral

O sistema permite:

- Visualizar leads no status **Invited**
- Aceitar ou recusar um lead
  - Ao aceitar: o status muda para `accepted` e um desconto de 10% é aplicado se o preço for > 500
  - Ao recusar: o status muda para `declined`
- Visualizar os leads aceitos na aba **Accepted**
- Gerar leads aleatórios com o endpoint `/api/seed`

---

## 📦 Tecnologias utilizadas

### Backend

- ASP.NET Core 6
- Entity Framework Core 6 (Code First)
- SQL Server (via Docker)
- Swagger para testes da API

### Frontend

- React 19 + Vite
- TypeScript
- TailwindCSS
- Axios

---

## 🚀 Como rodar o projeto localmente

### 🔧 1. Subir o banco SQL Server com Docker

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=SeuSenha123!" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest
```

> A senha pode ser personalizada. Certifique-se de atualizar a string de conexão em `appsettings.json` se necessário.

---

### 🛠️ 2. Rodar o backend (ASP.NET Core)

1. Acesse a pasta do projeto backend:

```bash
cd LeadManager.Api
```

2. Restaure os pacotes:

```bash
dotnet restore
```

3. Aplique as migrations:

```bash
dotnet ef database update
```

4. Rode a aplicação:

```bash
dotnet run
```

A API estará disponível em:

```
https://localhost:7194
```

---

### 📘 Acessar a documentação da API (Swagger)

Após rodar o backend, abra no navegador:

```
https://localhost:7194/swagger
```

> No Swagger é possível testar todos os endpoints da API:
> - `GET /api/leads?status=invited`
> - `POST /api/leads/{id}/accept`
> - `POST /api/leads/{id}/decline`
> - `POST /api/seed` → Gera 5 leads aleatórios
> - `DELETE /api/seed` → Remove todos os leads

---

### 💻 3. Rodar o frontend (React + Vite)

1. Acesse a pasta do projeto frontend:

```bash
cd lead-manager
```

2. Instale as dependências:

```bash
npm install
```

3. Inicie o projeto:

```bash
npm run dev
```

4. Acesse em:

```
http://localhost:5173
```

> Se necessário, use `--https` para igualar ao backend:
>
> ```bash
> npm run dev -- --https
> ```

---

## 🔁 Seed de dados

### Criar novos leads (aleatórios)

```http
POST https://localhost:7194/api/seed
```

### Limpar todos os leads do banco

```http
DELETE https://localhost:7194/api/seed
```

---

## 🗂️ Estrutura do Projeto

### 📁 Backend – `LeadManager.Api`

```
LeadManager.Api/
├── Controllers/
│   ├── LeadsController.cs
│   └── SeedController.cs
├── Models/
│   └── Lead.cs
├── Data/
│   └── AppDbContext.cs
├── Repositories/
│   ├── ILeadRepository.cs
│   └── LeadRepository.cs
├── Services/
│   ├── ILeadService.cs
│   └── LeadService.cs
├── Migrations/
├── appsettings.json
└── Program.cs
```

### 📁 Frontend – `lead-manager`

```
lead-manager/
├── src/
│   ├── api/
│   │   └── leadService.ts
│   ├── components/
│   │   └── LeadCard.tsx
│   ├── pages/
│   │   ├── Invited.tsx
│   │   └── Accepted.tsx
│   ├── types/
│   │   └── Lead.ts
│   ├── App.tsx
│   └── main.tsx
├── public/
├── index.html
├── tailwind.config.js
└── vite.config.ts
```

---

## ✅ Funcionalidades implementadas

- [x] Listagem de leads `invited` com botões de ação
- [x] Atualização de status via Accept/Decline
- [x] Desconto automático ao aceitar leads caros
- [x] Visualização completa dos leads aceitos (sem botões)
- [x] Geração dinâmica de leads aleatórios
- [x] Documentação com Swagger
- [x] Layout responsivo com Tailwind
- [x] Componentização no frontend (`LeadCard`, `leadService`, etc)

---

## 📝 Observações

- O envio de e-mail foi simulado (mock), conforme permitido pelo desafio.
- CORS foi liberado apenas para desenvolvimento.
- A aplicação pode ser facilmente adaptada para ambientes produtivos.

---


