CREATE PROCEDURE [dbo].[Procedure]
	@personId int,
	@name nvarchar(30),
	@address nvarchar(30),
	@email nvarchar(30),
	@username nvarchar(30),
	@password nvarchar(30),
	@role nvarchar(30)
AS
BEGIN
	BEGIN TRAN UpdateUser
		INSERT INTO Accounts (Username, Password, Role, IsActive) VALUES (@username, @password, @role, 'true');
		UPDATE People SET Name = @name, Address = @address, Email = @email, @username = @username WHERE personId = @personId;
		DELETE FROM Accounts WHERE Username = @username;
	COMMIT TRAN UpdateUser
END