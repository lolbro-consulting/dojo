SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Overview]') AND type in (N'U'))
BEGIN

CREATE TABLE [dbo].[Overview](
	[Id] [uniqueidentifier] NOT NULL,
	[Score] int NOT NULL,
    [Target] int NOT NULL,
    [DaysRemaining] int NOT NULL,
	[Updated] [datetime] NOT NULL,
    [UserId] varchar(50) NOT NULL
  CONSTRAINT [PK_Overview_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

END

GO