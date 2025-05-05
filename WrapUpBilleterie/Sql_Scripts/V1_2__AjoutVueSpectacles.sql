

CREATE VIEW Spectacles.VW_SpectaclesRepresentationSpectateurs
AS
	SELECT DISTINCT S.SpectacleID, S.Nom, S.Debut,S.Fin, S.Prix, COUNT(R.RepresentationID) AS [NbRepresentations], COUNT(B.NbBillet) AS [NbBilletsVendus]
	FROM Spectacles.Spectacle S
	INNER JOIN Spectacles.Representation R
	ON R.SpectacleID = S.SpectacleID
	INNER JOIN Spectacles.Billet B
	ON B.RepresentationID = R.RepresentationID 
	GROUP BY S.SpectacleID, S.Nom, S.Debut,S.Fin, S.Prix
GO