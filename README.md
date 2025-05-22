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
- EF Core 6 + Migrations
- SQL Server
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

### 🔧 2. Comando para executar as migrations

```bash
dotnet ef database update
```
