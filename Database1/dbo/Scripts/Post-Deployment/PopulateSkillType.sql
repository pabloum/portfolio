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
  IF NOT EXISTS (SELECT Id FROM [dbo].[SkillType] WHERE TypeName = 'None')
  BEGIN
    INSERT INTO [dbo].[SkillType] VALUES (0,  'None');
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[SkillType] WHERE TypeName = 'Technical')
  BEGIN
    INSERT INTO [dbo].[SkillType] VALUES (1,  'Technical');
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[SkillType] WHERE TypeName = 'Soft')
  BEGIN
    INSERT INTO [dbo].[SkillType] VALUES (2,  'Soft');
  END
END

BEGIN
  IF NOT EXISTS (SELECT Id FROM [dbo].[SkillType] WHERE TypeName = 'Language')
  BEGIN
    INSERT INTO [dbo].[SkillType] VALUES (3,  'Language');
  END
END