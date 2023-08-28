using Util.Microservices.Dapr.Tests.Samples;

namespace Util.Microservices.Dapr.Tests.StateManagements.Queries;

/// <summary>
/// 状态排序对象测试
/// </summary>
public class StateSortTest {
    /// <summary>
    /// 状态查询对象
    /// </summary>
    private readonly StateSort _sort;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public StateSortTest() {
        _sort = new StateSort();
    }

    /// <summary>
    /// 测试默认输出
    /// </summary>
    [Fact]
    public void TestDefault() {
        var json = Util.Helpers.Json.ToJson( _sort );
        Assert.Equal( "[]", json );
    }

    /// <summary>
    /// 测试添加排序条件 - 1个升序字段
    /// </summary>
    [Fact]
    public void TestOrderBy_1() {
        _sort.OrderBy( "a" );
        var json = Util.Helpers.Json.ToJson( _sort );

        //结果
        var result = new StringBuilder();
        result.Append( "[" );
        result.Append( "{\"key\":\"a\"}" );
        result.Append( "]" );
        Assert.Equal( result.ToString(), json );
    }

    /// <summary>
    /// 测试添加排序条件 - 1个升序字段 - 属性表达式
    /// </summary>
    [Fact]
    public void TestOrderBy_2() {
        _sort.OrderBy<CustomerDto2>( t => t.Product.CreationTime );
        var json = Util.Helpers.Json.ToJson( _sort );

        //结果
        var result = new StringBuilder();
        result.Append( "[" );
        result.Append( "{\"key\":\"product.creationTime\"}" );
        result.Append( "]" );
        Assert.Equal( result.ToString(), json );
    }

    /// <summary>
    /// 测试添加排序条件 - 1个降序字段
    /// </summary>
    [Fact]
    public void TestOrderByDescending_1() {
        _sort.OrderByDescending( "a" );
        var json = Util.Helpers.Json.ToJson( _sort );

        //结果
        var result = new StringBuilder();
        result.Append( "[" );
        result.Append( "{\"key\":\"a\"," );
        result.Append( "\"order\":\"DESC\"}" );
        result.Append( "]" );
        Assert.Equal( result.ToString(), json );
    }

    /// <summary>
    /// 测试添加排序条件 - 1个降序字段 - 属性表达式
    /// </summary>
    [Fact]
    public void TestOrderByDescending_2() {
        _sort.OrderByDescending<CustomerDto2>( t => t.Product.CreationTime );
        var json = Util.Helpers.Json.ToJson( _sort );

        //结果
        var result = new StringBuilder();
        result.Append( "[" );
        result.Append( "{\"key\":\"product.creationTime\"," );
        result.Append( "\"order\":\"DESC\"}" );
        result.Append( "]" );
        Assert.Equal( result.ToString(), json );
    }

    /// <summary>
    /// 测试添加排序条件 - 1个字段 - 升序
    /// </summary>
    [Fact]
    public void TestAdd_1() {
        _sort.Add( "a" );
        var json = Util.Helpers.Json.ToJson( _sort );

        //结果
        var result = new StringBuilder();
        result.Append( "[" );
        result.Append( "{\"key\":\"a\"}" );
        result.Append( "]" );
        Assert.Equal( result.ToString(), json );
    }

    /// <summary>
    /// 测试添加排序条件 - 2个字段
    /// </summary>
    [Fact]
    public void TestAdd_2() {
        _sort.Add( "a" );
        _sort.Add( "b desc" );
        var json = Util.Helpers.Json.ToJson( _sort );

        //结果
        var result = new StringBuilder();
        result.Append( "[" );
        result.Append( "{\"key\":\"a\"}," );
        result.Append( "{\"key\":\"b\"," );
        result.Append( "\"order\":\"DESC\"}" );
        result.Append( "]" );
        Assert.Equal( result.ToString(), json );
    }

    /// <summary>
    /// 测试添加排序条件 - 2个字段 - 一个字符串
    /// </summary>
    [Fact]
    public void TestAdd_3() {
        _sort.Add( " a    ,   b    desc  " );
        var json = Util.Helpers.Json.ToJson( _sort );

        //结果
        var result = new StringBuilder();
        result.Append( "[" );
        result.Append( "{\"key\":\"a\"}," );
        result.Append( "{\"key\":\"b\"," );
        result.Append( "\"order\":\"DESC\"}" );
        result.Append( "]" );
        Assert.Equal( result.ToString(), json );
    }
}