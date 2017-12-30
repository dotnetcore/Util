/*========================================================== 1. 创建数据库 ===========================================================*/
--删除数据库

--创建数据库
--create database "UtilTest";

/*========================================================== 2. 创建架构 ===========================================================*/
/* 1. Sales */
create schema "Sales";

/* 2. Productions */
create schema "Productions";

/* 3. Customers */
create schema "Customers";


/*========================================================== 3. 创建表 ===========================================================*/

/*==============================================================*/
/* Table: Customers                                             */
/*==============================================================*/
create table "Customers"."Customers" (
   "CustomerId" VARCHAR(50)          not null,
   "Name" VARCHAR(20)          not null,
   "Nickname" VARCHAR(30)          null,
   "Balance" DECIMAL(18,2)        not null,
   "Gender" INT4                 null,
   "Tel" VARCHAR(20)          null,
   "Mobile" VARCHAR(20)          null,
   "Email" VARCHAR(100)         null,
   "CreationTime" TIMESTAMP            null,
   "CreatorId" UUID                 null,
   "LastModificationTime" TIMESTAMP            null,
   "LastModifierId" UUID                 null,
   "Version" BYTEA                null,
   constraint PK_CUSTOMERS primary key ("CustomerId")
);

comment on table "Customers"."Customers" is
'客户';

comment on column  "Customers"."Customers"."CustomerId" is
'客户编号';

comment on column  "Customers"."Customers"."Name" is
'客户名称';

comment on column  "Customers"."Customers"."Nickname" is
'昵称';

comment on column  "Customers"."Customers"."Balance" is
'余额';

comment on column  "Customers"."Customers"."Gender" is
'性别';

comment on column  "Customers"."Customers"."Tel" is
'联系电话';

comment on column  "Customers"."Customers"."Mobile" is
'手机号';

comment on column  "Customers"."Customers"."Email" is
'电子邮件';

comment on column  "Customers"."Customers"."CreationTime" is
'创建时间';

comment on column  "Customers"."Customers"."CreatorId" is
'创建人';

comment on column  "Customers"."Customers"."LastModificationTime" is
'最后修改时间';

comment on column  "Customers"."Customers"."LastModifierId" is
'最后修改人';

comment on column  "Customers"."Customers"."Version" is
'版本号';
