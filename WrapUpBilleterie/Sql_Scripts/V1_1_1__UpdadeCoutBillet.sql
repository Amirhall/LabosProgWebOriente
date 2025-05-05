  UPDATE Spectacles.Billet
  SET CoutBillet = B.NbBillet * S.Prix
  FROM Spectacles.Billet B
  INNER JOIN Spectacles.Representation R
  ON B.RepresentationID= R.RepresentationID
  INNER JOIN Spectacles.Spectacle S
  ON R.SpectacleID = S.SpectacleID