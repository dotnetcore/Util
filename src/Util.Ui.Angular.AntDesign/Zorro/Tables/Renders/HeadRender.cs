using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Zorro.Tables.Renders {
    /// <summary>
    /// 表格头渲染器
    /// </summary>
    public class HeadRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;
        /// <summary>
        /// 表格包装器标识
        /// </summary>
        private readonly string _tableWrapperId;
        /// <summary>
        /// 是否排序
        /// </summary>
        private readonly bool _isSort;

        /// <summary>
        /// 初始化表格头渲染器
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="tableWrapperId">表格包装器标识</param>
        /// <param name="isSort">是否排序</param>
        public HeadRender( IConfig config,string tableWrapperId,bool? isSort ) : base( config ) {
            _config = config;
            _tableWrapperId = tableWrapperId;
            _isSort = isSort.SafeValue();
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TableHeadBuilder();
            ConfigHead( builder );
            var rowBuilder = new TableRowBuilder();
            builder.AppendContent( rowBuilder );
            ConfigRow( rowBuilder );
            return builder;
        }

        /// <summary>
        /// 配置thead
        /// </summary>
        private void ConfigHead( TableHeadBuilder builder ) {
            AddSortChange( builder );
        }

        /// <summary>
        /// 添加排序变更事件处理
        /// </summary>
        private void AddSortChange( TableHeadBuilder builder ) {
            if( _config.Contains( UiConst.OnSortChange ) ) {
                builder.AddSortChange( _config.GetValue( UiConst.OnSortChange ) );
                return;
            }
            if ( _isSort == false )
                return;
            builder.AddSortChange( $"{_tableWrapperId}.sort($event)" );
        }

        /// <summary>
        /// 配置tr
        /// </summary>
        private void ConfigRow( TableRowBuilder builder ) {
            InitBuilder( builder );
            ConfigId( builder );
            ConfigContent( builder );
        }
    }
}