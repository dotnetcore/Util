using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using String = Util.Helpers.String;

namespace Util.Tests.Helpers;

/// <summary>
/// 测试字符串操作 - 工具库
/// </summary>
public class StringTest {

    #region Join

    /// <summary>
    /// 测试将集合连接为带分隔符的字符串
    /// </summary>
    [Fact]
    public void TestJoin() {
        Assert.Equal( "1,2,3", String.Join( new List<int> { 1, 2, 3 } ) );
        Assert.Equal( "'1','2','3'", String.Join( new List<int> { 1, 2, 3 }, "'" ) );
        Assert.Equal( "123", String.Join( new List<int> { 1, 2, 3 }, "", "" ) );
        Assert.Equal( "\"1\",\"2\",\"3\"", String.Join( new List<int> { 1, 2, 3 }, "\"" ) );
        Assert.Equal( "1 2 3", String.Join( new List<int> { 1, 2, 3 }, "", " " ) );
        Assert.Equal( "1;2;3", String.Join( new List<int> { 1, 2, 3 }, "", ";" ) );
        Assert.Equal( "1,2,3", String.Join( new List<string> { "1", "2", "3" } ) );
        Assert.Equal( "'1','2','3'", String.Join( new List<string> { "1", "2", "3" }, "'" ) );

        var list = new List<Guid> {
            new( "83B0233C-A24F-49FD-8083-1337209EBC9A" ),
            new( "EAB523C6-2FE7-47BE-89D5-C6D440C3033A" )
        };
        Assert.Equal( "83B0233C-A24F-49FD-8083-1337209EBC9A,EAB523C6-2FE7-47BE-89D5-C6D440C3033A".ToLower(), String.Join( list ) );
        Assert.Equal( "'83B0233C-A24F-49FD-8083-1337209EBC9A','EAB523C6-2FE7-47BE-89D5-C6D440C3033A'".ToLower(), String.Join( list, "'" ) );
    }

    #endregion

    #region FirstLowerCase

    /// <summary>
    /// 首字母小写
    /// </summary>
    [Theory]
    [InlineData( null, "" )]
    [InlineData( "", "" )]
    [InlineData( " ", "" )]
    [InlineData( "a", "a" )]
    [InlineData( "A", "a" )]
    [InlineData( "Ab", "ab" )]
    [InlineData( "AB", "aB" )]
    [InlineData( "Abc", "abc" )]
    public void TestFirstLowerCase( string value, string result ) {
        Assert.Equal( result, String.FirstLowerCase( value ) );
    }

    #endregion

    #region FirstUpperCase

    /// <summary>
    /// 首字母大写
    /// </summary>
    [Theory]
    [InlineData( null, "" )]
    [InlineData( "", "" )]
    [InlineData( " ", "" )]
    [InlineData( "a", "A" )]
    [InlineData( "A", "A" )]
    [InlineData( "Ab", "Ab" )]
    [InlineData( "aB", "AB" )]
    [InlineData( "abc", "Abc" )]
    public void TestFirstUpperCase( string value, string result ) {
        Assert.Equal( result, String.FirstUpperCase( value ) );
    }

    #endregion

    #region RemoveStart

    /// <summary>
    /// 测试移除起始字符串
    /// </summary>
    [Theory]
    [InlineData( null, null, "" )]
    [InlineData( null, "a", "" )]
    [InlineData( "", "", "" )]
    [InlineData( "a", "b", "a" )]
    [InlineData( "ab", "b", "ab" )]
    [InlineData( "ab", "a", "b" )]
    [InlineData( "abc", "ab", "c" )]
    [InlineData( "abc", "abc", "" )]
    [InlineData( "ab", "abc", "ab" )]
    [InlineData( "a.cs.cshtml", "a.cs", ".cshtml" )]
    [InlineData( "\r\na", "\r\n", "a" )]
    public void TestRemoveStart( string value, string removeValue, string result ) {
        Assert.Equal( result, String.RemoveStart( value, removeValue ) );
    }

    /// <summary>
    /// 测试移除起始字符串 - 大小写
    /// </summary>
    [Fact]
    public void TestRemoveStart_2() {
        Assert.Equal( ".cs", String.RemoveStart( "ab.cs", "Ab" ) );
        Assert.Equal( "ab.cs", String.RemoveStart( "ab.cs", "Ab", false ) );
    }

    /// <summary>
    /// 测试移除起始字符串
    /// </summary>
    [Theory]
    [InlineData( null, null, null )]
    [InlineData( null, "a", null )]
    public void TestRemoveStart_StringBuilder( StringBuilder value, string removeValue, string result ) {
        Assert.Equal( result, Util.Helpers.String.RemoveStart( value, removeValue )?.ToString() );
    }

    /// <summary>
    /// 测试移除起始字符串
    /// </summary>
    [Theory]
    [InlineData( null, null, null )]
    [InlineData( null, "a", null )]
    [InlineData( "", "", null )]
    [InlineData( "a", "b", "a" )]
    [InlineData( "ab", "b", "ab" )]
    [InlineData( "ab", "a", "b" )]
    [InlineData( "abc", "ab", "c" )]
    [InlineData( "abc", "Ab", "abc" )]
    [InlineData( "abc", "abc", "" )]
    [InlineData( "ab", "abc", "ab" )]
    [InlineData( "a.cs.cshtml", "a.cs", ".cshtml" )]
    [InlineData( "\r\na", "\r\n", "a" )]
    public void TestRemoveStart_StringBuilder_2( string value, string removeValue, string result ) {
        var builder = new StringBuilder( value );
        Assert.Equal( result, Util.Helpers.String.RemoveStart( builder, removeValue )?.ToString() );
    }

    #endregion

    #region RemoveEnd

    /// <summary>
    /// 测试移除末尾字符串
    /// </summary>
    [Theory]
    [InlineData( null, null, "" )]
    [InlineData( null, "a", "" )]
    [InlineData( "", "", "" )]
    [InlineData( "a", "b", "a" )]
    [InlineData( "ab", "a", "ab" )]
    [InlineData( "ab", "b", "a" )]
    [InlineData( "abc", "abc", "" )]
    [InlineData( "bc", "abc", "bc" )]
    [InlineData( "ab", "abc", "ab" )]
    [InlineData( "a.cs.cshtml", ".cshtml", "a.cs" )]
    [InlineData( "a\r\n", "\r\n", "a" )]
    public void TestRemoveEnd( string value, string removeValue, string result ) {
        Assert.Equal( result, String.RemoveEnd( value, removeValue, false ) );
    }

    /// <summary>
    /// 测试移除末尾字符串 - 大小写
    /// </summary>
    [Fact]
    public void TestRemoveEnd_2() {
        Assert.Equal( "ab", String.RemoveEnd( "ab.cs", ".Cs" ) );
        Assert.Equal( "ab.cs", String.RemoveEnd( "ab.cs", ".Cs", false ) );
    }

    /// <summary>
    /// 测试移除末尾字符串
    /// </summary>
    [Theory]
    [InlineData( null, null, null )]
    [InlineData( null, "a", null )]
    public void TestRemoveEnd_StringBuilder( StringBuilder value, string removeValue, string result ) {
        Assert.Equal( result, Util.Helpers.String.RemoveEnd( value, removeValue )?.ToString() );
    }

    /// <summary>
    /// 测试移除末尾字符串
    /// </summary>
    [Theory]
    [InlineData( null, null, null )]
    [InlineData( null, "a", null )]
    [InlineData( "", "", null )]
    [InlineData( "a", "b", "a" )]
    [InlineData( "ab", "a", "ab" )]
    [InlineData( "ab", "b", "a" )]
    [InlineData( "abc", "abc", "" )]
    [InlineData( "bc", "abc", "bc" )]
    [InlineData( "ab", "abc", "ab" )]
    [InlineData( "a.cs.cshtml", ".cshtml", "a.cs" )]
    [InlineData( "a\r\n", "\r\n", "a" )]
    public void TestRemoveEnd_StringBuilder_2( string value, string removeValue, string result ) {
        var builder = new StringBuilder( value );
        Assert.Equal( result, Util.Helpers.String.RemoveEnd( builder, removeValue )?.ToString() );
    }

    #endregion

    #region PinYin

    /// <summary>
    /// 测试获取拼音简码
    /// </summary>
    [Theory]
    [InlineData( null, "" )]
    [InlineData( "", "" )]
    [InlineData( "中国", "zg" )]
    [InlineData( "a1宝藏b2", "a1bcb2" )]
    [InlineData( "饕餮", "tt" )]
    [InlineData( "爩", "y" )]
    public void TestPinYin( string input, string result ) {
        Assert.Equal( result, String.PinYin( input ) );
    }

    #endregion

    #region Extract

    /// <summary>
    /// 测试提取字符串中的变量值 - 原始值为空
    /// </summary>
    [Fact]
    public void TestExtract_1() {
        var result = String.Extract( "", "a" );
        Assert.Empty( result );
    }

    /// <summary>
    /// 测试提取字符串中的变量值 - 格式字符串为空
    /// </summary>
    [Fact]
    public void TestExtract_2() {
        var result = String.Extract( "a", "" );
        Assert.Empty( result );
    }

    /// <summary>
    /// 测试提取字符串中的变量值 - 格式字符串未包含{}
    /// </summary>
    [Fact]
    public void TestExtract_3() {
        var result = String.Extract( "a", "a" );
        Assert.Empty( result );
    }

    /// <summary>
    /// 测试提取字符串中的变量值 - 格式字符串未包含{}
    /// </summary>
    [Fact]
    public void TestExtract_4() {
        var result = String.Extract( "a", "{value}" );
        Assert.Single( result );
        Assert.Equal( "a", result["value"] );
    }

    /// <summary>
    /// 测试提取字符串中的变量值 - 值前后有空格
    /// </summary>
    [Fact]
    public void TestExtract_5() {
        var result = String.Extract( " a ", "{value}" );
        Assert.Single( result );
        Assert.Equal( "a", result["value"] );
    }

    /// <summary>
    /// 测试提取字符串中的变量值 - 格式字符串前后有空格
    /// </summary>
    [Fact]
    public void TestExtract_6() {
        var result = String.Extract( "a", "  {value}  " );
        Assert.Single( result );
        Assert.Equal( "a", result["value"] );
    }

    /// <summary>
    /// 测试提取字符串中的变量值 - 格式字符串左侧有文本 - 忽略大小写
    /// </summary>
    [Fact]
    public void TestExtract_7() {
        var result = String.Extract( "Hello,World", "hello,{value}" );
        Assert.Single( result );
        Assert.Equal( "World", result["value"] );
    }

    /// <summary>
    /// 测试提取字符串中的变量值 - 格式字符串右侧有文本 - 忽略大小写
    /// </summary>
    [Fact]
    public void TestExtract_8() {
        var result = String.Extract( "Hello,World", "{value},world" );
        Assert.Single( result );
        Assert.Equal( "Hello", result["value"] );
    }

    /// <summary>
    /// 测试提取字符串中的变量值 - 格式字符串左右侧都有文本
    /// </summary>
    [Fact]
    public void TestExtract_9() {
        var result = String.Extract( "Hello,Util,World", "Hello,{value},world" );
        Assert.Single( result );
        Assert.Equal( "Util", result["value"] );
    }

    /// <summary>
    /// 测试提取字符串中的变量值 - 格式字符串包含两个变量 - 左侧文本
    /// </summary>
    [Fact]
    public void TestExtract_10() {
        var result = String.Extract( "Hello,Util,World", "Hello,{a},{b}" );
        Assert.Equal( 2, result.Count );
        Assert.Equal( "Util", result["a"] );
        Assert.Equal( "World", result["b"] );
    }

    /// <summary>
    /// 测试提取字符串中的变量值 - 格式字符串包含两个变量 - 右侧文本
    /// </summary>
    [Fact]
    public void TestExtract_11() {
        var result = String.Extract( "Hello,Util,World", "{a},{b},World" );
        Assert.Equal( 2, result.Count );
        Assert.Equal( "Hello", result["a"] );
        Assert.Equal( "Util", result["b"] );
    }

    /// <summary>
    /// 测试提取字符串中的变量值 - 格式字符串包含两个变量 - 重复文本
    /// </summary>
    [Fact]
    public void TestExtract_12() {
        var result = String.Extract( "Hello,Util,Hello,Test,Hello,World", "Hello,{a},Hello,{b},Hello,World" );
        Assert.Equal( 2, result.Count );
        Assert.Equal( "Util", result["a"] );
        Assert.Equal( "Test", result["b"] );
    }

    /// <summary>
    /// 测试提取字符串中的变量值 - 没有分隔符
    /// </summary>
    [Fact]
    public void TestExtract_13() {
        var result = String.Extract( "acababcabcd", "a{b}c{d}" );
        Assert.Equal( 2, result.Count );
        Assert.Equal( "cabab", result["b"] );
        Assert.Equal( "abcd", result["d"] );
    }

    /// <summary>
    /// 测试提取字符串中的变量值 - 未匹配到变量b
    /// </summary>
    [Fact]
    public void TestExtract_14() {
        var result = String.Extract( "Hello,Util,World", "Hello,{a},{b},World" );
        Assert.Equal( 2, result.Count );
        Assert.Equal( "Util", result["a"] );
        Assert.Equal( "", result["b"] );
    }

    /// <summary>
    /// 测试提取字符串中的变量值 - 多个括号
    /// </summary>
    [Fact]
    public void TestExtract_15() {
        var result = String.Extract( "Hello,Util,Hello,Test,Hello,World", "Hello,{{a}},Hello,{{{b}}},Hello,World" );
        Assert.Equal( 2, result.Count );
        Assert.Equal( "Util", result["a"] );
        Assert.Equal( "Test", result["b"] );
    }

    #endregion
}