using System;
using System.Collections.Generic;
using System.Diagnostics;
using Util.Data.Metadata;
using Util.Dependency;
using Util.Generators.Configuration;
using Util.Generators.Contexts;
using Util.Generators.Resources;
using Util.Generators.Templates;

namespace Util.Generators.Logs {
    /// <summary>
    /// 生成器日志操作
    /// </summary>
    public interface IGeneratorLogger : ITransientDependency {
        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="exception">异常</param>
        void LogException( Exception exception );
        /// <summary>
        /// 打印生成器配置
        /// </summary>
        void LogOptions( GeneratorOptions options );
        /// <summary>
        /// 开始构建生成器上下文
        /// </summary>
        void BeginBuildContext();
        /// <summary>
        /// 打印生成器上下文基础信息
        /// </summary>
        /// <param name="context">生成器上下文</param>
        void LogGeneratorContextBaseInfo( GeneratorContext context );
        /// <summary>
        /// 开始构建生成器项目上下文
        /// </summary>
        /// <param name="project">项目</param>
        void BeginBuildProjectContext( string project );
        /// <summary>
        /// 开始获取数据库元数据
        /// </summary>
        /// <param name="projectOptions">项目配置</param>
        void BeginGetDbMetadata( ProjectOptions projectOptions );
        /// <summary>
        /// 获取数据库元数据完成
        /// </summary>
        /// <param name="info">数据库信息</param>
        void EndGetDbMetadata( DatabaseInfo info );
        /// <summary>
        /// 构建生成器项目上下文完成
        /// </summary>
        /// <param name="context">项目上下文</param>
        void EndProjectContext( ProjectContext context );
        /// <summary>
        /// 开始获取模板列表
        /// </summary>
        /// <param name="project">项目</param>
        /// <param name="templateRootPath">模板根路径</param>
        void BeginGeTemplates( string project, string templateRootPath );
        /// <summary>
        /// 获取模板列表完成
        /// </summary>
        /// <param name="project">项目</param>
        /// <param name="templates">模板列表</param>
        void EndGeTemplates( string project, List<ITemplate> templates );
        /// <summary>
        /// 过滤模板
        /// </summary>
        /// <param name="path">模板路径</param>
        void FilterTemplate( string path );
        /// <summary>
        /// 开始生成项目代码
        /// </summary>
        /// <param name="project">项目</param>
        void BeginGenerateProject( string project );
        /// <summary>
        /// 禁用项目代码
        /// </summary>
        /// <param name="project">项目</param>
        void DisableProject( string project );
        /// <summary>
        /// 开始生成实体代码
        /// </summary>
        /// <param name="entity">实体上下文</param>
        void BeginGenerateEntity( EntityContext entity );
        /// <summary>
        /// 跳过关联表实体
        /// </summary>
        /// <param name="entity">实体上下文</param>
        void SkipRelationTable( EntityContext entity );
        /// <summary>
        /// 渲染模板
        /// </summary>
        /// <param name="entity">实体上下文</param>
        /// <param name="template">模板</param>
        public void RenderTemplate( EntityContext entity, ITemplate template );
        /// <summary>
        /// 生成实体代码完成
        /// </summary>
        /// <param name="entity">实体上下文</param>
        void EndGenerateEntity( EntityContext entity );
        /// <summary>
        /// 过滤资源
        /// </summary>
        /// <param name="path">资源路径</param>
        void FilterResource( string path );
        /// <summary>
        /// 开始导入资源
        /// </summary>
        /// <param name="templateRootPath">模板根目录路径</param>
        /// <param name="outputRootPath">输出根目录路径</param>
        /// <param name="project">项目名称</param>
        /// <param name="resource">资源</param>
        void ImportResource( string templateRootPath, string outputRootPath, string project, Resource resource );
        /// <summary>
        /// 开始导入目录
        /// </summary>
        /// <param name="templateRootPath">模板根目录路径</param>
        /// <param name="outputRootPath">输出根目录路径</param>
        /// <param name="project">项目名称</param>
        /// <param name="from">资源路径</param>
        /// <param name="to">目标路径</param>
        void ImportDirectory( string templateRootPath, string outputRootPath, string project, string from, string to );
        /// <summary>
        /// 开始导入文件
        /// </summary>
        /// <param name="sourceFile">源文件路径</param>
        /// <param name="destFile">目标文件路径</param>
        void BeginImportFile( string sourceFile, string destFile );
        /// <summary>
        /// 导入文件完成
        /// </summary>
        /// <param name="sourceFile">源文件路径</param>
        /// <param name="destFile">目标文件路径</param>
        void EndImportFile( string sourceFile, string destFile );
        /// <summary>
        /// 生成项目代码完成
        /// </summary>
        /// <param name="project">项目</param>
        void EndGenerateProject( string project );
        /// <summary>
        /// 生成完成
        /// </summary>
        /// <param name="stopwatch">计时器</param>
        void EndGenerate( Stopwatch stopwatch );
    }
}
