using Util.Datas.Sql.Builders;
using Util.Datas.Sql.Builders.Core;
using Util.Datas.Sql.Matedatas;

namespace Util.Datas.Dapper.Oracle {
    /// <summary>
    /// Sql项
    /// </summary>
    public class OracleSqlItem : SqlItem{
        /// <summary>
        /// 初始化Sql项
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="prefix">前缀</param>
        /// <param name="alias">别名</param>
        /// <param name="raw">使用原始值</param>
        /// <param name="isSplit">是否用句点分割名称</param>
        public OracleSqlItem( string name, string prefix = null, string alias = null, bool raw = false, bool isSplit = true ) 
            :base( name, prefix, alias, raw, isSplit ) {
        }

        /// <summary>
        /// 获取列名和别名
        /// </summary>
        protected override string GetColumnAlias( IDialect dialect, ITableDatabase tableDatabase ) {
            return $"{GetColumn( dialect, tableDatabase )} {GetSafeName( dialect, Alias )}";
        }
    }
}
