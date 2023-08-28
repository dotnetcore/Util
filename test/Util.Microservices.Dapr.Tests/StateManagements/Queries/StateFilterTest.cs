using Util.Microservices.Dapr.Tests.Samples;

namespace Util.Microservices.Dapr.Tests.StateManagements.Queries;

/// <summary>
/// 状态过滤器测试
/// </summary>
public class StateFilterTest {

    #region 测试初始化

    /// <summary>
    /// 状态过滤器
    /// </summary>
    private readonly StateFilter _filter;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public StateFilterTest() {
        _filter = new StateFilter();
    }

    #endregion

    #region 默认输出

    /// <summary>
    /// 测试默认输出
    /// </summary>
    [Fact]
    public void TestDefault() {
        var json = Json.ToJson( _filter.GetCondition() );
        Assert.Equal( "", json );
    }

    #endregion

    #region Equal

    /// <summary>
    /// 测试添加相等条件 - 1个相等条件
    /// </summary>
    [Fact]
    public void TestEqual_1() {
        _filter.Equal( "a","1" );
        var json = Json.ToJson( _filter.GetCondition() );
        Assert.Equal( "{\"EQ\":{\"a\":\"1\"}}", json );
    }

    /// <summary>
    /// 测试添加相等条件 - 2个相等条件
    /// </summary>
    [Fact]
    public void TestEqual_2() {
        //添加2个相等条件
        _filter.Equal( "a", "1" );
        _filter.Equal( "b", "2" );
        var json = Json.ToJson( _filter.GetCondition() );

        //结果
        var result = new StringBuilder();
        result.Append( "{" );
        result.Append( "\"AND\":[" );
        result.Append( "{\"EQ\":{\"a\":\"1\"}}," );
        result.Append( "{\"EQ\":{\"b\":\"2\"}}" );
        result.Append( "]" );
        result.Append( "}" );

        //验证
        Assert.Equal( result.ToString(), json );
    }

    /// <summary>
    /// 测试添加相等条件 - 属性表达式
    /// </summary>
    [Fact]
    public void TestEqual_3() {
        _filter.Equal<CustomerDto2>( t => t.Product.CreationTime, "1" );
        var json = Json.ToJson( _filter.GetCondition() );
        Assert.Equal( "{\"EQ\":{\"product.creationTime\":\"1\"}}", json );
    }

    #endregion

    #region In

    /// <summary>
    /// 测试添加In条件 - 1个In条件
    /// </summary>
    [Fact]
    public void TestIn_1() {
        _filter.In( "a", new[] { "1", "2" } );
        var json = Json.ToJson( _filter.GetCondition() );
        Assert.Equal( "{\"IN\":{\"a\":[\"1\",\"2\"]}}", json );
    }

    /// <summary>
    /// 测试添加In条件 - 2个In条件
    /// </summary>
    [Fact]
    public void TestIn_2() {
        _filter.In( "a", new[] { "1", "2" } );
        _filter.In( "b", new[] { "3", "4" } );
        var json = Json.ToJson( _filter.GetCondition() );

        //结果
        var result = new StringBuilder();
        result.Append( "{" );
        result.Append( "\"AND\":[" );
        result.Append( "{\"IN\":{\"a\":[\"1\",\"2\"]}}," );
        result.Append( "{\"IN\":{\"b\":[\"3\",\"4\"]}}" );
        result.Append( "]" );
        result.Append( "}" );

        //验证
        Assert.Equal( result.ToString(), json );
    }

    /// <summary>
    /// 测试添加In条件 - 属性表达式
    /// </summary>
    [Fact]
    public void TestIn_3() {
        _filter.In<CustomerDto2>( t => t.Product.CreationTime, new[] { "1", "2" } );
        var json = Json.ToJson( _filter.GetCondition() );
        Assert.Equal( "{\"IN\":{\"product.creationTime\":[\"1\",\"2\"]}}", json );
    }

    #endregion

    #region Or

    /// <summary>
    /// 测试添加Or条件
    /// </summary>
    [Fact]
    public void TestOr() {
        //添加相等条件
        _filter.Equal( "a", "1" );

        //添加Or条件
        _filter.Or( new EqualCondition( "b", "2" ) );
        var json = Json.ToJson( _filter.GetCondition() );

        //结果
        var result = new StringBuilder();
        result.Append( "{" );
        result.Append( "\"OR\":[" );
        result.Append( "{\"EQ\":{\"a\":\"1\"}}," );
        result.Append( "{\"EQ\":{\"b\":\"2\"}}" );
        result.Append( "]" );
        result.Append( "}" );

        //验证
        Assert.Equal( result.ToString(), json );
    }

    #endregion
}