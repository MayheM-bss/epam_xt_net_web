USE [task 7.2.2]
GO
/****** Object:  StoredProcedure [dbo].[Users_GetAwards]    Script Date: 24.09.2020 1:25:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Users_GetAwards]
	-- Add the parameters for the stored procedure here
	@ID nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM UsersAwards inner join Awards
	on UserID = @ID
	WHERE AwardID = ID
END
