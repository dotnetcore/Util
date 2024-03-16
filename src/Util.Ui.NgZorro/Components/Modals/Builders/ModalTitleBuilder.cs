using Util.Ui.Angular.Builders;

namespace Util.Ui.NgZorro.Components.Modals.Builders; 

/// <summary>
/// 对话框标题标签生成器
/// </summary>
public class ModalTitleBuilder : AngularTagBuilder {
    /// <summary>
    /// 初始化对话框标题标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public ModalTitleBuilder( Config config ) : base( config,"div" ) {
        base.Attribute( "*nzModalTitle" );
    }
}