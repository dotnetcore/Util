using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Zorro.Grid.Builders;
using Util.Ui.Zorro.Grid.Helpers;

namespace Util.Ui.Zorro.Grid.Renders {
    /// <summary>
    /// 栅格列渲染器
    /// </summary>
    public class ColumnRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化栅格列渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ColumnRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new ColumnBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigSpan( builder );
            ConfigOffset( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置跨度
        /// </summary>
        private void ConfigSpan( TagBuilder builder ) {
            builder.AddAttribute( "[nzSpan]", GetColumnSpan() );
        }

        /// <summary>
        /// 获取列跨度
        /// </summary>
        private string GetColumnSpan() {
            var result = _config.GetValue( UiConst.Span );
            if( result.IsEmpty() == false )
                return result;
            var shareConfig = GridHelper.GetShareConfig( _config );
            return shareConfig?.ColumnSpan;
        }

        /// <summary>
        /// 配置偏移量
        /// </summary>
        private void ConfigOffset( TagBuilder builder ) {
            builder.AddAttribute( "[nzOffset]", _config.GetValue( UiConst.Offset ) );
            builder.AddAttribute( "[nzOrder]", _config.GetValue( UiConst.Order ) );
            builder.AddAttribute( "[nzPull]", _config.GetValue( UiConst.Pull ) );
            builder.AddAttribute( "[nzPush]", _config.GetValue( UiConst.Push ) );
        }
    }
}