using System.IO;
using System.Text.Encodings.Web;
using Util.Ui.Components;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Material.Extensions;
using Util.Ui.Material.Forms.Configs;
using Util.Ui.Material.Forms.Renders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Forms {
    /// <summary>
    /// 单选框
    /// </summary>
    public class Radio : ComponentBase, IRadio {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly SelectConfig _config;

        /// <summary>
        /// 初始化单选框
        /// </summary>
        public Radio() {
            _config = new SelectConfig();
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
            return new RadioRender( _config );
        }

        /// <summary>
        /// 渲染前操作
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        protected override void RenderBefore( TextWriter writer, HtmlEncoder encoder ) {
            AddItems();
        }

        /// <summary>
        /// 添加项集合
        /// </summary>
        private void AddItems() {
            if( _config.Items.Count == 0 )
                return;
            this.DataSource( Util.Helpers.Json.ToJson( _config.Items, true ) );
        }

        /// <summary>
        /// 绑定枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        public IRadio Enum<TEnum>() {
            return this.Add( Util.Helpers.Enum.GetItems<TEnum>().ToArray() );
        }
    }
}