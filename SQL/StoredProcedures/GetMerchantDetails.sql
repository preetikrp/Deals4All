USE [Final_Capstone2]
GO

/****** Object:  StoredProcedure [dbo].[GetMerchantDetails]    Script Date: 9/20/2017 12:11:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Stored Procedure to get Merchat Details
-- input is MerchantEmail
-- output will be all the columns from Merchants table
CREATE PROCEDURE [dbo].[GetMerchantDetails] @MerchantEmail nvarchar(30)
AS
SELECT MerchantID 
FROM Merchants
WHERE MerchantEmail = @MerchantEmail

GO

