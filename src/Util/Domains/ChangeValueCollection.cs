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
        /// <param name="isAttention">是否关注</param>
        public void Add( string propertyName, string description, string oldValue, string newValue, bool isAttention = false ) {
            if( string.IsNullOrWhiteSpace( propertyName ) )
                return;
            Add( new ChangeValue( propertyName, description, oldValue, newValue, isAttention ) );
        }

        /// <summary>
        /// 是否关注
        /// </summary>
        public bool IsAttention {
            get { return this.Any( t => t.IsAttention ); } 
        }

        /// <summary>
        /// 获取关注的变更集
        /// </summary>
        public List<ChangeValue> GetAttentionValues() {
            return this.Where( t => t.IsAttention ).ToList();
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
