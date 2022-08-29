IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'CompanyCatalog')
BEGIN
  CREATE DATABASE CompanyCatalog;
END;
GO