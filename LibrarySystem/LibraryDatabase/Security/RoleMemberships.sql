ALTER ROLE [db_owner] ADD MEMBER [LibraryOwner];


GO
ALTER ROLE [db_datareader] ADD MEMBER [LibraryOwner];


GO
ALTER ROLE [db_datawriter] ADD MEMBER [LibraryOwner];

