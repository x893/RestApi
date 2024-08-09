@echo off

@echo on
dotnet ef dbcontext scaffold --force ^
 "Data Source=(LocalDB)\MSSQLLocalDB;Database=RestApiDb;AttachDbFilename=%CD%\data\RestApiDb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False" ^
 Microsoft.EntityFrameworkCore.SqlServer ^
 -o Models ^
 -c "RestApiContext"
