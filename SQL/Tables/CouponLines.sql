USE [Final_Capstone2]
GO

/****** Object:  Table [dbo].[CouponLines]    Script Date: 9/20/2017 12:07:09 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CouponLines](
	[CouponLineID] [int] IDENTITY(1,1) NOT NULL,
	[CouponID] [int] NOT NULL,
	[MerchantID] [int] NOT NULL,
	[CouponCode] [nvarchar](max) NOT NULL,
	[RedeemedDate] [nvarchar](max) NOT NULL,
	[Redeemed] [nvarchar](max) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Active] [nvarchar](max) NOT NULL,
	[OrderTotal] [money] NOT NULL,
	[CommissionAmount] [money] NOT NULL,
 CONSTRAINT [PK_CouponLines] PRIMARY KEY CLUSTERED 
(
	[CouponLineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

