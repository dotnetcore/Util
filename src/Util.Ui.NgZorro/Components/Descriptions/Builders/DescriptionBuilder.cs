using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.NgZorro.Components.Grids.Helpers;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Descriptions.Builders;

/// <summary>
/// 描述列表标签生成器
/// </summary>
public class DescriptionBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化描述列表标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public DescriptionBuilder( Config config ) : base( config, "nz-descriptions" ) {
        _config = config;
    }

    /// <summary>
    /// 配置标题
    /// </summary>
    public DescriptionBuilder Title() {
        AttributeIfNotEmpty( "nzTitle", _config.GetValue( UiConst.Title ) );
        AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( AngularConst.BindTitle ) );
        return this;
    }

    /// <summary>
    /// 配置操作区域
    /// </summary>
    public DescriptionBuilder Extra() {
        AttributeIfNotEmpty( "nzExtra", _config.GetValue( UiConst.Extra ) );
        AttributeIfNotEmpty( "[nzExtra]", _config.GetValue( AngularConst.BindExtra ) );
        return this;
    }

    /// <summary>
    /// 配置是否显示边框
    /// </summary>
    public DescriptionBuilder Bordered() {
        AttributeIfNotEmpty( "[nzBordered]", _config.GetValue( UiConst.Bordered ) );
        return this;
    }

    /// <summary>
    /// 配置一行包含的描述列表项数量
    /// </summary>
    public DescriptionBuilder Column() {
        var column = _config.GetValue( UiConst.Column );
        var columnValue = column.ToIntOrNull();
        if ( column.IsEmpty() == false && columnValue == null )
            return Column( column );
        var model = new ColumnModel {
            Xs = _config.GetValue<int?>( UiConst.XsColumn ) ?? 1,
            Sm = _config.GetValue<int?>( UiConst.SmColumn ) ?? 1,
            Md = _config.GetValue<int?>( UiConst.MdColumn ) ?? 1,
            Lg = _config.GetValue<int?>( UiConst.LgColumn ) ?? 1,
            Xl = _config.GetValue<int?>( UiConst.XlColumn ) ?? columnValue ?? 2,
            Xxl = _config.GetValue<int?>( UiConst.XxlColumn ) ?? columnValue ?? 2
        };
        Column( model.ToJson() );
        return this;
    }

    /// <summary>
    /// 配置一行包含的描述列表项数量
    /// </summary>
    public DescriptionBuilder Column( string column ) {
        AttributeIfNotEmpty( "[nzColumn]", column );
        return this;
    }

    /// <summary>
    /// 配置列表大小
    /// </summary>
    public DescriptionBuilder Size() {
        AttributeIfNotEmpty( "nzSize", _config.GetValue<DescriptionSize?>( UiConst.Size )?.Description() );
        AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
        return this;
    }

    /// <summary>
    /// 配置是否显示冒号
    /// </summary>
    public DescriptionBuilder Colon() {
        AttributeIfNotEmpty( "[nzColon]", _config.GetValue( UiConst.Colon ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        Title().Extra().Bordered().Column().Size().Colon();
    }
}