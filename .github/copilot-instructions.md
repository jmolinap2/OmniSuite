<!-- Instrucciones para agentes AI que colaboran en este repositorio OmniSuite -->
# Copilot instructions — OmniSuite (resumen corto)

Este proyecto es una plantilla ASP.NET Core (backend) + Angular (frontend) basada en ABP. Usa generación de clientes con NSwag, soporte multi-tenant y despliegue opcional vía Docker.

Principales ubicaciones y arquitectura:
- Backend (.NET): `aspnet-core/src/OmniSuite.*/` — capas típicas: `Core`, `Application`, `EntityFrameworkCore`, `Web.Host`.
- Frontend (Angular): `angular/` — código fuente en `angular/src`, proxies generados en `angular/src/shared/service-proxies/service-proxies.ts`.
- Scripts y build: `aspnet-core/build/build-with-ng.ps1` (construye imágenes Docker para host y ng).
- NSwag config: `angular/nswag/service.config.nswag` y `angular/nswag/refresh.bat` para regenerar `service-proxies`.

Big picture (por qué y cómo está organizado):
- Separación clara: backend en `aspnet-core/src` con la API y host; frontend es una SPA Angular independiente en `angular/` que consume la API mediante proxies generados.
- Los clientes TS se generan desde el Swagger del backend (NSwag) y se colocan en `angular/src/shared/service-proxies` para mantener contratos sincronizados.
- Multi-tenancy y configuración dinámica se resuelven en el frontend durante la inicialización (`angular/src/app-initializer.ts`) leyendo `assets/appconfig*.json`.

Flujos de desarrollo esenciales (comandos detectables en el repo):
- Frontend (desarrollo):
```
cd angular
npm install
npm run start    # sirve la SPA en http://localhost:4200
```
- Frontend (tests e2e/unit):
```
cd angular
npm run test      # unit tests via Karma
npm run e2e       # requiere ng serve en ejecución
```
- Regenerar service-proxies (NSwag):
```
cd angular\nswag
refresh.bat       # ejecuta ..\node_modules\.bin\nswag run
```
- Backend / solución / Docker:
```
dotnet build aspnet-core\OmniSuite.sln
dotnet test test\OmniSuite.Web.Tests\

# Para build de imágenes (desde la raíz del repo ejecutar):
powershell -ExecutionPolicy Bypass -File aspnet-core\build\build-with-ng.ps1
```
Nota: `build-with-ng.ps1` asume que Docker está disponible y construye `abp/host` usando `src/OmniSuite.Web.Host/Dockerfile` y la imagen `abp/ng` desde `angular/Dockerfile`.

Convenciones y patrones específicos del proyecto (observables en el código):
- ABP framework: uso del objeto global `abp` en frontend (`abp.ui`, `abp.event`, `abp.localization`). Evitar inyectar `AppSessionService` en constructores donde el proyecto lo evita (ver `AppInitializer`).
- Service proxies: se generan y exportan desde `angular/src/shared/service-proxies/service-proxies.ts`. Modificar manualmente con cuidado; preferir regenerar via NSwag.
- Configuración runtime: `angular/src/assets/appconfig*.json` controla `AppConsts.remoteServiceBaseUrl` y `appBaseUrl` — el frontend depende de ellos para localizar la API.
- Multi-tenant: resolvers están en `angular/src/shared/multi-tenancy/` (p.ej. `SubdomainTenantResolver`). Si cambias flujo de autenticación o tenant, revisa `AppInitializer`.
- SignalR: se usa `@microsoft/signalr` — revisar llamadas en frontend y hubs en backend al cambiar contratos.

Dónde mirar primero para entender el código:
- `aspnet-core/src/OmniSuite.Application/OmniSuiteApplicationModule.cs` y `OmniSuiteAppServiceBase.cs` — para entender servicios de dominio y DTOs.
- `angular/src/app-initializer.ts` — inicialización de configuración, localización y tenant.
- `angular/src/shared/service-proxies/service-proxies.ts` — tipos/servicios generados que el frontend usa para llamar a la API.
- `aspnet-core/src/OmniSuite.Web.Host/Dockerfile` — cómo se empaqueta el host.

Reglas para agentes AI al editar/añadir código aquí:
- Mantener la separación backend/frontend: cambios en contratos (DTOs/API) requieren regenerar `service-proxies` y validarlos en el frontend.
- Prefiere cambios pequeños y revisables: actualizar un controlador o servicio normalmente implica actualizar el cliente NSwag y pruebas asociadas.
- Cuando propongas cambios en la inicialización o multi-tenancy, cita `angular/src/app-initializer.ts` y `angular/src/assets/appconfig*.json` en tu explicación.

Ejemplo de checklist que un PR debería cubrir (útil para agentes):
- ¿Se actualizó o regeneró `angular/src/shared/service-proxies/service-proxies.ts` al cambiar la API?
- ¿Se probaron los flujos de login/tenant en `AppInitializer` si la API cambia?
- ¿Se actualizaron `appconfig.*.json` si cambió la URL base de la API?

Preguntas abiertas para el mantenedor (pide aclaración si corres el agente):
- ¿Desean que los agentes ejecuten `nswag` automáticamente cuando modifiquen contratos? (actualmente hay `refresh.bat`).
- ¿Hay entornos de despliegue particulares (nombres de imagen o registry) que deba conocer para `build-with-ng.ps1`?

Si algo en estas instrucciones está incompleto o quieres que añada ejemplos concretos de refactorizaciones, dime qué áreas priorizar.
