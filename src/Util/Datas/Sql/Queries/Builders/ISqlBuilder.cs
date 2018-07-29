using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Util.Datas.Queries;
using Util.Datas.Sql.Queries.Builders.Conditions;

namespace Util.Datas.Sql.Queries.Builders {
    /// <summary>
    /// Sql生成器
    /// </summary>
    public interface ISqlBuilder : ICondition {
        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        ISqlBuilder New();
        /// <summary>
        /// 生成Sql语句
        /// </summary>
        string ToSql();
        /// <summary>
        /// 获取参数
        /// </summary>
        IDictionary<string, object> GetParams();
        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="columns">列名</param>
        /// <param name="tableAlias">表别名</param>
        ISqlBuilder Select( string columns, string tableAlias = null );
        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="columns">列名</param>
        /// <param name="tableAlias">表别名</param>
        ISqlBuilder Select<TEntity>( Expression<Func<TEntity, object[]>> columns,string tableAlias = null );
        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        ISqlBuilder From( string table, string alias = null, string schema = null );
        /// <summary>
        /// And连接条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        ISqlBuilder And( ICondition condition );
        /// <summary>
        /// 设置条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        /// <param name="tableAlias">表别名</param>
        ISqlBuilder Where( string column, object value, Operator @operator = Operator.Equal, string tableAlias = null );
    }
}
