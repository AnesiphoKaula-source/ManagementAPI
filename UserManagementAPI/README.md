# UserManagementAPI (.NET 8)

ASP.NET Core REST API for TechHive Solutions. Includes GET/POST/PUT/DELETE, data annotations, duplicate-email prevention, JWT bearer authentication, request logging and standardized 500 responses.

## Setup

Requires .NET 8 SDK. From the project folder:

```bash
dotnet user-secrets init
dotnet user-secrets set "Jwt:Key" "replace-with-a-random-secret-of-at-least-32-bytes"
dotnet run
```

Alternatively set `Jwt__Key` in the environment. Never commit a real secret. `Jwt:Issuer` and `Jwt:Audience` are set in appsettings.json. Obtain a JWT signed with HS256 using the configured key, issuer and audience, with a future `exp` claim. This sample validates tokens but deliberately does not issue them: use an existing trusted identity provider or an authorized test token generator.

## Routes

All routes require `Authorization: Bearer <JWT>`.

| Method | Route | Success | Errors |
|---|---|---|---|
| GET | /api/users | 200 | 401 |
| GET | /api/users/{id} | 200 | 400/401/404 |
| POST | /api/users | 201 | 400/401/409 |
| PUT | /api/users/{id} | 204 | 400/401/404/409 |
| DELETE | /api/users/{id} | 204 | 400/401/404 |

POST/PUT JSON: `{ "name": "Ana Silva", "email": "ana@example.com" }`.

## Testing (Postman)

1. GET /api/users without a token -> 401.
2. GET /api/users with an invalid token -> 401.
3. GET /api/users with a valid token -> 200 and `[]`.
4. POST valid user with token -> 201, capture `id`.
5. POST missing name / invalid email -> 400.
6. POST duplicate email -> 409.
7. GET existing id -> 200; random UUID -> 404.
8. PUT existing id -> 204; GET confirms new values.
9. PUT missing id -> 404.
10. DELETE existing id -> 204; repeat -> 404.
11. Review server console for request method, path, status and duration.

## Notes

Data is stored in memory and resets on restart; replace UserStore with EF Core and a persistent database for production. Auth middleware is ASP.NET Core's supported JWT bearer implementation, not handwritten cryptography. Validation uses `[ApiController]` and data annotations. Error handling middleware catches unexpected exceptions and avoids exposing stack traces. Logging intentionally excludes request bodies, secrets and authorization headers.

## GitHub

```bash
git init
git add .
git commit -m "Build User Management API with CRUD, validation and middleware"
git branch -M main
git remote add origin https://github.com/YOUR_USERNAME/UserManagementAPI.git
git push -u origin main
```

Create the empty GitHub repository first. The ZIP does **not** automatically create or publish a remote repository.

See `docs/copilot-worklog.md` for an honest template to record actual Copilot usage and debugging results.
