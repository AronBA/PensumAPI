USE master
GO
IF EXISTS (SELECT * FROM sysdatabases WHERE name = 'Pensum')
BEGIN
    --RAISERROR('Die Datenbank Pensum existiert bereits, sie wird jetzt gelöscht')
    ALTER DATABASE Pensum SET single_user WITH ROLLBACK IMMEDIATE
    DROP DATABASE Pensum
END

CREATE DATABASE Pensum
GO
USE Pensum
GO

CREATE TABLE tbl_Lektion (
	Id INT NOT NULL IDENTITY(0, 1),
	Lehrperson CHAR(2) NOT NULL,
	Klasse CHAR(3) NOT NULL,
	WochenTag CHAR(2) NOT NULL,
	Uhrzeit CHAR(5) NOT NULL,
	Zimmer CHAR(3) NOT NULL,
	Fach CHAR(5) NOT NULL,
	CONSTRAINT PK_Lektion PRIMARY KEY (Id)
)