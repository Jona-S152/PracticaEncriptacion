USE [EncriptacionDB]
GO

/****** Object:  StoredProcedure [dbo].[UpdateCapital]    Script Date: 28/10/2024 09:14:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER   PROCEDURE [dbo].[UpdateCapital]
@ID INT, @Nombre NVARCHAR (100), @Acronimo NVARCHAR (10), @CodigoPostal NVARCHAR (10), @PaisID INT, @Result BIT OUTPUT
AS
BEGIN
    IF ((SELECT COUNT(1)
         FROM   Capitales
         WHERE  ID = @ID
                OR Nombre = @Nombre
                OR CodigoPostal = @CodigoPostal) = 0)
        BEGIN
            SET @Result = 0;
            RETURN @Result;
        END
    UPDATE Capitales
    SET    ID           = @ID,
           Nombre       = @Nombre,
           Acronimo     = @Acronimo,
           CodigoPostal = @CodigoPostal,
           PaisID       = @PaisID
    WHERE  ID = @ID;
    SET @Result = 1;
    RETURN @Result;
END

GO

