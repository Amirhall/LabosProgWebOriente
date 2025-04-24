
	USE S09_Labo
    GO
-- Nouvelle vue
	
	CREATE VIEW Musique.VW_ChanteurNbChansons AS
	SELECT c.ChanteurID,c.Nom,c.DateNaissance AS [Date de naissance], Count(ch.ChanteurID) AS [Nombre de chansons] FROM Musique.Chanteur c
	INNER JOIN Musique.Chanson ch
	ON ch.ChanteurID = c.ChanteurID

	GROUP BY C.ChanteurID,C.Nom,c.DateNaissance
	GO
	---- ?
	
	--GO
	
	-- Résultat souhaité : id du chanteur, nom du chanteur, date de naissance et son nombre de chansons
	
	-- ChanteurID |Nom  | Date de naissance |Nombre de chansons
	-- -----------|-----|-------------------|------------------
	
