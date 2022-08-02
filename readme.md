# Util应用框架介绍

[![Member project of .NET Core Community](https://img.shields.io/badge/member%20project%20of-NCC-9e20c9.svg)](https://github.com/dotnetcore)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://mit-license.org/)

<a href="https://www.jetbrains.com/?from=Util" target="_blank">
    <img src="https://github.com/dotnetcore/Home/blob/master/img/jetbrains.svg" title="JetBrains" />
</a>

Util是一个.net core平台下的应用框架，旨在提升小型团队的开发输出能力，由常用公共操作类(工具类)、分层架构基类、Ui组件，第三方组件封装，第三方业务接口封装，配套代码生成模板，权限等组成。

## 引子

几年前我在博客园写了一个 [应用程序框架实战](https://www.cnblogs.com/xiadao521) 的系列文章，受到不少.net同学的青睐，不过由于种种原因（想写的范围过大，技术更新过快，工作忙，人越来越懒，好吧，我承认主要是最后一点）而烂尾。

我在博客中放出过一些示例代码，由于未正式开源，修复过的bug也未能更新，所以将博客中提供的示例项目都删除了。

一些同学将这些代码应用在项目上，当碰到问题时，由于没有技术支持，也没有相关教程，苦不堪言。而另外一些同学没有下载到示例项目。

虽然博客断更2年，但时常有同学通过加QQ或发EMAIL的方式联系我，希望能够得到最新代码，并对用法和设计思路进行讲解。

.net core发展迅猛，它为.net提供了更广阔的竞争力，同时也意味着新一轮的学习与代码移植工作开始，我也在这个大潮中跌跌撞撞的摸索着。

几位好友（[AlexLEWIS](https://github.com/alexinea "刘怡") [Kiler](https://github.com/kiler398 "谢炀") [Lemon](https://github.com/liuhaoyang "刘浩杨") ）发起了.net core学习小组，并打算为国内.net core开源大业作出贡献，我果断加入了队伍进行学习，并决定对Util应用框架进行开源。

经讨论，大家决定将各自的开源项目统一发布到 [.NET Core Community](https://github.com/dotnetcore) 之下，以方便国内.net core开源项目的推广，同时也欢迎国内.net core开源项目作者的加入。

## 技术框架与应用框架

框架是一种可复用的基础代码库，如果它只解决纯技术问题，可以认为是技术框架，如果它与你的业务相关，则可认为是应用框架（框架，应用框架均没有标准定义，我在此以个人理解描述术语含义，以方便后续讨论，并非权威定义）。

.net提供的基础类库是最基础的技术框架，它提供了进行.net开发所需要的基础API，这些API都比较原始。完全使用原始API进行项目开发，会导致高昂的学习成本，更多的Bug，难以维护的重复代码，低效的开发进度。

为了完成某项特定的技术需求，比如写日志，你可以使用原始API进行简单实现，并在多个地方复制粘贴进行调用。这很快会让你厌烦，除了冗余代码以外，你发现还需要经常扩展日志操作的功能，于是你想把日志操作封装成库来调用。

等等，不要再重复造轮子了(为了学习目的造轮子，这绝对是值得肯定的，但确实准备拿来使用的，如果不是真有几把刷子，建议还是省省吧)，一些前辈已经做了这些基础工作，并且他们的工作已经在全球大范围的使用，非常成熟，并且持续维护。

这些能够解决特定技术问题的类库暂时统称为第三方技术框架,在项目上使用第三方技术框架是项目成功的必要保障。从此，你不再为如何实现某项技术问题而烦恼，也不需要为持续扩展的技术需求而疲于奔命，更多的精力被用在业务上，这才是你应该干的事。

对于你的项目，每当碰到某种技术障碍时，你会四处打听有没有某个第三方技术框架解决了你的问题，找到以后，你通过调试一些Demo代码，简单的用起来了。每当需要这个功能的时候，你会从以前的代码复制粘贴，由于第三方技术框架已经高度封装，所以冗余代码不是特别显著，你没有理会它。

如果你的团队并不经常沟通，处理同一问题的过程将在团队中反复发生，这将导致对于某个问题的技术实现不一致，并且付出高昂的学习成本。当调用代码被大量的复制粘贴后，如果发现调用代码有Bug，或需要增加一些健壮性，你才意识到虽然第三方技术框架已经比较完善，但对它的调用依然有封装的必要。

你开始封装一些经常需要操作的代码，这些代码可能是用.net原始Api封装的，也可能是封装了第三方技术框架的调用，这些封装好的代码被称为公共操作类，也叫工具类。

对于最基础的Crud和业务代码的结构，你发现也可以抽取出来，形成分层架构基类。

你的项目可能需要在网页上进行开发，采用原始的html,css,js技术，将面临界面美观，浏览器兼容性,开发效率低下等问题，有第三方技术框架提供了相关的解决方案，比如EasyUi,Bootstrap,Angularjs,ReactJs等。将第三方UI框架集成并封装起来，能够显著提升开发效率。

如果在项目中，你需要实现支付等业务功能，你可以对这些第三方业务接口进行封装。

对于常规的项目，总是需要一些通用模块，比如权限，将它作为后续项目的起点是一个好主意。

当这些基础代码被高度封装后，常规的Crud代码变得非常简洁，但你还是需要复制这些基础结构，通过反复整理，可以得到一个代码模板，通过代码生成工具将基础的Crud代码生成出来，可以大幅提升生产力。

这个持续封装过程演变为一套项目开发模式，支持这套模式的所有基础代码库，我将它称之为应用框架。

应用框架为你项目的所有方面提供支持，你需要不断的完善它。由于应用框架需要解决你项目上的所有问题，所以没有绝对通用和包罗万象的应用框架，你必须在这些应用框架之上进行扩展。

## Util的由来

Util是我在.net开发生涯中不断积累而成的一套应用框架，最初的名字叫CommonUtilities，这是一个基本由公共操作类构成的类库。

随着经验和水平的上升，我根据自己的习惯，逐步实现了经典图书中某些概念（比如规约），并吸收了一些流行应用框架( 比如 [ABP](https://github.com/aspnetboilerplate/aspnetboilerplate) [Nop](https://www.nopcommerce.com) )的部分代码。

Util并不是一个完善的应用框架，我总是根据自己项目上的需求来扩展它，所以它基本只是为了满足我个人习惯和项目的产物。

由于技术更新异常迅速，多年来大量的代码被持续重构，还有更多的代码被抛弃，这也是Util不完善的一个重要原因。

发布Util的目的，是希望帮助技术还比较落后的.net小型团队能够搭建出自己的应用框架，提供一个示范，同时也希望它成为跟我有相似开发习惯和偏好的.net同学的重要工具。

## 愿景

让开发更简单

## 承诺

不必担心再次断更，代码会持续更新，使用文档将由Util核心开发团队成员编写，我会补充一些设计方面的文档上来。

## 特点

**简单易用**的傻瓜式API设计，让你的团队能够快速上手进行开发。对于简单操作，通常采用静态方法或扩展方法进行调用，对于更加复杂的操作，尽量封装为链式API。

**强类型（*静态类型*）** 化风格，将UI组件封装为asp.net core razor组件，充分发挥VS开发工具的优势，比如智能提示，编译时检查。

**代码整洁**，Util开发小组成员都有着代码洁癖，每行代码都经过反复斟酌。

地道的**中国味**，Util开发小组成员的英文水平比较菜，命名充满国风，并以中文注释进行补充。

## 面向群体

Util应用框架面向的是*架构初学者*，但不是.net初学者。

如果你是.Net初学者，基本的Crud（增删改查）尚且完成不了，请缓一年再来。

你可能已经有了一些项目经验，甚至已经开发多年，但你的项目依然进度缓慢，很难按时交付，代码质量糟糕，难以继续维护，你迫切希望找到一种方法来改善这个过程，Util就是为你准备的。

如果你手里没有任何积累，Util将是你搭建自己框架的一个很好的起点。

如果你已经身经百战，自己的框架也比较成熟，Util对你的帮助不会太大。

如果你对API的英文语法要求很高，Util可能无法达到你的要求，请自行修改命名或远离它。

## 使用方式

我推荐的方式是搭建你自己的应用框架，逐步吸收Util和其它应用框架的代码，但这需要你投入大量的学习时间。

我会逐步更新框架代码，当时机成熟时，将提供一个示例应用程序供大家参考。

在把框架完全应用到你的项目之前，你的团队至少要有一名成员能够根据项目需求进行扩展。对于懒汉，通常希望拿到一套干货，直接在项目上当成黑盒来使用，除非你的项目异常简单，否则这种方式不可取。

对于简单的操作，你可以运行和阅读相应单元测试代码，即可了解它们如何使用。对于复杂操作，一方面看单元测试，另外我们会编写相关文档以描述调用方式和工作机制。

## 开发环境及类库依赖

以下是我们在项目开发和部署时使用的工具和组件，这个列表会经常更新。

> 如果没有标注版本号，则采用最新版本。

1. 开发工具： 
  - Visual Studio 2017
  - [Resharper](https://www.jetbrains.com/resharper/)

2. 数据库
  - Sql Server
  - Mysql
  - PostgreSQL

3. 设计工具
  - PowerDesigner 16.5
  - XMind

4. 版本控制
  - Git

5. 部署环境
  - Ubuntu Server
  - Docker

6. SDK及Runtime
  - 当前SDK 64位版本：[Sdk v2.2.104](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.104-windows-x64-installer)，开发机器安装
  - 当前Runtime 64位版本：[Runtime v2.2.2](https://dotnet.microsoft.com/download/thank-you/dotnet-runtime-2.2.2-windows-hosting-bundle-installer)，服务器安装

7. 单元测试及模拟框架
  - XUnit
  - NSubstitute

8. 数据访问框架
  - [EntityFrameworkCore](https://docs.microsoft.com/zh-cn/ef/core/)
  - [Dapper](https://github.com/StackExchange/Dapper)

9. Ioc框架
  - Autofac

10. Aop框架
  - [AspectCore](https://github.com/dotnetcore/AspectCore-Framework)

11. Json框架
  - Json.Net

12. 映射框架
  - AutoMapper

13. 日志框架
  - [NLog](http://nlog-project.org/)
  - [Exceptionless](https://github.com/exceptionless)

14. 缓存
  - [EasyCaching](https://github.com/dotnetcore/EasyCaching)

15. 事件总线
  - [CAP](https://github.com/dotnetcore/CAP)

16. Id生成器
  - [ECommon.Utilities.ObjectId](https://github.com/tangxuehua/ecommon/blob/master/src/ECommon/Utilities/ObjectId.cs)

17. RSA加密算法
  - [DotnetCore.RSA](https://github.com/stulzq/DotnetCore.RSA/blob/master/DotnetCore.RSA/RSAHelper.cs)

18. 二维码操作
  - [QRCoder](https://github.com/codebude/QRCoder/)

19. 短信操作
  - [Luosimao](https://luosimao.com/)

20. Queryable动态扩展
  - [System.Linq.Dynamic.Core](https://github.com/StefH/System.Linq.Dynamic.Core)

21. Web框架
  - [Asp.Net Core](https://docs.microsoft.com/zh-cn/aspnet/core/)

22. 定时任务调度框架
  - [Quartz.Net](https://www.quartz-scheduler.net/)

23. UI
  - 脚本语言
    - [TypeScript](https://www.tslang.cn)
  - 脚本框架
    - [Angular 7](https://angular.cn/)
  - Css预处理器
    - [Less](http://lesscss.org)
    - [Sass](http://www.sass-lang.com)
  - 组件库
    - [Angular Material](https://material.angular.io/)
    - [PrimeNg](https://www.primefaces.org/primeng)
    - [Ng-Zorro](https://ng.ant.design)
    - [Ng-Alain](https://ng-alain.github.io/ng-alain/)
  - 编辑器
    - [CKEditor](https://ckeditor.com/ckeditor-4/)
    - [Ng2-CKEditor](https://github.com/chymz/ng2-ckeditor)    
  - 脚本库
    - [Lodash](https://lodash.com/)
    - [Moment](http://momentjs.cn/)
  - 图标
    - [Material Design Icon](https://material.io/icons/)
    - [Font Awesome Icon](http://fontawesome.io/)
    - [Ant Design Icon](https://ant.design/components/icon/)    
  - 图表
    - [Viser](https://viserjs.github.io/)
    - [Antv-G2](https://antv.alipay.com/zh-cn/g2/3.x/index.html)
  - 打包
    - Webpack
  - 测试
    - Karma
    - Jasmine

24. 权限
    - [Asp Net Core Identity](https://docs.microsoft.com/zh-cn/aspnet/core/security/authentication/identity?tabs=visual-studio%2Caspnetcore2x)
    - [Identity Server](https://identityserver4.readthedocs.io/en/latest/)

25. 代码生成器
  - CodeSmith 6.5

26. 参考应用框架
  - [ABP](http://aspnetboilerplate.com/)
  - [Nop](https://www.nopcommerce.com) 
    - Nop是一个开源商城，封装了大量实用的基础代码。

## 框架开发流程

  > *搜集* - *整理* - *集成* - *封装*

每当发现框架无法满足项目中的需求时，扩展的时刻来临。

从头造轮子是下策，所以总是先四处**搜集**相关资料。对于简单的需求，可能只需要找到一些代码片断即可。对于更专业的问题，比如将对象转换为json字符串，需要寻求第三方技术框架的帮助。

找到解决方案并调试通过后，需要对代码进行**整理**，以符合我们的编程风格。

对于像autofac这样的类库，只需要nuget引用一下就完事，但对于UI层面的框架，需要进行更复杂的**集成**才能工作，我们可能还会修改一些源码以方便后续扩展。

最后，为了达到复用的目的，需要仔细考虑如何**封装**才能让调用者最省力。

> 前几年，我喜欢把第三方技术框架的源码放到我的类库中，那是因为nuget经常连接失败，不过现在nuget比较稳定了，并且对包的嵌套引用支持得很好，所以不再采用山寨方式。

> 任何有技术含量的工作，均由第三方技术框架完成，Util应用框架仅对技术框架选型并集成封装。Util只是很薄的一层外观，为复杂的技术框架提供一个简易视图。这导致更健壮的实现和更易用的API。

## 项目开发流程

一套得心应手的应用框架，能让你的团队如虎添翼，开发效率和开发质量将同时提升N倍，这在拥有应用框架的公司已经是不争的事实。

那是不是意味着，只要下载到一套应用框架，你的团队马上就能脱胎换骨呢？ 非也，梅花香自苦寒来，宝剑锋从磨砺出，路漫漫其修远兮，你将上下而求索。

任何应用框架都属于辅助设施，能否高效完成项目，还是靠你团队本身的水平。要高效完成项目，需要对技术、架构、过程等方面达到一定认识，这是一个漫长的学习过程。我会为你分享一些项目开发流程上的经验，并提供一份经典图书的清单。

对于普通的项目，大体由简单的基础管理模块和较复杂的业务模块构成。

基础管理模块表现为Crud操作加上一些简单业务逻辑，它们的特点是功能简单但数量众多，解决它们的有效手段是代码生成器，由生成器生成全套代码（包括管理后台的UI代码），然后在这个基础上手工修改。

对于复杂的业务模块，它们往往由权限（操作权限与数据权限）、流程控制、复杂的计算、绕脑的策略等问题交织在一起，解决它们的有效手段是DDD（领域驱动设计），TDD(测试驱动开发)，设计模式。

> 遗憾的是，听过这些名词的部分开发人员，由于没有真正实践，还在道听途说的质疑这些方法的有效性，或是用这些方法来开发Crud操作，用大炮打蚊子，没用对地方反而质疑方法的作用。

对于权限，目前发现最通用，最简单，最易理解的方法是基于*资源*和*角色*的权限设计。操作权限是通用的，但数据权限太灵活，目前我们配合规约模式来解决。

由于项目开发流程是一个很大的主题，我会用专门的文章来进行介绍，以抛砖引玉。

## 作者

何镇汐

## 核心开发团队

[何镇汐](https://github.com/utilcore) [玄冰](https://github.com/jianxuanbing "简楚恩") [青成](https://github.com/nilpower "张青成")  [程序喵](https://github.com/program-meow "胡雲鹏") [叶铭](ym8290321@163.com "叶铭")

应用框架的开发工作量很大，个人显得力不从心，我也迫切希望找到一些志同道合的同学共同完成，同时也欢迎你的加入。

对于Util核心开发团队成员，需要至少独立完成Util中的一个模块（比如微信公众号接口封装），并持续维护它。

> 为了保持代码风格的统一，Util核心开发团队必须以统一的编码规范提交代码，在必要的时候，我会对代码进行重构。

## 技术顾问团队

[AlexLEWIS](https://github.com/alexinea "刘怡") [Kiler](https://github.com/kiler398 "谢炀") [Lemon](https://github.com/liuhaoyang "刘浩杨") [Savorboard](https://github.com/yang-xiaodong "杨晓东") [Lyrics](https://github.com/lyricsyo "娄宇")

Util应用框架技术顾问团队负责对API易用性，代码健壮性，设计缺陷等内容进行审查，在发现问题时提出改善意见。

> 如果您是一名资深.net开发专家，并希望为Util应用框架出谋划策，欢迎加入Util应用框架技术顾问团队。

## 贡献与反馈

> 如果你在阅读或使用发现Bug，或有更佳实现方式，请通知我们。

> 为了保持代码简单，目前很多功能只建立了基本结构，细节特性未进行迁移，在后续需要时进行添加，如果你发现某个类无法满足你的需求，请通知我们。

> 你可以通过github的Issue或Pull Request向我们提交问题和代码，如果你更喜欢使用QQ进行交流，请加入我们的交流QQ群。

> 对于你提交的代码，如果我们决定采纳，可能会进行相应重构，以统一代码风格。

> 对于热心的同学，将会把你的名字放到**贡献者**名单中。

## 贡献者

## 交流方式与技术支持

  当你在使用Util进行开发时，倘若碰到无法解决的问题，可以加群讨论，Util团队会尽力帮助你度过难关。

  - Util应用框架交流QQ群(一群)：24791014

  > 不论是Util应用框架的代码，还是交流活动都是免费的，所以你不能指望我们必须在短时间内响应你，同时也希望大家都保持开放的心态，为初学者提供一些便利。

  > 对于一些伸手党，本来百度3分钟就可以解决的问题，却四处找人问，对于这些家伙，我建议你们转JAVA。

## 免责申明

- 虽然我们对代码已经进行高度审查，并用于自己的项目中，但依然可能存在某些未知的BUG，如果你的生产系统蒙受损失，Util团队不会对此负责。

- 出于成本的考虑，我们不会对已发布的API保持兼容，每当更新代码时，请注意该问题。

## 开源地址

https://github.com/dotnetcore/util/

## License

**MIT**

> 这意味着你可以在任意场景下使用Util应用框架而不会有人找你要钱。

> Util会尽量引入开源免费的第三方技术框架，如有意外，还请自行了解。 

## 书单

> 本清单会持续更新

- 面向对象
  - 《UML和模式应用》 作者：Craig Larman
  - 《面向对象分析与设计》 作者：Grady Booch

- 架构模式
  - 《企业应用架构模式》 作者：Martin Fowler
  - 《领域驱动设计》 作者：Eric Evans
  - 《敏捷软件开发-原则、模式与实战》 作者：Robert C.Martin
  - 《实现领域驱动设计》 作者：Vaughn Vernon

- 设计模式
  - 《设计模式》 作者：Erich Gamma
  - 《Head First设计模式》 作者：Eric Freeman

- TDD
  - 《测试驱动开发》 作者：Kent Beck
  - 《测试驱动开发的艺术》 作者：Lasse Koskela
  - 《单元测试的艺术》 作者：Roy Osherove
  - 《重构-改善既有代码的设计》 作者：Martin Fowler
  - 《实现模式》 作者：Kent Beck
  - 《代码整洁之道-Clean Code》 作者：Robert C.Martin
  - 《重构与模式》 作者：Joshua Kerievsky
