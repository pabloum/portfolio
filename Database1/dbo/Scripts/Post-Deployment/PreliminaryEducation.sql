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
  IF NOT EXISTS (SELECT Id FROM [dbo].[Education] WHERE Title = 'Mechanical Engineer')
  BEGIN
    INSERT INTO [dbo].[Education] VALUES (1, 'Universidad Pontificia Bolivariana', 'Mechanical Engineer', DATEFROMPARTS(2011, 1, 11) , DATEFROMPARTS(2017, 7, 27) ,  'Long description');
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Education] WHERE Title = 'Aeronautical Engineer')
  BEGIN
    INSERT INTO [dbo].[Education] VALUES (2, 'Universidad Pontificia Bolivariana', 'Aeronautical Engineer', DATEFROMPARTS(2011, 1, 11) , DATEFROMPARTS(2017, 7, 27) ,  'Long description');
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Education] WHERE Title = 'Full stack Web Developer')
  BEGIN
    INSERT INTO [dbo].[Education] VALUES (3, 'Make it Real', 'Full stack Web Developer', DATEFROMPARTS(2018, 7, 15) , DATEFROMPARTS(2018, 9, 27) ,  'Long description');
  END
END