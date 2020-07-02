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
  IF NOT EXISTS (SELECT Id FROM [dbo].[Experience] WHERE Id = 1)
  BEGIN
    INSERT INTO [dbo].[Experience] VALUES (1, 'Renault-Sofasa', 'Production Intern', 'Main annd long functions', 'Excel', DATEFROMPARTS(2017, 1, 10) , DATEFROMPARTS(2017, 7, 9), DATEDIFF(day, '2017/01/10', '2017/07/9')/365.0);
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Experience] WHERE Id = 2)
  BEGIN
    INSERT INTO [dbo].[Experience] VALUES (2, 'Globant', 'C++ Developer', 'Streaming project', 'C++11, You.I Engine, CMake, Git', DATEFROMPARTS(2018, 11, 7) , DATEFROMPARTS(2019, 12, 31), DATEDIFF(day, '2018/11/7', '2019/12/31')/365.0);
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Experience] WHERE Id = 3)
  BEGIN
    INSERT INTO [dbo].[Experience] VALUES (3, 'Globant', '.Net Developer', 'Data hub project', '.Net Core, AWS Lambda, S3, Git, SQL Server', DATEFROMPARTS(2020, 1, 1) , null, null);
  END
END