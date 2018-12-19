using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util.Datas.Queries;
using Util.Datas.Sql.Queries.Builders.Abstractions;
using Util.Datas.Sql.Queries.Builders.Conditions;

namespace Util.Datas.Sql.Queries.Builders.Core {
    /// <summary>
    /// 表连接项
    /// </summary>
    public class JoinItem {
        /// <summary>
        /// 初始化表连接项
        /// </summary>
        /// <param name="joinType">连接类型</param>
        /// <param name="table">表名</param>
        /// <param name="schema">架构</param>
        /// <param name="alias">别名</param>
        /// <param name="raw">使用原始值</param>
        /// <param name="isSplit">是否用句点分割表名</param>
        public JoinItem( string joinType, string table, string schema = null, string alias = null, bool raw = false, bool isSplit = true ) {
            JoinType = joinType;
            Table = new SqlItem( table, schema, alias, raw, isSplit );
            Conditions = new List<List<OnItem>>();
        }

        /// <summary>
        /// 连接类型
        /// </summary>
        public string JoinType { get; }

        /// <summary>
        /// 表
        /// </summary>
        public SqlItem Table { get; }

        /// <summary>
        /// 连接条件列表
        /// </summary>
        public List<List<OnItem>> Conditions { get; }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="left">左表列名</param>
        /// <param name="right">右表列名</param>
        /// <param name="operator">条件运算符</param>
        public void On( string left, string right, Operator @operator ) {
            if( string.IsNullOrWhiteSpace( left ) || string.IsNullOrWhiteSpace( right ) )
                return;
            var conditions = GetFirstConditions();
            conditions.Add( new OnItem( left, right, @operator ) );
        }

        /// <summary>
        /// 获取第一个连接条件列表
        /// </summary>
        private List<OnItem> GetFirstConditions() {
            var result = Conditions.FirstOrDefault();
            if( result == null ) {
                result = new List<OnItem>();
                Conditions.Add( result );
            }
            return result;
        }

        /// <summary>
        /// 设置连接条件列表
        /// </summary>
        /// <param name="items">连接条件列表</param>
        public void On( List<OnItem> items ) {
            if( items == null )
                return;
            Conditions.Add( items );
        }

        /// <summary>
        /// 获取Join语句
        /// </summary>
        public string ToSql( IDialect dialect ) {
            var table = Table.ToSql( dialect );
            return $"{JoinType} {table}{GetOn( dialect )}";
        }

        /// <summary>
        /// 获取On语句
        /// </summary>
        private string GetOn( IDialect dialect ) {
            if( Conditions.Count == 0 )
                return null;
            var result = new StringBuilder();
            Conditions.ForEach( items => {
                On( items, result, dialect );
                result.Append( " Or " );
            } );
            result.Remove( result.Length - 4, 4 );
            return $" On {result}";
        }

        /// <summary>
        /// 获取单个连接条件
        /// </summary>
        private void On( List<OnItem> items, StringBuilder result, IDialect dialect ) {
            items.ForEach( item => {
                On( item, result, dialect );
                result.Append( " And " );
            } );
            result.Remove( result.Length - 5, 5 );
        }

        /// <summary>
        /// 获取单个连接条件
        /// </summary>
        private void On( OnItem item, StringBuilder result, IDialect dialect ) {
            var left = item.Left.ToSql( dialect );
            var right = item.Right.ToSql( dialect );
            result.Append( SqlConditionFactory.Create( left, right, item.Operator ).GetCondition() );
        }
    }
}
