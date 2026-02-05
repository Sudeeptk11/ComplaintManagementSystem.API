SELECT TOP (1000) [MigrationId]
      ,[ProductVersion]
  FROM [ComplaintDB].[dbo].[__EFMigrationsHistory]
  use ComplaintDB;
  select * from Users;
  select * from  Complaints;
  select * from RefreshTokens;
  UPDATE Users
SET Role = 'User'
WHERE Email = 'admin@test.com';

update users set role = 'User' where email='admin@test.com';