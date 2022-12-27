using System.Text;

namespace Util.Data.Sql.Builders.Conditions {
    /// <summary>
    /// Is Null查询条件
    /// </summary>
    public class IsNullCondition : ISqlCondition {
        /// <summary>
        /// 列名
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// 初始化Is Null查询条件
        /// </summary>
        /// <param name="name">列名</param>
        public IsNullCondition( string name ) {
            _name = name;
        }

        /// <summary>
        /// 添加到字符串生成器
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        public void AppendTo( StringBuilder builder ) {
            if ( _name.IsEmpty() )
                return;
            builder.AppendFormat( "{0} Is Null", _name );
        }
    }
}