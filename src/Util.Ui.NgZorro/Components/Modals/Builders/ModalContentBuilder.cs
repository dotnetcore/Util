using Util.Ui.Angular.Builders;

namespace Util.Ui.NgZorro.Components.Modals.Builders; 

/// <summary>
/// 对话框内容标签生成器
/// </summary>
public class ModalContentBuilder : AngularTagBuilder {
    /// <summary>
    /// 初始化对话框内容标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public ModalContentBuilder( Config config ) : base( config,"div" ) {
        base.Attribute( "*nzModalContent" );
    }
}