using System.Collections.Generic;
using Util.Datas.Sql.Builders;
using Util.Domains.Repositories;

namespace Util.Datas.Sql {
    /// <summary>
    /// Sql生成器
    /// </summary>
    public interface ISqlBuilder : ICondition, ISelect,IFrom,IJoin,IWhere,IGroupBy,IOrderBy {
        /// <summary>
        /// 复制Sql生成器
        /// </summary>
        ISqlBuilder Clone();
        /// <summary>
        /// 创建一个新的Sql生成器
        /// </summary>
        ISqlBuilder New();
        /// <summary>
        /// 生成Sql语句
        /// </summary>
        string ToSql();
        /// <summary>
        /// 生成调试Sql语句，Sql语句中的参数被替换为参数值
        /// </summary>
        string ToDebugSql();
        /// <summary>
        /// 清空并初始化
        /// </summary>
        void Clear();
        /// <summary>
        /// 清空Select子句
        /// </summary>
        void ClearSelect();
        /// <summary>
        /// 清空From子句
        /// </summary>
        void ClearFrom();
        /// <summary>
        /// 清空Join子句
        /// </summary>
        void ClearJoin();
        /// <summary>
        /// 清空Where子句
        /// </summary>
        void ClearWhere();
        /// <summary>
        /// 清空GroupBy子句
        /// </summary>
        void ClearGroupBy();
        /// <summary>
        /// 清空OrderBy子句
        /// </summary>
        void ClearOrderBy();
        /// <summary>
        /// 清空Sql参数
        /// </summary>
        void ClearSqlParams();
        /// <summary>
        /// 清空分页参数
        /// </summary>
        void ClearPageParams();
        /// <summary>
        /// 添加Sql参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        void AddParam( string name, object value );
        /// <summary>
        /// 获取Sql参数列表
        /// </summary>
        IReadOnlyDictionary<string, object> GetParams();
        /// <summary>
        /// 设置分页
        /// </summary>
        /// <param name="pager">分页参数</param>
        ISqlBuilder Page( IPager pager );
        /// <summary>
        /// 设置跳过行数
        /// </summary>
        /// <param name="count">跳过的行数</param>
        ISqlBuilder Skip( int count );
        /// <summary>
        /// 设置获取行数
        /// </summary>
        /// <param name="count">获取的行数</param>
        ISqlBuilder Take( int count );
        /// <summary>
        /// 分页参数
        /// </summary>
        IPager Pager { get; }
    }
}
