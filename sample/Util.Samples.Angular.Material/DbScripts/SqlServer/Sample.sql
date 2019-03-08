/*========================================================== 1. 创建数据库 ===========================================================*/
USE [master]
GO

--删除数据库
EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'Sample'
GO
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'Sample')
Begin
DROP DATABASE [Sample]
End
GO

--创建数据库
CREATE DATABASE [Sample]
GO

/*========================================================== 2. 创建架构 ===========================================================*/
USE [Sample]
GO

/* 1. 系统模块[Systems] */
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Systems')
DROP SCHEMA [Systems]
GO
CREATE SCHEMA [Systems] AUTHORIZATION [dbo]
GO

/*========================================================== 3. 创建表及索引 ===========================================================*/

if exists (select 1
            from  sysindexes
           where  id    = object_id('Systems.Application')
            and   name  = 'clus_idx_creationtime'
            and   indid > 0
            and   indid < 255)
   drop index Systems.Application.clus_idx_creationtime
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Systems.Application')
            and   type = 'U')
   drop table Systems.Application
go

/*==============================================================*/
/* Table: Application                                           */
/*==============================================================*/
create table Systems.Application (
   ApplicationId        uniqueidentifier     not null,
   Code                 nvarchar(60)         not null,
   Name                 nvarchar(200)        not null,
   Comment              nvarchar(500)        null,
   Enabled              bit                  not null,
   RegisterEnabled      bit                  not null,
   CreationTime         datetime             null,
   CreatorId            uniqueidentifier     null,
   LastModificationTime datetime             null,
   LastModifierId       uniqueidentifier     null,
   IsDeleted            bit                  not null,
   Version              timestamp            null,
   constraint PK_APPLICATION primary key nonclustered (ApplicationId)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Systems.Application') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'schema', 'Systems', 'table', 'Application' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '应用程序', 
   'schema', 'Systems', 'table', 'Application'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ApplicationId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Application', 'column', 'ApplicationId'

end


execute sp_addextendedproperty 'MS_Description', 
   '应用程序编号',
   'schema', 'Systems', 'table', 'Application', 'column', 'ApplicationId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Code')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Application', 'column', 'Code'

end


execute sp_addextendedproperty 'MS_Description', 
   '应用程序编码',
   'schema', 'Systems', 'table', 'Application', 'column', 'Code'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Application', 'column', 'Name'

end


execute sp_addextendedproperty 'MS_Description', 
   '应用程序名称',
   'schema', 'Systems', 'table', 'Application', 'column', 'Name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Comment')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Application', 'column', 'Comment'

end


execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'schema', 'Systems', 'table', 'Application', 'column', 'Comment'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Enabled')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Application', 'column', 'Enabled'

end


execute sp_addextendedproperty 'MS_Description', 
   '启用',
   'schema', 'Systems', 'table', 'Application', 'column', 'Enabled'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RegisterEnabled')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Application', 'column', 'RegisterEnabled'

end


execute sp_addextendedproperty 'MS_Description', 
   '启用注册',
   'schema', 'Systems', 'table', 'Application', 'column', 'RegisterEnabled'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreationTime')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Application', 'column', 'CreationTime'

end


execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'schema', 'Systems', 'table', 'Application', 'column', 'CreationTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatorId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Application', 'column', 'CreatorId'

end


execute sp_addextendedproperty 'MS_Description', 
   '创建人编号',
   'schema', 'Systems', 'table', 'Application', 'column', 'CreatorId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LastModificationTime')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Application', 'column', 'LastModificationTime'

end


execute sp_addextendedproperty 'MS_Description', 
   '最后修改时间',
   'schema', 'Systems', 'table', 'Application', 'column', 'LastModificationTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LastModifierId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Application', 'column', 'LastModifierId'

end


execute sp_addextendedproperty 'MS_Description', 
   '最后修改人编号',
   'schema', 'Systems', 'table', 'Application', 'column', 'LastModifierId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDeleted')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Application', 'column', 'IsDeleted'

end


execute sp_addextendedproperty 'MS_Description', 
   '是否删除',
   'schema', 'Systems', 'table', 'Application', 'column', 'IsDeleted'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Version')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Application', 'column', 'Version'

end


execute sp_addextendedproperty 'MS_Description', 
   '版本号',
   'schema', 'Systems', 'table', 'Application', 'column', 'Version'
go

/*==============================================================*/
/* Index: clus_idx_creationtime                                 */
/*==============================================================*/
create clustered index clus_idx_creationtime on Systems.Application (
CreationTime ASC
)
go


if exists (select 1
            from  sysindexes
           where  id    = object_id('Systems.Role')
            and   name  = 'cls_idx_creationtime'
            and   indid > 0
            and   indid < 255)
   drop index Systems.Role.cls_idx_creationtime
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Systems.Role')
            and   type = 'U')
   drop table Systems.Role
go

/*==============================================================*/
/* Table: Role                                                  */
/*==============================================================*/
create table Systems.Role (
   RoleId               uniqueidentifier     not null,
   Code                 nvarchar(256)        not null,
   Name                 nvarchar(256)        not null,
   NormalizedName       nvarchar(256)        not null,
   Type                 nvarchar(80)         not null,
   IsAdmin              bit                  not null,
   ParentId             uniqueidentifier     null,
   Path                 nvarchar(800)        not null,
   Level                int                  not null,
   SortId               int                  null,
   Enabled              bit                  not null,
   Comment              nvarchar(500)        null,
   PinYin               nvarchar(200)        null,
   Sign                 nvarchar(256)        null,
   CreationTime         datetime             null,
   CreatorId            uniqueidentifier     null,
   LastModificationTime datetime             null,
   LastModifierId       uniqueidentifier     null,
   IsDeleted            bit                  not null,
   Version              timestamp            null,
   constraint PK_ROLE primary key nonclustered (RoleId)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Systems.Role') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'schema', 'Systems', 'table', 'Role' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '角色', 
   'schema', 'Systems', 'table', 'Role'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RoleId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Role', 'column', 'RoleId'

end


execute sp_addextendedproperty 'MS_Description', 
   '角色编号',
   'schema', 'Systems', 'table', 'Role', 'column', 'RoleId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Code')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Role', 'column', 'Code'

end


execute sp_addextendedproperty 'MS_Description', 
   '角色编码',
   'schema', 'Systems', 'table', 'Role', 'column', 'Code'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Role', 'column', 'Name'

end


execute sp_addextendedproperty 'MS_Description', 
   '角色名称',
   'schema', 'Systems', 'table', 'Role', 'column', 'Name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NormalizedName')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Role', 'column', 'NormalizedName'

end


execute sp_addextendedproperty 'MS_Description', 
   '标准化角色名称',
   'schema', 'Systems', 'table', 'Role', 'column', 'NormalizedName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Type')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Role', 'column', 'Type'

end


execute sp_addextendedproperty 'MS_Description', 
   '角色类型',
   'schema', 'Systems', 'table', 'Role', 'column', 'Type'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsAdmin')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Role', 'column', 'IsAdmin'

end


execute sp_addextendedproperty 'MS_Description', 
   '管理员',
   'schema', 'Systems', 'table', 'Role', 'column', 'IsAdmin'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ParentId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Role', 'column', 'ParentId'

end


execute sp_addextendedproperty 'MS_Description', 
   '父编号',
   'schema', 'Systems', 'table', 'Role', 'column', 'ParentId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Path')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Role', 'column', 'Path'

end


execute sp_addextendedproperty 'MS_Description', 
   '路径',
   'schema', 'Systems', 'table', 'Role', 'column', 'Path'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Level')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Role', 'column', 'Level'

end


execute sp_addextendedproperty 'MS_Description', 
   '级数',
   'schema', 'Systems', 'table', 'Role', 'column', 'Level'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SortId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Role', 'column', 'SortId'

end


execute sp_addextendedproperty 'MS_Description', 
   '排序号',
   'schema', 'Systems', 'table', 'Role', 'column', 'SortId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Enabled')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Role', 'column', 'Enabled'

end


execute sp_addextendedproperty 'MS_Description', 
   '启用',
   'schema', 'Systems', 'table', 'Role', 'column', 'Enabled'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Comment')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Role', 'column', 'Comment'

end


execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'schema', 'Systems', 'table', 'Role', 'column', 'Comment'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PinYin')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Role', 'column', 'PinYin'

end


execute sp_addextendedproperty 'MS_Description', 
   '拼音简码',
   'schema', 'Systems', 'table', 'Role', 'column', 'PinYin'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sign')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Role', 'column', 'Sign'

end


execute sp_addextendedproperty 'MS_Description', 
   '签名',
   'schema', 'Systems', 'table', 'Role', 'column', 'Sign'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreationTime')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Role', 'column', 'CreationTime'

end


execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'schema', 'Systems', 'table', 'Role', 'column', 'CreationTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatorId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Role', 'column', 'CreatorId'

end


execute sp_addextendedproperty 'MS_Description', 
   '创建人编号',
   'schema', 'Systems', 'table', 'Role', 'column', 'CreatorId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LastModificationTime')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Role', 'column', 'LastModificationTime'

end


execute sp_addextendedproperty 'MS_Description', 
   '最后修改时间',
   'schema', 'Systems', 'table', 'Role', 'column', 'LastModificationTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LastModifierId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Role', 'column', 'LastModifierId'

end


execute sp_addextendedproperty 'MS_Description', 
   '最后修改人编号',
   'schema', 'Systems', 'table', 'Role', 'column', 'LastModifierId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDeleted')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Role', 'column', 'IsDeleted'

end


execute sp_addextendedproperty 'MS_Description', 
   '是否删除',
   'schema', 'Systems', 'table', 'Role', 'column', 'IsDeleted'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Systems.Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Version')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Systems', 'table', 'Role', 'column', 'Version'

end


execute sp_addextendedproperty 'MS_Description', 
   '版本号',
   'schema', 'Systems', 'table', 'Role', 'column', 'Version'
go

/*==============================================================*/
/* Index: cls_idx_creationtime                                  */
/*==============================================================*/
create clustered index cls_idx_creationtime on Systems.Role (
CreationTime DESC
)
go
