# DTOteachers

A clean ASP.NET Core Web API project for managing teachers, prepared for JetBrains Rider.

## Requirements
- .NET 8 SDK
- JetBrains Rider (or another .NET IDE)

## Open and run in Rider
1. Extract `DTOteachers_Rider.zip`.
2. Open the `DTOteachers` folder (the folder containing `DTOteachers.csproj`) in Rider.
3. Allow Rider to restore NuGet packages.
4. Run the project using the `DTOteachers` run configuration, or from the terminal:

   ```bash
   dotnet restore
   dotnet run
   ```

5. When running in Development, open `/swagger` at the URL printed in the Run console.

## API endpoints
- `GET /api/teachers` — list teachers
- `GET /api/teachers/{id}` — get one teacher
- `POST /api/teachers` — create a teacher
- `PUT /api/teachers/{id}` — update a teacher
- `DELETE /api/teachers/{id}` — delete a teacher

Example JSON for `POST /api/teachers`:

```json
{
  "firstName": "Ivan",
  "lastName": "Petrov",
  "email": "ivan.petrov@example.com",
  "subject": "Mathematics"
}
```

## Notes
The project uses an in-memory database, so data is reset when the application stops. It has no Git remote configured and contains no `.git` folder; connect it to your own repository when you're ready.
