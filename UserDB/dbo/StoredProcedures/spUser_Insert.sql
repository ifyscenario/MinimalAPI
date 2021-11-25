CREATE PROCEDURE [dbo].[spUser_Insert]
	@firstName nvarchar(50),
	@lastName nvarchar(50)
AS
begin 
	insert into dbo.[User] (FirstName, LastName)
	values (@firstName, @lastName);
end
