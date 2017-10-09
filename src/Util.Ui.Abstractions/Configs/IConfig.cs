using System.Collections.Generic;

namespace Util.Ui.Configs {
    /// <summary>
    /// 基础配置
    /// </summary>
    public interface IConfig {
        /// <summary>
        /// 标识
        /// </summary>
        string Id { get; set; }
        /// <summary>
        /// 文本
        /// </summary>
        string Text { get; set; }
        /// <summary>
        /// 添加类
        /// </summary>
        void AddClass( string @class );
        /// <summary>
        /// 获取类列表
        /// </summary>
        List<string> GetClassList();
        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">属性值</param>
        void AddAttribute( string name, string value );
        /// <summary>
        /// 获取属性集合
        /// </summary>
        Dictionary<string, string> GetAttributes();
        /// <summary>
        /// 获取属性
        /// </summary>
        /// <param name="name">属性名</param>
        string GetAttribute( string name );
    }
}
