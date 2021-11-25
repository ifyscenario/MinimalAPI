CREATE PROCEDURE [dbo].[spUser_Update]
	@id int,
	@firstName nvarchar(50),
	@lastName nvarchar(50)
AS
begin 
	update dbo.[User]
	set FirstName = @firstName, LastName = @lastName
	where Id=@id;
end