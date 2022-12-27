using Util.Domain.Properties;

namespace Util.Domain.Compare {
    /// <summary>
    /// 变更值
    /// </summary>
    public class ChangeValue {
        /// <summary>
        /// 初始化变更值
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="description">描述</param>
        /// <param name="originalValue">原始值</param>
        /// <param name="newValue">新值</param>
        public ChangeValue( string propertyName, string description, string originalValue, string newValue ) {
            PropertyName = propertyName;
            Description = description;
            OriginalValue = originalValue;
            NewValue = newValue;
        }

        /// <summary>
        /// 属性名
        /// </summary>
        public string PropertyName { get; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// 原始值
        /// </summary>
        public string OriginalValue { get; }
        /// <summary>
        /// 新值
        /// </summary>
        public string NewValue { get; }

        /// <summary>
        /// 输出变更信息
        /// </summary>
        public override string ToString() {
            return string.Format( DomainResource.ChangeValueToString, PropertyName, Description, OriginalValue, NewValue );
        }
    }
}
