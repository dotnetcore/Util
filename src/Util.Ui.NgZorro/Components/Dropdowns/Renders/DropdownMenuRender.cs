using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Dropdowns.Builders;

namespace Util.Ui.NgZorro.Components.Dropdowns.Renders {
    /// <summary>
    /// 下拉菜单渲染器
    /// </summary>
    public class DropdownMenuRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化下拉菜单渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public DropdownMenuRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new DropdownMenuBuilder();
            ConfigContent( builder );
            return builder;
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        protected override void ConfigId( TagBuilder builder ) {
            if( _config.Contains( UiConst.Id ) )
                builder.Attribute( $"#{_config.GetValue( UiConst.Id )}", "nzDropdownMenu" );
            builder.AttributeIfNotEmpty( "id", _config.GetValue( AngularConst.RawId ) );
        }

        /// <summary>
        /// 配置内容元素
        /// </summary>
        protected override void ConfigContent( TagBuilder builder ) {
            var notCreateUl = _config.GetValue<bool?>( UiConst.NotCreateUl );
            if( notCreateUl == true ) {
                _config.Content.AppendTo( builder );
                return;
            }
            var ulBuilder = CreateUlBuilder();
            ConfigSelectable( ulBuilder );
            ConfigEvents( ulBuilder );
            builder.SetContent( ulBuilder );
            _config.Content.AppendTo( ulBuilder );
        }

        /// <summary>
        /// 创建ul标签生成器
        /// </summary>
        private TagBuilder CreateUlBuilder() {
            var builder = new UlBuilder();
            builder.Attribute( "nz-menu" );
            return builder;
        }

        /// <summary>
        /// 配置允许选中
        /// </summary>
        private void ConfigSelectable( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[nzSelectable]", _config.GetBoolValue( UiConst.Selectable ) );
            builder.AttributeIfNotEmpty( "[nzSelectable]", _config.GetBoolValue( AngularConst.BindSelectable ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "(nzClick)", _config.GetValue( UiConst.OnClick ) );
        }
    }
}