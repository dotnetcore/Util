/*========================================================== 1. 创建数据库 ===========================================================*/
drop database if exists `Sample`;
create database `Sample`;
use `Sample`;

/*========================================================== 2. 创建架构 ===========================================================*/
drop schema if exists `Systems`;
create schema `Systems`;

/*========================================================== 3. 创建表 ===========================================================*/

drop table if exists `Systems.Application`;

/*==============================================================*/
/* Table: Application                                           */
/*==============================================================*/
create table `Systems.Application`
(
   ApplicationId        char(36) not null comment '应用程序编号',
   Code                 national varchar(60) not null comment '应用程序编码',
   Name                 national varchar(200) not null comment '应用程序名称',
   Comment              national varchar(500) comment '备注',
   Enabled              bool not null comment '启用',
   RegisterEnabled      bool not null comment '启用注册',
   CreationTime         datetime comment '创建时间',
   CreatorId            char(36) comment '创建人编号',
   LastModificationTime datetime comment '最后修改时间',
   LastModifierId       char(36) comment '最后修改人编号',
   IsDeleted            bool not null comment '是否删除',
   Version              tinyblob comment '版本号',
   primary key (ApplicationId)
);

alter table `Systems.Application` comment '应用程序';

drop table if exists `Systems.Role`;

/*==============================================================*/
/* Table: Role                                                  */
/*==============================================================*/
create table `Systems.Role`
(
   RoleId               char(36) not null comment '角色编号',
   Code                 national varchar(256) not null comment '角色编码',
   Name                 national varchar(256) not null comment '角色名称',
   NormalizedName       national varchar(256) not null comment '标准化角色名称',
   Type                 national varchar(80) not null comment '角色类型',
   IsAdmin              bool not null comment '管理员',
   ParentId             char(36) comment '父编号',
   Path                 national varchar(800) not null comment '路径',
   Level                int not null comment '级数',
   SortId               int comment '排序号',
   Enabled              bool not null comment '启用',
   Comment              national varchar(500) comment '备注',
   PinYin               national varchar(200) comment '拼音简码',
   Sign                 national varchar(256) comment '签名',
   CreationTime         datetime comment '创建时间',
   CreatorId            char(36) comment '创建人编号',
   LastModificationTime datetime comment '最后修改时间',
   LastModifierId       char(36) comment '最后修改人编号',
   IsDeleted            bool not null comment '是否删除',
   Version              tinyblob comment '版本号',
   primary key (RoleId)
);

alter table `Systems.Role` comment '角色';