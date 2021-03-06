/****** Script for SelectTopNRows command from SSMS  ******/
INSERT INTO CricketStatsDB..Countries (CountryCode, CountryDesc)
SELECt countrycode, countrydesc FROM CricketStatsOld..Country
  
SELECt * FRom CricketStatsDB..Countries 
  
INSERT INTO CricketStatsDB..Dismissals(DismissalCode, DismissalDesc)
SELECt dismissalcode, dismissaldesc FROM CricketStatsOld..Dismissals
  
SELECt * FROM CricketStatsDB..Dismissals  


INSERT INTO CricketStatsDB..MatchTypes(MatchTypeName)
SELECt matchtypename FROM CricketStatsOld..MatchType
  
SELECt * FROM CricketStatsDB..MatchTypes

  
  INSERT INTO CricketStatsDB..Venues (VenueName, VenueCity, CountryId)
    SELECT V.venuename, V.venuecity,NC.Id FROM CricketStatsOld..Venue V INNER JOIN CricketStatsOld..Country OC ON OC.countryid = V.countryid
    INNER JOIN CricketStatsDB..Countries NC ON OC.countrycode = NC.CountryCode COLLATE Latin1_General_CI_AI


SELECt * FROM CricketStatsDB..Venues



  INSERT INTO CricketStatsDB..Players (PlayerName, PlayerSurname, CountryId, Dob, Retired)
  SELECT OP.PlayerName, OP.PlayerSurname, NC.Id, OP.Dob, OP.Retired FROM CricketStatsOld..Player OP 
  INNER JOIN CricketStatsOld..Country OC ON OP.countryid = OC.countryid
  INNER JOIN CricketStatsDB..Countries NC ON OC.countrycode = NC.CountryCode COLLATE Latin1_General_CI_AI

    SELECt * FROM CricketStatsDB..Players