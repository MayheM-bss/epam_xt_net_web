USE [task 7.2.2]
GO
/****** Object:  StoredProcedure [dbo].[Awards_GetUsers]    Script Date: 24.09.2020 1:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Awards_GetUsers] 
	@ID nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM UsersAwards inner join Users
on AwardID = @ID
WHERE UserID = ID
END
