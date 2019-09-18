/*========================================================== 1. 创建数据库 ===========================================================*/
USE [master]
GO

--删除数据库
EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'Log'
GO
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'Log')
Begin
DROP DATABASE [Log]
End
GO

--创建数据库
CREATE DATABASE [Log]
GO

/*========================================================== 2. 创建架构 ===========================================================*/
USE [Log]
GO

/* 1. 日志模块[Logs] */
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Logs')
DROP SCHEMA [Logs]
GO
CREATE SCHEMA [Logs] AUTHORIZATION [dbo]
GO

/*========================================================== 3. 创建表及索引 ===========================================================*/
if exists (select 1
            from  sysobjects
           where  id = object_id('Logs.Log')
            and   type = 'U')
   drop table Logs.Log
go

/*==============================================================*/
/* Table: Log                                                   */
/*==============================================================*/
create table Logs.Log (
   Id                   bigint               identity,
   TraceId              nvarchar(50)         not null,
   BusinessId           nvarchar(50)         null,
   LogName              nvarchar(100)        not null,
   Level                nvarchar(20)         not null,
   OperationTime        nvarchar(30)         not null,
   Duration             nvarchar(50)         null,
   Url                  nvarchar(500)        null,
   Tenant               nvarchar(100)        null,
   Application          nvarchar(200)        null,
   Module               nvarchar(500)        null,
   Class                nvarchar(500)        null,
   Method               nvarchar(200)        null,
   Params               nvarchar(max)        null,
   Caption              nvarchar(500)        null,
   Content              nvarchar(max)        null,
   Sql                  nvarchar(max)        null,
   SqlParams            nvarchar(max)        null,
   ErrorCode            nvarchar(30)         null,
   ErrorMessage         nvarchar(2000)       null,
   StackTrace           nvarchar(max)        null,
   UserId               nvarchar(50)         null,
   Operator             nvarchar(50)         null,
   Role                 nvarchar(500)        null,
   Ip                   nvarchar(50)         null,
   Host                 nvarchar(200)        null,
   ThreadId             nvarchar(20)         null,
   Browser              nvarchar(2000)       null,
   constraint PK_LOG primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Logs.Log') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'schema', 'Logs', 'table', 'Log' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '日志', 
   'schema', 'Logs', 'table', 'Log'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'Id'

end


execute sp_addextendedproperty 'MS_Description', 
   '日志编号',
   'schema', 'Logs', 'table', 'Log', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TraceId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'TraceId'

end


execute sp_addextendedproperty 'MS_Description', 
   '跟踪号',
   'schema', 'Logs', 'table', 'Log', 'column', 'TraceId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'BusinessId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'BusinessId'

end


execute sp_addextendedproperty 'MS_Description', 
   '业务标识',
   'schema', 'Logs', 'table', 'Log', 'column', 'BusinessId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LogName')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'LogName'

end


execute sp_addextendedproperty 'MS_Description', 
   '日志名称',
   'schema', 'Logs', 'table', 'Log', 'column', 'LogName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Level')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'Level'

end


execute sp_addextendedproperty 'MS_Description', 
   '日志级别',
   'schema', 'Logs', 'table', 'Log', 'column', 'Level'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OperationTime')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'OperationTime'

end


execute sp_addextendedproperty 'MS_Description', 
   '操作时间',
   'schema', 'Logs', 'table', 'Log', 'column', 'OperationTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Duration')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'Duration'

end


execute sp_addextendedproperty 'MS_Description', 
   '执行时间',
   'schema', 'Logs', 'table', 'Log', 'column', 'Duration'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Url')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'Url'

end


execute sp_addextendedproperty 'MS_Description', 
   '请求地址',
   'schema', 'Logs', 'table', 'Log', 'column', 'Url'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Tenant')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'Tenant'

end


execute sp_addextendedproperty 'MS_Description', 
   '租户',
   'schema', 'Logs', 'table', 'Log', 'column', 'Tenant'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Application')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'Application'

end


execute sp_addextendedproperty 'MS_Description', 
   '应用程序',
   'schema', 'Logs', 'table', 'Log', 'column', 'Application'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Module')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'Module'

end


execute sp_addextendedproperty 'MS_Description', 
   '模块',
   'schema', 'Logs', 'table', 'Log', 'column', 'Module'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Class')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'Class'

end


execute sp_addextendedproperty 'MS_Description', 
   '类名',
   'schema', 'Logs', 'table', 'Log', 'column', 'Class'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Method')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'Method'

end


execute sp_addextendedproperty 'MS_Description', 
   '方法',
   'schema', 'Logs', 'table', 'Log', 'column', 'Method'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Params')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'Params'

end


execute sp_addextendedproperty 'MS_Description', 
   '参数',
   'schema', 'Logs', 'table', 'Log', 'column', 'Params'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Caption')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'Caption'

end


execute sp_addextendedproperty 'MS_Description', 
   '标题',
   'schema', 'Logs', 'table', 'Log', 'column', 'Caption'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Content')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'Content'

end


execute sp_addextendedproperty 'MS_Description', 
   '内容',
   'schema', 'Logs', 'table', 'Log', 'column', 'Content'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sql')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'Sql'

end


execute sp_addextendedproperty 'MS_Description', 
   'Sql语句',
   'schema', 'Logs', 'table', 'Log', 'column', 'Sql'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SqlParams')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'SqlParams'

end


execute sp_addextendedproperty 'MS_Description', 
   'Sql参数',
   'schema', 'Logs', 'table', 'Log', 'column', 'SqlParams'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ErrorCode')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'ErrorCode'

end


execute sp_addextendedproperty 'MS_Description', 
   '错误码',
   'schema', 'Logs', 'table', 'Log', 'column', 'ErrorCode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ErrorMessage')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'ErrorMessage'

end


execute sp_addextendedproperty 'MS_Description', 
   '错误消息',
   'schema', 'Logs', 'table', 'Log', 'column', 'ErrorMessage'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StackTrace')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'StackTrace'

end


execute sp_addextendedproperty 'MS_Description', 
   '堆栈跟踪',
   'schema', 'Logs', 'table', 'Log', 'column', 'StackTrace'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'UserId'

end


execute sp_addextendedproperty 'MS_Description', 
   '操作人标识',
   'schema', 'Logs', 'table', 'Log', 'column', 'UserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Operator')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'Operator'

end


execute sp_addextendedproperty 'MS_Description', 
   '操作人',
   'schema', 'Logs', 'table', 'Log', 'column', 'Operator'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Role')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'Role'

end


execute sp_addextendedproperty 'MS_Description', 
   '操作人角色',
   'schema', 'Logs', 'table', 'Log', 'column', 'Role'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Ip')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'Ip'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP地址',
   'schema', 'Logs', 'table', 'Log', 'column', 'Ip'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Host')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'Host'

end


execute sp_addextendedproperty 'MS_Description', 
   '主机',
   'schema', 'Logs', 'table', 'Log', 'column', 'Host'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ThreadId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'ThreadId'

end


execute sp_addextendedproperty 'MS_Description', 
   '线程号',
   'schema', 'Logs', 'table', 'Log', 'column', 'ThreadId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.Log')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Browser')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'Log', 'column', 'Browser'

end


execute sp_addextendedproperty 'MS_Description', 
   '浏览器',
   'schema', 'Logs', 'table', 'Log', 'column', 'Browser'
go
