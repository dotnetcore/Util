using System;
using System.Collections.Generic;
using System.Diagnostics;
using Util.Data.Metadata;
using Util.Generators.Configuration;
using Util.Generators.Contexts;
using Util.Generators.Resources;
using Util.Generators.Templates;
using Util.Logging;

namespace Util.Generators.Logs {
    /// <summary>
    /// 生成器日志操作
    /// </summary>
    public class GeneratorLogger : IGeneratorLogger {
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog<Generator> _logger;

        /// <summary>
        /// 初始化生成器日志操作
        /// </summary>
        /// <param name="logger">日志</param>
        public GeneratorLogger( ILog<Generator> logger ) {
            _logger = logger ?? Log<Generator>.Null;
        }

        /// <inheritdoc />
        public void LogException( Exception exception ) {
            _logger.Exception( exception ).LogError();
        }

        /// <inheritdoc />
        public void LogOptions( GeneratorOptions options ) {
            _logger.AppendLine( "读取生成器配置:" )
                .AppendLine( $"   模板根路径: {options.TemplatePath}," )
                .AppendLine( $"   输出根路径: {options.OutputPath}," )
                .AppendLine( $"   消息配置:" )
                .AppendLine( $"       必填项消息: {options.Messages.RequiredMessage}" )
                .AppendLine( $"       最大长度消息: {options.Messages.MaxLengthMessage}" )
                .AppendLine( $"   项目配置:" );
            foreach ( var project in options.Projects.Values ) {
                _logger.AppendLine( $"       项目名称: {project.Name}" )
                    .AppendLine( $"           数据库类型: {project.DbType}" )
                    .AppendLine( $"           目标数据库类型: {project.TargetDbType}" )
                    .AppendLine( $"           数据库连接字符串: {project.ConnectionString}" )
                    .AppendLine( $"           工作单元名称: {project.UnitOfWorkName}" )
                    .AppendLine( $"           是否启用: {project.Enabled.Description()}" );
            }
            _logger.LogDebug();
        }

        /// <inheritdoc />
        public void BeginBuildContext() {
            _logger.Message( "开始构建生成器上下文" ).LogDebug();
        }

        /// <inheritdoc />
        public void LogGeneratorContextBaseInfo( GeneratorContext context ) {
            _logger.AppendLine( "生成器上下文基础信息:" )
                .AppendLine( $"   模板根路径: {context.TemplateRootPath}," )
                .AppendLine( $"   输出根路径: {context.OutputRootPath}," )
                .AppendLine( $"   消息上下文信息:" )
                .AppendLine( $"       必填项消息: {context.Message.RequiredMessage}" )
                .AppendLine( $"       最大长度消息: {context.Message.MaxLengthMessage}" )
                .LogDebug();
        }

        /// <inheritdoc />
        public void BeginBuildProjectContext( string project ) {
            _logger.Message( $"开始构建生成器项目上下文: {project}" ).LogDebug();
        }

        /// <inheritdoc />
        public void BeginGetDbMetadata( ProjectOptions projectOptions ) {
            _logger.AppendLine( "开始获取数据库元数据," )
                .AppendLine( $"    数据库类型: {projectOptions.DbType}," )
                .AppendLine( $"    数据库连接字符串: {projectOptions.ConnectionString}" )
                .LogDebug();
        }

        /// <inheritdoc />
        public void EndGetDbMetadata( DatabaseInfo info ) {
            _logger.AppendLine( "获取数据库元数据完成," )
                .AppendLine( $"    数据库名称: {info.Name}" )
                .LogDebug();
        }

        /// <inheritdoc />
        public void EndProjectContext( ProjectContext context ) {
            _logger.AppendLine( "构建生成器项目上下文完成:" )
                .AppendLine( $"   项目名称: {context.Name}," )
                .AppendLine( $"   目标数据库类型: {context.TargetDbType}," )
                .AppendLine( $"   工作单元名称: {context.UnitOfWorkName}," )
                .AppendLine( $"   是否启用: {context.Enabled.Description()}" );
            foreach ( var entity in context.Entities ) {
                _logger.AppendLine( $"   实体: {entity.Name}," )
                    .AppendLineIf( $"       架构: {entity.Schema},", entity.Schema.IsEmpty() == false )
                    .AppendLine( $"       描述: {entity.Description}," )
                    .AppendLine( $"       输出根路径: {entity.Output.RootPath}," )
                    .AppendLineIf( $"       输出相对根路径: {entity.Output.RelativeRootPath},", entity.Output.RelativeRootPath.IsEmpty() == false )
                    .AppendLine( $"       输出文件名: {entity.Output.FileNameNoExtension}," )
                    .AppendLineIf( $"       输出文件扩展名: {entity.Output.Extension},", entity.Output.Extension.IsEmpty() == false )
                    .AppendLineIf( $"       输出文件命名约定: {entity.Output.NamingConvention},", entity.Output.NamingConvention != null );
                foreach ( var property in entity.Properties ) {
                    _logger.AppendLine( $"      属性: {property.Name}" )
                        .AppendLine( $"         描述: {property.Description}," )
                        .AppendLine( $"         是否主键: {property.IsKey.Description()}," )
                        .AppendLine( $"         是否必填: {property.IsRequired.Description()}," )
                        .AppendLine( $"         是否自增: {property.IsAutoIncrement.Description()}," )
                        .AppendLine( $"         DbType: {property.Type}," )
                        .AppendLine( $"         SystemType: {property.SystemType}," )
                        .AppendLine( $"         NativeType: {property.NativeType}," )
                        .AppendLineIf( $"         最大长度: {property.MaxLength},", property.MaxLength.SafeValue() > 0 )
                        .AppendLineIf( $"         数值精度: {property.Precision},",property.Precision.SafeValue() != 0 )
                        .AppendLineIf( $"         小数位数: {property.Scale}", property.Scale.SafeValue() != 0 );
                }
            }
            _logger.LogDebug();
        }

        /// <inheritdoc />
        public void BeginGeTemplates( string project, string templateRootPath ) {
            _logger.AppendLine( $"开始获取 {project}项目 的模板列表" )
                .AppendLine( $"    模板根路径: {templateRootPath}" )
                .LogDebug();
        }

        /// <inheritdoc />
        public void EndGeTemplates( string project, List<ITemplate> templates ) {
            _logger.AppendLine( $"获取 {project}项目 的模板列表完成" );
            foreach ( var template in templates ) {
                _logger.AppendLine( $"    {template.Path}," );
                _logger.Line();
            }
            _logger.LogDebug();
        }

        /// <inheritdoc />
        public void FilterTemplate( string path ) {
            _logger.AppendLine( $"过滤模板: {path}" ).LogDebug();
        }

        /// <inheritdoc />
        public void BeginGenerateProject( string project ) {
            _logger.AppendLine( $"开始生成项目: {project}" ).LogInformation();
        }

        /// <inheritdoc />
        public void DisableProject( string project ) {
            _logger.AppendLine( $"项目 {project} 已禁用,不生成该项目代码" ).LogInformation();
        }

        /// <inheritdoc />
        public void BeginGenerateEntity( EntityContext entity ) {
            _logger.AppendLine( $"开始生成 {entity.Description}( {entity.Name} ) 全部模板代码" ).LogDebug();
        }

        /// <inheritdoc />
        public void SkipRelationTable( EntityContext entity ) {
            _logger.AppendLine( $"{entity.Description}( {entity.Name} ) 是关联表,已跳过生成" ).LogDebug();
        }

        /// <inheritdoc />
        public void RenderTemplate( EntityContext entity, ITemplate template ) {
            _logger.AppendLine( $"生成 {entity.Description}( {entity.Name} ) 代码" )
                .AppendLine( $"    模板: {template.Path}" )
                .LogDebug();
        }

        /// <inheritdoc />
        public void EndGenerateEntity( EntityContext entity ) {
            _logger.AppendLine( $"{entity.Description}( {entity.Name} ) 代码生成成功" ).LogInformation();
        }

        /// <inheritdoc />
        public void FilterResource( string path ) {
            _logger.AppendLine( $"过滤资源: {path}" ).LogDebug();
        }

        /// <inheritdoc />
        public void ImportResource( string templateRootPath, string outputRootPath, string project, Resource resource ) {
            _logger.AppendLine( "开始导入静态资源" )
                .AppendLine( $"    模板根目录路径: {templateRootPath}" )
                .AppendLine( $"    输出根目录路径: {outputRootPath}" )
                .AppendLine( $"    项目名称: {project}" )
                .AppendLine( $"    资源路径: {resource.From}" )
                .AppendLine( $"    目标路径: {resource.To}" )
                .LogDebug();
        }

        /// <inheritdoc />
        public void ImportDirectory( string templateRootPath, string outputRootPath, string project, string from, string to ) {
            _logger.AppendLine( "开始导入静态资源目录" )
                .AppendLine( $"    模板根目录路径: {templateRootPath}" )
                .AppendLine( $"    输出根目录路径: {outputRootPath}" )
                .AppendLine( $"    项目名称: {project}" )
                .AppendLine( $"    资源路径: {from}" )
                .AppendLine( $"    目标路径: {to}" )
                .LogDebug();
        }

        /// <inheritdoc />
        public void BeginImportFile( string sourceFile, string destFile ) {
            _logger.AppendLine( "开始导入静态资源文件" )
                .AppendLine( $"    资源路径: {sourceFile}" )
                .AppendLine( $"    目标路径: {destFile}" )
                .LogDebug();
        }

        /// <inheritdoc />
        public void EndImportFile( string sourceFile, string destFile ) {
            _logger.AppendLine( "导入静态资源文件成功" )
                .AppendLine( $"    资源路径: {sourceFile}" )
                .AppendLine( $"    目标路径: {destFile}" )
                .LogInformation();
        }

        /// <inheritdoc />
        public void EndGenerateProject( string project ) {
            _logger.AppendLine( $"项目 {project} 生成完成" ).LogInformation();
        }

        /// <summary>
        /// 生成完成
        /// </summary>
        /// <param name="stopwatch">计时器</param>
        public void EndGenerate( Stopwatch stopwatch ) {
            _logger.AppendLine( $"代码生成完成,耗时: {stopwatch.Elapsed.Description()}" ).LogInformation();
        }
    }
}
