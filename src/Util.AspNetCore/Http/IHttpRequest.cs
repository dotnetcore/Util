using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Util.Http {
    /// <summary>
    /// Http请求
    /// </summary>
    public interface IHttpRequest {
    }

    /// <summary>
    /// Http请求
    /// </summary>
    /// <typeparam name="TResult">结果类型</typeparam>
    public interface IHttpRequest<TResult> : IHttpRequest where TResult : class {
        /// <summary>
        /// 设置字符编码
        /// </summary>
        /// <param name="encoding">字符编码,范例：gb2312</param>
        IHttpRequest<TResult> Encoding( string encoding );
        /// <summary>
        /// 设置字符编码
        /// </summary>
        /// <param name="encoding">字符编码</param>
        IHttpRequest<TResult> Encoding( Encoding encoding );
        /// <summary>
        /// 设置内容类型
        /// </summary>
        /// <param name="contentType">内容类型</param>
        IHttpRequest<TResult> ContentType( HttpContentType contentType );
        /// <summary>
        /// 设置内容类型
        /// </summary>
        /// <param name="contentType">内容类型</param>
        IHttpRequest<TResult> ContentType( string contentType );
        /// <summary>
        /// 设置证书
        /// </summary>
        /// <param name="path">证书路径</param>
        /// <param name="password">证书密码</param>
        IHttpRequest<TResult> Certificate( string path, string password );
        /// <summary>
        /// 设置Json序列化配置
        /// </summary>
        /// <param name="options">Json序列化配置</param>
        IHttpRequest<TResult> JsonSerializerOptions( JsonSerializerOptions options );
        /// <summary>
        /// 设置请求头
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        IHttpRequest<TResult> Header( string key, string value );
        /// <summary>
        /// 设置请求头
        /// </summary>
        /// <param name="headers">请求头键值对集合</param>
        IHttpRequest<TResult> Header( IDictionary<string, string> headers );
        /// <summary>
        /// 设置查询字符串,即url中?后面的参数
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        IHttpRequest<TResult> QueryString( string key, string value );
        /// <summary>
        /// 设置查询字符串,即url中?后面的参数
        /// </summary>
        /// <param name="queryString">查询字符串键值对集合</param>
        IHttpRequest<TResult> QueryString( IDictionary<string, string> queryString );
        /// <summary>
        /// 设置查询字符串,即url中?后面的参数
        /// </summary>
        /// <param name="queryString">查询字符串对象</param>
        IHttpRequest<TResult> QueryString( object queryString );
        /// <summary>
        /// 添加参数,作为请求内容发送
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        IHttpRequest<TResult> Content( string key, object value );
        /// <summary>
        /// 添加参数,作为请求内容发送
        /// </summary>
        /// <param name="parameters">参数字典</param>
        IHttpRequest<TResult> Content( IDictionary<string, object> parameters );
        /// <summary>
        /// 添加参数,作为请求内容发送
        /// </summary>
        /// <param name="value">值</param>
        IHttpRequest<TResult> Content( object value );
        /// <summary>
        /// 添加内容类型为 application/json 的参数
        /// </summary>
        /// <param name="value">值</param>
        IHttpRequest<TResult> JsonContent( object value );
        /// <summary>
        /// 添加内容类型为 text/xml 的参数
        /// </summary>
        /// <param name="value">值</param>
        IHttpRequest<TResult> XmlContent( string value );
        /// <summary>
        /// 发送前事件
        /// </summary>
        /// <param name="action">发送前操作,返回false取消发送</param>
        IHttpRequest<TResult> OnSendBefore( Func<HttpRequestMessage,bool> action );
        /// <summary>
        /// 发送后事件
        /// </summary>
        /// <param name="action">发送后操作,自定义解析返回值</param>
        IHttpRequest<TResult> OnSendAfter( Func<HttpResponseMessage, Task<TResult>> action );
        /// <summary>
        /// 结果转换事件
        /// </summary>
        /// <param name="action">结果转换操作,参数为响应内容</param>
        IHttpRequest<TResult> OnConvert( Func<string, TResult> action );
        /// <summary>
        /// 请求成功事件
        /// </summary>
        /// <param name="action">执行成功操作,参数为响应结果</param>
        IHttpRequest<TResult> OnSuccess( Action<TResult> action );
        /// <summary>
        /// 请求失败事件
        /// </summary>
        /// <param name="action">执行失败操作,参数为响应消息和响应内容</param>
        IHttpRequest<TResult> OnFail( Action<HttpResponseMessage,object> action );
        /// <summary>
        /// 请求完成事件,不论成功失败都会执行
        /// </summary>
        /// <param name="action">执行完成操作,参数为响应消息和响应内容</param>
        IHttpRequest<TResult> OnComplete( Action<HttpResponseMessage, object> action );
        /// <summary>
        /// 获取结果
        /// </summary>
        Task<TResult> GetResultAsync();
        /// <summary>
        /// 获取流
        /// </summary>
        Task<byte[]> GetStreamAsync();
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        Task WriteAsync( string filePath );
    }
}
