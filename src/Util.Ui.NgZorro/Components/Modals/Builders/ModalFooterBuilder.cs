using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Modals.Builders; 

/// <summary>
/// 对话框页脚标签生成器
/// </summary>
public class ModalFooterBuilder : AngularTagBuilder {
    /// <summary>
    /// 初始化对话框页脚标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public ModalFooterBuilder( Config config ) : base( config,"div" ) {
        base.Attribute( "*nzModalFooter" );
    }
}