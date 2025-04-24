
-- Création de la BD Lab09
IF EXISTS(SELECT * FROM sys.databases WHERE name='S09_Labo')
BEGIN
    DROP DATABASE S09_Labo
END

CREATE DATABASE S09_Labo
GO
