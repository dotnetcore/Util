using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Util.Datas.Sql;
using Util.Domains.Repositories;

namespace Util.Datas.Dapper {
    /// <summary>
    /// 查询对象扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static List<TReturn> ToList<T1, T2, TReturn>( this ISqlQuery sqlQuery, Func<T1, T2, TReturn> map, IDbConnection connection = null ) {
            return sqlQuery.Query( ( con, sql, sqlParmas ) => con.Query( sql, map, sqlParmas ).ToList(), connection );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="T3">参数类型3</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static List<TReturn> ToList<T1, T2, T3, TReturn>( this ISqlQuery sqlQuery, Func<T1, T2, T3, TReturn> map, IDbConnection connection = null ) {
            return sqlQuery.Query( ( con, sql, sqlParmas ) => con.Query( sql, map, sqlParmas ).ToList(), connection );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="T3">参数类型3</typeparam>
        /// <typeparam name="T4">参数类型4</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static List<TReturn> ToList<T1, T2, T3, T4, TReturn>( this ISqlQuery sqlQuery, Func<T1, T2, T3, T4, TReturn> map, IDbConnection connection = null ) {
            return sqlQuery.Query( ( con, sql, sqlParmas ) => con.Query( sql, map, sqlParmas ).ToList(), connection );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="T3">参数类型3</typeparam>
        /// <typeparam name="T4">参数类型4</typeparam>
        /// <typeparam name="T5">参数类型5</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static List<TReturn> ToList<T1, T2, T3, T4, T5, TReturn>( this ISqlQuery sqlQuery, 
            Func<T1, T2, T3, T4, T5, TReturn> map, IDbConnection connection = null ) {
            return sqlQuery.Query( ( con, sql, sqlParmas ) => con.Query( sql, map, sqlParmas ).ToList(), connection );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="T3">参数类型3</typeparam>
        /// <typeparam name="T4">参数类型4</typeparam>
        /// <typeparam name="T5">参数类型5</typeparam>
        /// <typeparam name="T6">参数类型6</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static List<TReturn> ToList<T1, T2, T3, T4, T5, T6, TReturn>( this ISqlQuery sqlQuery,
            Func<T1, T2, T3, T4, T5, T6, TReturn> map, IDbConnection connection = null ) {
            return sqlQuery.Query( ( con, sql, sqlParmas ) => con.Query( sql, map, sqlParmas ).ToList(), connection );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="T3">参数类型3</typeparam>
        /// <typeparam name="T4">参数类型4</typeparam>
        /// <typeparam name="T5">参数类型5</typeparam>
        /// <typeparam name="T6">参数类型6</typeparam>
        /// <typeparam name="T7">参数类型7</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static List<TReturn> ToList<T1, T2, T3, T4, T5, T6, T7, TReturn>( this ISqlQuery sqlQuery,
            Func<T1, T2, T3, T4, T5, T6, T7, TReturn> map, IDbConnection connection = null ) {
            return sqlQuery.Query( ( con, sql, sqlParmas ) => con.Query( sql, map, sqlParmas ).ToList(), connection );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<List<TReturn>> ToListAsync<T1, T2, TReturn>( this ISqlQuery sqlQuery, Func<T1, T2, TReturn> map, IDbConnection connection = null ) {
            return await sqlQuery.QueryAsync( async ( con, sql, sqlParmas ) => ( await con.QueryAsync( sql, map, sqlParmas ) ).ToList(), connection );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="T3">参数类型3</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<List<TReturn>> ToListAsync<T1, T2, T3, TReturn>( this ISqlQuery sqlQuery, 
            Func<T1, T2, T3, TReturn> map, IDbConnection connection = null ) {
            return await sqlQuery.QueryAsync( async ( con, sql, sqlParmas ) => ( await con.QueryAsync( sql, map, sqlParmas ) ).ToList(), connection );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="T3">参数类型3</typeparam>
        /// <typeparam name="T4">参数类型4</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<List<TReturn>> ToListAsync<T1, T2, T3, T4, TReturn>( this ISqlQuery sqlQuery,
            Func<T1, T2, T3, T4, TReturn> map, IDbConnection connection = null ) {
            return await sqlQuery.QueryAsync( async ( con, sql, sqlParmas ) => ( await con.QueryAsync( sql, map, sqlParmas ) ).ToList(), connection );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="T3">参数类型3</typeparam>
        /// <typeparam name="T4">参数类型4</typeparam>
        /// <typeparam name="T5">参数类型5</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<List<TReturn>> ToListAsync<T1, T2, T3, T4, T5, TReturn>( this ISqlQuery sqlQuery,
            Func<T1, T2, T3, T4, T5, TReturn> map, IDbConnection connection = null ) {
            return await sqlQuery.QueryAsync( async ( con, sql, sqlParmas ) => ( await con.QueryAsync( sql, map, sqlParmas ) ).ToList(), connection );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="T3">参数类型3</typeparam>
        /// <typeparam name="T4">参数类型4</typeparam>
        /// <typeparam name="T5">参数类型5</typeparam>
        /// <typeparam name="T6">参数类型6</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<List<TReturn>> ToListAsync<T1, T2, T3, T4, T5, T6, TReturn>( this ISqlQuery sqlQuery,
            Func<T1, T2, T3, T4, T5, T6, TReturn> map, IDbConnection connection = null ) {
            return await sqlQuery.QueryAsync( async ( con, sql, sqlParmas ) => ( await con.QueryAsync( sql, map, sqlParmas ) ).ToList(), connection );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="T3">参数类型3</typeparam>
        /// <typeparam name="T4">参数类型4</typeparam>
        /// <typeparam name="T5">参数类型5</typeparam>
        /// <typeparam name="T6">参数类型6</typeparam>
        /// <typeparam name="T7">参数类型7</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<List<TReturn>> ToListAsync<T1, T2, T3, T4, T5, T6, T7, TReturn>( this ISqlQuery sqlQuery,
            Func<T1, T2, T3, T4, T5, T6, T7, TReturn> map, IDbConnection connection = null ) {
            return await sqlQuery.QueryAsync( async ( con, sql, sqlParmas ) => ( await con.QueryAsync( sql, map, sqlParmas ) ).ToList(), connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static PagerList<TReturn> ToPagerList<T1, T2, TReturn>( this ISqlQuery sqlQuery, 
            Func<T1, T2, TReturn> map, IPager parameter = null, IDbConnection connection = null ) {
            return sqlQuery.PagerQuery( () => sqlQuery.ToList( map, connection ), parameter, connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="T3">参数类型3</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static PagerList<TReturn> ToPagerList<T1, T2, T3, TReturn>( this ISqlQuery sqlQuery, 
            Func<T1, T2, T3, TReturn> map, IPager parameter = null, IDbConnection connection = null ) {
            return sqlQuery.PagerQuery( () => sqlQuery.ToList( map, connection ), parameter, connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="T3">参数类型3</typeparam>
        /// <typeparam name="T4">参数类型4</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static PagerList<TReturn> ToPagerList<T1, T2, T3, T4, TReturn>( this ISqlQuery sqlQuery,
            Func<T1, T2, T3, T4, TReturn> map, IPager parameter = null, IDbConnection connection = null ) {
            return sqlQuery.PagerQuery( () => sqlQuery.ToList( map, connection ), parameter, connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="T3">参数类型3</typeparam>
        /// <typeparam name="T4">参数类型4</typeparam>
        /// <typeparam name="T5">参数类型5</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static PagerList<TReturn> ToPagerList<T1, T2, T3, T4, T5, TReturn>( this ISqlQuery sqlQuery,
            Func<T1, T2, T3, T4, T5, TReturn> map, IPager parameter = null, IDbConnection connection = null ) {
            return sqlQuery.PagerQuery( () => sqlQuery.ToList( map, connection ), parameter, connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="T3">参数类型3</typeparam>
        /// <typeparam name="T4">参数类型4</typeparam>
        /// <typeparam name="T5">参数类型5</typeparam>
        /// <typeparam name="T6">参数类型6</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static PagerList<TReturn> ToPagerList<T1, T2, T3, T4, T5, T6, TReturn>( this ISqlQuery sqlQuery,
            Func<T1, T2, T3, T4, T5, T6, TReturn> map, IPager parameter = null, IDbConnection connection = null ) {
            return sqlQuery.PagerQuery( () => sqlQuery.ToList( map, connection ), parameter, connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="T3">参数类型3</typeparam>
        /// <typeparam name="T4">参数类型4</typeparam>
        /// <typeparam name="T5">参数类型5</typeparam>
        /// <typeparam name="T6">参数类型6</typeparam>
        /// <typeparam name="T7">参数类型7</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static PagerList<TReturn> ToPagerList<T1, T2, T3, T4, T5, T6, T7, TReturn>( this ISqlQuery sqlQuery,
            Func<T1, T2, T3, T4, T5, T6, T7, TReturn> map, IPager parameter = null, IDbConnection connection = null ) {
            return sqlQuery.PagerQuery( () => sqlQuery.ToList( map, connection ), parameter, connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<PagerList<TReturn>> ToPagerListAsync<T1, T2, TReturn>( this ISqlQuery sqlQuery, Func<T1, T2, TReturn> map, IPager parameter = null, IDbConnection connection = null ) {
            return await sqlQuery.PagerQueryAsync( async () => await sqlQuery.ToListAsync( map, connection ), parameter, connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="T3">参数类型3</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<PagerList<TReturn>> ToPagerListAsync<T1, T2, T3, TReturn>( this ISqlQuery sqlQuery, 
            Func<T1, T2, T3, TReturn> map, IPager parameter = null, IDbConnection connection = null ) {
            return await sqlQuery.PagerQueryAsync( async () => await sqlQuery.ToListAsync( map, connection ), parameter, connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="T3">参数类型3</typeparam>
        /// <typeparam name="T4">参数类型4</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<PagerList<TReturn>> ToPagerListAsync<T1, T2, T3, T4, TReturn>( this ISqlQuery sqlQuery,
            Func<T1, T2, T3, T4, TReturn> map, IPager parameter = null, IDbConnection connection = null ) {
            return await sqlQuery.PagerQueryAsync( async () => await sqlQuery.ToListAsync( map, connection ), parameter, connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="T3">参数类型3</typeparam>
        /// <typeparam name="T4">参数类型4</typeparam>
        /// <typeparam name="T5">参数类型5</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<PagerList<TReturn>> ToPagerListAsync<T1, T2, T3, T4, T5, TReturn>( this ISqlQuery sqlQuery,
            Func<T1, T2, T3, T4, T5, TReturn> map, IPager parameter = null, IDbConnection connection = null ) {
            return await sqlQuery.PagerQueryAsync( async () => await sqlQuery.ToListAsync( map, connection ), parameter, connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="T3">参数类型3</typeparam>
        /// <typeparam name="T4">参数类型4</typeparam>
        /// <typeparam name="T5">参数类型5</typeparam>
        /// <typeparam name="T6">参数类型6</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<PagerList<TReturn>> ToPagerListAsync<T1, T2, T3, T4, T5, T6, TReturn>( this ISqlQuery sqlQuery,
            Func<T1, T2, T3, T4, T5, T6, TReturn> map, IPager parameter = null, IDbConnection connection = null ) {
            return await sqlQuery.PagerQueryAsync( async () => await sqlQuery.ToListAsync( map, connection ), parameter, connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="T1">参数类型1</typeparam>
        /// <typeparam name="T2">参数类型2</typeparam>
        /// <typeparam name="T3">参数类型3</typeparam>
        /// <typeparam name="T4">参数类型4</typeparam>
        /// <typeparam name="T5">参数类型5</typeparam>
        /// <typeparam name="T6">参数类型6</typeparam>
        /// <typeparam name="T7">参数类型7</typeparam>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="map">映射操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public static async Task<PagerList<TReturn>> ToPagerListAsync<T1, T2, T3, T4, T5, T6, T7, TReturn>( this ISqlQuery sqlQuery,
            Func<T1, T2, T3, T4, T5, T6, T7, TReturn> map, IPager parameter = null, IDbConnection connection = null ) {
            return await sqlQuery.PagerQueryAsync( async () => await sqlQuery.ToListAsync( map, connection ), parameter, connection );
        }
    }
}
