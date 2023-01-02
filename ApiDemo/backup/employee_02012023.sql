USE [Employee]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 02-01-2023 21:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 02-01-2023 21:17:18 ******/
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
/****** Object:  StoredProcedure [dbo].[Department_Add]    Script Date: 02-01-2023 21:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Department_Add](
@DepartmentName nvarchar(100),
@IsActive bit,
@CreateDate datetime,
@CreateBy int
)
as

begin

	insert into Department(DepartmentName,IsActive,CreateDate,CreateBy)
	values(@DepartmentName,@IsActive,@CreateDate,@CreateBy)

	select 'Department add successfully' as [Message], 'success' as [status]

end
GO
/****** Object:  StoredProcedure [dbo].[Department_Delete]    Script Date: 02-01-2023 21:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Department_Delete](
@DepartmentId int
)
as

begin

	if not exists(select 1 from Department where DepartmentId = @DepartmentId)
	begin
		select 'Invalid department id' as [Message], 'fail' as [status]
		return
	end

	delete Department 
	where DepartmentId=@DepartmentId


	select 'Department deleted successfully' as [Message], 'success' as [status]

end
GO
/****** Object:  StoredProcedure [dbo].[Department_List]    Script Date: 02-01-2023 21:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Department_List]( 
@DepartmentId int = -1,
@DepartmentName nvarchar(100) = ''
)
as

begin
	
	declare @query nvarchar(max) = '
	select * from Department
	where DepartmentId is not null 
	'

	if(@DepartmentId <> -1)
		set @query += 'and DepartmentId = '+ convert(nvarchar,@DepartmentId)+''

	if(@DepartmentName <> '')
		set @query += 'and DepartmentName = '+ convert(nvarchar,@DepartmentName)+''

	exec(@query)

end
GO
/****** Object:  StoredProcedure [dbo].[Department_Update]    Script Date: 02-01-2023 21:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Department_Update](
@DepartmentId int,
@DepartmentName nvarchar(100),
@IsActive bit
)
as

begin

	if not exists(select 1 from Department where DepartmentId = @DepartmentId)
	begin
		select 'Invalid department id' as [Message], 'fail' as [status]
		return
	end

	update Department set DepartmentName = @DepartmentName, IsActive = @IsActive
	where DepartmentId = @DepartmentId

	select 'Department updated successfully' as [Message], 'success' as [status]

end
GO
/****** Object:  StoredProcedure [dbo].[Employee_Add]    Script Date: 02-01-2023 21:17:18 ******/
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
/****** Object:  StoredProcedure [dbo].[Employee_Delete]    Script Date: 02-01-2023 21:17:18 ******/
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
/****** Object:  StoredProcedure [dbo].[Employee_List]    Script Date: 02-01-2023 21:17:18 ******/
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
/****** Object:  StoredProcedure [dbo].[Employee_List_Mapping]    Script Date: 02-01-2023 21:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[Employee_List_Mapping](
@Id int = -1,
@Name nvarchar(50) = ''
)
as
begin
	declare @query nvarchar(max) = '
	select Employee.*,Department.DepartmentId as id, Department.* 
	from Employee left join Department
	on Employee.DepartmentId = Department.DepartmentId
	where Id is not null 
	'

	if(@Id <> -1)
		set @query += 'and Id = '+ convert(nvarchar,@Id)+''

	if(@Name <> '')
		set @query += 'and Name = '+ convert(nvarchar,@Name)+''

	exec(@query)
end

GO
/****** Object:  StoredProcedure [dbo].[Employee_Update]    Script Date: 02-01-2023 21:17:18 ******/
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
