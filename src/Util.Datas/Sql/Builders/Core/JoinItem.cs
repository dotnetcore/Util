using System;
using System.Collections.Generic;
using Util.Datas.Queries;
using Util.Datas.Sql.Builders.Conditions;
using Util.Datas.Sql.Builders.Internal;
using Util.Datas.Sql.Matedatas;

namespace Util.Datas.Sql.Builders.Core {
    /// <summary>
    /// 表连接项
    /// </summary>
    public class JoinItem : IJoinOn {
        /// <summary>
        /// 辅助操作
        /// </summary>
        private Helper _helper;

        /// <summary>
        /// 初始化表连接项
        /// </summary>
        /// <param name="joinType">连接类型</param>
        /// <param name="table">表名</param>
        /// <param name="schema">架构</param>
        /// <param name="alias">别名</param>
        /// <param name="raw">使用原始值</param>
        /// <param name="isSplit">是否用句点分割表名</param>
        /// <param name="type">表实体类型</param>
        public JoinItem( string joinType, string table, string schema = null, string alias = null, bool raw = false, bool isSplit = true, Type type = null ) {
            JoinType = joinType;
            Table = new SqlItem( table, schema, alias, raw, isSplit );
            Type = type;
        }

        /// <summary>
        /// 初始化表连接项
        /// </summary>
        /// <param name="joinType">连接类型</param>
        /// <param name="table">表</param>
        /// <param name="type">表实体类型</param>
        /// <param name="condition">连接条件</param>
        public JoinItem( string joinType, SqlItem table, Type type, ICondition condition ) {
            JoinType = joinType;
            Table = table;
            Type = type;
            Condition = condition;
        }

        /// <summary>
        /// 设置依赖项
        /// </summary>
        public void SetDependency( Helper helper ) {
            _helper = helper;
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
        /// 表实体类型
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// 连接条件
        /// </summary>
        public ICondition Condition { get; private set; }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="condition">连接条件</param>
        public void On( ICondition condition ) {
            if( condition == null )
                return;
            Condition = new AndCondition( Condition, condition );
        }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        public void On( string column, object value, Operator @operator = Operator.Equal ) {
            if ( _helper == null )
                return;
            var condition = _helper.CreateCondition( column, value, @operator );
            On( condition );
        }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        public void On( List<List<OnItem>> items, IDialect dialect ) {
            if( items == null )
                return;
            ICondition orCondition = null;
            foreach( var onItems in items ) {
                ICondition condition = null;
                foreach( var item in onItems ) {
                    condition = new AndCondition( condition, SqlConditionFactory.Create( item.Left.ToSql( dialect ), item.Right.ToSql( dialect ), item.Operator ) );
                }
                orCondition = new OrCondition( orCondition, condition );
            }
            On( orCondition );
        }

        /// <summary>
        /// 添加到On子句
        /// </summary>
        public void AppendOn( string sql, IDialect dialect ) {
            if( string.IsNullOrWhiteSpace( sql ) )
                return;
            sql = Helper.ResolveSql( sql, dialect );
            On( new SqlCondition( sql ) );
        }

        /// <summary>
        /// 复制副本
        /// </summary>
        public JoinItem Clone( Helper helper ) {
            var result = new JoinItem( JoinType, Table, Type, new SqlCondition( Condition?.GetCondition() ) );
            result.SetDependency( helper );
            return result;
        }

        /// <summary>
        /// 获取Join语句
        /// </summary>
        public string ToSql( IDialect dialect = null, ITableDatabase tableDatabase=null ) {
            var table = Table.ToSql( dialect, tableDatabase );
            return $"{JoinType} {table}{GetOn()}";
        }

        /// <summary>
        /// 获取On语句
        /// </summary>
        private string GetOn() {
            return Condition == null ? null : $" On {Condition.GetCondition()}";
        }
    }
}
