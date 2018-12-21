using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Util.Datas.Queries;
using Util.Datas.Sql.Queries.Builders.Abstractions;
using Util.Datas.Sql.Queries.Builders.Core;
using Util.Datas.Sql.Queries.Builders.Extensions;
using Util.Helpers;

namespace Util.Datas.Sql.Queries.Builders.Clauses {
    /// <summary>
    /// 表连接子句
    /// </summary>
    public class JoinClause : IJoinClause {
        /// <summary>
        /// Join关键字
        /// </summary>
        private const string JoinKey = "Join";
        /// <summary>
        /// Left Join关键字
        /// </summary>
        private const string LeftJoinKey = "Left Join";
        /// <summary>
        /// Right Join关键字
        /// </summary>
        private const string RightJoinKey = "Right Join";
        /// <summary>
        /// 连接参数
        /// </summary>
        private readonly List<JoinItem> _params;
        /// <summary>
        /// 方言
        /// </summary>
        private readonly IDialect _dialect;
        /// <summary>
        /// 实体解析器
        /// </summary>
        private readonly IEntityResolver _resolver;
        /// <summary>
        /// 实体注册器
        /// </summary>
        private readonly IEntityAliasRegister _register;

        /// <summary>
        /// 初始化表连接子句
        /// </summary>
        /// <param name="dialect">方言</param>
        /// <param name="resolver">实体解析器</param>
        /// <param name="register">实体注册器</param>
        public JoinClause( IDialect dialect, IEntityResolver resolver, IEntityAliasRegister register ) {
            _params = new List<JoinItem>();
            _dialect = dialect;
            _resolver = resolver;
            _register = register;
        }

        /// <summary>
        /// 内连接
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public void Join( string table, string alias = null ) {
            Join( JoinKey, table, alias );
        }

        /// <summary>
        /// 表连接
        /// </summary>
        private void Join( string joinType, string table, string alias ) {
            _params.Add( CreateJoinItem( joinType, table, null, alias ) );
        }

        /// <summary>
        /// 创建连接项
        /// </summary>
        /// <param name="joinType">连接类型</param>
        /// <param name="table">表名</param>
        /// <param name="schema">架构名</param>
        /// <param name="alias">别名</param>
        protected virtual JoinItem CreateJoinItem( string joinType, string table, string schema, string alias ) {
            return new JoinItem( joinType, table, schema, alias );
        }

        /// <summary>
        /// 内连接
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public void Join<TEntity>( string alias = null, string schema = null ) where TEntity : class {
            Join<TEntity>( JoinKey, alias, schema );
        }

        /// <summary>
        /// 表连接
        /// </summary>
        private void Join<TEntity>( string joinType, string alias, string schema ) {
            var entity = typeof( TEntity );
            var table = _resolver.GetTableAndSchema( entity );
            _params.Add( CreateJoinItem( joinType, table, schema, alias ) );
            _register.Register( entity, _resolver.GetAlias( entity, alias ) );
        }

        /// <summary>
        /// 添加到内连接子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public void AppendJoin( string sql ) {
            AppendJoin( JoinKey, sql );
        }

        /// <summary>
        /// 添加到连接子句
        /// </summary>
        private void AppendJoin( string joinType, string sql ) {
            _params.Add( new JoinItem( joinType, sql, raw: true ) );
        }

        /// <summary>
        /// 左外连接
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public void LeftJoin( string table, string alias = null ) {
            Join( LeftJoinKey, table, alias );
        }

        /// <summary>
        /// 左外连接
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public void LeftJoin<TEntity>( string alias = null, string schema = null ) where TEntity : class {
            Join<TEntity>( LeftJoinKey, alias, schema );
        }

        /// <summary>
        /// 添加到左外连接子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public void AppendLeftJoin( string sql ) {
            AppendJoin( LeftJoinKey, sql );
        }

        /// <summary>
        /// 右外连接
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public void RightJoin( string table, string alias = null ) {
            Join( RightJoinKey, table, alias );
        }

        /// <summary>
        /// 右外连接
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public void RightJoin<TEntity>( string alias = null, string schema = null ) where TEntity : class {
            Join<TEntity>( RightJoinKey, alias, schema );
        }

        /// <summary>
        /// 添加到右外连接子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public void AppendRightJoin( string sql ) {
            AppendJoin( RightJoinKey, sql );
        }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="left">左表列名</param>
        /// <param name="right">右表列名</param>
        /// <param name="operator">条件运算符</param>
        public void On( string left, string right, Operator @operator = Operator.Equal ) {
            _params.LastOrDefault()?.On( left, right, @operator );
        }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="left">左表列名</param>
        /// <param name="right">右表列名</param>
        /// <param name="operator">条件运算符</param>
        public void On<TLeft, TRight>( Expression<Func<TLeft, object>> left, Expression<Func<TRight, object>> right, Operator @operator = Operator.Equal )
            where TLeft : class
            where TRight : class {
            On( GetColumn( left ), GetColumn( right ), @operator );
        }

        /// <summary>
        /// 获取列
        /// </summary>
        private string GetColumn<TEntity>( Expression<Func<TEntity, object>> column ) {
            return GetColumn( typeof( TEntity ), _resolver.GetColumn( column ) );
        }

        /// <summary>
        /// 获取列
        /// </summary>
        private string GetColumn( Type entity, string column ) {
            return $"{_register.GetAlias( entity )}.{column}";
        }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="expression">条件表达式</param>
        public void On<TLeft, TRight>( Expression<Func<TLeft, TRight, bool>> expression ) where TLeft : class where TRight : class {
            if( expression == null )
                throw new ArgumentNullException( nameof( expression ) );
            var expressions = Lambda.GetGroupPredicates( expression );
            expressions.ForEach( group => On( group, typeof( TLeft ), typeof( TRight ) ) );
        }

        /// <summary>
        /// 设置连接条件组
        /// </summary>
        private void On( List<Expression> group, Type typeLeft, Type typeRight ) {
            var items = group.Select( expression => new OnItem(
                GetColumn( expression, typeLeft, false ), GetColumn( expression, typeRight, true ), Lambda.GetOperator( expression ).SafeValue()
            ) ).ToList();
            _params.LastOrDefault()?.On( items );
        }

        /// <summary>
        /// 获取列
        /// </summary>
        private string GetColumn( Expression expression, Type entity, bool right ) {
            return GetColumn( entity, _resolver.GetColumn( expression, entity, right ) );
        }

        /// <summary>
        /// 输出Sql
        /// </summary>
        public string ToSql() {
            var result = new StringBuilder();
            _params.ForEach( item => {
                result.AppendLine( $"{item.ToSql( _dialect )} " );
            } );
            return result.ToString().Trim();
        }
    }
}
