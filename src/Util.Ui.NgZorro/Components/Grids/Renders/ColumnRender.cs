using Util.Ui.Angular.Extensions;
using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.Grids.Builders;
using Util.Ui.NgZorro.Configs;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Grids.Renders; 

/// <summary>
/// 栅格列渲染器
/// </summary>
public class ColumnRender : RenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 标识
    /// </summary>
    private string _id;

    /// <summary>
    /// 初始化栅格列渲染器
    /// </summary>
    public ColumnRender( Config config, string id ) {
        _config = config;
        _id = id;
    }

    /// <summary>
    /// 获取标签生成器
    /// </summary>
    protected override TagBuilder GetTagBuilder() {
        var builder = new ColumnBuilder( _config, _id );
        builder.Config();
        return builder;
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new ColumnRender( _config.CopyRemoveAttributes(), _id );
    }
}