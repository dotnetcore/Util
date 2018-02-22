using Util.Ui.Angular.Builders;
using Util.Ui.Builders;

namespace Util.Ui.Material.Tabs.Builders {
    /// <summary>
    /// Material选项卡生成器
    /// </summary>
    public class TabBuilder : TagBuilder {
        /// <summary>
        /// 初始化选项卡生成器
        /// </summary>
        public TabBuilder() : base( "mat-tab" ) {
            HeaderTemplateBuilder = new TemplateBuilder();
            HeaderTemplateBuilder.AddAttribute( "mat-tab-label" );
            ContenTemplateBuilder = new TemplateBuilder();
            ContenTemplateBuilder.AddAttribute( "matTabContent" );
        }

        /// <summary>
        /// 标题模板生成器
        /// </summary>
        public TemplateBuilder HeaderTemplateBuilder { get; set; }

        /// <summary>
        /// 内容模板生成器
        /// </summary>
        public TemplateBuilder ContenTemplateBuilder { get; set; }
    }
}