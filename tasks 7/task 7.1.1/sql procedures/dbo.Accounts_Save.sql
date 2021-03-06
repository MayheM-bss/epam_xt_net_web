USE [task 7.2.2]
GO
/****** Object:  StoredProcedure [dbo].[Accounts_Save]    Script Date: 23.09.2020 20:29:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Accounts_Save] 
	-- Add the parameters for the stored procedure here
	@Login nvarchar(50),
	@Password nvarchar(50),
	@Role nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	UPDATE dbo.Accounts
	SET
	Login = @Login
	Password = @Password,
	Role = @Role
	WHERE Login LIKE @Login

END
