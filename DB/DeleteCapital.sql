USE [EncriptacionDB]
GO

/****** Object:  StoredProcedure [dbo].[DeleteCapital]    Script Date: 28/10/2024 09:15:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER   PROCEDURE [dbo].[DeleteCapital]
@ID INT, @Result BIT OUTPUT
AS
BEGIN
    IF ((SELECT COUNT(1)
         FROM   Capitales
         WHERE  ID = @ID) = 0)
        BEGIN
            SET @Result = 0;
            RETURN @Result;
        END
    DELETE Capitales
    WHERE  ID = @ID;
    SET @Result = 1;
    RETURN @Result;
END

GO

