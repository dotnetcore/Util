using Util.Ui.Angular.Forms.Configs;
using Util.Ui.Components;
using Util.Ui.Configs;
using Util.Ui.Material.Extensions;
using Util.Ui.Material.Lists.Renders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Lists {
    /// <summary>
    /// 选择列表
    /// </summary>
    public class SelectList : ComponentBase, ISelectList {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly SelectConfig _config;

        /// <summary>
        /// 初始化选择列表
        /// </summary>
        public SelectList() {
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
            return new SelectListWrapperRender( _config );
        }

        /// <summary>
        /// 绑定枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        public ISelectList Enum<TEnum>() {
            return this.Add( Util.Helpers.Enum.GetItems<TEnum>().ToArray() );
        }
    }
}