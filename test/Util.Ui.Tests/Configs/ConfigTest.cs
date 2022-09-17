using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.Tests.Configs {
    /// <summary>
    /// UI配置测试
    /// </summary>
    public class ConfigTest {
        /// <summary>
        /// 创建配置
        /// </summary>
        private Config CreateConfig() {
            TagHelperAttributeList attributes = new TagHelperAttributeList { { "a", 1 }, { "b", true } };
            TagHelperContext context = new TagHelperContext( attributes, new Dictionary<object, object>(), Util.Helpers.Id.Create() );
            return new Config( context, null );
        }

        /// <summary>
        /// 测试获取值
        /// </summary>
        [Fact]
        public void TestGetValue_1() {
            var config = CreateConfig();
            Assert.Equal( "1", config.GetValue( "a" ) );
        }

        /// <summary>
        /// 测试获取值 - 泛型
        /// </summary>
        [Fact]
        public void TestGetValue_2() {
            var config = CreateConfig();
            Assert.Equal( 1, config.GetValue<int>( "a" ) );
        }

        /// <summary>
        /// 测试获取布尔值
        /// </summary>
        [Fact]
        public void TestGetBoolValue() {
            var config = CreateConfig();
            Assert.Equal( "true", config.GetBoolValue( "b" ) );
        }

        /// <summary>
        /// 测试设置属性
        /// </summary>
        [Fact]
        public void TestSetAttribute() {
            var config = CreateConfig();
            config.SetAttribute( "SetAttribute", 3 );
            Assert.Equal( 3, config.GetValue<int>( "SetAttribute" ) );
        }

        /// <summary>
        /// 测试设置属性 - 替换已存在的属性
        /// </summary>
        [Fact]
        public void TestSetAttribute_2() {
            var config = CreateConfig();
            config.SetAttribute( "a", 2 );
            Assert.Equal( 2, config.GetValue<int>( "a" ) );
        }

        /// <summary>
        /// 测试设置属性 - 属性已存在则忽略
        /// </summary>
        [Fact]
        public void TestSetAttribute_3() {
            var config = CreateConfig();
            config.SetAttribute( "a", 2, false );
            Assert.Equal( 1, config.GetValue<int>( "a" ) );
        }
    }
}
