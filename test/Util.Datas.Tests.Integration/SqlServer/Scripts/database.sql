/*========================================================== 1. 创建数据库 ===========================================================*/
USE [master]
GO

--删除数据库
EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'UtilTest'
GO
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'UtilTest')
Begin
DROP DATABASE [UtilTest]
End
GO

--创建数据库
CREATE DATABASE [UtilTest]
GO

/*========================================================== 2. 创建架构 ===========================================================*/
USE [UtilTest]
GO

/* 1. Sales */
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Sales')
DROP SCHEMA [Sales]
GO
CREATE SCHEMA [Sales] AUTHORIZATION [dbo]
GO

/*========================================================== 3. 创建表 ===========================================================*/

/*==============================================*/
/* Orders                                      */
/*============================================*/


if exists (select 1
            from  sysobjects
           where  id = object_id('Sales.Orders')
            and   type = 'U')
   drop table Sales.Orders
go

create table Sales.Orders (
   OrderId              uniqueidentifier     not null,
   Code                 nvarchar(30)         not null,
   Version              timestamp            null,
   constraint PK_ORDERS primary key (OrderId)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Sales.Orders') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'schema', 'Sales', 'table', 'Orders' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '订单', 
   'schema', 'Sales', 'table', 'Orders'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sales.Orders')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OrderId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Sales', 'table', 'Orders', 'column', 'OrderId'

end


execute sp_addextendedproperty 'MS_Description', 
   '订单编号',
   'schema', 'Sales', 'table', 'Orders', 'column', 'OrderId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sales.Orders')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Code')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Sales', 'table', 'Orders', 'column', 'Code'

end


execute sp_addextendedproperty 'MS_Description', 
   '订单编码',
   'schema', 'Sales', 'table', 'Orders', 'column', 'Code'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sales.Orders')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Version')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Sales', 'table', 'Orders', 'column', 'Version'

end


execute sp_addextendedproperty 'MS_Description', 
   '版本号',
   'schema', 'Sales', 'table', 'Orders', 'column', 'Version'
go
