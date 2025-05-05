

-- CREATION DE LA TABLE AFFICHE (Rencontre 19)
CREATE TABLE Spectacles.Affiche(
	AfficheID int IDENTITY(1,1) NOT NULL,
	Identifiant uniqueidentifier NOT NULL ROWGUIDCOL,
	SpectacleID int
	CONSTRAINT PK_Affiche_AfficheID PRIMARY KEY (AfficheID)
)
GO
ALTER TABLE Spectacles.Affiche ADD CONSTRAINT UC_Affiche_Identifiant
UNIQUE (Identifiant);
GO
ALTER TABLE Spectacles.Affiche ADD CONSTRAINT DF_Affiche_Identifiant
DEFAULT newid() FOR Identifiant;
GO
ALTER TABLE Spectacles.Affiche ADD
AfficheContent varbinary(MAX) FILESTREAM NULL;
GO

-- AJOUT du lien de clé étrangère
ALTER TABLE Spectacles.Affiche ADD CONSTRAINT FK_Affiche_SpectacleID
FOREIGN KEY (SpectacleID)
references Spectacles.Spectacle(SpectacleID)
GO

-- Insertion des images
INSERT INTO Spectacles.Affiche(SpectacleID, AfficheContent)
SELECT 1, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\Amir\Documents\WrapUpBilleterie\Affiches\LaMelodieDuBonheur.jfif', SINGLE_BLOB) AS myfile;

INSERT INTO Spectacles.Affiche(SpectacleID, AfficheContent)
SELECT 2, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\Amir\Documents\WrapUpBilleterie\Affiches\Verdict.jfif', SINGLE_BLOB) AS myfile;

INSERT INTO Spectacles.Affiche(SpectacleID, AfficheContent)
SELECT 3, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\Amir\Documents\WrapUpBilleterie\Affiches\AndreEtDorine.jfif', SINGLE_BLOB) AS myfile;

INSERT INTO Spectacles.Affiche(SpectacleID, AfficheContent)
SELECT 4, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\Amir\Documents\WrapUpBilleterie\Affiches\LesDixCommandementsDeDorothéeDix.jfif', SINGLE_BLOB) AS myfile;

INSERT INTO Spectacles.Affiche(SpectacleID, AfficheContent)
SELECT 5, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\Amir\Documents\WrapUpBilleterie\Affiches\LaMachineDeTuring.jfif', SINGLE_BLOB) AS myfile;
