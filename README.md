# Loyalty Platform

Repositorio de la solución software de la tesis:

**“Fidelización de Clientes: Una Aproximación Moderna para Pequeños Negocios”.**

## Propósito

Este repositorio contiene exclusivamente el software entregable: código fuente, pruebas y documentación técnica necesaria para construir y validar la solución.

La coordinación académica de la tesis, decisiones, backlog y material interno de asistencia mediante IA se mantienen separados en:

- `RafaelZacca/tesis-workspace`

## Estado

Scaffold inicial (TECH-002, arquitectura aprobada en DEC-012). No se implementa ninguna funcionalidad de negocio todavía; el proveedor de identidad (OAuth 2.0 + OpenID Connect) aún no está seleccionado.

## Stack aprobado

- Frontend: React + TypeScript, PWA mobile-first (`frontend/`, Vite)
- Backend: ASP.NET Core en .NET 10 LTS (`backend/`)
- Base de datos: PostgreSQL 18
- Persistencia: Entity Framework Core 10 + Npgsql
- Tiempo real: SignalR (aún sin hubs; se incorporará con la primera tarea que lo requiera)

## Estructura

```
backend/
  LoyaltyPlatform.sln
  src/LoyaltyPlatform.Api/          API mínima: /health/live y /health/ready
  tests/LoyaltyPlatform.Api.Tests/  pruebas xUnit
frontend/                           shell PWA mínimo (React + TS, Vitest)
docker-compose.yml                  PostgreSQL 18 para desarrollo local
```

## Requisitos

- .NET SDK 10
- Node.js 22+ y npm
- Docker (solo para PostgreSQL local)

## Ejecución local

### 1. Base de datos

```bash
docker compose up -d postgres
```

Credenciales de desarrollo (descartables) en `docker-compose.yml`; coinciden con `backend/src/LoyaltyPlatform.Api/appsettings.Development.json`. Para otro entorno, sobrescribir `ConnectionStrings__Default`.

### 2. Backend

```bash
cd backend
dotnet run --project src/LoyaltyPlatform.Api
```

- `GET http://localhost:5206/health/live`: el proceso está activo.
- `GET http://localhost:5206/health/ready`: responde 200 solo si PostgreSQL es alcanzable (503 en caso contrario).

### 3. Frontend

```bash
cd frontend
npm install
npm run dev
```

Abrir la URL que indica Vite (por defecto http://localhost:5173). Las rutas `/health` se reenvían al backend en desarrollo.

## Build y pruebas

```bash
# Backend
cd backend
dotnet build
dotnet test

# Frontend
cd frontend
npm ci
npm run lint
npm test
npm run build
```

Las pruebas no requieren PostgreSQL en ejecución.

## Regla principal

Toda implementación debe poder trazarse a una tarea o requisito aprobado del proyecto de tesis.
