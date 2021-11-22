using System.Collections.Generic;
using System.Text;

namespace Util.Domain.Compare {
    /// <summary>
    /// 变更值集合
    /// </summary>
    public class ChangeValueCollection : List<ChangeValue> {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="description">描述</param>
        /// <param name="originalValue">原始值</param>
        /// <param name="newValue">新值</param>
        public void Add( string propertyName, string description, string originalValue, string newValue ) {
            if( string.IsNullOrWhiteSpace( propertyName ) )
                return;
            Add( new ChangeValue( propertyName, description, originalValue, newValue ) );
        }

        /// <summary>
        /// 输出变更信息
        /// </summary>
        public override string ToString() {
            var result = new StringBuilder();
            foreach( var item in this )
                result.Append( $"{item}," );
            return result.ToString().TrimEnd( ',' );
        }
    }
}
