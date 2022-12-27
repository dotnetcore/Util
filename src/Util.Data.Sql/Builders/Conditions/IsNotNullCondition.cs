using System.Text;

namespace Util.Data.Sql.Builders.Conditions {
    /// <summary>
    /// Is Not Null查询条件
    /// </summary>
    public class IsNotNullCondition : ISqlCondition {
        /// <summary>
        /// 列名
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// 初始化Is Not Null查询条件
        /// </summary>
        /// <param name="name">列名</param>
        public IsNotNullCondition( string name ) {
            _name = name;
        }

        /// <summary>
        /// 添加到字符串生成器
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        public void AppendTo( StringBuilder builder ) {
            if( _name.IsEmpty() )
                return;
            builder.AppendFormat( "{0} Is Not Null", _name );
        }
    }
}