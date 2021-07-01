using System.Collections.Generic;
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
        public string SolutionFileName { get; set; } = "Util.sln";
        /// <summary>
        /// 构建配置
        /// </summary>
        [BuildConfiguration]
        public string BuildConfiguration { get; set; } = "Release";
        /// <summary>
        /// 源代码目录
        /// </summary>
        public FullPath SourceDir => RootDirectory.CombineWith( "src" );
        /// <summary>
        /// 源代码目录
        /// </summary>
        public FullPath TestDir => RootDirectory.CombineWith( "test" );
        /// <summary>
        /// 输出目录
        /// </summary>
        public FullPath OutputDir => RootDirectory.CombineWith( "output" );
        /// <summary>
        /// 项目文件列表
        /// </summary>
        public List<FileFullPath> ProjectFiles { get; set; }
        /// <summary>
        /// 测试项目文件列表
        /// </summary>
        public List<FileFullPath> TestProjectFiles { get; set; }

        /// <summary>
        /// 构建前操作
        /// </summary>
        /// <param name="context">构建任务上下文</param>
        protected override void BeforeBuildExecution( ITaskContext context ) {
            ProjectFiles = context.GetFiles( SourceDir, "*/*.csproj" );
            TestProjectFiles = context.GetFiles( TestDir, "*/*.csproj" );
        }

        /// <summary>
        /// 配置构建目标
        /// </summary>
        /// <param name="context">构建任务上下文</param>
        protected override void ConfigureTargets( ITaskContext context ) {
            var clean = CreateCleanTarget( context );
            var restore = CreateRestoreTarget( context, clean );
            var build = CreateBuildTarget( context, restore );
            var test = CreateTestTarget( context );
        }

        /// <summary>
        /// 创建清理步骤
        /// </summary>
        private ITarget CreateCleanTarget( ITaskContext context ) {
            return context.CreateTarget( "Clean" )
                .SetDescription( "Clean the solution." )
                .AddCoreTask( t => t.Clean().Configuration( "Debug" ).CleanOutputDir() )
                .AddCoreTask( t => t.Clean().Configuration( "Release" ).CleanOutputDir() );
        }

        /// <summary>
        /// 创建包还原步骤
        /// </summary>
        private ITarget CreateRestoreTarget( ITaskContext context, ITarget target ) {
            return context.CreateTarget( "Restore" )
                .SetDescription( "Restore the solution." )
                .DependsOn( target )
                .AddCoreTask( t => t.Restore() );
        }

        /// <summary>
        /// 创建构建步骤
        /// </summary>
        private ITarget CreateBuildTarget( ITaskContext context, ITarget target ) {
            return context.CreateTarget( "Build" )
                .SetDescription( "Build the solution." )
                .DependsOn( target )
                .AddCoreTask( t => t.Build() );
        }

        /// <summary>
        /// 创建测试步骤
        /// </summary>
        private ITarget CreateTestTarget( ITaskContext context ) {
            return context.CreateTarget( "Test" )
                .SetDescription( "Run all tests." )
                .ForEach( TestProjectFiles, ( project, target ) => {
                    target.AddCoreTask( t => t.Test().Project( project ) );
                } );
        }
    }
}