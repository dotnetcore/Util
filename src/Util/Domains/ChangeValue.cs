using System.Text;

namespace Util.Domains {
    /// <summary>
    /// 变更值
    /// </summary>
    public class ChangeValue {
        /// <summary>
        /// 初始化变更值
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="description">描述</param>
        /// <param name="oldValue">旧值</param>
        /// <param name="newValue">新值</param>
        /// <param name="isAttention">是否关注</param>
        public ChangeValue( string propertyName, string description, string oldValue, string newValue, bool isAttention ) {
            PropertyName = propertyName;
            Description = description;
            OldValue = oldValue;
            NewValue = newValue;
            IsAttention = isAttention;
        }

        /// <summary>
        /// 属性名
        /// </summary>
        public string PropertyName { get;private set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// 旧值
        /// </summary>
        public string OldValue { get; private set; }
        /// <summary>
        /// 新值
        /// </summary>
        public string NewValue { get; private set; }
        /// <summary>
        /// 是否关注
        /// </summary>
        public bool IsAttention { get; private set; }

        /// <summary>
        /// 输出变更信息
        /// </summary>
        public override string ToString() {
            var result = new StringBuilder();
            result.AppendFormat( "{0}({1}),", PropertyName, Description );
            result.AppendFormat( "旧值:{0},新值:{1}", OldValue, NewValue );
            return result.ToString();
        }
    }
}
