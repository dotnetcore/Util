using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Util.Ui.Configs {
    /// <summary>
    /// 基础配置
    /// </summary>
    public interface IConfig {
        /// <summary>
        /// 全部属性集合
        /// </summary>
        TagHelperAttributeList AllAttributes { get; }
        /// <summary>
        /// 输出属性集合，TagHelper中未明确定义的属性从该集合获取
        /// </summary>
        TagHelperAttributeList OutputAttributes { get; }
        /// <summary>
        /// 内容
        /// </summary>
        TagHelperContent Content { get; }
        /// <summary>
        /// 属性集合是否包含指定属性
        /// </summary>
        /// <param name="name">属性名</param>
        bool Contains( string name );
        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="name">属性名</param>
        string GetValue( string name );
        /// <summary>
        /// 获取属性值，无值则返回null
        /// </summary>
        /// <param name="name">属性名</param>
        string GetValueOrNull( string name );
        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="name">属性名</param>
        T GetValue<T>( string name );
        /// <summary>
        /// 获取布尔属性值
        /// </summary>
        /// <param name="name">属性名</param>
        string GetBoolValue( string name );
        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">值</param>
        /// <param name="replaceExisting">是否替换已存在的属性</param>
        void SetAttribute( string name, object value, bool replaceExisting = true );
        /// <summary>
        /// 移除属性
        /// </summary>
        /// <param name="name">属性名</param>
        void Remove( string name );
        /// <summary>
        /// 添加类
        /// </summary>
        void AddClass( string @class );
        /// <summary>
        /// 获取类列表
        /// </summary>
        List<string> GetClassList();
        /// <summary>
        /// 验证
        /// </summary>
        string Validate();
        /// <summary>
        /// 从TagHelperContext Items里获取值
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="key">键</param>
        T GetValueFromItems<T>( object key = null );
        /// <summary>
        /// 设置TagHelperContext Items值
        /// </summary>
        /// <param name="value">值</param>
        void SetValueToItems<T>( T value );
        /// <summary>
        /// 从TagHelperContext AllAttributes里获取值
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="key">键</param>
        T GetValueFromAttributes<T>( string key );
    }
}
