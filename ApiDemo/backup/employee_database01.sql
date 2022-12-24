USE [Employee]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 24-12-2022 21:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Mobile] [nvarchar](20) NULL,
	[Email] [nvarchar](200) NULL,
	[LoginId] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[DepartmentId] [int] NULL,
	[CreateBy] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Employee_Add]    Script Date: 24-12-2022 21:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Employee_Add](
@Name nvarchar(100),
@Mobile nvarchar(20),
@Email nvarchar(200),
@LoginId nvarchar(50),
@Password nvarchar(50),
@CreateDate datetime,
@DepartmentId int,
@CreateBy int
)
as

begin

	insert into Employee(Name,Mobile,Email,LoginId,Password,CreateDate,DepartmentId,CreateBy)
	values(@Name,@Mobile,@Email,@LoginId,@Password,@CreateDate,@DepartmentId,@CreateBy)

	select 'Employee add successfully' as [Message], 'success' as [status]

end
GO
/****** Object:  StoredProcedure [dbo].[Employee_Delete]    Script Date: 24-12-2022 21:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Employee_Delete](
@Id int
)
as

begin

	if not exists(select 1 from Employee where Id = @Id)
	begin
		select 'Invalid employee id' as [Message], 'fail' as [status]
		return
	end

	delete Employee 
	where Id=@Id


	select 'Employee deleted successfully' as [Message], 'success' as [status]

end
GO
/****** Object:  StoredProcedure [dbo].[Employee_List]    Script Date: 24-12-2022 21:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Employee_List]( 
@Id int = -1,
@Name nvarchar(50) = ''
)
as

begin
	
	declare @query nvarchar(max) = '
	select * from Employee
	where Id is not null 
	'

	if(@Id <> -1)
		set @query += 'and Id = '+ convert(nvarchar,@Id)+''

	if(@Name <> '')
		set @query += 'and Name = '+ convert(nvarchar,@Name)+''

	exec(@query)

end
GO
/****** Object:  StoredProcedure [dbo].[Employee_Update]    Script Date: 24-12-2022 21:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Employee_Update](
@Id int,
@Name nvarchar(100),
@Mobile nvarchar(20),
@Email nvarchar(200),
@LoginId nvarchar(50),
@Password nvarchar(50),
@DepartmentId int
)
as

begin

	if not exists(select 1 from Employee where Id = @Id)
	begin
		select 'Invalid employee id' as [Message], 'fail' as [status]
		return
	end

	update Employee set Name = @Name, Mobile = @Mobile, Email = @Email, LoginId = @LoginId, Password = @Password, DepartmentId = @DepartmentId 
	where Id = @Id

	select 'Employee updated successfully' as [Message], 'success' as [status]

end
GO
