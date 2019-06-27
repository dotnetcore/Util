using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Zorro.Trees.Builders;

namespace Util.Ui.Zorro.Trees.Renders {
    /// <summary>
    /// 树形渲染器
    /// </summary>
    public class TreeRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化树形包装器渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TreeRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TreeWrapperBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigData( builder );
            ConfigNode( builder );
            ConfigKeys( builder );
            ConfigEvents( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置数据源
        /// </summary>
        private void ConfigData( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Url, _config.GetValue( UiConst.Url ) );
            builder.AddAttribute( "[url]", _config.GetValue( AngularConst.BindUrl ) );
            builder.AddAttribute( "[(queryParam)]", _config.GetValue( UiConst.QueryParam ) );
        }

        /// <summary>
        /// 配置节点
        /// </summary>
        private void ConfigNode( TagBuilder builder ) {
            builder.AddAttribute( "expandAll", _config.GetBoolValue( UiConst.ExpandAll ) );
            builder.AddAttribute( "blockNode", _config.GetBoolValue( UiConst.BlockNode ) );
            builder.AddAttribute( "showCheckbox", _config.GetBoolValue( UiConst.ShowCheckbox ) );
            builder.AddAttribute( "showExpand", _config.GetBoolValue( UiConst.ShowExpand ) );
            builder.AddAttribute( "showLine", _config.GetBoolValue( UiConst.ShowLine ) );
            builder.AddAttribute( "showIcon", _config.GetBoolValue( UiConst.ShowIcon ) );
            builder.AddAttribute( "multiple", _config.GetBoolValue( UiConst.Multiple ) );
        }

        /// <summary>
        /// 配置键列表
        /// </summary>
        private void ConfigKeys( TagBuilder builder ) {
            builder.AddAttribute( "[checkedKeys]", _config.GetValue( UiConst.CheckedKeys ) );
            builder.AddAttribute( "[expandedKeys]", _config.GetValue( UiConst.ExpandedKeys ) );
            builder.AddAttribute( "[selectedKeys]", _config.GetValue( UiConst.SelectedKeys ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(onClick)", _config.GetValue( UiConst.OnClick ) );
            builder.AddAttribute( "(onDblClick)", _config.GetValue( UiConst.OnDblClick ) );
            builder.AddAttribute( "(onCheckBoxChange)", _config.GetValue( UiConst.OnCheckBoxChange ) );
            builder.AddAttribute( "(onExpand)", _config.GetValue( UiConst.OnExpand ) );
        }
    }
}
