using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Descriptions;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Descriptions {
    /// <summary>
    /// 描述列表测试
    /// </summary>
    public class DescriptionTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper _wrapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public DescriptionTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new DescriptionTagHelper().ToWrapper();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult() {
            var result = _wrapper.GetResult();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzColumn]=\"{xs:1,sm:1,md:1,lg:1,xl:2,xxl:2}\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions nzTitle=\"a\" [nzColumn]=\"{xs:1,sm:1,md:1,lg:1,xl:2,xxl:2}\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestBindTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzColumn]=\"{xs:1,sm:1,md:1,lg:1,xl:2,xxl:2}\" [nzTitle]=\"a\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试操作区域
        /// </summary>
        [Fact]
        public void TestExtra() {
            _wrapper.SetContextAttribute( UiConst.Extra, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions nzExtra=\"a\" [nzColumn]=\"{xs:1,sm:1,md:1,lg:1,xl:2,xxl:2}\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试操作区域
        /// </summary>
        [Fact]
        public void TestBindExtra() {
            _wrapper.SetContextAttribute( AngularConst.BindExtra, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzColumn]=\"{xs:1,sm:1,md:1,lg:1,xl:2,xxl:2}\" [nzExtra]=\"a\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示边框
        /// </summary>
        [Fact]
        public void TestBordered() {
            _wrapper.SetContextAttribute( UiConst.Bordered, "true" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzBordered]=\"true\" [nzColumn]=\"{xs:1,sm:1,md:1,lg:1,xl:2,xxl:2}\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试一行中描述列表项的数量
        /// </summary>
        [Fact]
        public void TestColumn() {
            _wrapper.SetContextAttribute( UiConst.Column, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzColumn]=\"{xs:1,sm:1,md:1,lg:1,xl:1,xxl:1}\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试一行中描述列表项的数量
        /// </summary>
        [Fact]
        public void TestColumn_2() {
            _wrapper.SetContextAttribute( UiConst.Column, 1 );
            _wrapper.SetContextAttribute( UiConst.XsColumn, 2 );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzColumn]=\"{xs:2,sm:1,md:1,lg:1,xl:1,xxl:1}\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试一行中描述列表项的数量
        /// </summary>
        [Fact]
        public void TestXsColumn() {
            _wrapper.SetContextAttribute( UiConst.XsColumn, 2 );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzColumn]=\"{xs:2,sm:1,md:1,lg:1,xl:2,xxl:2}\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试一行中描述列表项的数量
        /// </summary>
        [Fact]
        public void TestSmColumn() {
            _wrapper.SetContextAttribute( UiConst.SmColumn, 2 );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzColumn]=\"{xs:1,sm:2,md:1,lg:1,xl:2,xxl:2}\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试一行中描述列表项的数量
        /// </summary>
        [Fact]
        public void TestMdColumn() {
            _wrapper.SetContextAttribute( UiConst.MdColumn, 2 );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzColumn]=\"{xs:1,sm:1,md:2,lg:1,xl:2,xxl:2}\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试一行中描述列表项的数量
        /// </summary>
        [Fact]
        public void TestLgColumn() {
            _wrapper.SetContextAttribute( UiConst.LgColumn, 2 );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzColumn]=\"{xs:1,sm:1,md:1,lg:2,xl:2,xxl:2}\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试一行中描述列表项的数量
        /// </summary>
        [Fact]
        public void TestXlColumn() {
            _wrapper.SetContextAttribute( UiConst.XlColumn, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzColumn]=\"{xs:1,sm:1,md:1,lg:1,xl:1,xxl:2}\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试一行中描述列表项的数量
        /// </summary>
        [Fact]
        public void TestXxlColumn() {
            _wrapper.SetContextAttribute( UiConst.XxlColumn, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzColumn]=\"{xs:1,sm:1,md:1,lg:1,xl:2,xxl:1}\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试一行中描述列表项的数量
        /// </summary>
        [Fact]
        public void TestXxlColumn_2() {
            _wrapper.SetContextAttribute( UiConst.LgColumn, 3 );
            _wrapper.SetContextAttribute( UiConst.XxlColumn, 3 );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzColumn]=\"{xs:1,sm:1,md:1,lg:3,xl:2,xxl:3}\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列表大小
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, DescriptionSize.Small );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions nzSize=\"small\" [nzColumn]=\"{xs:1,sm:1,md:1,lg:1,xl:2,xxl:2}\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列表大小
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzColumn]=\"{xs:1,sm:1,md:1,lg:1,xl:2,xxl:2}\" [nzSize]=\"a\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示冒号
        /// </summary>
        [Fact]
        public void TestColon() {
            _wrapper.SetContextAttribute( UiConst.Colon, "true" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzColon]=\"true\" [nzColumn]=\"{xs:1,sm:1,md:1,lg:1,xl:2,xxl:2}\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzColumn]=\"{xs:1,sm:1,md:1,lg:1,xl:2,xxl:2}\">a</nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}