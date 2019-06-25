/*========================================================== 创建架构 ===========================================================*/
CREATE USER "Systems"
IDENTIFIED BY system;

/*========================================================== 创建表 ===========================================================*/

/*==============================================================*/
/* Table: Application                                           */
/*==============================================================*/

create table "Systems"."Application" 
(
   "ApplicationId"      RAW(16)              not null,
   "Code"               NVARCHAR2(60)        not null,
   "Name"               NVARCHAR2(200)       not null,
   "Comment"            NVARCHAR2(500),
   "Enabled"            SMALLINT             not null,
   "RegisterEnabled"    SMALLINT             not null,
   "CreationTime"       DATE,
   "CreatorId"          RAW(16),
   "LastModificationTime" DATE,
   "LastModifierId"     RAW(16),
   "IsDeleted"          SMALLINT             not null,
   "Version"            RAW(72),
   constraint PK_APPLICATION primary key ("ApplicationId")
);


/*==============================================================*/
/* Table: "Role"                                                */
/*==============================================================*/
create table "Systems"."Role" 
(
   "RoleId"             RAW(16)              not null,
   "Code"               NVARCHAR2(256)       not null,
   "Name"               NVARCHAR2(256)       not null,
   "NormalizedName"     NVARCHAR2(256)       not null,
   "Type"               NVARCHAR2(80)        not null,
   "IsAdmin"            SMALLINT             not null,
   "ParentId"           RAW(16),
   "Path"               NVARCHAR2(800)       not null,
   "Level"              INTEGER              not null,
   "SortId"             INTEGER,
   "Enabled"            SMALLINT             not null,
   "Comment"            NVARCHAR2(500),
   "PinYin"             NVARCHAR2(200),
   "Sign"               NVARCHAR2(256),
   "CreationTime"       DATE,
   "CreatorId"          RAW(16),
   "LastModificationTime" DATE,
   "LastModifierId"     RAW(16),
   "IsDeleted"          SMALLINT             not null,
   "Version"            RAW(72),
   constraint PK_ROLE primary key ("RoleId")
);
