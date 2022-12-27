using System.Collections.Generic;
using System.Text;

namespace Util.Domain.Compare {
    /// <summary>
    /// 变更值集合
    /// </summary>
    public class ChangeValueCollection : List<ChangeValue> {
        /// <summary>
        /// 初始化变更值集合
        /// </summary>
        /// <param name="typeName">类型名称</param>
        /// <param name="typeDescription">类型描述</param>
        /// <param name="id">标识</param>
        public ChangeValueCollection( string typeName = null,string typeDescription = null, string id = null ) {
            TypeName = typeName;
            TypeDescription = typeDescription;
            Id = id;
        }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeName { get; }

        /// <summary>
        /// 类型描述
        /// </summary>
        public string TypeDescription { get; }

        /// <summary>
        /// 标识
        /// </summary>
        public string Id { get; }

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
            result.Append( $"{TypeName}({TypeDescription})," );
            if ( Id.IsEmpty() == false )
                result.Append( $"Id: {Id}," );
            foreach ( var item in this )
                result.Append( $"{item}," );
            return result.ToString().TrimEnd( ',' );
        }
    }
}
