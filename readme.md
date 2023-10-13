# Util应用框架介绍

[![Member project of .NET Core Community](https://img.shields.io/badge/member%20project%20of-NCC-9e20c9.svg)](https://github.com/dotnetcore)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://mit-license.org/)

<a href="https://www.jetbrains.com/?from=Util" target="_blank">
    <img src="https://github.com/dotnetcore/Home/blob/master/img/jetbrains.svg" title="JetBrains" />
</a>


## 什么是Util应用框架? 

Util是一个.Net平台下的应用框架，旨在提升中小团队的开发能力，由工具类、分层架构基类、Ui组件，配套代码生成模板，权限等组成。


### Util应用框架的目标: **让开发更简单**

Util应用框架让你的团队迅速进入业务开发状态,并在开发过程中持续提供帮助。


### Util应用框架的特点: **简单易用**

Util应用框架的设计理念是追求Api简单化,尽量少的配置,不用精确记忆Api,有个模糊印象即可使用。

Util应用框架的学习成本相对较低,对于有.Net基础的开发人员,进行常规业务开发,通常在3天内上手。

### Util应用框架相关资源

#### Github项目地址

- **Util** <https://github.com/dotnetcore/Util>

    该项目包含Util应用框架全部源码。
- **Util.Generator** <https://github.com/util-core/Util.Generator>

    该项目提供Util代码生成模板,帮助你迅速创建业务项目基架。
- **util-angular** <https://github.com/util-core/util-angular>

    该项目是对angular,ng zorro,ng alain前端框架的二次封装Js库,与Util.Ui.NgZorro类库配合使用。
- **Util.Platform.Single** <https://github.com/util-core/Util.Platform.Single>

    使用新的应用框架通常具有高昂的成本,为帮助你减轻初始负担,该项目提供一些常用业务功能,你可以将它作为项目起点。
    
    目前提供了权限管理模块,可以控制到菜单和按钮,并能基于角色资源对API进行访问控制,后续将不断完善其它常用功能。

    该项目提供单体和微服务两个版本,Util.Platform.Single是单体版本。
- **Util.Platform.Dapr** <https://github.com/util-core/Util.Platform.Dapr>

    它是Util Platform的微服务版本,采用Dapr微服务框架,项目结构参考自eShopOnDapr。
- **Util.Platform.Share** <https://github.com/util-core/Util.Platform.Share>

    包含Util.Platform.Single和Util.Platform.Dapr的共享代码,并发布到Nuget,供两个版本使用。

#### Gitee项目地址

**由于国内访问Github非常缓慢,现在Util所有项目发布时会在Gitee进行同步更新。**

- **Util** <https://gitee.com/util-core/util>
- **Util.Generator** <https://gitee.com/util-core/Util.Generator>
- **util-angular** <https://gitee.com/util-core/util-angular>
- **Util.Platform.Single** <https://gitee.com/util-core/Util.Platform.Single>
- **Util.Platform.Dapr** <https://gitee.com/util-core/Util.Platform.Dapr>
- **Util.Platform.Share** <https://gitee.com/util-core/Util.Platform.Share>

#### Nuget包

| 包名 |  版本 | 下载量
|--------------|  ------- | ----
| Util.Core | ![](https://img.shields.io/nuget/v/Util.Core.svg) | ![](https://img.shields.io/nuget/dt/Util.Core.svg)
| Util.ObjectMapping.AutoMapper | ![](https://img.shields.io/nuget/v/Util.ObjectMapping.AutoMapper.svg) | ![](https://img.shields.io/nuget/dt/Util.ObjectMapping.AutoMapper.svg)
| Util.Aop.AspectCore | ![](https://img.shields.io/nuget/v/Util.Aop.AspectCore.svg) | ![](https://img.shields.io/nuget/dt/Util.Aop.AspectCore.svg)
| Util.Validation | ![](https://img.shields.io/nuget/v/Util.Validation.svg) | ![](https://img.shields.io/nuget/dt/Util.Validation.svg)
| Util.Security | ![](https://img.shields.io/nuget/v/Util.Security.svg) | ![](https://img.shields.io/nuget/dt/Util.Security.svg)
| Util.Data.Abstractions | ![](https://img.shields.io/nuget/v/Util.Data.Abstractions.svg) | ![](https://img.shields.io/nuget/dt/Util.Data.Abstractions.svg)
| Util.AspNetCore | ![](https://img.shields.io/nuget/v/Util.AspNetCore.svg) | ![](https://img.shields.io/nuget/dt/Util.AspNetCore.svg)
| Util.Localization | ![](https://img.shields.io/nuget/v/Util.Localization.svg) | ![](https://img.shields.io/nuget/dt/Util.Localization.svg)
| Util.Logging | ![](https://img.shields.io/nuget/v/Util.Logging.svg) | ![](https://img.shields.io/nuget/dt/Util.Logging.svg)
| Util.Logging.Serilog | ![](https://img.shields.io/nuget/v/Util.Logging.Serilog.svg) | ![](https://img.shields.io/nuget/dt/Util.Logging.Serilog.svg)
| Util.Logging.Serilog.Exceptionless | ![](https://img.shields.io/nuget/v/Util.Logging.Serilog.Exceptionless.svg) | ![](https://img.shields.io/nuget/dt/Util.Logging.Serilog.Exceptionless.svg)
| Util.Events.Abstractions | ![](https://img.shields.io/nuget/v/Util.Events.Abstractions.svg) | ![](https://img.shields.io/nuget/dt/Util.Events.Abstractions.svg)
| Util.Events | ![](https://img.shields.io/nuget/v/Util.Events.svg) | ![](https://img.shields.io/nuget/dt/Util.Events.svg)
| Util.Events.MediatR | ![](https://img.shields.io/nuget/v/Util.Events.MediatR.svg) | ![](https://img.shields.io/nuget/dt/Util.Events.MediatR.svg)
| Util.Templates | ![](https://img.shields.io/nuget/v/Util.Templates.svg) | ![](https://img.shields.io/nuget/dt/Util.Templates.svg)
| Util.Templates.Razor | ![](https://img.shields.io/nuget/v/Util.Templates.Razor.svg) | ![](https://img.shields.io/nuget/dt/Util.Templates.Razor.svg)
| Util.Templates.Handlebars | ![](https://img.shields.io/nuget/v/Util.Templates.Handlebars.svg) | ![](https://img.shields.io/nuget/dt/Util.Templates.Handlebars.svg)
| Util.Caching | ![](https://img.shields.io/nuget/v/Util.Caching.svg) | ![](https://img.shields.io/nuget/dt/Util.Caching.svg)
| Util.Caching.EasyCaching | ![](https://img.shields.io/nuget/v/Util.Caching.EasyCaching.svg) | ![](https://img.shields.io/nuget/dt/Util.Caching.EasyCaching.svg)
| Util.Scheduling | ![](https://img.shields.io/nuget/v/Util.Scheduling.svg) | ![](https://img.shields.io/nuget/dt/Util.Scheduling.svg)
| Util.Scheduling.Quartz | ![](https://img.shields.io/nuget/v/Util.Scheduling.Quartz.svg) | ![](https://img.shields.io/nuget/dt/Util.Scheduling.Quartz.svg)
| Util.Scheduling.Hangfire | ![](https://img.shields.io/nuget/v/Util.Scheduling.Hangfire.svg) | ![](https://img.shields.io/nuget/dt/Util.Scheduling.Hangfire.svg)
| Util.Images.ImageSharp | ![](https://img.shields.io/nuget/v/Util.Images.ImageSharp.svg) | ![](https://img.shields.io/nuget/dt/Util.Images.ImageSharp.svg)
| Util.Images.Avatar | ![](https://img.shields.io/nuget/v/Util.Images.Avatar.svg) | ![](https://img.shields.io/nuget/dt/Util.Images.Avatar.svg)
| Util.FileStorage | ![](https://img.shields.io/nuget/v/Util.FileStorage.svg) | ![](https://img.shields.io/nuget/dt/Util.FileStorage.svg)
| Util.FileStorage.Minio | ![](https://img.shields.io/nuget/v/Util.FileStorage.Minio.svg) | ![](https://img.shields.io/nuget/dt/Util.FileStorage.Minio.svg)
| Util.Tenants.Abstractions | ![](https://img.shields.io/nuget/v/Util.Tenants.Abstractions.svg) | ![](https://img.shields.io/nuget/dt/Util.Tenants.Abstractions.svg)
| Util.Tenants | ![](https://img.shields.io/nuget/v/Util.Tenants.svg) | ![](https://img.shields.io/nuget/dt/Util.Tenants.svg)
| Util.Domain | ![](https://img.shields.io/nuget/v/Util.Domain.svg) | ![](https://img.shields.io/nuget/dt/Util.Domain.svg)
| Util.Domain.Biz | ![](https://img.shields.io/nuget/v/Util.Domain.Biz.svg) | ![](https://img.shields.io/nuget/dt/Util.Domain.Biz.svg)
| Util.Data.Core | ![](https://img.shields.io/nuget/v/Util.Data.Core.svg) | ![](https://img.shields.io/nuget/dt/Util.Data.Core.svg)
| Util.Data.Sql | ![](https://img.shields.io/nuget/v/Util.Data.Sql.svg) | ![](https://img.shields.io/nuget/dt/Util.Data.Sql.svg)
| Util.Data.Metadata | ![](https://img.shields.io/nuget/v/Util.Data.Metadata.svg) | ![](https://img.shields.io/nuget/dt/Util.Data.Metadata.svg)
| Util.Data.EntityFrameworkCore | ![](https://img.shields.io/nuget/v/Util.Data.EntityFrameworkCore.svg) | ![](https://img.shields.io/nuget/dt/Util.Data.EntityFrameworkCore.svg)
| Util.Data.EntityFrameworkCore.SqlServer | ![](https://img.shields.io/nuget/v/Util.Data.EntityFrameworkCore.SqlServer.svg) | ![](https://img.shields.io/nuget/dt/Util.Data.EntityFrameworkCore.SqlServer.svg)
| Util.Data.EntityFrameworkCore.PostgreSql | ![](https://img.shields.io/nuget/v/Util.Data.EntityFrameworkCore.PostgreSql.svg) | ![](https://img.shields.io/nuget/dt/Util.Data.EntityFrameworkCore.PostgreSql.svg)
| Util.Data.EntityFrameworkCore.MySql | ![](https://img.shields.io/nuget/v/Util.Data.EntityFrameworkCore.MySql.svg) | ![](https://img.shields.io/nuget/dt/Util.Data.EntityFrameworkCore.MySql.svg)
| Util.Data.EntityFrameworkCore.Sqlite | ![](https://img.shields.io/nuget/v/Util.Data.EntityFrameworkCore.Sqlite.svg) | ![](https://img.shields.io/nuget/dt/Util.Data.EntityFrameworkCore.Sqlite.svg)
| Util.Data.EntityFrameworkCore.Oracle | ![](https://img.shields.io/nuget/v/Util.Data.EntityFrameworkCore.Oracle.svg) | ![](https://img.shields.io/nuget/dt/Util.Data.EntityFrameworkCore.Oracle.svg)
| Util.Data.Dapper.Core | ![](https://img.shields.io/nuget/v/Util.Data.Dapper.Core.svg) | ![](https://img.shields.io/nuget/dt/Util.Data.Dapper.Core.svg)
| Util.Data.Dapper.SqlServer | ![](https://img.shields.io/nuget/v/Util.Data.Dapper.SqlServer.svg) | ![](https://img.shields.io/nuget/dt/Util.Data.Dapper.SqlServer.svg)
| Util.Data.Dapper.PostgreSql | ![](https://img.shields.io/nuget/v/Util.Data.Dapper.PostgreSql.svg) | ![](https://img.shields.io/nuget/dt/Util.Data.Dapper.PostgreSql.svg)
| Util.Data.Dapper.MySql | ![](https://img.shields.io/nuget/v/Util.Data.Dapper.MySql.svg) | ![](https://img.shields.io/nuget/dt/Util.Data.Dapper.MySql.svg)
| Util.Data.Dapper.All | ![](https://img.shields.io/nuget/v/Util.Data.Dapper.All.svg) | ![](https://img.shields.io/nuget/dt/Util.Data.Dapper.All.svg)
| Util.Application | ![](https://img.shields.io/nuget/v/Util.Application.svg) | ![](https://img.shields.io/nuget/dt/Util.Application.svg)
| Util.Application.EntityFrameworkCore | ![](https://img.shields.io/nuget/v/Util.Application.EntityFrameworkCore.svg) | ![](https://img.shields.io/nuget/dt/Util.Application.EntityFrameworkCore.svg)
| Util.Application.WebApi | ![](https://img.shields.io/nuget/v/Util.Application.WebApi.svg) | ![](https://img.shields.io/nuget/dt/Util.Application.WebApi.svg)
| Util.Microservices | ![](https://img.shields.io/nuget/v/Util.Microservices.svg) | ![](https://img.shields.io/nuget/dt/Util.Microservices.svg)
| Util.Microservices.Polly | ![](https://img.shields.io/nuget/v/Util.Microservices.Polly.svg) | ![](https://img.shields.io/nuget/dt/Util.Microservices.Polly.svg)
| Util.Microservices.Dapr | ![](https://img.shields.io/nuget/v/Util.Microservices.Dapr.svg) | ![](https://img.shields.io/nuget/dt/Util.Microservices.Dapr.svg)
| Util.Microservices.HealthChecks | ![](https://img.shields.io/nuget/v/Util.Microservices.HealthChecks.svg) | ![](https://img.shields.io/nuget/dt/Util.Microservices.HealthChecks.svg)
| Util.Ui | ![](https://img.shields.io/nuget/v/Util.Ui.svg) | ![](https://img.shields.io/nuget/dt/Util.Ui.svg)
| Util.Ui.Angular | ![](https://img.shields.io/nuget/v/Util.Ui.Angular.svg) | ![](https://img.shields.io/nuget/dt/Util.Ui.Angular.svg)
| Util.Ui.NgZorro | ![](https://img.shields.io/nuget/v/Util.Ui.NgZorro.svg) | ![](https://img.shields.io/nuget/dt/Util.Ui.NgZorro.svg)
| Util.Ui.NgAlain | ![](https://img.shields.io/nuget/v/Util.Ui.NgAlain.svg) | ![](https://img.shields.io/nuget/dt/Util.Ui.NgAlain.svg)
| Util.Generators | ![](https://img.shields.io/nuget/v/Util.Generators.svg) | ![](https://img.shields.io/nuget/dt/Util.Generators.svg)
| Util.Generators.Razor | ![](https://img.shields.io/nuget/v/Util.Generators.Razor.svg) | ![](https://img.shields.io/nuget/dt/Util.Generators.Razor.svg)