/*========================================================== 1. 创建数据库 ===========================================================*/
--create database "Sample";

/*========================================================== 2. 创建架构 ===========================================================*/
create schema "Systems";

/*========================================================== 3. 创建表 ===========================================================*/

/*==============================================================*/
/* Table: Application                                           */
/*==============================================================*/
create table "Systems"."Application" (
   "ApplicationId" UUID                 not null,
   "Code" VARCHAR(60)          not null,
   "Name" VARCHAR(200)         not null,
   "Comment" VARCHAR(500)         null,
   "Enabled" BOOL                 not null,
   "RegisterEnabled" BOOL                 not null,
   "CreationTime" TIMESTAMP            null,
   "CreatorId" UUID                 null,
   "LastModificationTime" TIMESTAMP            null,
   "LastModifierId" UUID                 null,
   "IsDeleted" BOOL                 not null,
   "Version" BYTEA                null,
   constraint PK_APPLICATION primary key ("ApplicationId")
);

comment on table "Systems"."Application" is
'应用程序';

comment on column  "Systems"."Application"."ApplicationId" is
'应用程序编号';

comment on column  "Systems"."Application"."Code" is
'应用程序编码';

comment on column  "Systems"."Application"."Name" is
'应用程序名称';

comment on column  "Systems"."Application"."Comment" is
'备注';

comment on column  "Systems"."Application"."Enabled" is
'启用';

comment on column  "Systems"."Application"."RegisterEnabled" is
'启用注册';

comment on column  "Systems"."Application"."CreationTime" is
'创建时间';

comment on column  "Systems"."Application"."CreatorId" is
'创建人编号';

comment on column  "Systems"."Application"."LastModificationTime" is
'最后修改时间';

comment on column  "Systems"."Application"."LastModifierId" is
'最后修改人编号';

comment on column  "Systems"."Application"."IsDeleted" is
'是否删除';

comment on column  "Systems"."Application"."Version" is
'版本号';

/*==============================================================*/
/* Table: Role                                                  */
/*==============================================================*/
create table "Systems"."Role" (
   "RoleId" UUID                 not null,
   "Code" VARCHAR(256)         not null,
   "Name" VARCHAR(256)         not null,
   "NormalizedName" VARCHAR(256)         not null,
   "Type" VARCHAR(80)          not null,
   "IsAdmin" BOOL                 not null,
   "ParentId" UUID                 null,
   "Path" VARCHAR(800)         not null,
   "Level" INT4                 not null,
   "SortId" INT4                 null,
   "Enabled" BOOL                 not null,
   "Comment" VARCHAR(500)         null,
   "PinYin" VARCHAR(200)         null,
   "Sign" VARCHAR(256)         null,
   "CreationTime" TIMESTAMP            null,
   "CreatorId" UUID                 null,
   "LastModificationTime" TIMESTAMP            null,
   "LastModifierId" UUID                 null,
   "IsDeleted" BOOL                 not null,
   "Version" BYTEA                null,
   constraint PK_ROLE primary key ("RoleId")
);

comment on table "Systems"."Role" is
'角色';

comment on column  "Systems"."Role"."RoleId" is
'角色编号';

comment on column  "Systems"."Role"."Code" is
'角色编码';

comment on column  "Systems"."Role"."Name" is
'角色名称';

comment on column  "Systems"."Role"."NormalizedName" is
'标准化角色名称';

comment on column  "Systems"."Role"."Type" is
'角色类型';

comment on column  "Systems"."Role"."IsAdmin" is
'管理员';

comment on column  "Systems"."Role"."ParentId" is
'父编号';

comment on column  "Systems"."Role"."Path" is
'路径';

comment on column  "Systems"."Role"."Level" is
'级数';

comment on column  "Systems"."Role"."SortId" is
'排序号';

comment on column  "Systems"."Role"."Enabled" is
'启用';

comment on column  "Systems"."Role"."Comment" is
'备注';

comment on column  "Systems"."Role"."PinYin" is
'拼音简码';

comment on column  "Systems"."Role"."Sign" is
'签名';

comment on column  "Systems"."Role"."CreationTime" is
'创建时间';

comment on column  "Systems"."Role"."CreatorId" is
'创建人编号';

comment on column  "Systems"."Role"."LastModificationTime" is
'最后修改时间';

comment on column  "Systems"."Role"."LastModifierId" is
'最后修改人编号';

comment on column  "Systems"."Role"."IsDeleted" is
'是否删除';

comment on column  "Systems"."Role"."Version" is
'版本号';