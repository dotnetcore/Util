using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Util.Data;
using Util.Helpers;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Helpers {
    /// <summary>
    /// 测试Lambda表达式操作
    /// </summary>
    public class LambdaTest {

        #region GetMember(获取成员)

        /// <summary>
        /// 测试获取成员
        /// </summary>
        [Fact]
        public void TestGetMember() {
            Assert.Null( Lambda.GetMember( null ) );

            Expression<Func<Sample, string>> expression = t => t.StringValue;
            Assert.Equal( "StringValue", Lambda.GetMember( expression ).Name );

            Expression<Func<Sample, string>> expression2 = t => t.Test2.StringValue;
            Assert.Equal( "StringValue", ( (PropertyInfo)Lambda.GetMember( expression2 ) ).Name );
        }

        #endregion

        #region GetName(获取成员名称)

        /// <summary>
        /// 测试获取成员名称
        /// </summary>
        [Fact]
        public void TestGetName() {
            Assert.Equal( "", Lambda.GetName( null ) );

            Expression<Func<Sample, string>> expression = t => t.StringValue;
            Assert.Equal( "StringValue", Lambda.GetName( expression ) );

            Expression<Func<Sample, string>> expression2 = t => t.Test2.StringValue;
            Assert.Equal( "Test2.StringValue", Lambda.GetName( expression2 ) );

            Expression<Func<Sample, string>> expression3 = t => t.Test2.Test3.StringValue;
            Assert.Equal( "Test2.Test3.StringValue", Lambda.GetName( expression3 ) );

            Expression<Func<Sample, int?>> expression4 = t => t.NullableIntValue;
            Assert.Equal( "NullableIntValue", Lambda.GetName( expression4 ) );

            Expression<Func<Sample, int?>> expression5 = t => t.IntValue;
            Assert.Equal( "IntValue", Lambda.GetName( expression5 ) );

            Expression<Func<Sample, bool>> expression6 = t => t.BoolValue;
            Assert.Equal( "BoolValue", Lambda.GetName( expression6 ) );

            expression6 = t => !t.BoolValue;
            Assert.Equal( "BoolValue", Lambda.GetName( expression6 ) );

            expression6 = t => !t.Test2.BoolValue;
            Assert.Equal( "Test2.BoolValue", Lambda.GetName( expression6 ) );
        }

        #endregion

        #region GetNames(获取成员名称列表)

        /// <summary>
        /// 测试获取成员名称列表
        /// </summary>
        [Fact]
        public void TestGetNames() {
            Expression<Func<Sample, object[]>> expression = ( t => new object[] { t.Test2.StringValue, t.IntValue } );
            Assert.Equal( 2, Lambda.GetNames( expression ).Count );
            Assert.Equal( "Test2.StringValue", Lambda.GetNames( expression )[0] );
            Assert.Equal( "IntValue", Lambda.GetNames( expression )[1] );
        }

        #endregion

        #region GetLastName(获取最后一级成员名称)

        /// <summary>
        /// 测试获取成员名称 - 返回类型为Object
        /// </summary>
        [Fact]
        public void TestGetLastName_Object() {
            Expression<Func<Sample, object>> expression = t => t.StringValue == "A";
            Assert.Equal( "StringValue", Lambda.GetLastName( expression ) );
        }

        /// <summary>
        /// 测试获取成员名称 - 返回类型为bool
        /// </summary>
        [Fact]
        public void TestGetLastName_Bool() {
            Assert.Empty( Lambda.GetLastName( null ) );

            Expression<Func<Sample, bool>> expression = t => t.StringValue == "A";
            Assert.Equal( "StringValue", Lambda.GetLastName( expression ) );

            Expression<Func<Sample, bool>> expression2 = t => t.Test2.IntValue == 1;
            Assert.Equal( "IntValue", Lambda.GetLastName( expression2 ) );

            Expression<Func<Sample, bool>> expression3 = t => t.Test2.Test3.StringValue == "B";
            Assert.Equal( "StringValue", Lambda.GetLastName( expression3 ) );

            expression3 = t => !t.Test2.BoolValue;
            Assert.Equal( "BoolValue", Lambda.GetLastName( expression3 ) );

            expression = t => t.StringValue == "A";
            Assert.Empty( Lambda.GetLastName( expression, true ) );

            var value = "a";
            expression = t => t.StringValue == value;
            Assert.Empty( Lambda.GetLastName( expression, true ) );

            var sample = new Sample();
            expression = t => t.StringValue == sample.StringValue;
            Assert.Empty( Lambda.GetLastName( expression, true ) );
        }

        /// <summary>
        /// 测试获取成员名称 - 运算符
        /// </summary>
        [Fact]
        public void TestGetLastName_Operation() {
            Expression<Func<Sample, bool>> expression = t => t.Test2.IntValue != 1;
            Assert.Equal( "IntValue", Lambda.GetLastName( expression ) );

            expression = t => t.Test2.IntValue > 1;
            Assert.Equal( "IntValue", Lambda.GetLastName( expression ) );

            expression = t => t.Test2.IntValue < 1;
            Assert.Equal( "IntValue", Lambda.GetLastName( expression ) );

            expression = t => t.Test2.IntValue >= 1;
            Assert.Equal( "IntValue", Lambda.GetLastName( expression ) );

            expression = t => t.Test2.IntValue <= 1;
            Assert.Equal( "IntValue", Lambda.GetLastName( expression ) );
        }

        /// <summary>
        /// 测试获取成员名称 - 可空类型
        /// </summary>
        [Fact]
        public void TestGetLastName_Nullable() {
            Expression<Func<Sample, bool>> expression = t => t.NullableIntValue == 1;
            Assert.Equal( "NullableIntValue", Lambda.GetLastName( expression ) );

            expression = t => t.NullableDecimalValue == 1.5M;
            Assert.Equal( "NullableDecimalValue", Lambda.GetLastName( expression ) );
        }

        /// <summary>
        /// 测试获取成员名称 - 方法
        /// </summary>
        [Fact]
        public void TestGetLastName_Method() {
            Expression<Func<Sample, bool>> expression = t => t.StringValue.Contains( "A" );
            Assert.Equal( "StringValue", Lambda.GetLastName( expression ) );

            expression = t => t.Test2.StringValue.Contains( "B" );
            Assert.Equal( "StringValue", Lambda.GetLastName( expression ) );

            expression = t => t.Test2.Test3.StringValue.StartsWith( "C" );
            Assert.Equal( "StringValue", Lambda.GetLastName( expression ) );

            var test = new Sample { Email = "a" };
            expression = t => t.StringValue.Contains( test.Email );
            Assert.Equal( "StringValue", Lambda.GetLastName( expression ) );
        }

        /// <summary>
        /// 测试获取成员名称 - 实例
        /// </summary>
        [Fact]
        public void TestGetLastName_Instance() {
            var test = new Sample() { StringValue = "a", Test2 = new Sample2() { StringValue = "b", Test3 = new Sample3() { StringValue = "c" } } };

            Expression<Func<string>> expression = () => test.StringValue;
            Assert.Empty( Lambda.GetLastName( expression ) );

            Expression<Func<string>> expression2 = () => test.Test2.StringValue;
            Assert.Empty( Lambda.GetLastName( expression2 ) );

            Expression<Func<string>> expression3 = () => test.Test2.Test3.StringValue;
            Assert.Empty( Lambda.GetLastName( expression3 ) );
        }

        /// <summary>
        /// 测试获取成员名称 - 复杂类型
        /// </summary>
        [Fact]
        public void TestGetLastName_Complex() {
            var test = new Sample() { StringValue = "a", Test2 = new Sample2() { StringValue = "b" } };

            Expression<Func<Sample, bool>> expression = t => t.StringValue == test.StringValue;
            Assert.Equal( "StringValue", Lambda.GetLastName( expression ) );
            Expression<Func<Sample, bool>> expression2 = t => t.StringValue == test.Test2.StringValue;
            Assert.Equal( "StringValue", Lambda.GetLastName( expression2 ) );

            Expression<Func<Sample, bool>> expression3 = t => t.StringValue.Contains( test.StringValue );
            Assert.Equal( "StringValue", Lambda.GetLastName( expression3 ) );
            Expression<Func<Sample, bool>> expression4 = t => t.StringValue.Contains( test.Test2.StringValue );
            Assert.Equal( "StringValue", Lambda.GetLastName( expression4 ) );
        }

        /// <summary>
        /// 测试获取成员名称 - 枚举
        /// </summary>
        [Fact]
        public void TestGetLastName_Enum() {
            var test1 = new Sample { NullableEnumValue = EnumSample.C };

            Expression<Func<Sample, bool>> expression = test => test.EnumValue == EnumSample.D;
            Assert.Equal( "EnumValue", Lambda.GetLastName( expression ) );

            expression = test => test.EnumValue == test1.NullableEnumValue;
            Assert.Equal( "EnumValue", Lambda.GetLastName( expression ) );

            expression = test => test.NullableEnumValue == EnumSample.E;
            Assert.Equal( "NullableEnumValue", Lambda.GetLastName( expression ) );

            expression = test => test.NullableEnumValue == test1.NullableEnumValue;
            Assert.Equal( "NullableEnumValue", Lambda.GetLastName( expression ) );

            test1.NullableEnumValue = null;
            expression = test => test.NullableEnumValue == test1.NullableEnumValue;
            Assert.Equal( "NullableEnumValue", Lambda.GetLastName( expression ) );
        }

        /// <summary>
        /// 测试获取成员名称 - 集合
        /// </summary>
        [Fact]
        public void TestGetLastName_List() {
            var list = new List<string> { "a", "b" };
            Expression<Func<Sample, bool>> expression = t => list.Contains( t.Test2.StringValue );
            Assert.Equal( "StringValue", Lambda.GetLastName( expression ) );
        }

        /// <summary>
        /// 测试获取成员名称 - 静态成员
        /// </summary>
        [Fact]
        public void TestGetLastName_Static() {
            Expression<Func<Sample, bool>> expression = t => t.StringValue == Sample.StaticString;
            Assert.Equal( "StringValue", Lambda.GetLastName( expression ) );

            expression = t => t.StringValue == Sample.StaticSample.StringValue;
            Assert.Equal( "StringValue", Lambda.GetLastName( expression ) );

            expression = t => t.Test2.StringValue == Sample.StaticString;
            Assert.Equal( "StringValue", Lambda.GetLastName( expression ) );

            expression = t => t.Test2.StringValue == Sample.StaticSample.StringValue;
            Assert.Equal( "StringValue", Lambda.GetLastName( expression ) );

            expression = t => t.Test2.StringValue.Contains( Sample.StaticSample.StringValue );
            Assert.Equal( "StringValue", Lambda.GetLastName( expression ) );
        }

        /// <summary>
        /// 测试获取成员名称 - 返回右侧表达式名称
        /// </summary>
        [Fact]
        public void TestGetLastName_Right() {
            Expression<Func<Sample, Sample2, bool>> expression = ( l, r ) => l.DisplayValue == r.Test3.StringValue;
            Assert.Equal( "DisplayValue", Lambda.GetLastName( expression ) );
            Assert.Equal( "StringValue", Lambda.GetLastName( expression, true ) );
        }

        #endregion

        #region GetLastNames(获取最后一级成员名称列表)

        /// <summary>
        /// 获取最后一级成员名称列表
        /// </summary>
        [Fact]
        public void TestGetLastNames() {
            Expression<Func<Sample, object[]>> expression = ( t => new object[] { t.Test2.StringValue, t.IntValue } );
            Assert.Equal( 2, Lambda.GetLastNames( expression ).Count );
            Assert.Equal( "StringValue", Lambda.GetLastNames( expression )[0] );
            Assert.Equal( "IntValue", Lambda.GetLastNames( expression )[1] );
        }

        #endregion

        #region GetValue(获取成员值)

        /// <summary>
        /// 测试获取成员值 - 返回类型为Object
        /// </summary>
        [Fact]
        public void TestGetValue_Object() {
            Expression<Func<Sample, object>> expression = t => t.StringValue == "A";
            Assert.Equal( "A", Lambda.GetValue( expression ) );
        }

        /// <summary>
        /// 测试获取成员值
        /// </summary>
        [Fact]
        public void TestGetValue() {
            Assert.Null( Lambda.GetValue( null ) );

            Expression<Func<Sample, bool>> expression = t => t.StringValue == "A";
            Assert.Equal( "A", Lambda.GetValue( expression ) );

            Expression<Func<Sample, bool>> expression2 = t => t.Test2.IntValue == 1;
            Assert.Equal( 1, Lambda.GetValue( expression2 ) );

            Expression<Func<Sample, bool>> expression3 = t => t.Test2.Test3.StringValue == "B";
            Assert.Equal( "B", Lambda.GetValue( expression3 ) );

            var value = Guid.NewGuid();
            Expression<Func<Sample, bool>> expression4 = t => t.GuidValue == value;
            Assert.Equal( value, Lambda.GetValue( expression4 ) );

            Expression<Func<Sample, bool>> expression5 = t => 1 == t.Test2.IntValue;
            Assert.Equal( 1, Lambda.GetValue( expression5 ) );
        }

        /// <summary>
        /// 测试获取成员值 - 布尔属性
        /// </summary>
        [Fact]
        public void TestGetValue_Bool() {
            Expression<Func<Sample, bool>> expression = t => t.BoolValue;
            Assert.Equal( "True", Lambda.GetValue( expression ).ToString() );

            expression = t => !t.BoolValue;
            Assert.Equal( "False", Lambda.GetValue( expression ).ToString() );

            expression = t => t.Test2.BoolValue;
            Assert.Equal( "True", Lambda.GetValue( expression ).ToString() );

            expression = t => !t.Test2.BoolValue;
            Assert.Equal( "False", Lambda.GetValue( expression ).ToString() );

            expression = t => t.BoolValue == true;
            Assert.Equal( "True", Lambda.GetValue( expression ).ToString() );

            expression = t => t.BoolValue == false;
            Assert.Equal( "False", Lambda.GetValue( expression ).ToString() );
        }

        /// <summary>
        /// 测试获取成员值 - Guid.NewGuid
        /// </summary>
        [Fact]
        public void TestGetValue_NewGuid() {
            Expression<Func<Sample, bool>> expression = t => t.GuidValue == Guid.NewGuid();
            var value = Lambda.GetValue( expression );
            Assert.NotEqual( Guid.Empty, Util.Helpers.Convert.ToGuid( value ) );
        }

        /// <summary>
        /// 测试获取成员值 - DateTime.Now
        /// </summary>
        [Fact]
        public void TestGetValue_DateTimeNow() {
            Expression<Func<Sample, bool>> expression = t => t.DateValue == DateTime.Now;
            var value = Lambda.GetValue( expression );
            Assert.NotNull( Util.Helpers.Convert.ToDateTimeOrNull( value ) );
        }

        /// <summary>
        /// 测试获取成员值 - 运算符
        /// </summary>
        [Fact]
        public void TestGetValue_Operation() {
            Expression<Func<Sample, bool>> expression = t => t.Test2.IntValue != 1;
            Assert.Equal( 1, Lambda.GetValue( expression ) );

            expression = t => t.Test2.IntValue > 1;
            Assert.Equal( 1, Lambda.GetValue( expression ) );

            expression = t => t.Test2.IntValue < 1;
            Assert.Equal( 1, Lambda.GetValue( expression ) );

            expression = t => t.Test2.IntValue >= 1;
            Assert.Equal( 1, Lambda.GetValue( expression ) );

            expression = t => t.Test2.IntValue <= 1;
            Assert.Equal( 1, Lambda.GetValue( expression ) );
        }

        /// <summary>
        /// 测试获取成员值 - 可空类型
        /// </summary>
        [Fact]
        public void TestGetValue_Nullable() {
            Expression<Func<Sample, bool>> expression = t => t.NullableIntValue == 1;
            Assert.Equal( 1, Lambda.GetValue( expression ) );

            expression = t => t.NullableDecimalValue == 1.5M;
            Assert.Equal( 1.5M, Lambda.GetValue( expression ) );

            var sample = new Sample();
            expression = t => t.BoolValue == sample.NullableBoolValue;
            Assert.Null( Lambda.GetValue( expression ) );
        }

        /// <summary>
        /// 测试获取成员值 - 方法
        /// </summary>
        [Fact]
        public void TestGetValue_Method() {
            Expression<Func<Sample, bool>> expression = t => t.StringValue.Contains( "A" );
            Assert.Equal( "A", Lambda.GetValue( expression ) );

            expression = t => t.Test2.StringValue.Contains( "B" );
            Assert.Equal( "B", Lambda.GetValue( expression ) );

            expression = t => t.Test2.Test3.StringValue.StartsWith( "C" );
            Assert.Equal( "C", Lambda.GetValue( expression ) );

            var test = new Sample { Email = "a" };
            expression = t => t.StringValue.Contains( test.Email );
            Assert.Equal( "a", Lambda.GetValue( expression ) );
        }

        /// <summary>
        /// 测试获取成员值 - 扩展方法
        /// </summary>
        [Fact]
        public void TestGetValue_ExtensionMethod() {
            var test = new Sample { Email = "a" };
            Expression<Func<Sample, bool>> expression = t => t.TestList.Any( a => a.StringValue == test.Email );
            Assert.Equal( "a", Lambda.GetValue( expression ) );
        }

        /// <summary>
        /// 测试获取成员值 - 扩展方法 - 值为null
        /// </summary>
        [Fact]
        public void TestGetValue_ExtensionMethod_Null() {
            var test = new Sample { Email = null };
            Expression<Func<Sample, bool>> expression = t => t.TestList.Any( a => a.StringValue == test.Email );
            Assert.Null( Lambda.GetValue( expression ) );
        }

        /// <summary>
        /// 测试获取成员值 - 实例
        /// </summary>
        [Fact]
        public void TestGetValue_Instance() {
            var test = new Sample() { StringValue = "a", BoolValue = true, Test2 = new Sample2() { StringValue = "b", Test3 = new Sample3() { StringValue = "c" } } };

            Expression<Func<string>> expression = () => test.StringValue;
            Assert.Equal( "a", Lambda.GetValue( expression ) );

            Expression<Func<string>> expression2 = () => test.Test2.StringValue;
            Assert.Equal( "b", Lambda.GetValue( expression2 ) );

            Expression<Func<string>> expression3 = () => test.Test2.Test3.StringValue;
            Assert.Equal( "c", Lambda.GetValue( expression3 ) );

            Expression<Func<bool>> expression4 = () => test.BoolValue;
            Assert.True( Util.Helpers.Convert.ToBool( Lambda.GetValue( expression4 ) ) );
        }

        /// <summary>
        /// 测试获取成员值 - 复杂类型
        /// </summary>
        [Fact]
        public void TestGetValue_Complex() {
            var test = new Sample() { StringValue = "a", Test2 = new Sample2() { StringValue = "b" } };

            Expression<Func<Sample, bool>> expression = t => t.StringValue == test.StringValue;
            Assert.Equal( "a", Lambda.GetValue( expression ) );
            Expression<Func<Sample, bool>> expression2 = t => t.StringValue == test.Test2.StringValue;
            Assert.Equal( "b", Lambda.GetValue( expression2 ) );

            Expression<Func<Sample, bool>> expression3 = t => t.StringValue.Contains( test.StringValue );
            Assert.Equal( "a", Lambda.GetValue( expression3 ) );
            Expression<Func<Sample, bool>> expression4 = t => t.StringValue.Contains( test.Test2.StringValue );
            Assert.Equal( "b", Lambda.GetValue( expression4 ) );
        }

        /// <summary>
        /// 测试获取成员值 - 枚举
        /// </summary>
        [Fact]
        public void TestGetValue_Enum() {
            var test1 = new Sample { NullableEnumValue = EnumSample.C };

            Expression<Func<Sample, bool>> expression = test => test.EnumValue == EnumSample.D;
            Assert.Equal( EnumSample.D.Value(), Util.Helpers.Enum.GetValue<EnumSample>( Lambda.GetValue( expression ) ) );

            expression = test => test.EnumValue == test1.NullableEnumValue;
            Assert.Equal( EnumSample.C, Lambda.GetValue( expression ) );

            expression = test => test.NullableEnumValue == EnumSample.E;
            Assert.Equal( EnumSample.E, Lambda.GetValue( expression ) );

            expression = test => test.NullableEnumValue == test1.NullableEnumValue;
            Assert.Equal( EnumSample.C, Lambda.GetValue( expression ) );

            test1.NullableEnumValue = null;
            expression = test => test.NullableEnumValue == test1.NullableEnumValue;
            Assert.Null( Lambda.GetValue( expression ) );
        }

        /// <summary>
        /// 测试获取成员值 - 集合
        /// </summary>
        [Fact]
        public void TestGetValue_List() {
            var list = new List<string> { "a", "b" };
            Expression<Func<Sample, bool>> expression = t => list.Contains( t.StringValue );
            Assert.Equal( list, Lambda.GetValue( expression ) );
        }

        /// <summary>
        /// 测试获取成员值 - 静态成员
        /// </summary>
        [Fact]
        public void TestGetValue_Static() {
            Expression<Func<Sample, bool>> expression = t => t.StringValue == Sample.StaticString;
            Assert.Equal( "TestStaticString", Lambda.GetValue( expression ) );

            expression = t => t.StringValue == Sample.StaticSample.StringValue;
            Assert.Equal( "TestStaticSample", Lambda.GetValue( expression ) );

            expression = t => t.Test2.StringValue == Sample.StaticString;
            Assert.Equal( "TestStaticString", Lambda.GetValue( expression ) );

            expression = t => t.Test2.StringValue == Sample.StaticSample.StringValue;
            Assert.Equal( "TestStaticSample", Lambda.GetValue( expression ) );

            expression = t => t.Test2.StringValue.Contains( Sample.StaticSample.StringValue );
            Assert.Equal( "TestStaticSample", Lambda.GetValue( expression ) );
        }

        #endregion

        #region GetOperator(获取查询操作符)

        /// <summary>
        /// 获取查询操作符 - 返回类型为Object
        /// </summary>
        [Fact]
        public void TestGetOperator_Object() {
            Expression<Func<Sample, object>> expression = t => t.StringValue == "A";
            Assert.Equal( Operator.Equal, Lambda.GetOperator( expression ) );
        }

        /// <summary>
        /// 获取查询操作符 - 返回类型为bool
        /// </summary>
        [Fact]
        public void TestGetOperator() {
            Assert.Null( Lambda.GetOperator( null ) );

            Expression<Func<Sample, bool>> expression = t => t.StringValue == "A";
            Assert.Equal( Operator.Equal, Lambda.GetOperator( expression ) );

            Expression<Func<Sample, bool>> expression2 = t => t.Test2.IntValue == 1;
            Assert.Equal( Operator.Equal, Lambda.GetOperator( expression2 ) );

            Expression<Func<Sample, bool>> expression3 = t => t.Test2.Test3.StringValue == "B";
            Assert.Equal( Operator.Equal, Lambda.GetOperator( expression3 ) );
        }

        /// <summary>
        /// 获取查询操作符 - 运算符
        /// </summary>
        [Fact]
        public void TestGetOperator_Operation() {
            Expression<Func<Sample, bool>> expression = t => t.Test2.IntValue != 1;
            Assert.Equal( Operator.NotEqual, Lambda.GetOperator( expression ) );

            expression = t => t.Test2.IntValue > 1;
            Assert.Equal( Operator.Greater, Lambda.GetOperator( expression ) );

            expression = t => t.Test2.IntValue < 1;
            Assert.Equal( Operator.Less, Lambda.GetOperator( expression ) );

            expression = t => t.Test2.IntValue >= 1;
            Assert.Equal( Operator.GreaterEqual, Lambda.GetOperator( expression ) );

            expression = t => t.Test2.IntValue <= 1;
            Assert.Equal( Operator.LessEqual, Lambda.GetOperator( expression ) );
        }

        /// <summary>
        /// 获取查询操作符 - 可空类型
        /// </summary>
        [Fact]
        public void TestGetOperator_Nullable() {
            Expression<Func<Sample, bool>> expression = t => t.NullableIntValue == 1;
            Assert.Equal( Operator.Equal, Lambda.GetOperator( expression ) );

            expression = t => t.NullableDecimalValue == 1.5M;
            Assert.Equal( Operator.Equal, Lambda.GetOperator( expression ) );
        }

        /// <summary>
        /// 获取查询操作符 - 方法
        /// </summary>
        [Fact]
        public void TestGetOperator_Method() {
            Expression<Func<Sample, bool>> expression = t => t.StringValue.Contains( "A" );
            Assert.Equal( Operator.Contains, Lambda.GetOperator( expression ) );

            expression = t => t.Test2.StringValue.EndsWith( "B" );
            Assert.Equal( Operator.Ends, Lambda.GetOperator( expression ) );

            expression = t => t.Test2.Test3.StringValue.StartsWith( "C" );
            Assert.Equal( Operator.Starts, Lambda.GetOperator( expression ) );
        }

        /// <summary>
        /// 获取查询操作符 - 复杂类型
        /// </summary>
        [Fact]
        public void TestGetOperator_Complex() {
            var test = new Sample() { StringValue = "a", Test2 = new Sample2() { StringValue = "b" } };

            Expression<Func<Sample, bool>> expression = t => t.StringValue == test.StringValue;
            Assert.Equal( Operator.Equal, Lambda.GetOperator( expression ) );
            Expression<Func<Sample, bool>> expression2 = t => t.StringValue != test.Test2.StringValue;
            Assert.Equal( Operator.NotEqual, Lambda.GetOperator( expression2 ) );

            Expression<Func<Sample, bool>> expression3 = t => t.StringValue.Contains( test.StringValue );
            Assert.Equal( Operator.Contains, Lambda.GetOperator( expression3 ) );
            Expression<Func<Sample, bool>> expression4 = t => t.StringValue.EndsWith( test.Test2.StringValue );
            Assert.Equal( Operator.Ends, Lambda.GetOperator( expression4 ) );
        }

        /// <summary>
        /// 获取查询操作符 - 枚举
        /// </summary>
        [Fact]
        public void TestGetOperator_Enum() {
            var test1 = new Sample { NullableEnumValue = EnumSample.C };

            Expression<Func<Sample, bool>> expression = test => test.EnumValue == EnumSample.D;
            Assert.Equal( Operator.Equal, Lambda.GetOperator( expression ) );

            expression = test => test.EnumValue == test1.NullableEnumValue;
            Assert.Equal( Operator.Equal, Lambda.GetOperator( expression ) );

            expression = test => test.NullableEnumValue == EnumSample.E;
            Assert.Equal( Operator.Equal, Lambda.GetOperator( expression ) );

            expression = test => test.NullableEnumValue == test1.NullableEnumValue;
            Assert.Equal( Operator.Equal, Lambda.GetOperator( expression ) );
        }

        /// <summary>
        /// 获取查询操作符 - 集合
        /// </summary>
        [Fact]
        public void TestGetOperator_List() {
            var list = new List<string> { "a", "b" };
            Expression<Func<Sample, bool>> expression = t => list.Contains( t.StringValue );
            Assert.Equal( Operator.Contains, Lambda.GetOperator( expression ) );
        }

        /// <summary>
        /// 获取查询操作符 - 静态成员
        /// </summary>
        [Fact]
        public void TestGetOperator_Static() {
            Expression<Func<Sample, bool>> expression = t => t.StringValue == Sample.StaticString;
            Assert.Equal( Operator.Equal, Lambda.GetOperator( expression ) );

            expression = t => t.StringValue == Sample.StaticSample.StringValue;
            Assert.Equal( Operator.Equal, Lambda.GetOperator( expression ) );

            expression = t => t.Test2.StringValue == Sample.StaticString;
            Assert.Equal( Operator.Equal, Lambda.GetOperator( expression ) );

            expression = t => t.Test2.StringValue == Sample.StaticSample.StringValue;
            Assert.Equal( Operator.Equal, Lambda.GetOperator( expression ) );

            expression = t => t.Test2.StringValue.Contains( Sample.StaticSample.StringValue );
            Assert.Equal( Operator.Contains, Lambda.GetOperator( expression ) );
        }

        #endregion

        #region GetParameter(获取参数)

        /// <summary>
        /// 测试获取参数
        /// </summary>
        [Fact]
        public void TestGetParameter() {
            Assert.Null( Lambda.GetParameter( null ) );

            Expression<Func<Sample, object>> expression = test => test.StringValue == "A";
            Assert.Equal( "test", Lambda.GetParameter( expression ).ToString() );

            expression = test => test.Test2.IntValue == 1;
            Assert.Equal( "test", Lambda.GetParameter( expression ).ToString() );

            expression = test => test.Test2.Test3.StringValue == "B";
            Assert.Equal( "test", Lambda.GetParameter( expression ).ToString() );

            expression = test => test.Test2.IntValue;
            Assert.Equal( "test", Lambda.GetParameter( expression ).ToString() );

            expression = test => test.Test2.Test3.StringValue.Contains( "B" );
            Assert.Equal( "test", Lambda.GetParameter( expression ).ToString() );
        }

        #endregion

        #region GetCriteriaCount(获取查询条件个数)

        /// <summary>
        /// 测试获取查询条件个数
        /// </summary>
        [Fact]
        public void TestGetConditionCount() {
            Assert.Equal( 0, Lambda.GetConditionCount( null ) );

            Expression<Func<Sample, bool>> expression = test => test.StringValue == "A";
            Assert.Equal( 1, Lambda.GetConditionCount( expression ) );

            expression = test => test.StringValue == "A" && test.StringValue == "B";
            Assert.Equal( 2, Lambda.GetConditionCount( expression ) );

            expression = test => test.StringValue == "A" || test.StringValue == "B";
            Assert.Equal( 2, Lambda.GetConditionCount( expression ) );

            expression = test => test.StringValue == "A" && test.StringValue == "B" || test.StringValue == "C";
            Assert.Equal( 3, Lambda.GetConditionCount( expression ) );

            expression = test => test.Test2.StringValue == "A" && test.StringValue == "B" || test.StringValue == "C";
            Assert.Equal( 3, Lambda.GetConditionCount( expression ) );

            expression = t => t.StringValue.Contains( "A" );
            Assert.Equal( 1, Lambda.GetConditionCount( expression ) );

            expression = t => t.StringValue.Contains( "A" ) && t.StringValue == "A";
            Assert.Equal( 2, Lambda.GetConditionCount( expression ) );

            expression = t => t.StringValue.Contains( "A" ) || t.Test2.StringValue == "A";
            Assert.Equal( 2, Lambda.GetConditionCount( expression ) );
        }

        #endregion

        #region GetAttribute(获取特性)

        /// <summary>
        /// 测试获取特性
        /// </summary>
        [Fact]
        public void TestGetAttribute() {
            DisplayAttribute attribute = Lambda.GetAttribute<Sample, string, DisplayAttribute>( t => t.StringValue );
            Assert.Equal( "字符串值", attribute.Name );
        }

        #endregion

        #region GetAttributes(获取特性列表)

        /// <summary>
        /// 测试获取特性列表
        /// </summary>
        [Fact]
        public void TestGetAttributes() {
            IEnumerable<ValidationAttribute> attributes = Lambda.GetAttributes<Sample, string, ValidationAttribute>( t => t.StringValue );
            Assert.Equal( 2, attributes.Count() );
        }

        #endregion

        #region Constant(获取常量表达式)

        /// <summary>
        /// 测试获取常量表达式
        /// </summary>
        [Fact]
        public void TestConstant() {
            var constantExpression = Lambda.Constant( 1 );
            Assert.Equal( typeof( int ), constantExpression.Type );
        }

        /// <summary>
        /// 测试获取常量表达式
        /// </summary>
        [Fact]
        public void TestConstant_2() {
            Expression<Func<Sample, int?>> property = t => t.NullableIntValue;
            var constantExpression = Lambda.Constant( 1 , property );
            Assert.Equal( typeof( int? ), constantExpression.Type );
        }

        #endregion

        #region Equal(创建等于表达式)

        /// <summary>
        /// 测试创建等于表达式
        /// </summary>
        [Fact]
        public void TestEqual() {
            Expression<Func<Sample, bool>> expected = t => t.IntValue == 1;
            Assert.Equal( expected.ToString(), Lambda.Equal<Sample>( "IntValue", 1 ).ToString() );

            Expression<Func<Sample, bool>> expected2 = t => t.Test2.IntValue == 1;
            Assert.Equal( expected2.ToString(), Lambda.Equal<Sample>( "Test2.IntValue", 1 ).ToString() );
        }

        #endregion

        #region NotEqual(创建不等于表达式)

        /// <summary>
        /// 测试创建不等于表达式
        /// </summary>
        [Fact]
        public void TestNotEqual() {
            Expression<Func<Sample, bool>> expected = t => t.IntValue != 1;
            Assert.Equal( expected.ToString(), Lambda.NotEqual<Sample>( "IntValue", 1 ).ToString() );

            Expression<Func<Sample, bool>> expected2 = t => t.Test2.IntValue != 1;
            Assert.Equal( expected2.ToString(), Lambda.NotEqual<Sample>( "Test2.IntValue", 1 ).ToString() );
        }

        #endregion

        #region Greater(创建大于表达式)

        /// <summary>
        /// 测试创建大于表达式
        /// </summary>
        [Fact]
        public void TestGreater() {
            Expression<Func<Sample, bool>> expected = t => t.IntValue > 1;
            Assert.Equal( expected.ToString(), Lambda.Greater<Sample>( "IntValue", 1 ).ToString() );

            Expression<Func<Sample, bool>> expected2 = t => t.Test2.IntValue > 1;
            Assert.Equal( expected2.ToString(), Lambda.Greater<Sample>( "Test2.IntValue", 1 ).ToString() );
        }

        #endregion

        #region GreaterEqual(创建大于等于表达式)

        /// <summary>
        /// 测试创建大于等于表达式
        /// </summary>
        [Fact]
        public void TestGreaterEqual() {
            Expression<Func<Sample, bool>> expected = t => t.IntValue >= 1;
            Assert.Equal( expected.ToString(), Lambda.GreaterEqual<Sample>( "IntValue", 1 ).ToString() );

            Expression<Func<Sample, bool>> expected2 = t => t.Test2.IntValue >= 1;
            Assert.Equal( expected2.ToString(), Lambda.GreaterEqual<Sample>( "Test2.IntValue", 1 ).ToString() );
        }

        #endregion

        #region Less(创建小于表达式)

        /// <summary>
        /// 测试创建小于表达式
        /// </summary>
        [Fact]
        public void TestLess() {
            Expression<Func<Sample, bool>> expected = t => t.IntValue < 1;
            Assert.Equal( expected.ToString(), Lambda.Less<Sample>( "IntValue", 1 ).ToString() );

            Expression<Func<Sample, bool>> expected2 = t => t.Test2.IntValue < 1;
            Assert.Equal( expected2.ToString(), Lambda.Less<Sample>( "Test2.IntValue", 1 ).ToString() );
        }

        #endregion

        #region LessEqual(创建小于等于表达式)

        /// <summary>
        /// 测试创建小于等于表达式
        /// </summary>
        [Fact]
        public void TestLessEqual() {
            Expression<Func<Sample, bool>> expected = t => t.IntValue <= 1;
            Assert.Equal( expected.ToString(), Lambda.LessEqual<Sample>( "IntValue", 1 ).ToString() );

            Expression<Func<Sample, bool>> expected2 = t => t.Test2.IntValue <= 1;
            Assert.Equal( expected2.ToString(), Lambda.LessEqual<Sample>( "Test2.IntValue", 1 ).ToString() );
        }

        #endregion

        #region Starts(调用StartsWith方法)

        /// <summary>
        /// 测试调用StartsWith方法
        /// </summary>
        [Fact]
        public void TestStarts() {
            Expression<Func<Sample, bool>> expected = t => t.StringValue.StartsWith( "A" );
            Assert.Equal( expected.ToString(), Lambda.Starts<Sample>( "StringValue", "A" ).ToString() );

            Expression<Func<Sample, bool>> expected2 = t => t.Test2.StringValue.StartsWith( "A" );
            Assert.Equal( expected2.ToString(), Lambda.Starts<Sample>( "Test2.StringValue", "A" ).ToString() );

            Expression<Func<Sample, bool>> expected3 = t => t.Test2.Test3.StringValue.StartsWith( "A" );
            Assert.Equal( expected3.ToString(), Lambda.Starts<Sample>( "Test2.Test3.StringValue", "A" ).ToString() );
        }

        #endregion

        #region Ends(调用EndsWith方法)

        /// <summary>
        /// 测试调用EndsWith方法
        /// </summary>
        [Fact]
        public void TestEnds() {
            Expression<Func<Sample, bool>> expected = t => t.StringValue.EndsWith( "A" );
            Assert.Equal( expected.ToString(), Lambda.Ends<Sample>( "StringValue", "A" ).ToString() );

            Expression<Func<Sample, bool>> expected2 = t => t.Test2.StringValue.EndsWith( "A" );
            Assert.Equal( expected2.ToString(), Lambda.Ends<Sample>( "Test2.StringValue", "A" ).ToString() );

            Expression<Func<Sample, bool>> expected3 = t => t.Test2.Test3.StringValue.EndsWith( "A" );
            Assert.Equal( expected3.ToString(), Lambda.Ends<Sample>( "Test2.Test3.StringValue", "A" ).ToString() );
        }

        #endregion

        #region Contains(调用Contains方法)

        /// <summary>
        /// 测试调用Contains方法
        /// </summary>
        [Fact]
        public void TestContains() {
            Expression<Func<Sample, bool>> expected = t => t.StringValue.Contains( "A" );
            Assert.Equal( expected.ToString(), Lambda.Contains<Sample>( "StringValue", "A" ).ToString() );

            Expression<Func<Sample, bool>> expected2 = t => t.Test2.StringValue.Contains( "A" );
            Assert.Equal( expected2.ToString(), Lambda.Contains<Sample>( "Test2.StringValue", "A" ).ToString() );

            Expression<Func<Sample, bool>> expected3 = t => t.Test2.Test3.StringValue.Contains( "A" );
            Assert.Equal( expected3.ToString(), Lambda.Contains<Sample>( "Test2.Test3.StringValue", "A" ).ToString() );
        }

        #endregion

        #region ParsePredicate(解析为谓词表达式)

        /// <summary>
        /// 测试解析为谓词表达式
        /// </summary>
        [Fact]
        public void TestParsePredicate() {
            Assert.Equal( "t => (t.StringValue == \"A\")", Lambda.ParsePredicate<Sample2>( "StringValue", "A", Operator.Equal ).SafeString() );
            Assert.Equal( "t => t.StringValue.Contains(\"A\")", Lambda.ParsePredicate<Sample2>( "StringValue", "A", Operator.Contains ).SafeString() );
        }

        #endregion
    }
}
