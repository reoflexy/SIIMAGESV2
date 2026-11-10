# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Product

SIIMAGES is an image library (Pexels-style). Users register as either an **artist** (photographer, uploads images) or a **consumer** (browses/downloads). Most images are free; artists can mark individual images as paid and set the price.

## Architecture

Microservices, one folder per service. Each backend service is an independent ASP.NET Core Web API on **.NET 10** (controllers + built-in `Microsoft.AspNetCore.OpenApi`), all listed in `SIIMAGES.sln`. Services are currently template scaffolds (sample `WeatherForecastController`) — no inter-service communication, persistence, or auth is wired up yet.

| Service | Folder | HTTP | HTTPS |
|---|---|---|---|
| Authentication | `Authentication/` | 5001 | 7001 |
| Users | `Users/` | 5002 | 7002 |
| FileHandling | `FileHandling/` | 5003 | 7003 |
| Payments | `Payments/` | 5004 | 7004 |
| Subscriptions | `Subscriptions/` | 5005 | 7005 |
| Requests | `Requests/` | 5006 | 7006 |
| MessagingQueue | `MessagingQueue/` | 5007 | 7007 |
| Admin | `Admin/` | 5008 | 7008 |
| Frontend (React) | `Frontend/` | 5173 (Vite dev) | — |

`Shared/` is a class library referenced by every backend service. It holds cross-service types only: enums (e.g. `UserRole`) and message contracts under `Contracts/` (integration events derive from `IntegrationEvent`). Don't put service-specific logic or persistence in it.

Ports are fixed in each service's `Properties/launchSettings.json`; keep them unique when adding services.

`Frontend/` is React + TypeScript built with Vite 5 (pinned to v5 because the local Node is 21.x, which Vite 6+/7 don't support).

## Commands

```bash
# Backend
dotnet build SIIMAGES.sln
dotnet run --project Users --launch-profile http     # run one service
# OpenAPI doc (Development only): http://localhost:<port>/openapi/v1.json

# Frontend (from Frontend/)
npm install
npm run dev
npm run build
npm run lint
```

There are no test projects yet.
