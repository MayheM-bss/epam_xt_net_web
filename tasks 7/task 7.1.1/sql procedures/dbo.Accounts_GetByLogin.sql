USE [task 7.2.2]
GO
/****** Object:  StoredProcedure [dbo].[Accounts_GetByLogin]    Script Date: 23.09.2020 20:45:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Accounts_GetByLogin]
	@Login nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT Login, Password, Role 
	FROM Accounts
	WHERE Login LIKE @Login
END
