using System;
using System.IO;
using Util.Ui.Components;
using Util.Ui.Configs;
using Util.Ui.Material.Tabs.Renders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Tabs {
    /// <summary>
    /// 选项卡组
    /// </summary>
    public class TabGroup : ContainerBase<IDisposable>, ITabGroup {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化选项卡组
        /// </summary>
        public TabGroup() : this( null ) {
        }

        /// <summary>
        /// 初始化菜单
        /// </summary>
        /// <param name="writer">流写入器</param>
        public TabGroup( TextWriter writer ) : base( writer ) {
            _config = new Config();
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        protected override IConfig GetConfig() {
            return _config;
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new TabGroupRender( _config );
        }

        /// <summary>
        /// 获取容器包装器
        /// </summary>
        protected override IDisposable GetWrapper() {
            return new ContainerWrapper( this );
        }
    }
}