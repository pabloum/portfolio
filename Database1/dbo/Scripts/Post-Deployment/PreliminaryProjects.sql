/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Project] WHERE Id = 1)
  BEGIN
    INSERT INTO [dbo].[Project] VALUES (1, 'Flow overstack', 'Ruby, Rails, HTML, CSS, SQL', 'A copy for Stack Overflow');
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Project] WHERE Id = 2)
  BEGIN
    INSERT INTO [dbo].[Project] VALUES (2, 'My Portfolio', 'C#, .Net Core, HTML, CSS, SQL', 'This is my personal portfolio');
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Project] WHERE Id = 3)
  BEGIN
    INSERT INTO [dbo].[Project] VALUES (3, 'Guess the number', 'Javascript, HTML, CSS', 'A game. User must guess the number');
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Project] WHERE Id = 4)
  BEGIN
    INSERT INTO [dbo].[Project] VALUES (4, 'Vigenere cypher', 'Javascript, HTML, CSS', 'App to cypher messages with Vigenere code');
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Project] WHERE Id = 5)
  BEGIN
    INSERT INTO [dbo].[Project] VALUES (5, 'Color game', 'Javascript, HTML, CSS', 'A game to guess the color according to RGB code');
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Project] WHERE Id = 6)
  BEGIN
    INSERT INTO [dbo].[Project] VALUES (6, 'Financial calculator', 'Javascript, HTML, CSS', 'An app that calculate taxes, following colombian regulations');
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Project] WHERE Id = 7)
  BEGIN
    INSERT INTO [dbo].[Project] VALUES (7, 'Notes', 'Ruby on Rails, HTML, CSS, Javascript, Sinatra', 'An app creates notes.');
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Project] WHERE Id = 8)
  BEGIN
    INSERT INTO [dbo].[Project] VALUES (8, 'Data hub', '.Net Core, SQL Server, AWS Lambda, S3, Git', 'Exposes data information to different applications');
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Project] WHERE Id = 9)
  BEGIN
    INSERT INTO [dbo].[Project] VALUES (9, 'Video streaming app', 'C++11 You.I Engine, Git', 'An app to stream live and VOD (on demand) videos. ');
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Project] WHERE Id = 10)
  BEGIN
    INSERT INTO [dbo].[Project] VALUES (10, 'API for bank comissions', 'C#, .Net Core, SQL', 'Creation of an API that that calculates some bank comissions, from a given input');
  END
END