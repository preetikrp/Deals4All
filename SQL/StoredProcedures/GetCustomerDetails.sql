USE [Final_Capstone2]
GO

/****** Object:  StoredProcedure [dbo].[GetCustomerDetails]    Script Date: 9/20/2017 12:12:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Stored Procedure to get Customer Details
-- input is CustomerEmail
-- output will be all the columns from Customers table
CREATE PROCEDURE [dbo].[GetCustomerDetails] @CustomerEmail nvarchar(30)
AS
SELECT CustomerID 
FROM Customers
WHERE CustomerEmail = @CustomerEmail

GO

