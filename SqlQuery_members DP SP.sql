--
GO
 CREATE PROCEDURE [dbo].[sp_AddMember]
 @id int, @Name Nvarchar(50) , @Contact nvarchar(50), @Address Nvarchar(50), @retVal int output
 AS
 BEGIN
     SET NOCOUNT ON;
     Insert into members([Name],Contact,[Address],RegDate) VALUES(@Name,@Contact,@Address,GETDATE())
     if @@ROWCOUNT > 0
     BEGIN
     SET @retVal = 200
     END
     ELSE
     BEGIN
     SET @retVal = 500
     END
 END

 --
 GO
 CREATE PROCEDURE [dbo].[sp_DeleteMember]
 @id int, @retVal int output
 AS
 BEGIN
     SET NOCOUNT ON;
     Delete members where Id = @id
 if @@ROWCOUNT > 0 BEGIN SET @retVal = 200 END ELSE BEGIN SET @retVal = 500 END
 END

 --
 GO
 CREATE PROCEDURE [dbo].[sp_UpdateMember]
 @id int, @Name Nvarchar(50) , @Contact nvarchar(50), @Address Nvarchar(50), @retVal int output
 AS
 BEGIN
     SET NOCOUNT ON;
     UPDATE members SET [Name] = @Name, Contact=@Contact, [Address] = @Address where Id = @id
 if @@ROWCOUNT > 0 BEGIN SET @retVal = 200 END ELSE BEGIN SET @retVal = 500 END
 END


 --

 GO
 SET ANSI_NULLS ON
 GO
 SET QUOTED_IDENTIFIER ON
 GO
  -- =============================================
  -- Author:    FreeCode Spot
  -- Create date: 
  -- Description:    
  -- =============================================
  CREATE PROCEDURE [dbo].[sp_loginUser]
      @email Nvarchar(50),
      @password nvarchar(200),
      @retVal int OUTPUT
      AS
  BEGIN
      SET NOCOUNT ON;
         Select 
                userid,
                username,
                email,
                [role],
                reg_date 
                FROM tbl_users 
                where Email = @email and 
               [Password] = CONVERT(VARCHAR(32), HashBytes('MD5', @password), 2)
         IF(@@ROWCOUNT > 0)
         BEGIN
          SET @retVal = 200
         END
         ELSE
         BEGIN
           SET @retVal = 500
         END
  END


  GO
 SET ANSI_NULLS ON
 GO
 SET QUOTED_IDENTIFIER ON
 GO
  -- =============================================
  -- Author:        FeeCode Spot
  -- Create date: 
  -- Description:    
  -- =============================================
  CREATE PROCEDURE [dbo].[sp_registerUser]
      @username Nvarchar(50),
      @email Nvarchar(50),
      @password nvarchar(200),
      @role nvarchar(50),
      @retval int OUTPUT
  AS
  BEGIN
      SET NOCOUNT ON;
        INSERT INTO tbl_users(
                              username,
                              Email,
                              [Password],
                              [role],
                              reg_date) 
                              VALUES(
                              @username,
                              @email,
                              CONVERT(VARCHAR(32), HashBytes('MD5', @password), 2),
                              @role,
                              GETDATE())
        if(@@ROWCOUNT > 0)
        BEGIN
          SET @retval = 200 --return value when changes is detected on table
        END
        ELSE
        BEGIN
        SET @retval = 500  --return value if something went wronng
        END
  END

  GO
 SET ANSI_NULLS ON
 GO
 SET QUOTED_IDENTIFIER ON
 GO
  -- =============================================
  -- Author:        FeeCode Spot
  -- Create date: 
  -- Description:    
  -- =============================================
  CREATE PROCEDURE [dbo].[sp_deleteUser]
      @userid int,
      @retval int OUTPUT
  AS
  BEGIN
      SET NOCOUNT ON;
           Delete tbl_users where userid = @userid
        
           if(@@ROWCOUNT > 0)
        BEGIN
          SET @retval = 200 --return value when changes is detected on table
        END
        ELSE
        BEGIN
        SET @retval = 500  --return value if something went wronng
        END
  END 