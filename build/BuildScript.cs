using System;
using System.Collections.Generic;
using System.IO;
using FlubuCore.Context;
using FlubuCore.Context.Attributes.BuildProperties;
using FlubuCore.Context.FluentInterface.Interfaces;
using FlubuCore.IO;
using FlubuCore.Scripting;

namespace Build {
    /// <summary>
    /// 构建脚本
    /// </summary>
    public class BuildScript : DefaultBuildScript {
        /// <summary>
        /// 解决方案文件名
        /// </summary>
        [SolutionFileName]
        public string SolutionFileName { get; set; } = "../Util.sln";
        /// <summary>
        /// 构建配置
        /// </summary>
        [FromArg( "c|configuration" )]
        [BuildConfiguration]
        public string BuildConfiguration { get; set; } = "Release";
        /// <summary>
        /// Nuget推送地址
        /// </summary>
        [FromArg( "nugetUrl" )]
        public string NugetUrl { get; set; } = "https://api.nuget.org/v3/index.json";
        /// <summary>
        /// Nuget密钥
        /// </summary>
        [FromArg( "nugetKey", "Nuget api key for publishing nuget packages." )]
        public string NugetApiKey { get; set; }
        /// <summary>
        /// 源代码目录
        /// </summary>
        public FullPath SourceDir => RootDirectory.CombineWith( "../src" );
        /// <summary>
        /// 源代码目录
        /// </summary>
        public FullPath TestDir => RootDirectory.CombineWith( "../test" );
        /// <summary>
        /// 输出目录
        /// </summary>
        public FullPath OutputDir => RootDirectory.CombineWith( "../output" );
        /// <summary>
        /// 项目文件列表
        /// </summary>
        public List<FileFullPath> Projects { get; set; }
        /// <summary>
        /// 测试项目文件列表
        /// </summary>
        public List<FileFullPath> TestProjecs { get; set; }

        /// <summary>
        /// 构建前操作
        /// </summary>
        /// <param name="context">构建任务上下文</param>
        protected override void BeforeBuildExecution( ITaskContext context ) {
            Projects = context.GetFiles( SourceDir, "*/*.csproj" );
            TestProjecs = context.GetFiles( TestDir, "*/*.csproj" );
        }

        /// <summary>
        /// 配置构建目标
        /// </summary>
        /// <param name="context">构建任务上下文</param>
        protected override void ConfigureTargets( ITaskContext context ) {
            var clean = Clean( context );
            var restore = Restore( context, clean );
            var build = Build( context, restore );
            var pack = Pack( context, clean );
            PublishNuGetPackage( context, pack );
            Test( context );
        }

        /// <summary>
        /// 清理解决方案
        /// </summary>
        private ITarget Clean( ITaskContext context ) {
            return context.CreateTarget( "clean" )
                .SetDescription( "Clean the solution." )
                .AddCoreTask( t => t.Clean().AddDirectoryToClean( OutputDir, false ) );
        }

        /// <summary>
        /// 还原包
        /// </summary>
        private ITarget Restore( ITaskContext context, ITarget target ) {
            return context.CreateTarget( "restore" )
                .SetDescription( "Restore the solution." )
                .DependsOn( target )
                .AddCoreTask( t => t.Restore() );
        }

        /// <summary>
        /// 编译解决方案
        /// </summary>
        private ITarget Build( ITaskContext context, ITarget target ) {
            return context.CreateTarget( "compile" )
                .SetDescription( "Compiles the solution." )
                .DependsOn( target )
                .AddCoreTask( t => t.Build() );
        }

        /// <summary>
        /// 创建nuget包
        /// </summary>
        private ITarget Pack( ITaskContext context, ITarget dependTarget ) {
            return context.CreateTarget( "pack" )
                .SetDescription( "Create nuget packages." )
                .DependsOn( dependTarget )
                .ForEach( Projects, ( project, target ) => {
                    target.AddCoreTask( t => t.Pack()
                        .Project( project )
                        .IncludeSymbols()
                        .OutputDirectory( OutputDir ) );
                } );
        }

        /// <summary>
        /// 发布nuget包
        /// </summary>
        private void PublishNuGetPackage( ITaskContext context, ITarget dependTarget ) {
            context.CreateTarget( "nuget.publish" )
                .SetDescription( "Publishes nuget packages" )
                .DependsOn( dependTarget )
                .Do( t => {
                    var packages = Directory.GetFiles( OutputDir, "*.nupkg" );
                    foreach ( var package in packages ) {
                        if( package.EndsWith( "symbols.nupkg", StringComparison.OrdinalIgnoreCase ) )
                            continue;
                        context.CoreTasks().NugetPush( package )
                            .DoNotFailOnError( ex => { Console.WriteLine( $"Failed to publish {package}.exception: {ex.Message}" ); } )
                            .ServerUrl( NugetUrl )
                            .ApiKey( NugetApiKey )
                            .Execute( context );
                    }
                } );
        }

        /// <summary>
        /// 运行测试
        /// </summary>
        private void Test( ITaskContext context ) {
            context.CreateTarget( "test" )
                .SetDescription( "Run all tests." )
                .ForEach( TestProjecs, ( project, target ) => {
                    target.AddCoreTask( t => t.Test().Project( project ) );
                } );
        }
    }
}