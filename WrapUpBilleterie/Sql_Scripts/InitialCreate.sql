USE master 
GO

-- CREATION de la BD R22_Billeterie
IF EXISTS(SELECT * FROM sys.databases WHERE name='R22_Billeterie')
BEGIN
    DROP DATABASE R22_Billeterie
END

CREATE DATABASE R22_Billeterie
GO


USE R22_Billeterie
GO

-- Configuration de FILESTREAM
-- nous avons vu ça lors de la rencontre 19
EXEC sp_configure filestream_access_level, 2;
RECONFIGURE;

ALTER DATABASE R22_Billeterie
ADD FILEGROUP FG CONTAINS FILESTREAM;
GO

ALTER DATABASE R22_Billeterie
ADD FILE (
    NAME = FG_File,
    FILENAME = 'C:\FG'
)
TO FILEGROUP FG;
GO


-- Configuration des clés symétriques
-- il s'agit de créer la clé master, le certificat et enfin la clé symmétrique

CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'Passw0rd!2005';

CREATE CERTIFICATE CertificatUtilisateur
WITH SUBJECT = 'Certificat';

GO
CREATE SYMMETRIC KEY CleSecreteUtilisateur
WITH ALGORITHM = AES_256
ENCRYPTION BY CERTIFICATE CertificatUtilisateur;

GO