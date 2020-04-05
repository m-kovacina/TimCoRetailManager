CREATE PROCEDURE [dbo].[spUserLookup]
	@id nvarchar(128)
AS
Begin
	set nocount on;

	SELECT Id, FirstName, LastName, EmailAddress, CreatedDate
	from [dbo].[User]
	where Id = @Id;
end
