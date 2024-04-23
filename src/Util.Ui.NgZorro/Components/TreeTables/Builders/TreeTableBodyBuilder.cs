using Util.Ui.Angular.Extensions;
using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.Tables.Builders;
using Util.Ui.NgZorro.Configs;

namespace Util.Ui.NgZorro.Components.TreeTables.Builders; 

/// <summary>
/// 树形表格主体标签生成器
/// </summary>
public class TreeTableBodyBuilder : TableBodyBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化树形表格主体标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public TreeTableBodyBuilder( Config config ) : base( config ) {
        _config = config;
    }

    /// <summary>
    /// 创建表格主体行标签生成器
    /// </summary>
    public override TagBuilder CreateTableBodyRowBuilder() {
        return CreateContainerBuilder();
    }

    /// <summary>
    /// 创建容器标签生成器
    /// </summary>
    private TreeTableContainerBuilder CreateContainerBuilder() {
        var shareConfig = GetTableShareConfig();
        var containerBuilder = new TreeTableContainerBuilder( _config.CopyRemoveAttributes(), CreateRowBuilder() );
        containerBuilder.NgFor( $"let row of {shareConfig.TableExtendId}.dataSource;index as index" );
        return containerBuilder;
    }

    /// <summary>
    /// 创建行标签生成器
    /// </summary>
    private TreeTableBodyRowBuilder CreateRowBuilder() {
        return new TreeTableBodyRowBuilder( _config.CopyRemoveAttributes() );
    }
}