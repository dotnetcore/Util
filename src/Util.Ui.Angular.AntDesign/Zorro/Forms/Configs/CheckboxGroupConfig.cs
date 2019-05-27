using System;
using System.Collections.Generic;
using System.Linq;
using Util.Ui.Configs;
using Util.Ui.TagHelpers;

namespace Util.Ui.Zorro.Forms.Configs {
    /// <summary>
    /// 复选框组配置
    /// </summary>
    public class CheckboxGroupConfig : Config {
        /// <summary>
        /// 列表项集合
        /// </summary>
        public readonly List<CheckboxGroupItem> Items = new List<CheckboxGroupItem>();

        /// <summary>
        /// 初始化复选框组配置
        /// </summary>
        public CheckboxGroupConfig() {
        }

        /// <summary>
        /// 初始化复选框组配置
        /// </summary>
        /// <param name="context">TagHelper上下文</param>
        public CheckboxGroupConfig( Context context ) : base( context ) {
        }

        /// <summary>
        /// 添加项集合
        /// </summary>
        /// <param name="items">列表项集合</param>
        public void AddItems( params CheckboxGroupItem[] items ) {
            Items.AddRange( items );
        }

        /// <summary>
        /// 添加布尔
        /// </summary>
        public void AddBool() {
            AddItems( new CheckboxGroupItem( "是", true ), new CheckboxGroupItem( "否", false ) );
        }

        /// <summary>
        /// 添加枚举
        /// </summary>
        /// <param name="type">枚举类型</param>
        public void AddEnum( Type type ) {
            AddItems( Util.Helpers.Enum.GetItems( type ).Select( t => new CheckboxGroupItem( t.Text, t.Value ) ).ToArray() );
        }
    }
}
