CREATE PROCEDURE [dbo].[spUser_Get]
	@id int
AS
begin
	select * 
	from dbo.[User]
	where Id = @id;
end
