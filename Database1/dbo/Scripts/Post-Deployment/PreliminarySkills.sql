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

Category:
    None       - 0
    Technical  - 1
    Soft       - 2
    Language   - 3

*/

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Skill] WHERE Name = 'C++')
  BEGIN
    INSERT INTO [dbo].[Skill] VALUES (1, 'C++', 1, 70); /* Id, Name, Category, Percentage */
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Skill] WHERE Name = 'C')
  BEGIN
    INSERT INTO [dbo].[Skill] VALUES (2, 'C', 1, 60); /* Id, Name, Category, Percentage */
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Skill] WHERE Name = 'C#')
  BEGIN
    INSERT INTO [dbo].[Skill] VALUES (3, 'C#', 1, 70); /* Id, Name, Category, Percentage */
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Skill] WHERE Name = 'Python')
  BEGIN
    INSERT INTO [dbo].[Skill] VALUES (4, 'Python', 1, 65); /* Id, Name, Category, Percentage */
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Skill] WHERE Name = 'Ruby')
  BEGIN
    INSERT INTO [dbo].[Skill] VALUES (5, 'Ruby', 1, 55); /* Id, Name, Category, Percentage */
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Skill] WHERE Name = 'Ruby on Rails')
  BEGIN
    INSERT INTO [dbo].[Skill] VALUES (6, 'Ruby on Rails', 1, 55); /* Id, Name, Category, Percentage */
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Skill] WHERE Name = 'Javascript')
  BEGIN
    INSERT INTO [dbo].[Skill] VALUES (7, 'Javascript', 1, 55); /* Id, Name, Category, Percentage */
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Skill] WHERE Name = 'HTML/CSS')
  BEGIN
    INSERT INTO [dbo].[Skill] VALUES (8, 'HTML/CSS', 1, 60); /* Id, Name, Category, Percentage */
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Skill] WHERE Name = '.Net Core')
  BEGIN
    INSERT INTO [dbo].[Skill] VALUES (9, '.Net Core', 1, 65); /* Id, Name, Category, Percentage */
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Skill] WHERE Name = 'SQL / SQL Server')
  BEGIN
    INSERT INTO [dbo].[Skill] VALUES (10, 'SQL / SQL Server', 1, 65); /* Id, Name, Category, Percentage */
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Skill] WHERE Name = 'Responsible')
  BEGIN
    INSERT INTO [dbo].[Skill] VALUES (11, 'Responsible', 2, 95); /* Id, Name, Category, Percentage */
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Skill] WHERE Name = 'Disciplined')
  BEGIN
    INSERT INTO [dbo].[Skill] VALUES (12, 'Disciplined', 2, 95); /* Id, Name, Category, Percentage */
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Skill] WHERE Name = 'Fast learner')
  BEGIN
    INSERT INTO [dbo].[Skill] VALUES (13, 'Fast learner', 2, 95); /* Id, Name, Category, Percentage */
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Skill] WHERE Name = 'Spanish')
  BEGIN
    INSERT INTO [dbo].[Skill] VALUES (14, 'Spanish', 3, 95); /* Id, Name, Category, Percentage */
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Skill] WHERE Name = 'English')
  BEGIN
    INSERT INTO [dbo].[Skill] VALUES (15, 'English', 3, 90); /* Id, Name, Category, Percentage */
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Skill] WHERE Name = 'French')
  BEGIN
    INSERT INTO [dbo].[Skill] VALUES (16, 'French', 3, 80); /* Id, Name, Category, Percentage */
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[Skill] WHERE Name = 'German')
  BEGIN
    INSERT INTO [dbo].[Skill] VALUES (17, 'German', 3, 60); /* Id, Name, Category, Percentage */
  END
END
