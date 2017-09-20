USE [Final_Capstone2]
GO

/****** Object:  StoredProcedure [dbo].[ProcRedeemCoupon]    Script Date: 9/20/2017 12:10:55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Stored Procedure to Redeem Coupons 
--Exec dbo.ProcRedeemCoupon 'Test1','1','preetikrp@gmail.com','29.95','' 
-- 
CREATE PROCEDURE [dbo].[ProcRedeemCoupon]
@CouponCode varchar(100), 
@MerchantID int,
@CustomerEmail varchar(100),
@OrderTotal varchar(100),
@Result varchar(100) output

AS

BEGIN
Declare @CouponID int,
	@CommissionValue Float, --varchar(100),
	@FinalCommission Float, --varchar(100)
	@CustomerId int

IF EXISTS(Select CustomerId from Customers where CustomerEmail = @CustomerEmail)
	BEGIN
	Select @CustomerId = CustomerId from Customers where CustomerEmail = @CustomerEmail
	IF EXISTS (Select CouponMasterID from Coupons where CouponName = @CouponCode and MerchantID = @MerchantID)
		BEGIN
		Select @CouponID = CouponMasterID, @CommissionValue = CommissionValue from Coupons where CouponName = @CouponCode and MerchantID = @MerchantID
		Set @FinalCommission = @CommissionValue * @OrderTotal/100 
		IF EXISTS (SELECT top 1 * from CouponLines where CouponCode = @CouponCode and MerchantID = @MerchantID and CustomerID = @CustomerID)
			BEGIN
				PRINT 'Coupon already Redeemed by this customer.'
				Set @Result = 'Coupon already Redeemed by this customer.'
			END
			ELSE 
			BEGIN
					Insert into dbo.CouponLines (CouponID, MerchantID, CouponCode, RedeemedDate, Redeemed, CustomerID, Active, OrderTotal, CommissionAmount )
					values (@CouponID, @MerchantID, @CouponCode, GetDate(), '1', @CustomerId, '0', @OrderTotal, @FinalCommission )
	
					--PRINT 'Thanks for Redeeming this Coupon.'
					Set @Result = 'Thanks for Redeeming this Coupon.'
			END
		END
		--ELSE PRINT 'Coupon Code not Valid.'
		ELSE Set @Result = 'Coupon Code not Valid.'
	END
	--ELSE PRINT 'Customer Not Registered.'
	ELSE Set @Result = 'Customer Not Registered.'
	
END

GO

