# Util应用框架介绍

[![Member project of .NET Core Community](https://img.shields.io/badge/member%20project%20of-NCC-9e20c9.svg)](https://github.com/dotnetcore)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://mit-license.org/)

<a href="https://www.jetbrains.com/?from=Util" target="_blank">
    <img src="https://github.com/dotnetcore/Home/blob/master/img/jetbrains.svg" title="JetBrains" />
</a>


## 什么是Util应用框架? 

Util是一个.Net平台下的应用框架，旨在提升中小团队的开发能力，由工具类、分层架构基类、Ui组件，配套代码生成模板，权限等组成。

## Util应用框架的作者: **何镇汐**

Util应用框架的主要作者为何镇汐。

## Util应用框架的开源协议: **MIT**

这是最宽松的开源协议,意味着可以以任何方式使用该代码。

## Util应用框架的主要贡献者

[汪总](https://github.com/jianxuanbing "简楚恩")    [胡兴业](https://github.com/huxingye) 

这里只列出了主要贡献者,还有很多开发人员以不同形式对Util做出了宝贵贡献。

## Util应用框架的目标: **让开发更简单**

Util应用框架让你的团队迅速进入业务开发状态,并在开发过程中持续提供帮助。

## Util应用框架的特点: **简单易用**

Util应用框架的设计理念是追求Api简单化,尽量少的配置,不用精确记忆Api,有个模糊印象即可使用。

Util应用框架的学习成本相对较低,对于有.Net基础的开发人员,进行常规业务开发,通常在3天内上手。

## Util应用框架开发流程

> *搜集* - *整理* - *集成* - *封装*

每当发现无法满足项目需求时，扩展框架的时刻来临。

从头造轮子是下策，所以总是先四处**搜集**相关资料。对于简单的需求，可能只需要找到一些代码片断即可。对于更专业的问题，需要寻求第三方技术框架的帮助。

找到解决方案并调试通过后，需要对代码进行**整理**，以符合我们的编程风格。

通常以Nuget包或Npm包的方式进行**集成**,为了降低学习成本，需要仔细考虑如何**封装**才能让调用者最省力。

> 任何有技术含量的工作，均由第三方技术框架完成，Util应用框架仅对技术框架选型并集成封装。
>
> Util应用框架只是很薄的一层外观，为复杂的技术框架提供一个简易视图。
>
> 这导致更健壮的实现和更易用的API。

## Util应用框架的使用方式

使用Util应用框架有几种不同的方式。

最灵活的方式是将Util应用框架的代码复制到你自己的应用框架中,然后可以随意修改它们来满足项目需求。

不过这种方式的代价也很大,很难合并Util的任何更新,你需要自行维护相当大的代码库。

由于Util应用框架的体积在不断增长,维护这些代码库可能给你带来不小的负担。

另一种可行的方式是将Util应用框架作为你的基础库,使用Nuget引入它们,基础的工作让Util应用框架帮你完成,你只需要扩展自己业务领域相关的功能。

这种方式的限制也很明显,Util提供的功能可能无法满足你的要求。

解决这个问题的关键是与Util开发团队保持沟通,将你的需求告诉我们。

对于通用功能,我们会尽量满足,这样会让更多的开发者受益,对于定制需求,我们也会为你提供扩展点,方便你能自行扩展。

## 框架核心

- ### 启动器

Util应用框架在项目启动时,会扫描全部程序集,并自动执行服务注册器,执行相关依赖配置.

启动器核心代码参考自 [NopCommerce](https://www.nopcommerce.com) .

- ### 服务注册器

项目启动扫描时,会加载所有的服务注册器,并按顺序执行.

> 服务注册器类似其它应用框架的模块概念,但功能有限.
>
> 只能用于配置依赖注入关系,无法获取服务提供程序,所以不能执行复杂的操作.

- ### 依赖注册器

扫描 ISingletonDependency, IScopeDependency, ITransientDependency 接口,并自动配置依赖.

## 框架基础

- ### 对象到对象映射

技术选型: [AutoMapper](http://automapper.org/).

对象到对象映射主要用于分层对象之间的转换,比如从实体映射到DTO.

Util 在所有对象上添加 **MapTo** 扩展方法,自动完成基础配置,如果映射的两端对象属性名相同,则无需配置,直接使用即可.

- ### AOP( 面向切面编程 )

技术选型: [AspectCore](https://github.com/dotnetcore/AspectCore-Framework).

AOP用于在调用方法时进行拦截,在执行前后添加自定义逻辑.

Util 主要使用AOP拦截器进行验证.

- ### 对象验证

Util 使用 DataAnnotation 注解作为基础验证方式,并提供 **验证规则** 和 **验证处理器** 等构造块进行自定义验证和处理.

Util 在实体,DTO等对象上添加了 **Validate** 方法, 以标准化的方式进行对象验证.

- ### 异常处理

Util 提供了 **Warning** 类型,表示业务异常,并封装相关异常操作.

- ### 身份认证和授权

技术选型: [Identity](https://learn.microsoft.com/zh-cn/aspnet/core/security/authentication/identity), [Identity Server 4](https://github.com/IdentityServer/IdentityServer4)

Identity 是Asp.Net Core自带的身份认证框架,提供用户管理,登录认证等功能.

> Identity Server 4 是一个身份认证服务器,用于颁发令牌和验证令牌等操作.
>
> Identity Server 4 已经停止更新,它的新版本是收费的,Util 仅使用 Identity Server 4 的基础功能,由于它的基础功能已经十分稳定,暂时不需要迁移到其它框架.

Util 除了集成 Identity 和 Identity Server 4,还扩展了Asp.Net Core自定义授权策略,提供简单易行的Api访问控制方法.

Util Platform提供了基于角色和资源的权限管理功能,可以轻松设置前端UI菜单和按钮等权限,同时对后端API进行访问控制.

- ### 本地化

技术选型: [My.Extensions.Localization.Json](https://github.com/hishamco/My.Extensions.Localization.Json)

Util 本地化支持Json文件或自定义数据存储方式.

My.Extensions.Localization.Json 提供了Json本地化功能.

由于无法满足项目需求, 以源码方式引入, 对健壮性和性能进行了提升.

- ### 日志

技术选型: [Serilog](https://serilog.net/), [Seq](https://datalust.co/), [Exceptionless](https://exceptionless.com/)

Serilog是.Net目前最流行的日志框架,支持结构化日志.

Seq 和 Exceptionless 是日志管理系统,提供了操作日志的界面,可以使用Serilog写入.

Util 对它们进行了轻度封装,集成了常用配置,并提供日志上下文等扩展.

- ### 缓存

技术选型: [EasyCaching](https://github.com/dotnetcore/EasyCaching)

Util 集成了内存缓存和Redis缓存两种提供程序.

- ### 事件总线

技术选型: [MediatR](https://github.com/jbogard/MediatR), [Dapr](https://dapr.io/)

> 事件总线分为本地事件总线和集成事件总线.

Util 本地事件总线提供两种实现,默认使用Ioc方式实现,无需外部依赖. 另外引入了 MediatR 框架,它是流行的进程内事件处理框架.

集成事件总线用于微服务之间消息通信,Util 集成了 Dapr 微服务框架,基于 Dapr 的发布订阅实现集成事件总线.

- ### 模板引擎

技术选型: [RazorEngineCore](https://github.com/adoconnection/razorenginecore) , [Handlebars.Net](https://github.com/Handlebars-Net/Handlebars.Net)

Util 以源码方式引入 RazorEngineCore ,并进行大量修改.

Razor 模板引擎目前主要用在 Util 代码生成器.

- ### 图像处理

技术选型: [ImageSharp](https://sixlabors.com/)

ImageSharp 是一个图像处理库.

Util 使用 ImageSharp 实现动态文本头像生成.

- ### 文件存储

技术选型: [Minio](http://minio.org.cn/)

Minio 是流行的对象存储系统,适合部署到内部服务器.

Util 集成封装了 Minio SDK, 提供 存储桶名称处理策略, 文件名处理策略等构造块进行扩展处理.

- ### 后台任务

技术选型: [Quartz](https://www.quartz-scheduler.net/) , [HangFire](https://www.hangfire.io/)

Util 封装了 Quartz 和 HangFire, 用于处理后台任务.

- ### 数据访问

技术选型: [EntityFrameworkCore](https://docs.microsoft.com/zh-cn/ef/core/) , [Dapper](https://github.com/DapperLib/Dapper)

Util数据访问主要使用 EntityFrameworkCore ,它是.Net官方提供的ORM框架,属于重量级数据访问框架.

EntityFrameworkCore 支持工作单元模式,对复杂的业务处理非常有效,但对复杂的查询操作无能为力.

可以直接使用 EntityFrameworkCore 执行Sql语句, 但此操作非常原始,效率低下.

Dapper是轻量级数据访问框架, Util引入它并进行封装,用于解决查询问题.

目前 Util Dapper 封装尚不可用,它还缺乏分页,Lambda表达式支持等高级功能,现在仅用于代码生成读取元数据,后续会进行扩展.

由于使用国产数据库的需求逐渐增多,后续将考虑引入 [FreeSql](https://github.com/dotnetcore/FreeSql) 数据访问框架.

- ### 工具类

Util包含大量工具类,用于处理常用操作.

- 类型转换操作
- Lambda操作
- 命令行操作
- 配置操作
- 枚举操作
- Ioc操作
- Json操作
- 字符串操作
- 时间操作
- IP操作
- Web操作
- 加密操作
- ...

## 架构支持

### 多租户架构支持

Saas系统支持多家客户使用同一系统,客户数据彼此隔离.

Util 参考了 [ABP](https://abp.io/) 应用框架的多租户架构设计的租户解析和数据过滤部分.

Util 多租户架构在独立部署租户数据库方面基于 EntityFrameworkCore 的官方建议,有一些限制.

### DDD分层架构支持

Util 分层架构基于领域驱动设计(DDD) 和 企业应用架构模式(POEAA) 的基础构造块.

.Net 早期流行的分层架构是三层架构, 对于不熟悉 DDD 的开发人员,可以把它当成三层架构使用,不过术语的变化而已.

但是对于有一定领域模型使用经验的开发人员,该架构在处理更复杂的业务时可以有效管控复杂性.

对于复杂模块的开发,该架构与三层架构的主要区别在于,实体是作为简单数据容器,还是作为业务处理的场所.

对于很多业务领域,将实体对应的业务操作封装到实体本身,可以提升业务表达能力和封装性.

Util 分层架构分为四层.

#### 领域层

领域层是Util分层架构的核心.

领域层非常纯净, 没有对数据访问和UI的依赖,很容易对该层进行单元测试.

  - ##### 聚合根

    作为并发单元的最外层实体.

  - ##### 实体

    由唯一标识决定的业务对象.

  - ##### 值对象

    表示实体属性值的对象.

  - ##### 仓储

    表示聚合根的集合,用于进行数据访问.

  - ##### 领域服务

    用于封装多个聚合根的操作.

  - ##### 领域事件

    表示实体数据发生变化.

    使用Util本地事件总线发布领域事件.

    有几个标准领域事件:

    - EntityChangedEvent - 实体变更事件
    - EntityCreatedEvent - 实体创建事件
    - EntityUpdatedEvent - 实体修改事件
    - EntityDeletedEvent - 实体删除事件

#### 基础设施层

对于大多项目,基础设施层主要包含数据访问的实现.

#### 应用层

集成了领域层和基础设施层,为UI提供服务.

  - ##### 应用服务

    应用服务接收UI请求,并将调用委托给实体,领域服务等构造块完成业务功能.

    对于普通项目,业务逻辑直接在应用服务中实现即可,这与三层架构相似.

  - ##### 数据传输对象(DTO)
    
    数据传输对象是一种用来传递参数的对象.

  - ##### 查询参数对象

    查询参数对象是一种专门用来传递查询参数的对象.

#### 表现层

### 微服务架构支持

Util 集成了 [Dapr](https://dapr.io/) ,它是微软主推的微服务框架.

Util 封装了 Dapr Http同步调用,异步事件发布订阅,状态存储等功能.

并对身份认证,事件日志,事件重发等重要功能进行扩展.

### 常见业务功能支持

#### 树形结构支持

有些数据包含层次结构.

Util 分层架构包含对树形结构的支持.

如果使用 Util UI,无论加载树形表格还是树形,继承基类即可实现功能.

#### 审计支持

大多操作需要记录创建人,创建时间,修改人,修改时间等审计信息.

Util支持保存时自动设置审计信息.

Util 审计设计参考自 [ABP](https://abp.io/) 应用框架.

#### 逻辑删除支持

Util 支持逻辑删除,删除时更新为已删除状态,查询时自动过滤已删除记录.

Util 逻辑删除设计参考自 [ABP](https://abp.io/) 应用框架.

#### 对象变更值支持

修改时可能需要获取对象哪些数据发生了变化.

Util 提供多种方式获取对象变更值记录.


## 代码生成

由于 Util 采用 DDD分层架构,导致简单需求也需要创建大量的类型.

手工创建这些类型效率低下,通过代码生成迅速创建它们,可以大幅提升开发效率和质量.

Util 配套代码生成器, 简单易用, 可解决大部分机械工作.

在生成的代码基础上进行修改,比从头开始工作要好得多.

## UI 技术选型

- ### Js语言
  - #### [TypeScript](https://www.typescriptlang.org/zh/)
    TypeScript 是 微软开发的脚本语言, 扩展了弱类型的 Javascript,提供增强的语法和强类型支持.
    
    为编辑器代码提示和语法错误检测奠定坚实基础.

- ### Js框架
  - #### [Angular](https://angular.io)

    Angular 是 Google开发的 Js框架.

    Angular使用 TypeScript 脚本语言开发, 并采用 [RxJs](https://github.com/ReactiveX/RxJS) 响应式编程框架.

    Angular 是前端Js三大框架之一,另外两个是 Vue 和 React.    

    Util UI 用于开发管理后台,选择 Angular 是因为它的语法最优雅, 也最符合后端开发人员的习惯.

- ### Angular 组件库

  - #### [Ng Zorro](https://ng.ant.design/)

    Ng Zorro 是阿里 Ant Design 的 Angular 版本,提供 80+ 常用组件,覆盖大部分业务开发场景.

  - #### [Ng Alain](https://ng-alain.com/)

    虽然 Ng Zorro 提供了大量常用组件,但项目开发需要一个集成度更高的环境.
    
    Ng Alain 是一个基架项目, 集成了 Ng Zorro 组件,提供业务开发的项目模板,除了菜单导航等框架元素,还有很多开箱即用的业务处理页面模板.

- ### Angular 微前端框架

  - #### [Angular Module Federation](https://github.com/angular-architects/module-federation-plugin)

    如果你的项目包含大量 Angular 模块,所有文件在同一个项目中,会导致开发环境卡顿和缓慢.

    发布项目也可能需要很长时间.

    另外,如果某个模块需要进行修改,哪怕只修改一行代码,也需要对所有模块重新发布.

    与后端的微服务类似,微前端是前端的项目拆分方法.

    微前端将不同的 Angular 模块拆分到不同项目中,可以独立开发,独立测试和独立部署.

    > 无论你是否使用微服务架构,均可使用微前端拆分方式.

    Angular Module Federation 是基于Webpack模块联合的Angular微前端解决方案.


## Util Angular UI 特点

- ### 组件扩展支持

  除了支持 Ng Zorro 原生功能外,Util UI还对常用组件进行了扩展.

  最重要的扩展是支持常用组件直接发出 Api 请求,而不用定义额外的服务.

- ### Razor TagHelper 支持
  
  Util Angular UI不仅可以使用 html 页面,还能使用 .Net Razor 页面.

  Razor 页面可以使用 TagHelper 服务端标签. 

  Util 已将大部分 Ng Zorro 组件封装为 TagHelper 标签.

  除了获得强类型提示外,TagHelper 作为抽象层,提供更简洁的标签语法.

  另一个强大之处在于Lambda表达式支持, 可以将DTO直接绑定到 TagHelper 标签上.

  能够从Lambda表达式提取元数据,并自动设置大量常用属性,比如name,验证,模型绑定等.

- ### 前后分离

  一些开发人员看到 Util Angular UI 使用 .Net Razor 页面,可能认为 UI 与 .Net 高度耦合,但现在的趋势是前后分离.

  所谓前后分离,是前端UI和后端API没有依赖,更换某一端对另一端没有影响.

  另外,前后分离后,前端UI和后端API可以由不同的开发人员完成.

  .Net Razor页面仅在开发阶段提供帮助,在发布时, Razor 页面会转换为 html ,后续发布流程与纯前端开发方式相同.

  一旦发布成功,将完全脱离.Net 环境,可以使用 Nginx 容器承载它.

  发布后的产物,与你使用纯前端方式开发打包没有区别.

  如果你喜欢,可以把后端API换成JAVA,也能正常运行.  

- ### 配套Api支持

  前端UI和后端API的开发是两个完全不同的领域.

  但开发一个功能,又需要前端和后端的配合,他们需要沟通,作出一些约定.

  对于配合不到位的团队,前后端的沟通成本可能很高,另外提供的API可能无法满足UI的需求,从而让前端代码变得畸形.

  通常.Net开发人员的Js编程功底高于常规前端人员,前端人员更擅长样式布局.

  Util Angular UI 不仅提供对前端组件的封装,同时也为常见功能提供 Api 支持. 

  对于使用 Util Angular UI 的团队, 将 UI 和 API 交给同一个.Net开发人员就是最好的选择.

  前端人员仅调整界面样式即可.

  不仅减少了沟通成本, API和前端组件的高度集成封装,让常规功能的开发效率得到大幅提升.

  当然,这对 .Net 开发人员的水平有一定要求.  

- ### 本地化支持

  得益于 Ng Alain 本地化的良好设计, 可以使用 i18n 管道进行文本的本地化转换.

  ```
  '文本' | i18n
  ```

  不过对于需要支持本地化的项目,这依然是一个负担,每个表单项,每个表格项,每个文本,可能都需要添加 i18n 管道.

  Util Angular UI 让本地化开发更进一步,对大部分组件提供了本地化支持,只有极少数文本需要手工添加 i18n 管道.

- ### 授权访问支持

  Ng Alain提供了授权访问的支持.

  Util Platform权限模块基于资源和角色的设计,可以很好的与 Ng Alain授权进行集成.

  你可以控制菜单和任意区域根据权限显示和隐藏.

- ### 微前端支持

  Util Angular UI 引入了 [Angular Module Federation](https://github.com/angular-architects/module-federation-plugin) , 能够将 Angular 模块拆分到不同项目中,可以独立开发,独立测试和独立部署.

  对于大中型项目,这是非常有必要的.


## Util Angular UI 功能列表

Util Angular UI 主要由 util-angular 和 Util.Ui.NgZorro 两个库提供支持.

  - ### util-angular 功能列表

    [util-angular](https://github.com/util-core/util-angular) 是一个 Js 库, 由Curd组件基类, Ng Zorro常用组件扩展指令和一组工具类组成.

    - #### 基础类型

      - ViewModel - 视图模型基类
      - TreeViewModel - 树形视图模型基类
      - TreeNode - 树形节点基类
      - PageList - 分页列表
      - QueryParameter - 查询参数基类
      - TreeQueryParameter - 树形查询参数基类
      - Result - 服务端返回结果
      - StateCode - 服务端状态码约定
      - SelectItem - 列表项
      - SelectList - 列表
      - SelectOptionGroup - 列表配置组
      - SelectOption - 列表配置项

    - #### 工具类

      - 浏览器本地存储操作
      - Cookie操作
      - 事件总线操作
      - 本地化操作
      - Ioc操作
      - 加载操作
      - 路由操作
      - 弹出层操作
      - 抽屉操作
      - 表单操作
      - Http操作
      - Web Api操作
      - 消息操作
      - ...

    - #### Crud组件基类

      - 编辑组件基类
      - 表格编辑组件基类
      - 树形编辑组件基类
      - 查询组件基类
      - 表格查询组件基类
      - 树形表格查询组件基类

    - #### Ng Zorro指令扩展

      - 必填项验证扩展指令
      - 验证消息扩展指令
      - Ng Zorro 按钮扩展指令
      - Ng Zorro 选择框扩展指令
      - Ng Zorro 表格扩展指令
      - Ng Zorro 表格编辑扩展指令
      - Ng Zorro 树形表格扩展指令
      - Ng Zorro 树形扩展指令
      - Ng Zorro 上传扩展指令

  - ### Util.Ui.NgZorro 库介绍
      
    Util.Ui.NgZorro 是一个 C# 类库,包含 TagHelper标签和树形控制器等类型.
    
    绝大部分 Ng Zorro 组件已经封装.
    
    由于组件很多,就不一一列出.

## Util Angular UI 已知缺陷

Util Angular UI 所有已知缺陷均已解决.

## Util Angular UI 适合你吗?

Util Angular UI 是为 .Net 全栈工程师准备的,如果你喜欢更简洁的语法,希望开发的成本更低,它就适合你.

## 参考应用框架

很明显,闭门造车不可取。

Util应用框架大部分依赖以Nuget方式引入,极少部分需要修改源码,则以复制源码方式使用。

另外,.Net应用框架还有很多优秀的开源项目,从中学习和吸取养分是Util成长的关键。

Util应用框架主要参考了以下开源项目,从中吸收架构和代码,并以Util风格进行整理。

- [ABP](https://abp.io/)

- [NopCommerce](https://www.nopcommerce.com) 

- [Csla](https://cslanet.com/)

## Util应用框架相关资源

### Util教程目录

- 知乎: <https://zhuanlan.zhihu.com/p/663947596>

- 掘金: <https://juejin.cn/post/7298765809290477607>

### Github项目地址

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

### Gitee项目地址

**由于国内访问Github非常缓慢,现在Util所有项目发布时会在Gitee进行同步更新。**

- **Util** <https://gitee.com/util-core/util>
- **Util.Generator** <https://gitee.com/util-core/Util.Generator>
- **util-angular** <https://gitee.com/util-core/util-angular>
- **Util.Platform.Single** <https://gitee.com/util-core/Util.Platform.Single>
- **Util.Platform.Dapr** <https://gitee.com/util-core/Util.Platform.Dapr>
- **Util.Platform.Share** <https://gitee.com/util-core/Util.Platform.Share>

### Nuget包

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
| Util.FileStorage.Abstractions | ![](https://img.shields.io/nuget/v/Util.FileStorage.Abstractions.svg) | ![](https://img.shields.io/nuget/dt/Util.FileStorage.Abstractions.svg)
| Util.FileStorage | ![](https://img.shields.io/nuget/v/Util.FileStorage.svg) | ![](https://img.shields.io/nuget/dt/Util.FileStorage.svg)
| Util.FileStorage.Minio | ![](https://img.shields.io/nuget/v/Util.FileStorage.Minio.svg) | ![](https://img.shields.io/nuget/dt/Util.FileStorage.Minio.svg)
| Util.FileStorage.Aliyun | ![](https://img.shields.io/nuget/v/Util.FileStorage.Aliyun.svg) | ![](https://img.shields.io/nuget/dt/Util.FileStorage.Aliyun.svg)
| Util.FileStorage.All | ![](https://img.shields.io/nuget/v/Util.FileStorage.All.svg) | ![](https://img.shields.io/nuget/dt/Util.FileStorage.All.svg)
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

### Npm包

**util-angular** 
[![npm package](https://img.shields.io/npm/v/util-angular.svg?style=flat-square)](https://www.npmjs.org/package/util-angular) 
[![NPM downloads](http://img.shields.io/npm/dm/util-angular.svg?style=flat-square)](https://npmjs.org/package/util-angular)