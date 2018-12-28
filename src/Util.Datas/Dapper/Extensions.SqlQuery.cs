using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Util.Datas.Sql.Queries;
using Util.Domains.Repositories;

namespace Util.Datas.Dapper {
    /// <summary>
    /// 查询对象扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static List<TReturn> ToList<TFirst, TSecond, TReturn>( this ISqlQuery sqlQuery, Func<TFirst, TSecond, TReturn> map, IDbConnection connection = null ) {
            return sqlQuery.Query( ( con, sql, sqlParmas ) => con.Query( sql, map, sqlParmas ).ToList(), connection );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TThird">参数类型3</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static List<TReturn> ToList<TFirst, TSecond, TThird, TReturn>( this ISqlQuery sqlQuery, Func<TFirst, TSecond, TThird, TReturn> map, IDbConnection connection = null ) {
            return sqlQuery.Query( ( con, sql, sqlParmas ) => con.Query( sql, map, sqlParmas ).ToList(), connection );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TThird">参数类型3</typeparam>
        /// <typeparam name="TFourth">参数类型4</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static List<TReturn> ToList<TFirst, TSecond, TThird, TFourth, TReturn>( this ISqlQuery sqlQuery, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, IDbConnection connection = null ) {
            return sqlQuery.Query( ( con, sql, sqlParmas ) => con.Query( sql, map, sqlParmas ).ToList(), connection );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TThird">参数类型3</typeparam>
        /// <typeparam name="TFourth">参数类型4</typeparam>
        /// <typeparam name="TFifth">参数类型5</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static List<TReturn> ToList<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>( this ISqlQuery sqlQuery, 
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, IDbConnection connection = null ) {
            return sqlQuery.Query( ( con, sql, sqlParmas ) => con.Query( sql, map, sqlParmas ).ToList(), connection );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TThird">参数类型3</typeparam>
        /// <typeparam name="TFourth">参数类型4</typeparam>
        /// <typeparam name="TFifth">参数类型5</typeparam>
        /// <typeparam name="TSixth">参数类型6</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static List<TReturn> ToList<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>( this ISqlQuery sqlQuery,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, IDbConnection connection = null ) {
            return sqlQuery.Query( ( con, sql, sqlParmas ) => con.Query( sql, map, sqlParmas ).ToList(), connection );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TThird">参数类型3</typeparam>
        /// <typeparam name="TFourth">参数类型4</typeparam>
        /// <typeparam name="TFifth">参数类型5</typeparam>
        /// <typeparam name="TSixth">参数类型6</typeparam>
        /// <typeparam name="TSeventh">参数类型7</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static List<TReturn> ToList<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>( this ISqlQuery sqlQuery,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, IDbConnection connection = null ) {
            return sqlQuery.Query( ( con, sql, sqlParmas ) => con.Query( sql, map, sqlParmas ).ToList(), connection );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<List<TReturn>> ToListAsync<TFirst, TSecond, TReturn>( this ISqlQuery sqlQuery, Func<TFirst, TSecond, TReturn> map, IDbConnection connection = null ) {
            return await sqlQuery.QueryAsync( async ( con, sql, sqlParmas ) => ( await con.QueryAsync( sql, map, sqlParmas ) ).ToList(), connection );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TThird">参数类型3</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<List<TReturn>> ToListAsync<TFirst, TSecond, TThird, TReturn>( this ISqlQuery sqlQuery, 
            Func<TFirst, TSecond, TThird, TReturn> map, IDbConnection connection = null ) {
            return await sqlQuery.QueryAsync( async ( con, sql, sqlParmas ) => ( await con.QueryAsync( sql, map, sqlParmas ) ).ToList(), connection );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TThird">参数类型3</typeparam>
        /// <typeparam name="TFourth">参数类型4</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<List<TReturn>> ToListAsync<TFirst, TSecond, TThird, TFourth, TReturn>( this ISqlQuery sqlQuery,
            Func<TFirst, TSecond, TThird, TFourth, TReturn> map, IDbConnection connection = null ) {
            return await sqlQuery.QueryAsync( async ( con, sql, sqlParmas ) => ( await con.QueryAsync( sql, map, sqlParmas ) ).ToList(), connection );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TThird">参数类型3</typeparam>
        /// <typeparam name="TFourth">参数类型4</typeparam>
        /// <typeparam name="TFifth">参数类型5</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<List<TReturn>> ToListAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>( this ISqlQuery sqlQuery,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, IDbConnection connection = null ) {
            return await sqlQuery.QueryAsync( async ( con, sql, sqlParmas ) => ( await con.QueryAsync( sql, map, sqlParmas ) ).ToList(), connection );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TThird">参数类型3</typeparam>
        /// <typeparam name="TFourth">参数类型4</typeparam>
        /// <typeparam name="TFifth">参数类型5</typeparam>
        /// <typeparam name="TSixth">参数类型6</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<List<TReturn>> ToListAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>( this ISqlQuery sqlQuery,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, IDbConnection connection = null ) {
            return await sqlQuery.QueryAsync( async ( con, sql, sqlParmas ) => ( await con.QueryAsync( sql, map, sqlParmas ) ).ToList(), connection );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TThird">参数类型3</typeparam>
        /// <typeparam name="TFourth">参数类型4</typeparam>
        /// <typeparam name="TFifth">参数类型5</typeparam>
        /// <typeparam name="TSixth">参数类型6</typeparam>
        /// <typeparam name="TSeventh">参数类型7</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<List<TReturn>> ToListAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>( this ISqlQuery sqlQuery,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, IDbConnection connection = null ) {
            return await sqlQuery.QueryAsync( async ( con, sql, sqlParmas ) => ( await con.QueryAsync( sql, map, sqlParmas ) ).ToList(), connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static PagerList<TReturn> ToPagerList<TFirst, TSecond, TReturn>( this ISqlQuery sqlQuery, 
            Func<TFirst, TSecond, TReturn> map, IPager parameter, IDbConnection connection = null ) {
            return sqlQuery.PagerQuery( () => sqlQuery.ToList( map, connection ), parameter, connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TThird">参数类型3</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static PagerList<TReturn> ToPagerList<TFirst, TSecond, TThird, TReturn>( this ISqlQuery sqlQuery, 
            Func<TFirst, TSecond, TThird, TReturn> map, IPager parameter, IDbConnection connection = null ) {
            return sqlQuery.PagerQuery( () => sqlQuery.ToList( map, connection ), parameter, connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TThird">参数类型3</typeparam>
        /// <typeparam name="TFourth">参数类型4</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static PagerList<TReturn> ToPagerList<TFirst, TSecond, TThird, TFourth, TReturn>( this ISqlQuery sqlQuery,
            Func<TFirst, TSecond, TThird, TFourth, TReturn> map, IPager parameter, IDbConnection connection = null ) {
            return sqlQuery.PagerQuery( () => sqlQuery.ToList( map, connection ), parameter, connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TThird">参数类型3</typeparam>
        /// <typeparam name="TFourth">参数类型4</typeparam>
        /// <typeparam name="TFifth">参数类型5</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static PagerList<TReturn> ToPagerList<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>( this ISqlQuery sqlQuery,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, IPager parameter, IDbConnection connection = null ) {
            return sqlQuery.PagerQuery( () => sqlQuery.ToList( map, connection ), parameter, connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TThird">参数类型3</typeparam>
        /// <typeparam name="TFourth">参数类型4</typeparam>
        /// <typeparam name="TFifth">参数类型5</typeparam>
        /// <typeparam name="TSixth">参数类型6</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static PagerList<TReturn> ToPagerList<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>( this ISqlQuery sqlQuery,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, IPager parameter, IDbConnection connection = null ) {
            return sqlQuery.PagerQuery( () => sqlQuery.ToList( map, connection ), parameter, connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TThird">参数类型3</typeparam>
        /// <typeparam name="TFourth">参数类型4</typeparam>
        /// <typeparam name="TFifth">参数类型5</typeparam>
        /// <typeparam name="TSixth">参数类型6</typeparam>
        /// <typeparam name="TSeventh">参数类型7</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static PagerList<TReturn> ToPagerList<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>( this ISqlQuery sqlQuery,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, IPager parameter, IDbConnection connection = null ) {
            return sqlQuery.PagerQuery( () => sqlQuery.ToList( map, connection ), parameter, connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<PagerList<TReturn>> ToPagerListAsync<TFirst, TSecond, TReturn>( this ISqlQuery sqlQuery, Func<TFirst, TSecond, TReturn> map, IPager parameter, IDbConnection connection = null ) {
            return await sqlQuery.PagerQueryAsync( async () => await sqlQuery.ToListAsync( map, connection ), parameter, connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TThird">参数类型3</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<PagerList<TReturn>> ToPagerListAsync<TFirst, TSecond, TThird, TReturn>( this ISqlQuery sqlQuery, 
            Func<TFirst, TSecond, TThird, TReturn> map, IPager parameter, IDbConnection connection = null ) {
            return await sqlQuery.PagerQueryAsync( async () => await sqlQuery.ToListAsync( map, connection ), parameter, connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TThird">参数类型3</typeparam>
        /// <typeparam name="TFourth">参数类型4</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<PagerList<TReturn>> ToPagerListAsync<TFirst, TSecond, TThird, TFourth, TReturn>( this ISqlQuery sqlQuery,
            Func<TFirst, TSecond, TThird, TFourth, TReturn> map, IPager parameter, IDbConnection connection = null ) {
            return await sqlQuery.PagerQueryAsync( async () => await sqlQuery.ToListAsync( map, connection ), parameter, connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TThird">参数类型3</typeparam>
        /// <typeparam name="TFourth">参数类型4</typeparam>
        /// <typeparam name="TFifth">参数类型5</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<PagerList<TReturn>> ToPagerListAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>( this ISqlQuery sqlQuery,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, IPager parameter, IDbConnection connection = null ) {
            return await sqlQuery.PagerQueryAsync( async () => await sqlQuery.ToListAsync( map, connection ), parameter, connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TThird">参数类型3</typeparam>
        /// <typeparam name="TFourth">参数类型4</typeparam>
        /// <typeparam name="TFifth">参数类型5</typeparam>
        /// <typeparam name="TSixth">参数类型6</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<PagerList<TReturn>> ToPagerListAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>( this ISqlQuery sqlQuery,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, IPager parameter, IDbConnection connection = null ) {
            return await sqlQuery.PagerQueryAsync( async () => await sqlQuery.ToListAsync( map, connection ), parameter, connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TFirst">参数类型1</typeparam>
        /// <typeparam name="TSecond">参数类型2</typeparam>
        /// <typeparam name="TThird">参数类型3</typeparam>
        /// <typeparam name="TFourth">参数类型4</typeparam>
        /// <typeparam name="TFifth">参数类型5</typeparam>
        /// <typeparam name="TSixth">参数类型6</typeparam>
        /// <typeparam name="TSeventh">参数类型7</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<PagerList<TReturn>> ToPagerListAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>( this ISqlQuery sqlQuery,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, IPager parameter, IDbConnection connection = null ) {
            return await sqlQuery.PagerQueryAsync( async () => await sqlQuery.ToListAsync( map, connection ), parameter, connection );
        }
    }
}
