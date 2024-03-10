using Util.Ui.Angular.Builders;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Resizable.Builders;

/// <summary>
/// 调整尺寸手柄标签生成器
/// </summary>
public class ResizeHandleBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化调整尺寸手柄标签生成器
    /// </summary>
    public ResizeHandleBuilder( Config config ) : base( config, "nz-resize-handle" ) {
        _config = config;
    }

    /// <summary>
    /// 配置调整方向
    /// </summary>
    public ResizeHandleBuilder Direction( ResizeDirection direction ) {
        AttributeIfNotEmpty( "nzDirection", direction.Description() );
        return this;
    }

    /// <summary>
    /// 配置调整方向
    /// </summary>
    public ResizeHandleBuilder BindDirection( string direction ) {
        AttributeIfNotEmpty( "[nzDirection]", direction );
        return this;
    }

    /// <summary>
    /// 配置光标类型
    /// </summary>
    public ResizeHandleBuilder CursorType( CursorType cursor ) {
        AttributeIfNotEmpty( "nzCursorType", cursor.Description() );
        return this;
    }

    /// <summary>
    /// 配置光标类型
    /// </summary>
    public ResizeHandleBuilder BindCursorType( string cursor ) {
        AttributeIfNotEmpty( "[nzCursorType]", cursor );
        return this;
    }
}