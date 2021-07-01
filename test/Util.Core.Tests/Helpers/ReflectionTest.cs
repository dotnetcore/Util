using System.Collections.Generic;
using System.Reflection;
using Util.Helpers;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Helpers {
    /// <summary>
    /// 测试反射操作
    /// </summary>
    public class ReflectionTest {
        /// <summary>
        /// 测试样例
        /// </summary>
        private readonly Sample _sample;
        
        /// <summary>
        /// 测试初始化
        /// </summary>
        public ReflectionTest() {
            _sample = new Sample();
        }

        /// <summary>
        /// 测试获取类型描述
        /// </summary>
        [Fact]
        public void TestGetDescription_1() {
            Assert.Equal( "测试样例", Util.Helpers.Reflection.GetDescription<Sample>() );
            Assert.Equal( "Sample2", Util.Helpers.Reflection.GetDescription<Sample2>() );
        }

        /// <summary>
        /// 测试获取类型成员描述
        /// </summary>
        [Fact]
        public void TestGetDescription_2() {
            Assert.Equal( "", Util.Helpers.Reflection.GetDescription<EnumSample>( "X" ) );
            Assert.Equal( "A", Util.Helpers.Reflection.GetDescription<EnumSample>( "A" ) );
            Assert.Equal( "B2", Util.Helpers.Reflection.GetDescription<EnumSample>( "B" ) );
            Assert.Equal( "IntValue", Util.Helpers.Reflection.GetDescription<Sample>( "IntValue" ) );
        }

        /// <summary>
        /// 测试显示名
        /// </summary>
        [Fact]
        public void TestGetDisplayName() {
            Assert.Equal( "", Util.Helpers.Reflection.GetDisplayName<Sample>() );
            Assert.Equal( "测试样例2", Util.Helpers.Reflection.GetDisplayName<Sample2>() );
        }

        /// <summary>
        /// 测试获取类描述或显示名
        /// </summary>
        [Fact]
        public void TestGetDescriptionOrDisplayName() {
            Assert.Equal( "测试样例", Util.Helpers.Reflection.GetDisplayNameOrDescription<Sample>() );
            Assert.Equal( "测试样例2", Util.Helpers.Reflection.GetDisplayNameOrDescription<Sample2>() );
            Assert.Equal( "测试样例", Util.Helpers.Reflection.GetDisplayNameOrDescription<Sample>() );
        }

        /// <summary>
        /// 测试是否布尔类型
        /// </summary>
        [Fact]
        public void TestIsBool() {
            Assert.True( Util.Helpers.Reflection.IsBool( _sample.BoolValue.GetType().GetTypeInfo() ), "BoolValue GetType" );
            Assert.True( Util.Helpers.Reflection.IsBool( _sample.GetType().GetMember( "BoolValue" )[0] ), "BoolValue" );
            Assert.True( Util.Helpers.Reflection.IsBool( _sample.GetType().GetMember( "NullableBoolValue" )[0] ), "NullableBoolValue" );
            Assert.False( Util.Helpers.Reflection.IsBool( _sample.GetType().GetMember( "EnumValue" )[0] ), "EnumValue" );
        }

        /// <summary>
        /// 测试获取直接接口列表
        /// </summary>
        [Fact]
        public void TestGetDirectInterfaces() {
            var interfaceTypes = Util.Helpers.Reflection.GetDirectInterfaceTypes<TestSample>();
            Assert.Equal( 2, interfaceTypes.Count );
            Assert.True( interfaceTypes.Exists( t => t.Name == "ITestSample" ) );
            Assert.True( interfaceTypes.Exists( t => t.Name == "ITestSample5" ) );
        }

        /// <summary>
        /// 测试获取直接接口列表 - 一个基接口
        /// </summary>
        [Fact]
        public void TestGetDirectInterfaces_2() {
            var interfaceTypes = Util.Helpers.Reflection.GetDirectInterfaceTypes<TestSample>( typeof( ITestSample4 ) );
            Assert.Single( interfaceTypes );
            Assert.True( interfaceTypes.Exists( t => t.Name == "ITestSample5" ) );
        }

        /// <summary>
        /// 测试获取直接接口列表 - 两个基接口
        /// </summary>
        [Fact]
        public void TestGetDirectInterfaces_3() {
            var interfaceTypes = Util.Helpers.Reflection.GetDirectInterfaceTypes<TestSample>( typeof( ITestSample4 ), typeof( ITestSample2 ) );
            Assert.Equal( 2, interfaceTypes.Count );
            Assert.True( interfaceTypes.Exists( t => t.Name == "ITestSample" ) );
            Assert.True( interfaceTypes.Exists( t => t.Name == "ITestSample5" ) );
        }

        /// <summary>
        /// 测试是否集合
        /// </summary>
        [Fact]
        public void TestIsCollection() {
            Assert.True( Util.Helpers.Reflection.IsCollection( _sample.StringArray.GetType() ) );
        }

        /// <summary>
        /// 测试是否泛型集合
        /// </summary>
        [Fact]
        public void TestIsGenericCollection() {
            Assert.True( Util.Helpers.Reflection.IsGenericCollection( _sample.StringList.GetType() ) );
        }

        /// <summary>
        /// 测试获取元素类型
        /// </summary>
        [Fact]
        public void TestGetElementType_1() {
            Sample sample = new Sample();
            Assert.Equal( typeof( Sample ), Reflection.GetElementType( sample.GetType() ) );
        }

        /// <summary>
        /// 获取元素类型 - 数组
        /// </summary>
        [Fact]
        public void TestGetElementType_2() {
            var list = new[] { new Sample() };
            var type = list.GetType();
            Assert.Equal( typeof( Sample ), Reflection.GetElementType( type ) );
        }

        /// <summary>
        /// 获取元素类型 - 集合
        /// </summary>
        [Fact]
        public void TestGetElementType_3() {
            var list = new List<Sample> { new Sample() };
            var type = list.GetType();
            Assert.Equal( typeof( Sample ), Reflection.GetElementType( type ) );
        }
    }
}
