using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util.Domains {
    /// <summary>
    /// 变更值集合
    /// </summary>
    public class ChangeValueCollection : List<ChangeValue> {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="description">描述</param>
        /// <param name="oldValue">旧值</param>
        /// <param name="newValue">新值</param>
        public void Add( string propertyName, string description, string oldValue, string newValue ) {
            if( string.IsNullOrWhiteSpace( propertyName ) )
                return;
            Add( new ChangeValue( propertyName, description, oldValue, newValue ) );
        }

        /// <summary>
        /// 输出变更信息
        /// </summary>
        public override string ToString() {
            var result = new StringBuilder();
            foreach( var item in this )
                result.AppendLine( item.ToString() );
            return result.ToString();
        }
    }
}
