# BankApp

A simple banking application example built with .NET 8, Entity Framework Core, and React (Vite).

## Features
- Account and transaction management
- RESTful API
- In-memory database for development
- React-based frontend

## Project Structure
- `BankApp.Api` — ASP.NET Core Web API
- `BankApp.Application` — Application layer
- `BankApp.Domain` — Domain models
- `BankApp.Infrastructure` — Data access layer
- `client` — React frontend

## Setup

### 1. Initial Setup
Run the setup batch file to restore and prepare all projects:
```bash
setup_backend.bat
setup_frontend.bat
setup_docker.bat
```

### 2. Backend (API)
```bash
cd BankApp.Api
dotnet run
```
The API will run at http://localhost:5000 by default.

### 3. Frontend (React)
```bash
cd client
npm install
npm run dev
```
The frontend will run at http://localhost:5173 by default.

## Usage
- You can list and add transactions via the `/api/transactions` endpoint.
- Use the frontend UI to view transactions.

## Developer Notes
- EF Core uses an in-memory database for development. For a real database, update the `AppDbContext` configuration.
- CORS is configured to work with the frontend.

## License
MIT
