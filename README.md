# LibraryApp

Application de gestion de bibliothèque.

## Technologies utilisées

- **.NET 10**
- **Blazor WebAssembly** (interface utilisateur cliente)
- **ASP.NET Core Web API** (backend)
- **Entity Framework Core 10** (accès aux données)
- **SQL Server** (base de données)
- **Scalar.AspNetCore** (documentation API)
- **Swashbuckle / Swagger UI** (documentation OpenAPI)

## Architecture du projet

La solution est organisée selon une architecture en couches :

- `LibraryApp.Client` — Application Blazor WebAssembly (frontend)
- `LibraryApp.Api` — API ASP.NET Core (backend)
- `LibraryApp.Application` — Logique applicative
- `LibraryApp.Domain` — Entités et règles métier
- `LibraryApp.Infrastructure` — Accès aux données (EF Core, migrations, repositories)
- `LibraryApp.Shared` — Modèles partagés entre le client et l'API

## Démarrage

1. Cloner le dépôt
2. Ouvrir `LibraryApp/LibraryApp.slnx` dans Visual Studio
3. Configurer la chaîne de connexion SQL Server dans `LibraryApp.Api/appsettings.json`
4. Appliquer les migrations Entity Framework
5. Démarrer le projet `LibraryApp.Api` (backend) et `LibraryApp.Client` (frontend)

## Licence

Projet à but éducatif.
