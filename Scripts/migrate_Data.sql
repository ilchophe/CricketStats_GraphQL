/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [venueid]
      ,[venuename]
      ,[venuecity]
      ,[countryid]
      ,[lastupdated]
  FROM [CricketStats].[dbo].[Venue]

  SELECT V.venuename, V.venuecity,NC.Id, OC.countryid FROM CricketStats..Venue V INNER JOIN CricketStats..Country OC ON OC.countryid = V.countryid
    INNER JOIN CricketStatsDB..Countries NC ON OC.countrycode = NC.CountryCode COLLATE Latin1_General_CI_AI

BEGIN TRANSACTION
  INSERT INTO CricketStatsDB..Venues (VenueName, VenueCity, CountryId)
    SELECT V.venuename, V.venuecity,NC.Id FROM CricketStats..Venue V INNER JOIN CricketStats..Country OC ON OC.countryid = V.countryid
    INNER JOIN CricketStatsDB..Countries NC ON OC.countrycode = NC.CountryCode COLLATE Latin1_General_CI_AI
COMMIT TRANSACTION

SELECt * FROM CricketStatsDB..Venues


  SELECt * FROM CricketStats..Country



  SELECt * FROM CricketStats..Player


  BEGIN TRANSACTION
  INSERT INTO CricketStatsDB..Players (PlayerName, PlayerSurname, CountryId, Dob, Retired)
  SELECT OP.PlayerName, OP.PlayerSurname, NC.Id, OP.Dob, OP.Retired FROM CricketStats..Player OP 
  INNER JOIN CricketStats..Country OC ON OP.countryid = OC.countryid
  INNER JOIN CricketStatsDB..Countries NC ON OC.countrycode = NC.CountryCode COLLATE Latin1_General_CI_AI

  COMMIT TRANSACTION

    SELECt * FROM CricketStatsDB..Players