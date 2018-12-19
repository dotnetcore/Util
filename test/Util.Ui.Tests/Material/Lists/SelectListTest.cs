using System.IO;
using System.Text.Encodings.Web;
using Util.Biz.Enums;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Material.Extensions;
using Util.Ui.Material.Lists;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Lists {
    /// <summary>
    /// 选择列表测试
    /// </summary>
    public class SelectListTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 选择列表
        /// </summary>
        private readonly SelectList _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SelectListTest( ITestOutputHelper output ) {
            _output = output;
            _component = new SelectList();
            Config.IsValidate = false;
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( SelectList component ) {
            component.WriteTo( new StringWriter(), HtmlEncoder.Default );
            var result = component.ToString();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();
            result.Append( "<mat-select-list-wrapper></mat-select-list-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component ) );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var result = new String();
            result.Append( "<mat-select-list-wrapper #a=\"\"></mat-select-list-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Id( "a" ) ) );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestName() {
            var result = new String();
            result.Append( "<mat-select-list-wrapper name=\"a\"></mat-select-list-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Name( "a" ) ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisable() {
            var result = new String();
            result.Append( "<mat-select-list-wrapper [disabled]=\"true\"></mat-select-list-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Disable() ) );
        }

        /// <summary>
        /// 测试设置Url
        /// </summary>
        [Fact]
        public void TestUrl() {
            var result = new String();
            result.Append( "<mat-select-list-wrapper url=\"a\"></mat-select-list-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Url( "a" ) ) );
        }

        /// <summary>
        /// 测试设置数据源
        /// </summary>
        [Fact]
        public void TestDataSource() {
            var result = new String();
            result.Append( "<mat-select-list-wrapper [dataSource]=\"a\"></mat-select-list-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.DataSource( "a" ) ) );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestModel() {
            var result = new String();
            result.Append( "<mat-select-list-wrapper [(model)]=\"a\"></mat-select-list-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Model( "a" ) ) );
        }

        /// <summary>
        /// 测试变更事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            var result = new String();
            result.Append( "<mat-select-list-wrapper (onChange)=\"a\"></mat-select-list-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.OnChange( "a" ) ) );
        }

        /// <summary>
        /// 测试添加项
        /// </summary>
        [Fact]
        public void TestAdd_1() {
            var result = new String();
            result.Append( "<mat-select-list-wrapper [dataSource]=\"[{" );
            result.Append( "'text':'a','value':'1'" );
            result.Append( "}]\"></mat-select-list-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Add( "a", "1" ) ) );
        }

        /// <summary>
        /// 测试添加项
        /// </summary>
        [Fact]
        public void TestAdd_2() {
            var result = new String();
            result.Append( "<mat-select-list-wrapper [dataSource]=\"[{" );
            result.Append( "'text':'a','value':'1'" );
            result.Append( "}]\"></mat-select-list-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Add( new Item( "a", "1" ) ) ) );
        }

        /// <summary>
        /// 测试绑定bool
        /// </summary>
        [Fact]
        public void TestBool() {
            var result = new String();
            result.Append( "<mat-select-list-wrapper [dataSource]=\"[" );
            result.Append( "{'text':'是','value':true}," );
            result.Append( "{'text':'否','value':false}" );
            result.Append( "]\"></mat-select-list-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Bool() ) );
        }

        /// <summary>
        /// 测试绑定枚举
        /// </summary>
        [Fact]
        public void TestEnum() {
            var result = new String();
            result.Append( "<mat-select-list-wrapper [dataSource]=\"[" );
            result.Append( "{'text':'女','value':1,'sortId':1}," );
            result.Append( "{'text':'男','value':2,'sortId':2}" );
            result.Append( "]\"></mat-select-list-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( (SelectList)_component.Enum<Gender>() ) );
        }
    }
}