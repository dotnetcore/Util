using Util.Ui.Angular.Builders;
using Util.Ui.Builders;

namespace Util.Ui.Material.Menus.Builders {
    /// <summary>
    /// Material菜单生成器
    /// </summary>
    public class MenuBuilder : TagBuilder {
        /// <summary>
        /// 模板生成器
        /// </summary>
        private readonly TemplateBuilder _templateBuilder;

        /// <summary>
        /// 初始化菜单生成器
        /// </summary>
        public MenuBuilder() : base( "mat-menu" ) {
            _templateBuilder = new TemplateBuilder();
            _templateBuilder.AddAttribute( "matMenuContent", "", false );
            SetContent( _templateBuilder );
        }

        /// <summary>
        /// 模板生成器
        /// </summary>
        public TemplateBuilder TemplateBuilder => _templateBuilder;
    }
}
