-- Para criar o banco
-- sqlcmd -S localhost -U sa -P SQLServer2019
CREATE DATABASE PrimeiraApi; -- Para criar o banco
SELECT name, database_id, create_date FROM sys.databases; -- Para checar se deu certo!
GO

-- Connection String: "Server=localhost;Database=PrimeiraAPI;User Id=sa;Password=SQLServer2019;"

-- Pacotes NuGet
-- Microsoft.EntityFrameworkCore.SqlServer
-- Microsoft.EntityFrameworkCore.Tools
-- Microsoft.EntityFrameworkCore.Design


-- Para checar a tabela
-- sqlcmd -S localhost -U sa -P SQLServer2019
USE PrimeiraApi;
SELECT * FROM Albuns;
GO

-- Add-Migration Migration00 -Context AppDbContext -OutputDir DAL/Migrations
-- Update-Database  -Context AppDbContext
