-- Para criar o banco
-- sqlcmd -S localhost -U sa -P SQLServer2019
CREATE DATABASE PrimeiraApi; -- Para criar o banco
SELECT name, database_id, create_date FROM sys.databases; -- Para checar se deu certo!
GO

-- Connection String: "Server=localhost;Database=PrimeiraAPI;User Id=sa;Password=SQLServer2019;"

-- Para checar a tabela
-- sqlcmd -S localhost -U sa -P SQLServer2019
USE PrimeiraApi;
SELECT * FROM Albuns;
GO
